namespace WindowsFormsAppcCityBusStation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSignIn = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonFromSignInToMain = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.buttonResultEdit = new System.Windows.Forms.Button();
            this.buttonFromEditToMain = new System.Windows.Forms.Button();
            this.labelEditTitle = new System.Windows.Forms.Label();
            this.splitContainerEdit = new System.Windows.Forms.SplitContainer();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonFromMainToShedules = new System.Windows.Forms.Button();
            this.buttonFromMainToPoints = new System.Windows.Forms.Button();
            this.buttonFromMainToRoutes = new System.Windows.Forms.Button();
            this.buttonFromMainToDrivers = new System.Windows.Forms.Button();
            this.buttonFromMainToBuses = new System.Windows.Forms.Button();
            this.buttonFromMainToTickets = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonToMain = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonFromMainSignIn = new System.Windows.Forms.Button();
            this.panelSignIn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEdit)).BeginInit();
            this.splitContainerEdit.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.panelData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSignIn
            // 
            this.panelSignIn.Controls.Add(this.groupBox1);
            this.panelSignIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSignIn.Location = new System.Drawing.Point(0, 0);
            this.panelSignIn.Name = "panelSignIn";
            this.panelSignIn.Size = new System.Drawing.Size(1778, 844);
            this.panelSignIn.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.buttonFromSignInToMain);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxLogin);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Location = new System.Drawing.Point(751, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 421);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.label1.Location = new System.Drawing.Point(81, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Пароль";
            // 
            // buttonFromSignInToMain
            // 
            this.buttonFromSignInToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonFromSignInToMain.Location = new System.Drawing.Point(28, 321);
            this.buttonFromSignInToMain.Name = "buttonFromSignInToMain";
            this.buttonFromSignInToMain.Size = new System.Drawing.Size(395, 66);
            this.buttonFromSignInToMain.TabIndex = 1;
            this.buttonFromSignInToMain.Text = "Войти";
            this.buttonFromSignInToMain.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Логин";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxLogin.Location = new System.Drawing.Point(28, 119);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(395, 39);
            this.textBoxLogin.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxPassword.Location = new System.Drawing.Point(28, 227);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(395, 39);
            this.textBoxPassword.TabIndex = 3;
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.buttonResultEdit);
            this.panelEdit.Controls.Add(this.buttonFromEditToMain);
            this.panelEdit.Controls.Add(this.labelEditTitle);
            this.panelEdit.Controls.Add(this.splitContainerEdit);
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdit.Location = new System.Drawing.Point(0, 0);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(1778, 844);
            this.panelEdit.TabIndex = 2;
            this.panelEdit.Visible = false;
            // 
            // buttonResultEdit
            // 
            this.buttonResultEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonResultEdit.Location = new System.Drawing.Point(970, 9);
            this.buttonResultEdit.Name = "buttonResultEdit";
            this.buttonResultEdit.Size = new System.Drawing.Size(395, 66);
            this.buttonResultEdit.TabIndex = 9;
            this.buttonResultEdit.Text = "Кнопка";
            this.buttonResultEdit.UseVisualStyleBackColor = true;
            // 
            // buttonFromEditToMain
            // 
            this.buttonFromEditToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonFromEditToMain.Location = new System.Drawing.Point(1371, 8);
            this.buttonFromEditToMain.Name = "buttonFromEditToMain";
            this.buttonFromEditToMain.Size = new System.Drawing.Size(395, 66);
            this.buttonFromEditToMain.TabIndex = 8;
            this.buttonFromEditToMain.Text = "На главную";
            this.buttonFromEditToMain.UseVisualStyleBackColor = true;
            // 
            // labelEditTitle
            // 
            this.labelEditTitle.AutoSize = true;
            this.labelEditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelEditTitle.Location = new System.Drawing.Point(3, 9);
            this.labelEditTitle.Name = "labelEditTitle";
            this.labelEditTitle.Size = new System.Drawing.Size(233, 52);
            this.labelEditTitle.TabIndex = 0;
            this.labelEditTitle.Text = "Заголовок";
            // 
            // splitContainerEdit
            // 
            this.splitContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEdit.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEdit.Name = "splitContainerEdit";
            this.splitContainerEdit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEdit.Panel2
            // 
            this.splitContainerEdit.Panel2.AutoScroll = true;
            this.splitContainerEdit.Size = new System.Drawing.Size(1778, 844);
            this.splitContainerEdit.SplitterDistance = 103;
            this.splitContainerEdit.TabIndex = 10;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.buttonFromMainSignIn);
            this.panelMain.Controls.Add(this.groupBox3);
            this.panelMain.Controls.Add(this.label11);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1778, 844);
            this.panelMain.TabIndex = 4;
            this.panelMain.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonFromMainToShedules);
            this.groupBox3.Controls.Add(this.buttonFromMainToPoints);
            this.groupBox3.Controls.Add(this.buttonFromMainToRoutes);
            this.groupBox3.Controls.Add(this.buttonFromMainToDrivers);
            this.groupBox3.Controls.Add(this.buttonFromMainToBuses);
            this.groupBox3.Controls.Add(this.buttonFromMainToTickets);
            this.groupBox3.Location = new System.Drawing.Point(440, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(879, 399);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // buttonFromMainToShedules
            // 
            this.buttonFromMainToShedules.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonFromMainToShedules.Location = new System.Drawing.Point(26, 75);
            this.buttonFromMainToShedules.Name = "buttonFromMainToShedules";
            this.buttonFromMainToShedules.Size = new System.Drawing.Size(395, 66);
            this.buttonFromMainToShedules.TabIndex = 3;
            this.buttonFromMainToShedules.Text = "Расписание";
            this.buttonFromMainToShedules.UseVisualStyleBackColor = true;
            this.buttonFromMainToShedules.Click += new System.EventHandler(this.buttonFromMainToShedules_Click);
            // 
            // buttonFromMainToPoints
            // 
            this.buttonFromMainToPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonFromMainToPoints.Location = new System.Drawing.Point(449, 170);
            this.buttonFromMainToPoints.Name = "buttonFromMainToPoints";
            this.buttonFromMainToPoints.Size = new System.Drawing.Size(395, 66);
            this.buttonFromMainToPoints.TabIndex = 8;
            this.buttonFromMainToPoints.Text = "Пункты назначения";
            this.buttonFromMainToPoints.UseVisualStyleBackColor = true;
            this.buttonFromMainToPoints.Click += new System.EventHandler(this.buttonFromMainToPoints_Click);
            // 
            // buttonFromMainToRoutes
            // 
            this.buttonFromMainToRoutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonFromMainToRoutes.Location = new System.Drawing.Point(449, 75);
            this.buttonFromMainToRoutes.Name = "buttonFromMainToRoutes";
            this.buttonFromMainToRoutes.Size = new System.Drawing.Size(395, 66);
            this.buttonFromMainToRoutes.TabIndex = 4;
            this.buttonFromMainToRoutes.Text = "Маршруты";
            this.buttonFromMainToRoutes.UseVisualStyleBackColor = true;
            this.buttonFromMainToRoutes.Click += new System.EventHandler(this.buttonFromMainToRoutes_Click);
            // 
            // buttonFromMainToDrivers
            // 
            this.buttonFromMainToDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonFromMainToDrivers.Location = new System.Drawing.Point(26, 170);
            this.buttonFromMainToDrivers.Name = "buttonFromMainToDrivers";
            this.buttonFromMainToDrivers.Size = new System.Drawing.Size(395, 66);
            this.buttonFromMainToDrivers.TabIndex = 7;
            this.buttonFromMainToDrivers.Text = "Водители";
            this.buttonFromMainToDrivers.UseVisualStyleBackColor = true;
            this.buttonFromMainToDrivers.Click += new System.EventHandler(this.buttonFromMainToDrivers_Click);
            // 
            // buttonFromMainToBuses
            // 
            this.buttonFromMainToBuses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonFromMainToBuses.Location = new System.Drawing.Point(26, 263);
            this.buttonFromMainToBuses.Name = "buttonFromMainToBuses";
            this.buttonFromMainToBuses.Size = new System.Drawing.Size(395, 66);
            this.buttonFromMainToBuses.TabIndex = 5;
            this.buttonFromMainToBuses.Text = "Автобусы";
            this.buttonFromMainToBuses.UseVisualStyleBackColor = true;
            this.buttonFromMainToBuses.Click += new System.EventHandler(this.buttonFromMainToBuses_Click);
            // 
            // buttonFromMainToTickets
            // 
            this.buttonFromMainToTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonFromMainToTickets.Location = new System.Drawing.Point(449, 263);
            this.buttonFromMainToTickets.Name = "buttonFromMainToTickets";
            this.buttonFromMainToTickets.Size = new System.Drawing.Size(395, 66);
            this.buttonFromMainToTickets.TabIndex = 6;
            this.buttonFromMainToTickets.Text = "Билеты";
            this.buttonFromMainToTickets.UseVisualStyleBackColor = true;
            this.buttonFromMainToTickets.Click += new System.EventHandler(this.buttonFromMainToTickets_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(742, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(337, 52);
            this.label11.TabIndex = 0;
            this.label11.Text = "Выбор раздела";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonUpload);
            this.splitContainer1.Panel1.Controls.Add(this.buttonCreate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewData);
            this.splitContainer1.Size = new System.Drawing.Size(1778, 844);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.TabIndex = 3;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonCreate.Location = new System.Drawing.Point(940, 26);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(395, 66);
            this.buttonCreate.TabIndex = 11;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewData.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewData.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.ReadOnly = true;
            this.dataGridViewData.RowHeadersVisible = false;
            this.dataGridViewData.RowHeadersWidth = 62;
            this.dataGridViewData.RowTemplate.Height = 28;
            this.dataGridViewData.Size = new System.Drawing.Size(1778, 717);
            this.dataGridViewData.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(220, 52);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Название";
            // 
            // buttonToMain
            // 
            this.buttonToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonToMain.Location = new System.Drawing.Point(1371, 26);
            this.buttonToMain.Name = "buttonToMain";
            this.buttonToMain.Size = new System.Drawing.Size(395, 66);
            this.buttonToMain.TabIndex = 2;
            this.buttonToMain.Text = "На главную";
            this.buttonToMain.UseVisualStyleBackColor = true;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.buttonToMain);
            this.panelData.Controls.Add(this.labelTitle);
            this.panelData.Controls.Add(this.splitContainer1);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1778, 844);
            this.panelData.TabIndex = 1;
            this.panelData.Visible = false;
            // 
            // buttonUpload
            // 
            this.buttonUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonUpload.Location = new System.Drawing.Point(503, 26);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(395, 66);
            this.buttonUpload.TabIndex = 12;
            this.buttonUpload.Text = "Выгрузить в TXT";
            this.buttonUpload.UseVisualStyleBackColor = true;
            // 
            // buttonFromMainSignIn
            // 
            this.buttonFromMainSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonFromMainSignIn.Location = new System.Drawing.Point(1371, 12);
            this.buttonFromMainSignIn.Name = "buttonFromMainSignIn";
            this.buttonFromMainSignIn.Size = new System.Drawing.Size(395, 66);
            this.buttonFromMainSignIn.TabIndex = 10;
            this.buttonFromMainSignIn.Text = "Выход";
            this.buttonFromMainSignIn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1778, 844);
            this.Controls.Add(this.panelSignIn);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelEdit);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Городской автовокзал";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSignIn.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEdit)).EndInit();
            this.splitContainerEdit.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSignIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Label labelEditTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonFromSignInToMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonFromEditToMain;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonFromMainToPoints;
        private System.Windows.Forms.Button buttonFromMainToDrivers;
        private System.Windows.Forms.Button buttonFromMainToTickets;
        private System.Windows.Forms.Button buttonFromMainToBuses;
        private System.Windows.Forms.Button buttonFromMainToRoutes;
        private System.Windows.Forms.Button buttonFromMainToShedules;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonToMain;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Button buttonResultEdit;
        private System.Windows.Forms.SplitContainer splitContainerEdit;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonFromMainSignIn;
    }
}

