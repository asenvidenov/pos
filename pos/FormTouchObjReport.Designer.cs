namespace pos
{
    partial class FormTouchObjReport
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Object = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdersCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdersOpened = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdersClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdersRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdersSUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2020, 1, 24, 23, 36, 0, 0);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(241, 11);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.Value = new System.DateTime(2020, 1, 25, 18, 36, 0, 0);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Object,
            this.OrdersCount,
            this.OrdersOpened,
            this.OrdersClosed,
            this.OrdersRE,
            this.OrdersSUM,
            this.Cash,
            this.Terminal});
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(875, 385);
            this.dataGridView1.TabIndex = 2;
            // 
            // Object
            // 
            this.Object.HeaderText = "ОБЕКТ";
            this.Object.Name = "Object";
            this.Object.ReadOnly = true;
            // 
            // OrdersCount
            // 
            this.OrdersCount.HeaderText = "БРОЙ ПРОДАЖБИ";
            this.OrdersCount.Name = "OrdersCount";
            this.OrdersCount.ReadOnly = true;
            // 
            // OrdersOpened
            // 
            this.OrdersOpened.HeaderText = "ОТВОРЕНИ";
            this.OrdersOpened.Name = "OrdersOpened";
            this.OrdersOpened.ReadOnly = true;
            // 
            // OrdersClosed
            // 
            this.OrdersClosed.HeaderText = "ЗАТВОРЕНИ";
            this.OrdersClosed.Name = "OrdersClosed";
            this.OrdersClosed.ReadOnly = true;
            // 
            // OrdersRE
            // 
            this.OrdersRE.HeaderText = "СТОРНИРАНИ";
            this.OrdersRE.Name = "OrdersRE";
            this.OrdersRE.ReadOnly = true;
            // 
            // OrdersSUM
            // 
            this.OrdersSUM.HeaderText = "ОБША СУМА";
            this.OrdersSUM.Name = "OrdersSUM";
            this.OrdersSUM.ReadOnly = true;
            // 
            // Cash
            // 
            this.Cash.HeaderText = "В БРОЙ";
            this.Cash.Name = "Cash";
            this.Cash.ReadOnly = true;
            // 
            // Terminal
            // 
            this.Terminal.HeaderText = "БЕЗКАСОВО";
            this.Terminal.Name = "Terminal";
            this.Terminal.ReadOnly = true;
            // 
            // FormTouchObjReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "FormTouchObjReport";
            this.Text = "FormTouchObjReport";
            this.Load += new System.EventHandler(this.FormTouchObjReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Object;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdersCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdersOpened;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdersClosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdersRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdersSUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal;
    }
}