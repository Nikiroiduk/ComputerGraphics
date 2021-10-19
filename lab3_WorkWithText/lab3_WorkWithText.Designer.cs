
namespace lab3_WorkWithText
{
    partial class lab3_WorkWithText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveInFile = new System.Windows.Forms.Button();
            this.Show = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 468);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveInFile);
            this.groupBox1.Controls.Add(this.Show);
            this.groupBox1.Controls.Add(this.Clear);
            this.groupBox1.Location = new System.Drawing.Point(734, 486);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(238, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // SaveInFile
            // 
            this.SaveInFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveInFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveInFile.Location = new System.Drawing.Point(7, 13);
            this.SaveInFile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.SaveInFile.Name = "SaveInFile";
            this.SaveInFile.Size = new System.Drawing.Size(75, 44);
            this.SaveInFile.TabIndex = 2;
            this.SaveInFile.Text = "Save in file";
            this.SaveInFile.UseVisualStyleBackColor = true;
            this.SaveInFile.Click += new System.EventHandler(this.SaveInFile_Click);
            // 
            // Show
            // 
            this.Show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Show.Dock = System.Windows.Forms.DockStyle.Right;
            this.Show.Location = new System.Drawing.Point(82, 13);
            this.Show.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(75, 44);
            this.Show.TabIndex = 1;
            this.Show.Text = "Show";
            this.Show.UseVisualStyleBackColor = true;
            this.Show.Click += new System.EventHandler(this.Show_Click);
            // 
            // Clear
            // 
            this.Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Clear.Dock = System.Windows.Forms.DockStyle.Right;
            this.Clear.Location = new System.Drawing.Point(157, 13);
            this.Clear.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 44);
            this.Clear.TabIndex = 0;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "lab3_WorkWithText";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button SaveInFile;
        private System.Windows.Forms.Button Show;
    }
}

