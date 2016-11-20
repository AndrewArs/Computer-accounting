namespace Computer_accounting
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motherboardColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.logColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonFullLog = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.computerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.processorColumn,
            this.memoryColumn,
            this.motherboardColumn,
            this.infoColumn,
            this.logColumn});
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(442, 210);
            this.dataGridView.TabIndex = 0;
            // 
            // IdColumn
            // 
            this.IdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Width = 43;
            // 
            // processorColumn
            // 
            this.processorColumn.HeaderText = "Processor";
            this.processorColumn.Name = "processorColumn";
            this.processorColumn.ReadOnly = true;
            this.processorColumn.Width = 79;
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
            // infoColumn
            // 
            this.infoColumn.HeaderText = "Full info";
            this.infoColumn.Name = "infoColumn";
            this.infoColumn.ReadOnly = true;
            this.infoColumn.Text = "Show";
            this.infoColumn.Width = 49;
            // 
            // logColumn
            // 
            this.logColumn.HeaderText = "Change log";
            this.logColumn.Name = "logColumn";
            this.logColumn.ReadOnly = true;
            this.logColumn.Text = "Show";
            this.logColumn.Width = 67;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(12, 290);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add ";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.Location = new System.Drawing.Point(93, 289);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpdate.Location = new System.Drawing.Point(174, 290);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonFullLog
            // 
            this.buttonFullLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFullLog.Location = new System.Drawing.Point(379, 290);
            this.buttonFullLog.Name = "buttonFullLog";
            this.buttonFullLog.Size = new System.Drawing.Size(75, 23);
            this.buttonFullLog.TabIndex = 4;
            this.buttonFullLog.Text = "Full Log";
            this.buttonFullLog.UseVisualStyleBackColor = true;
            this.buttonFullLog.Click += new System.EventHandler(this.buttonFullLog_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(463, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.aboutToolStripMenuItem.Text = "about";
            // 
            // autoUpdateCheckBox
            // 
            this.autoUpdateCheckBox.AutoSize = true;
            this.autoUpdateCheckBox.Location = new System.Drawing.Point(367, 243);
            this.autoUpdateCheckBox.Name = "autoUpdateCheckBox";
            this.autoUpdateCheckBox.Size = new System.Drawing.Size(84, 17);
            this.autoUpdateCheckBox.TabIndex = 6;
            this.autoUpdateCheckBox.Text = "Auto update";
            this.autoUpdateCheckBox.UseVisualStyleBackColor = true;
            this.autoUpdateCheckBox.CheckedChanged += new System.EventHandler(this.autoUpdateCheckBox_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // computerButton
            // 
            this.computerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.computerButton.Location = new System.Drawing.Point(12, 261);
            this.computerButton.Name = "computerButton";
            this.computerButton.Size = new System.Drawing.Size(101, 23);
            this.computerButton.TabIndex = 7;
            this.computerButton.Text = "This computer";
            this.computerButton.UseVisualStyleBackColor = true;
            this.computerButton.Click += new System.EventHandler(this.computerButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 327);
            this.Controls.Add(this.computerButton);
            this.Controls.Add(this.autoUpdateCheckBox);
            this.Controls.Add(this.buttonFullLog);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Computer accounting";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn processorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motherboardColumn;
        private System.Windows.Forms.DataGridViewButtonColumn infoColumn;
        private System.Windows.Forms.DataGridViewButtonColumn logColumn;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonFullLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox autoUpdateCheckBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button computerButton;
    }
}

