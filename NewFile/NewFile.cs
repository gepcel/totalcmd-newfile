using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using IniParser;
using IniParser.Model;
using IniParser.Parser;

namespace NewFile
{
    enum FileType
    {
        File,
        Folder,
    }
    public partial class NewFile : Form
    {
        private string? _root;
        public string? Root
        {
            get { return _root; }
            set
            {
                _root = value;
                label1.Text = _root;
            }
        }
        public string FileOrFolderName
        {
            get
            {
                return txtFileName.Text;
            }
        }
        private bool IsOpenAfter
        {
            get
            {
                return checkBoxOpenAfter.Checked;
            }
        }
        private bool IsWriteClipboard
        {
            get
            {
                return checkBoxWriteClipboard.Checked;
            }
        }
        private NewFileConfig config;
        private List<string> TxtFormats { get; set; } = new List<string>{ ".txt", ".md", ".ini",".py",".xml",".cs"};
        public NewFile(string? root)
        {
            InitializeComponent();
            string s = AppDomain.CurrentDomain.BaseDirectory;
            config = new NewFileConfig(s);
            checkBoxWriteClipboard.Checked = config.Clipboard;
            checkBoxOpenAfter.Checked=config.OpenAfter;

            if (root == null)
            {
                root = "";
            }
            Root = root;
            if (Root.Length == 0)
            {
                Root = Directory.GetCurrentDirectory();
            }
            Directory.SetCurrentDirectory(Root);
        }

        private void NewFile_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                bool openafter = IsOpenAfter;
                if (e.Control)
                {
                    openafter = !IsOpenAfter;
                }
                if (FileType.File != GetFileType(FileOrFolderName))
                {
                    CreateNewFile(txtFileName.Text, IsWriteClipboard, openafter);
                }
                else
                {
                    CreateNewFolder(txtFileName.Text, openafter);
                }
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                bool openafter = IsOpenAfter;
                if (e.Control)
                {
                    openafter = !IsOpenAfter;
                }
                if (FileType.File == GetFileType(FileOrFolderName))
                {
                    CreateNewFile(txtFileName.Text, IsWriteClipboard, openafter);
                }
                else
                {
                    CreateNewFolder(txtFileName.Text, openafter);
                }
                this.Close();
            }
            else if (e.KeyCode == Keys.F1)
            {
                checkBoxWriteClipboard.Checked = !checkBoxWriteClipboard.Checked;
                config.IsNeedCreateIni = true;
                config.Clipboard = IsWriteClipboard;
                config.Update();
            }
            else if (e.KeyCode == Keys.F2)
            {
                checkBoxOpenAfter.Checked = !checkBoxOpenAfter.Checked;
                config.IsNeedCreateIni = true;
                config.OpenAfter = IsOpenAfter;
                config.Update();
            }
        }

        private void CreateNewFolder(string name, bool openafter)
        {
            Directory.SetCurrentDirectory(Root);
            if ((!Directory.Exists(name)) && (!File.Exists(name)))
            {
                Directory.CreateDirectory(name);
            }
            if (openafter)
            {
                Process process = new Process();
                process.StartInfo.FileName = @"C:\python\tools\totalcmd1151\TOTALCMD64.EXE";
                process.StartInfo.Arguments = String.Format("/O /S /L={0}", Path.Combine(Root!, name));
                process.StartInfo.UseShellExecute = true;
                process.EnableRaisingEvents = false;
                process.Start();
            }
        }

        private string CreateNewFile(string name, bool writeclipboard, bool openafter)
        {
            int i = 0;
            string fullname = name;
            Directory.SetCurrentDirectory(Root);
            while (File.Exists(fullname) || Path.Exists(fullname))
            {
                i++;
                fullname = fullname + i.ToString();
                fullname = Path.GetFileNameWithoutExtension(name) + i.ToString() + Path.GetExtension(name);
            }
            var fs = File.Create(fullname);
            fs.Close();
            if (writeclipboard)
            {
                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    File.WriteAllText(fullname, text);
                }
            }
            //fs.Close();
            if (openafter)
            {
                Process process = new Process();
                process.StartInfo.FileName = fullname;
                process.StartInfo.UseShellExecute = true;
                process.EnableRaisingEvents = false;
                process.Start();
                //System.Diagnostics.Process.Start(fullname);
            }
            return fullname;
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            CreateNewFile(txtFileName.Text, IsWriteClipboard, IsOpenAfter);
            this.Close();
        }
        private void btnFolder_Click(object sender, EventArgs e)
        {
            CreateNewFolder(txtFileName.Text, IsOpenAfter);
            this.Close();
        }

        private FileType GetFileType(string name)
        {
            if (name.Contains("."))
            {                
                string ext = Path.GetExtension(name);
                if (TxtFormats.Contains(ext))
                {
                    return FileType.File;
                }
            }
            return FileType.Folder;
        }        
    }

    class NewFileConfig
    {
        private bool _clipboard = true;
        public bool Clipboard 
        { 
            get=>_clipboard; 
            set
            {
                _clipboard = value;
                data["Configuration"]["autowriteclipboard"] = _clipboard.ToString();
            }
        }
        private bool _openafter = true;
        public bool OpenAfter 
        { get=>_openafter;
            set
            {
                _openafter = value;
                data["Configuration"]["autoopenaftercreated"] = _openafter.ToString();
            }
        }
        private string _totalcmdpath = @"C:\python\tools\totalcmd1151\TOTALCMD64.EXE";
        public string Totalcmdpath
        {
            get => _totalcmdpath;
            set
            {
                _totalcmdpath = value;
                //data["Configuration"]["totalcmd"] = _totalcmdpath;
            }
        }

        public string CurrentPath {  get; set; }
        public bool IniExists { get; set; } = false;
        public IniData data { get; set; }
        public FileIniDataParser parser { get; set; } = new FileIniDataParser();
        public bool IsNeedCreateIni { get; set; } = false;
        public List<string> TxtFormats { get; set; }= new List<string> { ".txt", ".md", ".ini", ".py", ".xml", ".cs" };

        public NewFileConfig(string currentPath)
        {
            string filepath = Path.Join(currentPath, "NewFile.ini");
            CurrentPath = filepath;
            if (File.Exists(filepath))
            {
                //load config
                IniExists = true;                
                data = parser.ReadFile(CurrentPath);
                Clipboard = Convert.ToBoolean(data["Configuration"]["autowriteclipboard"]);
                OpenAfter = Convert.ToBoolean(data["Configuration"]["autoopenaftercreated"]);
                var txtformat = data["Configuration"]["txtformat"]?? ".txt,.md,.ini,.py,.xml,.cs";
                data["Configuration"]["txtformat"] = txtformat;
                //txtformat ??= ".txt,.md,.ini,.py,.xml,.cs";
                TxtFormats = new List<string>(txtformat!.Split(",", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries));
                Totalcmdpath = data["Configuration"]["totalcmd"];
            }
            else
            {
                //parser = new FileIniDataParser();
                data=new IniData();                
                data["Configuration"]["autowriteclipboard"] = Clipboard.ToString();
                data["Configuration"]["autoopenaftercreated"] = OpenAfter.ToString();
                data["Configuration"]["txtformat"] = string.Join(",", TxtFormats);
                string t = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\TOTALCMD64.EXE"));
                
                if (File.Exists(t))
                {
                    data["Configuration"]["totalcmd"] = t;
                }
            }
        }
        public void Update()
        {
            if (IsNeedCreateIni)
            {
                parser.WriteFile(CurrentPath, data);
            }            
        }
    }
}