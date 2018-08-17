namespace CCInstallDirChanger
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBox_Dir = new System.Windows.Forms.TextBox();
            this.Btn_Browse = new System.Windows.Forms.Button();
            this.Btn_Activate = new System.Windows.Forms.Button();
            this.Btn_Deactivate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desired Install Directory for Adobe CC:";
            // 
            // TxtBox_Dir
            // 
            this.TxtBox_Dir.Enabled = false;
            this.TxtBox_Dir.Location = new System.Drawing.Point(337, 5);
            this.TxtBox_Dir.Name = "TxtBox_Dir";
            this.TxtBox_Dir.Size = new System.Drawing.Size(512, 25);
            this.TxtBox_Dir.TabIndex = 1;
            this.TxtBox_Dir.Text = "D:\\Software\\Adobe\\";
            // 
            // Btn_Browse
            // 
            this.Btn_Browse.Location = new System.Drawing.Point(855, 4);
            this.Btn_Browse.Name = "Btn_Browse";
            this.Btn_Browse.Size = new System.Drawing.Size(99, 26);
            this.Btn_Browse.TabIndex = 2;
            this.Btn_Browse.Text = "Browse";
            this.Btn_Browse.UseVisualStyleBackColor = true;
            this.Btn_Browse.Click += new System.EventHandler(this.Btn_Browse_Click);
            // 
            // Btn_Activate
            // 
            this.Btn_Activate.Enabled = false;
            this.Btn_Activate.Location = new System.Drawing.Point(15, 48);
            this.Btn_Activate.Name = "Btn_Activate";
            this.Btn_Activate.Size = new System.Drawing.Size(143, 75);
            this.Btn_Activate.TabIndex = 3;
            this.Btn_Activate.Text = "Activate";
            this.Btn_Activate.UseVisualStyleBackColor = true;
            this.Btn_Activate.Click += new System.EventHandler(this.Btn_Activate_Click);
            // 
            // Btn_Deactivate
            // 
            this.Btn_Deactivate.Enabled = false;
            this.Btn_Deactivate.Location = new System.Drawing.Point(179, 48);
            this.Btn_Deactivate.Name = "Btn_Deactivate";
            this.Btn_Deactivate.Size = new System.Drawing.Size(139, 75);
            this.Btn_Deactivate.TabIndex = 4;
            this.Btn_Deactivate.Text = "Deactivate";
            this.Btn_Deactivate.UseVisualStyleBackColor = true;
            this.Btn_Deactivate.Click += new System.EventHandler(this.Btn_Deactivate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(623, 75);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 142);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_Deactivate);
            this.Controls.Add(this.Btn_Activate);
            this.Controls.Add(this.Btn_Browse);
            this.Controls.Add(this.TxtBox_Dir);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Adobe CC 2017/2018 Install Directory Changer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBox_Dir;
        private System.Windows.Forms.Button Btn_Browse;
        private System.Windows.Forms.Button Btn_Activate;
        private System.Windows.Forms.Button Btn_Deactivate;
        private System.Windows.Forms.Label label2;
    }
}

