namespace NewFile
{
    partial class NewFile
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFile));
            txtFileName = new TextBox();
            btnFolder = new Button();
            checkBoxWriteClipboard = new CheckBox();
            checkBoxOpenAfter = new CheckBox();
            label1 = new Label();
            btnFile = new Button();
            SuspendLayout();
            // 
            // txtFileName
            // 
            txtFileName.Font = new Font("Microsoft YaHei UI", 12F);
            txtFileName.Location = new Point(4, 22);
            txtFileName.Margin = new Padding(2, 3, 2, 3);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(522, 28);
            txtFileName.TabIndex = 1;
            // 
            // btnFolder
            // 
            btnFolder.Location = new Point(278, 56);
            btnFolder.Margin = new Padding(2, 3, 2, 3);
            btnFolder.Name = "btnFolder";
            btnFolder.Size = new Size(115, 25);
            btnFolder.TabIndex = 2;
            btnFolder.Text = "文件夹 (Enter)";
            btnFolder.UseVisualStyleBackColor = true;
            btnFolder.Click += btnFolder_Click;
            // 
            // checkBoxWriteClipboard
            // 
            checkBoxWriteClipboard.AutoSize = true;
            checkBoxWriteClipboard.Checked = true;
            checkBoxWriteClipboard.CheckState = CheckState.Checked;
            checkBoxWriteClipboard.Location = new Point(4, 57);
            checkBoxWriteClipboard.Margin = new Padding(2, 3, 2, 3);
            checkBoxWriteClipboard.Name = "checkBoxWriteClipboard";
            checkBoxWriteClipboard.Size = new Size(146, 23);
            checkBoxWriteClipboard.TabIndex = 3;
            checkBoxWriteClipboard.Text = "写入剪切板内容 (F1)";
            checkBoxWriteClipboard.UseVisualStyleBackColor = true;
            // 
            // checkBoxOpenAfter
            // 
            checkBoxOpenAfter.AutoSize = true;
            checkBoxOpenAfter.Checked = true;
            checkBoxOpenAfter.CheckState = CheckState.Checked;
            checkBoxOpenAfter.Location = new Point(154, 57);
            checkBoxOpenAfter.Margin = new Padding(2, 3, 2, 3);
            checkBoxOpenAfter.Name = "checkBoxOpenAfter";
            checkBoxOpenAfter.Size = new Size(120, 23);
            checkBoxOpenAfter.TabIndex = 4;
            checkBoxOpenAfter.Text = "创建后打开 (F2)";
            checkBoxOpenAfter.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(4, 4);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(482, 16);
            label1.TabIndex = 5;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnFile
            // 
            btnFile.Location = new Point(397, 56);
            btnFile.Margin = new Padding(2, 3, 2, 3);
            btnFile.Name = "btnFile";
            btnFile.Size = new Size(129, 25);
            btnFile.TabIndex = 6;
            btnFile.Text = "文件 (Shift+Enter)";
            btnFile.UseVisualStyleBackColor = true;
            btnFile.Click += btnFile_Click;
            // 
            // NewFile
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(528, 83);
            Controls.Add(btnFile);
            Controls.Add(label1);
            Controls.Add(checkBoxOpenAfter);
            Controls.Add(checkBoxWriteClipboard);
            Controls.Add(btnFolder);
            Controls.Add(txtFileName);
            Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(2, 3, 2, 3);
            Name = "NewFile";
            Text = "NewFile";
            KeyUp += NewFile_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtFileName;
        private Button btnFolder;
        private CheckBox checkBoxWriteClipboard;
        private CheckBox checkBoxOpenAfter;
        private Label label1;
        private Button btnFile;
    }
}