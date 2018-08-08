namespace AMPS.forms
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuMonthlyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCalculationOfWages = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPositionInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSocialSecuritySystem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuAdd,
            this.MnuMonthlyReport,
            this.MnuCalculationOfWages,
            this.MnuPositionInformation,
            this.MnuSocialSecuritySystem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuAdd
            // 
            this.MnuAdd.Name = "MnuAdd";
            this.MnuAdd.Size = new System.Drawing.Size(96, 20);
            this.MnuAdd.Text = "افزودن بخش جدید";
            this.MnuAdd.Click += new System.EventHandler(this.MnuAdd_Click_1);
            // 
            // MnuMonthlyReport
            // 
            this.MnuMonthlyReport.Name = "MnuMonthlyReport";
            this.MnuMonthlyReport.Size = new System.Drawing.Size(81, 20);
            this.MnuMonthlyReport.Text = "گزارش ماهانه";
            this.MnuMonthlyReport.Click += new System.EventHandler(this.MnuMonthlyReport_Click);
            // 
            // MnuCalculationOfWages
            // 
            this.MnuCalculationOfWages.Name = "MnuCalculationOfWages";
            this.MnuCalculationOfWages.Size = new System.Drawing.Size(38, 20);
            this.MnuCalculationOfWages.Text = "بیمه";
            this.MnuCalculationOfWages.Click += new System.EventHandler(this.calculationOfWagesToolStripMenuItem_Click);
            // 
            // MnuPositionInformation
            // 
            this.MnuPositionInformation.Name = "MnuPositionInformation";
            this.MnuPositionInformation.Size = new System.Drawing.Size(113, 20);
            this.MnuPositionInformation.Text = "اطلاعات موقعیت افراد";
            this.MnuPositionInformation.Click += new System.EventHandler(this.MnuPositionInformation_Click);
            // 
            // MnuSocialSecuritySystem
            // 
            this.MnuSocialSecuritySystem.Name = "MnuSocialSecuritySystem";
            this.MnuSocialSecuritySystem.Size = new System.Drawing.Size(120, 20);
            this.MnuSocialSecuritySystem.Text = "سیستم تامین اجتماعی";
            this.MnuSocialSecuritySystem.Click += new System.EventHandler(this.MnuSelectiveServiceSystem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.exitToolStripMenuItem.Text = "خروج";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 499);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tahlildadeh";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuAdd;
        private System.Windows.Forms.ToolStripMenuItem MnuMonthlyReport;
        private System.Windows.Forms.ToolStripMenuItem MnuCalculationOfWages;
        private System.Windows.Forms.ToolStripMenuItem MnuPositionInformation;
        private System.Windows.Forms.ToolStripMenuItem MnuSocialSecuritySystem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;


    }
}