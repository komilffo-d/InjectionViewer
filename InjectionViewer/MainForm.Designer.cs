namespace InjectionViewer
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            timeEnd = new DateTimePicker();
            pGroup = new GroupBox();
            pEnd = new TextBox();
            pMiddle = new TextBox();
            pBegin = new TextBox();
            timeBegin = new DateTimePicker();
            timeBeginLabel = new Label();
            timeEndLabel = new Label();
            name = new TextBox();
            timeCount = new NumericUpDown();
            timeGroup = new GroupBox();
            timeCountLabel = new Label();
            genInfoGroup = new GroupBox();
            specificWeight = new TextBox();
            volumeInjection = new TextBox();
            volume = new TextBox();
            formMenu = new MenuStrip();
            formMenuChart = new ToolStripMenuItem();
            formMenuChartCreate = new ToolStripMenuItem();
            formMenuChartSaveJpg = new ToolStripMenuItem();
            formMenuChartSavePng = new ToolStripMenuItem();
            formMenuChartSaveBmp = new ToolStripMenuItem();
            formMenuForm = new ToolStripMenuItem();
            formMenuFormDropState = new ToolStripMenuItem();
            gridTopPanel = new TableLayoutPanel();
            chartName = new Label();
            chartDate = new Label();
            chartVolume = new Label();
            chart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            chartGroup = new Panel();
            validateProvider = new ErrorProvider(components);
            pGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeCount).BeginInit();
            timeGroup.SuspendLayout();
            genInfoGroup.SuspendLayout();
            formMenu.SuspendLayout();
            gridTopPanel.SuspendLayout();
            chartGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)validateProvider).BeginInit();
            SuspendLayout();
            // 
            // timeEnd
            // 
            timeEnd.CustomFormat = "";
            timeEnd.Format = DateTimePickerFormat.Time;
            timeEnd.Location = new Point(90, 55);
            timeEnd.Name = "timeEnd";
            timeEnd.ShowUpDown = true;
            timeEnd.Size = new Size(92, 25);
            timeEnd.TabIndex = 2;
            timeEnd.Validating += timeEnd_Validating;
            // 
            // pGroup
            // 
            pGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pGroup.Controls.Add(pEnd);
            pGroup.Controls.Add(pMiddle);
            pGroup.Controls.Add(pBegin);
            pGroup.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            pGroup.Location = new Point(324, 3);
            pGroup.Name = "pGroup";
            pGroup.Size = new Size(315, 145);
            pGroup.TabIndex = 13;
            pGroup.TabStop = false;
            pGroup.Text = "Давление";
            // 
            // pEnd
            // 
            pEnd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pEnd.Location = new Point(15, 94);
            pEnd.Name = "pEnd";
            pEnd.PlaceholderText = "Pкон";
            pEnd.Size = new Size(270, 25);
            pEnd.TabIndex = 39;
            pEnd.KeyPress += DeleteSpace_KeyPress;
            pEnd.Validating += pEnd_Validating;
            // 
            // pMiddle
            // 
            pMiddle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pMiddle.Location = new Point(15, 58);
            pMiddle.Name = "pMiddle";
            pMiddle.PlaceholderText = "Pср";
            pMiddle.Size = new Size(270, 25);
            pMiddle.TabIndex = 38;
            pMiddle.KeyPress += DeleteSpace_KeyPress;
            pMiddle.Validating += pMiddle_Validating;
            // 
            // pBegin
            // 
            pBegin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pBegin.Location = new Point(15, 24);
            pBegin.Name = "pBegin";
            pBegin.PlaceholderText = "Pнач";
            pBegin.Size = new Size(270, 25);
            pBegin.TabIndex = 37;
            pBegin.KeyPress += DeleteSpace_KeyPress;
            pBegin.Validating += pBegin_Validating;
            // 
            // timeBegin
            // 
            timeBegin.CustomFormat = "";
            timeBegin.Format = DateTimePickerFormat.Time;
            timeBegin.ImeMode = ImeMode.NoControl;
            timeBegin.Location = new Point(90, 17);
            timeBegin.Name = "timeBegin";
            timeBegin.ShowUpDown = true;
            timeBegin.Size = new Size(92, 25);
            timeBegin.TabIndex = 14;
            timeBegin.Validating += timeBegin_Validating;
            // 
            // timeBeginLabel
            // 
            timeBeginLabel.AutoSize = true;
            timeBeginLabel.CausesValidation = false;
            timeBeginLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            timeBeginLabel.Location = new Point(18, 21);
            timeBeginLabel.Name = "timeBeginLabel";
            timeBeginLabel.Size = new Size(66, 21);
            timeBeginLabel.TabIndex = 15;
            timeBeginLabel.Text = "Начало";
            // 
            // timeEndLabel
            // 
            timeEndLabel.AutoSize = true;
            timeEndLabel.CausesValidation = false;
            timeEndLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            timeEndLabel.Location = new Point(18, 55);
            timeEndLabel.Name = "timeEndLabel";
            timeEndLabel.Size = new Size(58, 21);
            timeEndLabel.TabIndex = 16;
            timeEndLabel.Text = "Конец";
            // 
            // name
            // 
            name.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            name.Location = new Point(9, 83);
            name.Name = "name";
            name.PlaceholderText = "Наименование";
            name.Size = new Size(291, 25);
            name.TabIndex = 18;
            name.Validating += name_Validating;
            // 
            // timeCount
            // 
            timeCount.Location = new Point(258, 22);
            timeCount.Name = "timeCount";
            timeCount.Size = new Size(45, 25);
            timeCount.TabIndex = 29;
            timeCount.Value = new decimal(new int[] { 21, 0, 0, 0 });
            // 
            // timeGroup
            // 
            timeGroup.Controls.Add(timeCountLabel);
            timeGroup.Controls.Add(timeBegin);
            timeGroup.Controls.Add(timeEnd);
            timeGroup.Controls.Add(timeCount);
            timeGroup.Controls.Add(timeBeginLabel);
            timeGroup.Controls.Add(timeEndLabel);
            timeGroup.Dock = DockStyle.Fill;
            timeGroup.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            timeGroup.Location = new Point(3, 3);
            timeGroup.Name = "timeGroup";
            timeGroup.Size = new Size(315, 145);
            timeGroup.TabIndex = 32;
            timeGroup.TabStop = false;
            timeGroup.Text = "Время";
            // 
            // timeCountLabel
            // 
            timeCountLabel.AutoSize = true;
            timeCountLabel.CausesValidation = false;
            timeCountLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            timeCountLabel.Location = new Point(188, 20);
            timeCountLabel.Name = "timeCountLabel";
            timeCountLabel.Size = new Size(64, 21);
            timeCountLabel.TabIndex = 30;
            timeCountLabel.Text = "Кол-во";
            // 
            // genInfoGroup
            // 
            genInfoGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            genInfoGroup.Controls.Add(specificWeight);
            genInfoGroup.Controls.Add(volumeInjection);
            genInfoGroup.Controls.Add(volume);
            genInfoGroup.Controls.Add(name);
            genInfoGroup.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            genInfoGroup.Location = new Point(645, 3);
            genInfoGroup.Name = "genInfoGroup";
            genInfoGroup.Size = new Size(316, 145);
            genInfoGroup.TabIndex = 33;
            genInfoGroup.TabStop = false;
            genInfoGroup.Text = "Общая информация";
            // 
            // specificWeight
            // 
            specificWeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            specificWeight.Location = new Point(9, 114);
            specificWeight.Name = "specificWeight";
            specificWeight.PlaceholderText = "Удельный вес";
            specificWeight.Size = new Size(291, 25);
            specificWeight.TabIndex = 35;
            specificWeight.KeyPress += DeleteSpace_KeyPress;
            specificWeight.Validating += specificWeight_Validating;
            // 
            // volumeInjection
            // 
            volumeInjection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            volumeInjection.Location = new Point(9, 55);
            volumeInjection.Name = "volumeInjection";
            volumeInjection.PlaceholderText = "Объём закачки";
            volumeInjection.Size = new Size(291, 25);
            volumeInjection.TabIndex = 34;
            volumeInjection.KeyPress += DeleteSpace_KeyPress;
            volumeInjection.Validating += volumeInjection_Validating;
            // 
            // volume
            // 
            volume.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            volume.Location = new Point(9, 26);
            volume.Name = "volume";
            volume.PlaceholderText = "Объём";
            volume.Size = new Size(291, 25);
            volume.TabIndex = 33;
            volume.KeyPress += DeleteSpace_KeyPress;
            volume.Validating += volume_Validating;
            // 
            // formMenu
            // 
            formMenu.Items.AddRange(new ToolStripItem[] { formMenuChart, formMenuForm });
            formMenu.Location = new Point(0, 0);
            formMenu.Name = "formMenu";
            formMenu.Size = new Size(964, 24);
            formMenu.TabIndex = 35;
            formMenu.Text = "menuStrip1";
            // 
            // formMenuChart
            // 
            formMenuChart.DropDownItems.AddRange(new ToolStripItem[] { formMenuChartCreate, formMenuChartSaveJpg, formMenuChartSavePng, formMenuChartSaveBmp });
            formMenuChart.Name = "formMenuChart";
            formMenuChart.Size = new Size(60, 20);
            formMenuChart.Text = "График";
            // 
            // formMenuChartCreate
            // 
            formMenuChartCreate.Name = "formMenuChartCreate";
            formMenuChartCreate.Size = new Size(215, 22);
            formMenuChartCreate.Text = "Создать график";
            formMenuChartCreate.Click += formMenuChartCreate_Click;
            // 
            // formMenuChartSaveJpg
            // 
            formMenuChartSaveJpg.Enabled = false;
            formMenuChartSaveJpg.Name = "formMenuChartSaveJpg";
            formMenuChartSaveJpg.Size = new Size(215, 22);
            formMenuChartSaveJpg.Text = "Сохранить график (.jpg)";
            formMenuChartSaveJpg.Click += formMenuChartSaveJpg_Click;
            // 
            // formMenuChartSavePng
            // 
            formMenuChartSavePng.Enabled = false;
            formMenuChartSavePng.Name = "formMenuChartSavePng";
            formMenuChartSavePng.Size = new Size(215, 22);
            formMenuChartSavePng.Text = "Сохранить график (.png)";
            formMenuChartSavePng.Click += formMenuChartSavePng_Click;
            // 
            // formMenuChartSaveBmp
            // 
            formMenuChartSaveBmp.Enabled = false;
            formMenuChartSaveBmp.Name = "formMenuChartSaveBmp";
            formMenuChartSaveBmp.Size = new Size(215, 22);
            formMenuChartSaveBmp.Text = "Сохранить график (.bmp)";
            formMenuChartSaveBmp.Click += formMenuChartSaveBmp_Click;
            // 
            // formMenuForm
            // 
            formMenuForm.DropDownItems.AddRange(new ToolStripItem[] { formMenuFormDropState });
            formMenuForm.Name = "formMenuForm";
            formMenuForm.Size = new Size(57, 20);
            formMenuForm.Text = "Форма";
            // 
            // formMenuFormDropState
            // 
            formMenuFormDropState.Enabled = false;
            formMenuFormDropState.Name = "formMenuFormDropState";
            formMenuFormDropState.Size = new Size(187, 22);
            formMenuFormDropState.Text = "Сбросить состояние";
            formMenuFormDropState.Click += formMenuFormDropState_Click;
            // 
            // gridTopPanel
            // 
            gridTopPanel.ColumnCount = 3;
            gridTopPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            gridTopPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            gridTopPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            gridTopPanel.Controls.Add(genInfoGroup, 2, 0);
            gridTopPanel.Controls.Add(timeGroup, 0, 0);
            gridTopPanel.Controls.Add(pGroup, 1, 0);
            gridTopPanel.Dock = DockStyle.Top;
            gridTopPanel.Location = new Point(0, 24);
            gridTopPanel.Name = "gridTopPanel";
            gridTopPanel.RowCount = 1;
            gridTopPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            gridTopPanel.Size = new Size(964, 151);
            gridTopPanel.TabIndex = 36;
            // 
            // chartName
            // 
            chartName.AutoSize = true;
            chartName.CausesValidation = false;
            chartName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            chartName.Location = new Point(93, 9);
            chartName.Name = "chartName";
            chartName.Size = new Size(0, 21);
            chartName.TabIndex = 26;
            // 
            // chartDate
            // 
            chartDate.AutoSize = true;
            chartDate.CausesValidation = false;
            chartDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            chartDate.Location = new Point(93, 30);
            chartDate.Name = "chartDate";
            chartDate.Size = new Size(0, 21);
            chartDate.TabIndex = 27;
            // 
            // chartVolume
            // 
            chartVolume.AutoSize = true;
            chartVolume.CausesValidation = false;
            chartVolume.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            chartVolume.Location = new Point(93, 51);
            chartVolume.Name = "chartVolume";
            chartVolume.Size = new Size(0, 21);
            chartVolume.TabIndex = 28;
            // 
            // chart
            // 
            chart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chart.CausesValidation = false;
            chart.Location = new Point(9, 72);
            chart.Margin = new Padding(0);
            chart.Name = "chart";
            chart.Size = new Size(924, 441);
            chart.TabIndex = 1;
            // 
            // chartGroup
            // 
            chartGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartGroup.BackColor = SystemColors.Window;
            chartGroup.CausesValidation = false;
            chartGroup.Controls.Add(chartName);
            chartGroup.Controls.Add(chartDate);
            chartGroup.Controls.Add(chartVolume);
            chartGroup.Controls.Add(chart);
            chartGroup.Location = new Point(12, 189);
            chartGroup.Name = "chartGroup";
            chartGroup.Size = new Size(940, 520);
            chartGroup.TabIndex = 37;
            // 
            // validateProvider
            // 
            validateProvider.BlinkRate = 0;
            validateProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            validateProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(964, 721);
            Controls.Add(chartGroup);
            Controls.Add(gridTopPanel);
            Controls.Add(formMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(980, 600);
            Name = "MainForm";
            Text = "Визуализация данных";
            FormClosing += MainForm_FormClosing;
            pGroup.ResumeLayout(false);
            pGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeCount).EndInit();
            timeGroup.ResumeLayout(false);
            timeGroup.PerformLayout();
            genInfoGroup.ResumeLayout(false);
            genInfoGroup.PerformLayout();
            formMenu.ResumeLayout(false);
            formMenu.PerformLayout();
            gridTopPanel.ResumeLayout(false);
            chartGroup.ResumeLayout(false);
            chartGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)validateProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker timeEnd;
        private Label label2;
        private GroupBox pGroup;
        private DateTimePicker timeBegin;
        private Label timeBeginLabel;
        private Label timeEndLabel;
        private TextBox name;
        private NumericUpDown timeCount;
        private GroupBox timeGroup;
        private Label timeCountLabel;
        private GroupBox genInfoGroup;
        private MenuStrip formMenu;
        private ToolStripMenuItem formMenuChart;
        private ToolStripMenuItem formMenuChartCreate;
        private ToolStripMenuItem formMenuChartSaveJpg;
        private ToolStripMenuItem formMenuChartSavePng;
        private ToolStripMenuItem formMenuChartSaveBmp;
        private ToolStripMenuItem formMenuForm;
        private ToolStripMenuItem formMenuFormDropState;
        private TableLayoutPanel gridTopPanel;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chart;
        private Label chartVolume;
        private Label chartDate;
        private Label chartName;
        private Panel chartGroup;
        private ErrorProvider validateProvider;
        private TextBox volumeInjection;
        private TextBox volume;
        private TextBox specificWeight;
        private TextBox pEnd;
        private TextBox pMiddle;
        private TextBox pBegin;
    }
}
