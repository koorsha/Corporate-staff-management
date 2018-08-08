﻿namespace AMPS.forms
{
    partial class FormPhilHealth
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.dataGridViewPhilHealth = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhilHealth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(525, 21);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(243, 26);
            this.label1.TabIndex = 95;
            this.label1.Text = "بارگذاری اطلاعات جدول بیمه";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Image = global::AMPS.Properties.Resources.Delete_XS;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(445, 366);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(85, 25);
            this.buttonCancel.TabIndex = 94;
            this.buttonCancel.Text = "انصراف";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = global::AMPS.Properties.Resources.Save_L;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(551, 366);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(85, 25);
            this.buttonSave.TabIndex = 93;
            this.buttonSave.Text = "ذخیره";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Image = global::AMPS.Properties.Resources.folder;
            this.buttonChooseFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChooseFile.Location = new System.Drawing.Point(658, 366);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(114, 25);
            this.buttonChooseFile.TabIndex = 92;
            this.buttonChooseFile.Text = "انتخاب فایل";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // dataGridViewPhilHealth
            // 
            this.dataGridViewPhilHealth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPhilHealth.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewPhilHealth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhilHealth.Enabled = false;
            this.dataGridViewPhilHealth.Location = new System.Drawing.Point(19, 60);
            this.dataGridViewPhilHealth.Name = "dataGridViewPhilHealth";
            this.dataGridViewPhilHealth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewPhilHealth.Size = new System.Drawing.Size(750, 300);
            this.dataGridViewPhilHealth.TabIndex = 91;
            // 
            // FormPhilHealth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonChooseFile);
            this.Controls.Add(this.dataGridViewPhilHealth);
            this.Name = "FormPhilHealth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load PhilHealth";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhilHealth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.DataGridView dataGridViewPhilHealth;
    }
}