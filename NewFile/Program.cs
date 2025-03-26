using System.Reflection;

namespace NewFile
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string root = "";
            if (args.Length == 1)
            {
                root = args[0];
            }
            else
            {
                root = "";
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Application.Run(new NewFile(root));
        }

        private static Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var steam = Assembly.GetExecutingAssembly().GetManifestResourceStream("NewFile.IniParser.dll"))
            {
                byte[] assemblyData = new byte[steam!.Length];
                steam.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}