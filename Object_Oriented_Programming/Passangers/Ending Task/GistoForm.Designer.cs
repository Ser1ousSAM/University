namespace Ending_Task
{
    partial class GistoForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartOfPassangerItems = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartOfPassangerItems)).BeginInit();
            this.SuspendLayout();
            // 
            // chartOfPassangerItems
            // 
            chartArea1.Name = "ChartArea1";
            this.chartOfPassangerItems.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartOfPassangerItems.Legends.Add(legend1);
            this.chartOfPassangerItems.Location = new System.Drawing.Point(337, -4);
            this.chartOfPassangerItems.Name = "chartOfPassangerItems";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Items";
            this.chartOfPassangerItems.Series.Add(series1);
            this.chartOfPassangerItems.Size = new System.Drawing.Size(849, 612);
            this.chartOfPassangerItems.TabIndex = 0;
            this.chartOfPassangerItems.Text = "chart1";
            title1.Name = "Items";
            title1.Text = "Passangers\' items";
            this.chartOfPassangerItems.Titles.Add(title1);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(27, 204);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(265, 180);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Работа с файлами";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // GistoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 662);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.chartOfPassangerItems);
            this.Name = "GistoForm";
            this.Text = "GistoForm";
            this.Load += new System.EventHandler(this.GistoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartOfPassangerItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartOfPassangerItems;
        private System.Windows.Forms.Button buttonBack;
    }
}