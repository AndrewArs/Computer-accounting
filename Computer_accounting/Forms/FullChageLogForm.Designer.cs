namespace Computer_accounting
{
    partial class FullChageLogForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computerIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motherboardColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.graphicsCardColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardDriveColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyboardColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monitorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateColumn,
            this.computerIdColumn,
            this.cpuColumn,
            this.memoryColumn,
            this.motherboardColumn,
            this.graphicsCardColumn,
            this.hardDriveColumn,
            this.keyboardColumn,
            this.monitorColumn,
            this.mouseColumn,
            this.operationColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(876, 262);
            this.dataGridView.TabIndex = 1;
            // 
            // dateColumn
            // 
            this.dateColumn.HeaderText = "Date";
            this.dateColumn.Name = "dateColumn";
            this.dateColumn.ReadOnly = true;
            this.dateColumn.Width = 55;
            // 
            // computerIdColumn
            // 
            this.computerIdColumn.HeaderText = "Computer ID";
            this.computerIdColumn.Name = "computerIdColumn";
            this.computerIdColumn.ReadOnly = true;
            this.computerIdColumn.Width = 91;
            // 
            // cpuColumn
            // 
            this.cpuColumn.HeaderText = "CPU";
            this.cpuColumn.Name = "cpuColumn";
            this.cpuColumn.ReadOnly = true;
            this.cpuColumn.Width = 54;
            // 
            // memoryColumn
            // 
            this.memoryColumn.HeaderText = "Memory";
            this.memoryColumn.Name = "memoryColumn";
            this.memoryColumn.ReadOnly = true;
            this.memoryColumn.Width = 69;
            // 
            // motherboardColumn
            // 
            this.motherboardColumn.HeaderText = "Motherboard";
            this.motherboardColumn.Name = "motherboardColumn";
            this.motherboardColumn.ReadOnly = true;
            this.motherboardColumn.Width = 92;
            // 
            // graphicsCardColumn
            // 
            this.graphicsCardColumn.HeaderText = "Graphics card";
            this.graphicsCardColumn.Name = "graphicsCardColumn";
            this.graphicsCardColumn.ReadOnly = true;
            this.graphicsCardColumn.Width = 98;
            // 
            // hardDriveColumn
            // 
            this.hardDriveColumn.HeaderText = "Hard drive";
            this.hardDriveColumn.Name = "hardDriveColumn";
            this.hardDriveColumn.ReadOnly = true;
            this.hardDriveColumn.Width = 81;
            // 
            // keyboardColumn
            // 
            this.keyboardColumn.HeaderText = "Keyboard";
            this.keyboardColumn.Name = "keyboardColumn";
            this.keyboardColumn.ReadOnly = true;
            this.keyboardColumn.Width = 77;
            // 
            // monitorColumn
            // 
            this.monitorColumn.HeaderText = "Monitor";
            this.monitorColumn.Name = "monitorColumn";
            this.monitorColumn.ReadOnly = true;
            this.monitorColumn.Width = 67;
            // 
            // mouseColumn
            // 
            this.mouseColumn.HeaderText = "Mouse";
            this.mouseColumn.Name = "mouseColumn";
            this.mouseColumn.ReadOnly = true;
            this.mouseColumn.Width = 64;
            // 
            // operationColumn
            // 
            this.operationColumn.HeaderText = "Operation";
            this.operationColumn.Name = "operationColumn";
            this.operationColumn.ReadOnly = true;
            this.operationColumn.Width = 78;
            // 
            // FullChageLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 262);
            this.Controls.Add(this.dataGridView);
            this.Name = "FullChageLogForm";
            this.Text = "FullChageLogForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn computerIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motherboardColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn graphicsCardColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardDriveColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyboardColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monitorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouseColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationColumn;
    }
}