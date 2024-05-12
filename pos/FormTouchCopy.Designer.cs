namespace pos
{
    partial class FormTouchCopy
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrderSum = new System.Windows.Forms.Label();
            this.lblOpName = new System.Windows.Forms.Label();
            this.btnPrintCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ОПЕРАТОР:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "СУМА:";
            // 
            // lblOrderSum
            // 
            this.lblOrderSum.AutoSize = true;
            this.lblOrderSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOrderSum.Location = new System.Drawing.Point(190, 50);
            this.lblOrderSum.Name = "lblOrderSum";
            this.lblOrderSum.Size = new System.Drawing.Size(78, 25);
            this.lblOrderSum.TabIndex = 3;
            this.lblOrderSum.Text = "СУМА:";
            // 
            // lblOpName
            // 
            this.lblOpName.AutoSize = true;
            this.lblOpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOpName.Location = new System.Drawing.Point(190, 9);
            this.lblOpName.Name = "lblOpName";
            this.lblOpName.Size = new System.Drawing.Size(134, 25);
            this.lblOpName.TabIndex = 2;
            this.lblOpName.Text = "ОПЕРАТОР:";
            // 
            // btnPrintCopy
            // 
            this.btnPrintCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrintCopy.Location = new System.Drawing.Point(17, 91);
            this.btnPrintCopy.Name = "btnPrintCopy";
            this.btnPrintCopy.Size = new System.Drawing.Size(307, 59);
            this.btnPrintCopy.TabIndex = 4;
            this.btnPrintCopy.Text = "ДУБЛИКАТ";
            this.btnPrintCopy.UseVisualStyleBackColor = true;
            this.btnPrintCopy.Click += new System.EventHandler(this.btnPrintCopy_Click);
            // 
            // FormTouchCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 175);
            this.Controls.Add(this.btnPrintCopy);
            this.Controls.Add(this.lblOrderSum);
            this.Controls.Add(this.lblOpName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormTouchCopy";
            this.Text = "FormTouchCopy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOrderSum;
        private System.Windows.Forms.Label lblOpName;
        private System.Windows.Forms.Button btnPrintCopy;
    }
}