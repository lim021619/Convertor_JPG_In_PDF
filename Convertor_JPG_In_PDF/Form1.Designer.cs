namespace Convertor_JPG_In_PDF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartConvert = new System.Windows.Forms.Button();
            this.IndicatorsBar = new System.Windows.Forms.ProgressBar();
            this.CountTextLabel = new System.Windows.Forms.Label();
            this.PathDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogsLabel = new System.Windows.Forms.Label();
            this.listLogs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // StartConvert
            // 
            this.StartConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartConvert.Location = new System.Drawing.Point(505, 353);
            this.StartConvert.Name = "StartConvert";
            this.StartConvert.Size = new System.Drawing.Size(162, 34);
            this.StartConvert.TabIndex = 0;
            this.StartConvert.Text = "Начать";
            this.StartConvert.UseVisualStyleBackColor = true;
            this.StartConvert.Click += new System.EventHandler(this.button1_Click);
            // 
            // IndicatorsBar
            // 
            this.IndicatorsBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IndicatorsBar.Location = new System.Drawing.Point(12, 363);
            this.IndicatorsBar.Name = "IndicatorsBar";
            this.IndicatorsBar.Size = new System.Drawing.Size(473, 21);
            this.IndicatorsBar.TabIndex = 1;
            // 
            // CountTextLabel
            // 
            this.CountTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CountTextLabel.AutoSize = true;
            this.CountTextLabel.Location = new System.Drawing.Point(10, 345);
            this.CountTextLabel.Name = "CountTextLabel";
            this.CountTextLabel.Size = new System.Drawing.Size(78, 15);
            this.CountTextLabel.TabIndex = 2;
            this.CountTextLabel.Text = "Готово 0 из 0";
            // 
            // PathDirectory
            // 
            this.PathDirectory.Location = new System.Drawing.Point(12, 31);
            this.PathDirectory.Name = "PathDirectory";
            this.PathDirectory.PlaceholderText = "Введите полный адресс к папке";
            this.PathDirectory.Size = new System.Drawing.Size(655, 23);
            this.PathDirectory.TabIndex = 3;
            this.PathDirectory.TextChanged += new System.EventHandler(this.PathDirectory_TextChanged);
            this.PathDirectory.VisibleChanged += new System.EventHandler(this.PathDirectory_VisibleChanged);
            this.PathDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PathDirectory_KeyDown);
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Адрес папки";
            // 
            // LogsLabel
            // 
            this.LogsLabel.AutoSize = true;
            this.LogsLabel.Location = new System.Drawing.Point(13, 73);
            this.LogsLabel.Name = "LogsLabel";
            this.LogsLabel.Size = new System.Drawing.Size(51, 15);
            this.LogsLabel.TabIndex = 6;
            this.LogsLabel.Text = "Журнал";
            this.LogsLabel.Click += new System.EventHandler(this.LogsLabel_Click);
            // 
            // listLogs
            // 
            this.listLogs.AllowDrop = true;
            this.listLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listLogs.Enabled = false;
            this.listLogs.FormattingEnabled = true;
            this.listLogs.HorizontalScrollbar = true;
            this.listLogs.ItemHeight = 15;
            this.listLogs.Location = new System.Drawing.Point(12, 91);
            this.listLogs.Name = "listLogs";
            this.listLogs.Size = new System.Drawing.Size(652, 242);
            this.listLogs.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 396);
            this.Controls.Add(this.listLogs);
            this.Controls.Add(this.LogsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PathDirectory);
            this.Controls.Add(this.CountTextLabel);
            this.Controls.Add(this.IndicatorsBar);
            this.Controls.Add(this.StartConvert);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Конвертаци JPG в PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartConvert;
        private ProgressBar IndicatorsBar;
        private Label CountTextLabel;
        private TextBox PathDirectory;
        private Label label1;
        private Label LogsLabel;
        private ListBox listLogs;
    }
}