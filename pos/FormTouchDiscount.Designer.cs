using System;

namespace pos
{
    partial class FormTouchDiscount
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
            this.txtCardNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDPercent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCardNum
            // 
            this.txtCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNum.Location = new System.Drawing.Point(12, 66);
            this.txtCardNum.Name = "txtCardNum";
            this.txtCardNum.Size = new System.Drawing.Size(209, 38);
            this.txtCardNum.TabIndex = 0;
            this.txtCardNum.UseSystemPasswordChar = true;
            this.txtCardNum.LostFocus += new System.EventHandler(this.txtCardNum_LostFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "КАРТА:";
            // 
            // lblDName
            // 
            this.lblDName.AutoSize = true;
            this.lblDName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDName.ForeColor = System.Drawing.Color.Red;
            this.lblDName.Location = new System.Drawing.Point(6, 129);
            this.lblDName.Name = "lblDName";
            this.lblDName.Size = new System.Drawing.Size(174, 31);
            this.lblDName.TabIndex = 2;
            this.lblDName.Text = "ОТСТЪПКА";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "ПОТВЪРДИ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDPercent
            // 
            this.lblDPercent.AutoSize = true;
            this.lblDPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDPercent.ForeColor = System.Drawing.Color.Red;
            this.lblDPercent.Location = new System.Drawing.Point(12, 198);
            this.lblDPercent.Name = "lblDPercent";
            this.lblDPercent.Size = new System.Drawing.Size(174, 31);
            this.lblDPercent.TabIndex = 5;
            this.lblDPercent.Text = "ОТСТЪПКА";
            // 
            // FormTouchDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 331);
            this.Controls.Add(this.lblDPercent);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCardNum);
            this.Name = "FormTouchDiscount";
            this.Text = "FormTouchDiscount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox txtCardNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDPercent;
    }
}