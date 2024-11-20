namespace KegLandForms
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
            Button DoInit;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            FetchData = new Button();
            txtDaysBackInTime = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            checkBox1 = new CheckBox();
            HydrometerIdOgNavn = new Label();
            hydroMeters = new ComboBox();
            hydr = new Label();
            DoInit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // DoInit
            // 
            DoInit.Location = new Point(12, 24);
            DoInit.Name = "DoInit";
            DoInit.Size = new Size(88, 46);
            DoInit.TabIndex = 9;
            DoInit.Text = "init";
            DoInit.UseVisualStyleBackColor = true;
            DoInit.Click += DoInit_Click;
            // 
            // FetchData
            // 
            FetchData.Location = new Point(582, 93);
            FetchData.Margin = new Padding(4);
            FetchData.Name = "FetchData";
            FetchData.Size = new Size(146, 44);
            FetchData.TabIndex = 0;
            FetchData.Text = "Fetch data";
            FetchData.UseVisualStyleBackColor = true;
            FetchData.Click += FetchData_Click;
            // 
            // txtDaysBackInTime
            // 
            txtDaysBackInTime.Location = new Point(320, 93);
            txtDaysBackInTime.Margin = new Padding(4);
            txtDaysBackInTime.Name = "txtDaysBackInTime";
            txtDaysBackInTime.Size = new Size(194, 39);
            txtDaysBackInTime.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 93);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(203, 32);
            label1.TabIndex = 2;
            label1.Text = "Days back in time";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 461);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1650, 640);
            dataGridView1.TabIndex = 3;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(826, 58);
            chart1.Margin = new Padding(4);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(809, 396);
            chart1.TabIndex = 4;
            chart1.Text = "ChartTelemetry";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(235, 173);
            checkBox1.Margin = new Padding(4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(510, 36);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Save a excel compatible text file to C:\\temp";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // HydrometerIdOgNavn
            // 
            HydrometerIdOgNavn.AutoSize = true;
            HydrometerIdOgNavn.Location = new Point(826, 12);
            HydrometerIdOgNavn.Margin = new Padding(4, 0, 4, 0);
            HydrometerIdOgNavn.Name = "HydrometerIdOgNavn";
            HydrometerIdOgNavn.Size = new Size(142, 32);
            HydrometerIdOgNavn.TabIndex = 6;
            HydrometerIdOgNavn.Text = "Hydrometer";
            // 
            // hydroMeters
            // 
            hydroMeters.DropDownStyle = ComboBoxStyle.DropDownList;
            hydroMeters.FormattingEnabled = true;
            hydroMeters.Location = new Point(319, 28);
            hydroMeters.Name = "hydroMeters";
            hydroMeters.Size = new Size(409, 40);
            hydroMeters.TabIndex = 7;
            // 
            // hydr
            // 
            hydr.AutoSize = true;
            hydr.Location = new Point(157, 36);
            hydr.Name = "hydr";
            hydr.Size = new Size(142, 32);
            hydr.TabIndex = 8;
            hydr.Text = "Hydrometer";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1650, 1101);
            Controls.Add(DoInit);
            Controls.Add(hydr);
            Controls.Add(hydroMeters);
            Controls.Add(HydrometerIdOgNavn);
            Controls.Add(checkBox1);
            Controls.Add(chart1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(txtDaysBackInTime);
            Controls.Add(FetchData);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button FetchData;
        private TextBox txtDaysBackInTime;
        private Label label1;
        private DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private CheckBox checkBox1;
        private Label HydrometerIdOgNavn;
        private ComboBox hydroMeters;
        private Label hydr;
    }
}
