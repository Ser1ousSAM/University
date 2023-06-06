namespace Ending_Task
{
    partial class Form1
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
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.selectorFile = new System.Windows.Forms.ComboBox();
            this.textBoxInputSurname = new System.Windows.Forms.TextBox();
            this.buttonFileOutput = new System.Windows.Forms.Button();
            this.buttonFindPassanger = new System.Windows.Forms.Button();
            this.textBoxFileOutput = new System.Windows.Forms.TextBox();
            this.textBoxInputCountItems = new System.Windows.Forms.TextBox();
            this.textBoxInputWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxOverWeight = new System.Windows.Forms.TextBox();
            this.textBoxRequestOutput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selectorRequest = new System.Windows.Forms.ComboBox();
            this.textBoxFindOnSurname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFindOnFirstLetter = new System.Windows.Forms.TextBox();
            this.buttonBuildGisto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddFile.Location = new System.Drawing.Point(379, 12);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(145, 100);
            this.buttonAddFile.TabIndex = 0;
            this.buttonAddFile.Text = "Добавить в файл f";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // selectorFile
            // 
            this.selectorFile.FormattingEnabled = true;
            this.selectorFile.Items.AddRange(new object[] {
            "fileF.txt",
            "fileG.txt"});
            this.selectorFile.Location = new System.Drawing.Point(530, 12);
            this.selectorFile.Name = "selectorFile";
            this.selectorFile.Size = new System.Drawing.Size(155, 24);
            this.selectorFile.TabIndex = 1;
            // 
            // textBoxInputSurname
            // 
            this.textBoxInputSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInputSurname.Location = new System.Drawing.Point(7, 57);
            this.textBoxInputSurname.Multiline = true;
            this.textBoxInputSurname.Name = "textBoxInputSurname";
            this.textBoxInputSurname.Size = new System.Drawing.Size(118, 55);
            this.textBoxInputSurname.TabIndex = 2;
            // 
            // buttonFileOutput
            // 
            this.buttonFileOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFileOutput.Location = new System.Drawing.Point(530, 42);
            this.buttonFileOutput.Name = "buttonFileOutput";
            this.buttonFileOutput.Size = new System.Drawing.Size(155, 70);
            this.buttonFileOutput.TabIndex = 3;
            this.buttonFileOutput.Text = "Выгрузить файл";
            this.buttonFileOutput.UseVisualStyleBackColor = true;
            this.buttonFileOutput.Click += new System.EventHandler(this.buttonFileOutput_Click);
            // 
            // buttonFindPassanger
            // 
            this.buttonFindPassanger.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFindPassanger.Location = new System.Drawing.Point(10, 400);
            this.buttonFindPassanger.Name = "buttonFindPassanger";
            this.buttonFindPassanger.Size = new System.Drawing.Size(333, 74);
            this.buttonFindPassanger.TabIndex = 4;
            this.buttonFindPassanger.Text = "Найти";
            this.buttonFindPassanger.UseVisualStyleBackColor = true;
            this.buttonFindPassanger.Click += new System.EventHandler(this.buttonFindPassanger_Click);
            // 
            // textBoxFileOutput
            // 
            this.textBoxFileOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFileOutput.Location = new System.Drawing.Point(893, 12);
            this.textBoxFileOutput.Multiline = true;
            this.textBoxFileOutput.Name = "textBoxFileOutput";
            this.textBoxFileOutput.ReadOnly = true;
            this.textBoxFileOutput.Size = new System.Drawing.Size(482, 652);
            this.textBoxFileOutput.TabIndex = 5;
            // 
            // textBoxInputCountItems
            // 
            this.textBoxInputCountItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInputCountItems.Location = new System.Drawing.Point(131, 57);
            this.textBoxInputCountItems.Multiline = true;
            this.textBoxInputCountItems.Name = "textBoxInputCountItems";
            this.textBoxInputCountItems.Size = new System.Drawing.Size(118, 55);
            this.textBoxInputCountItems.TabIndex = 2;
            // 
            // textBoxInputWeight
            // 
            this.textBoxInputWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInputWeight.Location = new System.Drawing.Point(255, 57);
            this.textBoxInputWeight.Multiline = true;
            this.textBoxInputWeight.Name = "textBoxInputWeight";
            this.textBoxInputWeight.Size = new System.Drawing.Size(118, 55);
            this.textBoxInputWeight.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(126, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 50);
            this.label2.TabIndex = 7;
            this.label2.Text = "Количество \r\nпредметов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(260, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Вес груза";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1381, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 100);
            this.label4.TabIndex = 9;
            this.label4.Text = "Количество\r\nпассажиров\r\nс перевесом\r\nбагажа";
            // 
            // textBoxOverWeight
            // 
            this.textBoxOverWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOverWeight.Location = new System.Drawing.Point(1386, 120);
            this.textBoxOverWeight.Multiline = true;
            this.textBoxOverWeight.Name = "textBoxOverWeight";
            this.textBoxOverWeight.ReadOnly = true;
            this.textBoxOverWeight.Size = new System.Drawing.Size(125, 65);
            this.textBoxOverWeight.TabIndex = 10;
            // 
            // textBoxRequestOutput
            // 
            this.textBoxRequestOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRequestOutput.Location = new System.Drawing.Point(377, 126);
            this.textBoxRequestOutput.Multiline = true;
            this.textBoxRequestOutput.Name = "textBoxRequestOutput";
            this.textBoxRequestOutput.ReadOnly = true;
            this.textBoxRequestOutput.Size = new System.Drawing.Size(510, 535);
            this.textBoxRequestOutput.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(-3, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(346, 75);
            this.label5.TabIndex = 12;
            this.label5.Text = "Номера запросов:\r\n1) Найти по фамилии;\r\n2) Найти по первой букве фамилии.";
            // 
            // selectorRequest
            // 
            this.selectorRequest.FormattingEnabled = true;
            this.selectorRequest.Items.AddRange(new object[] {
            "1",
            "2"});
            this.selectorRequest.Location = new System.Drawing.Point(12, 221);
            this.selectorRequest.Name = "selectorRequest";
            this.selectorRequest.Size = new System.Drawing.Size(140, 24);
            this.selectorRequest.TabIndex = 13;
            this.selectorRequest.SelectedIndexChanged += new System.EventHandler(this.selectorRequest_SelectedIndexChanged);
            // 
            // textBoxFindOnSurname
            // 
            this.textBoxFindOnSurname.Enabled = false;
            this.textBoxFindOnSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFindOnSurname.Location = new System.Drawing.Point(41, 290);
            this.textBoxFindOnSurname.Multiline = true;
            this.textBoxFindOnSurname.Name = "textBoxFindOnSurname";
            this.textBoxFindOnSurname.Size = new System.Drawing.Size(302, 34);
            this.textBoxFindOnSurname.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(5, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "1)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(5, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "2)";
            // 
            // textBoxFindOnFirstLetter
            // 
            this.textBoxFindOnFirstLetter.Enabled = false;
            this.textBoxFindOnFirstLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFindOnFirstLetter.Location = new System.Drawing.Point(41, 350);
            this.textBoxFindOnFirstLetter.MaxLength = 2;
            this.textBoxFindOnFirstLetter.Multiline = true;
            this.textBoxFindOnFirstLetter.Name = "textBoxFindOnFirstLetter";
            this.textBoxFindOnFirstLetter.Size = new System.Drawing.Size(41, 34);
            this.textBoxFindOnFirstLetter.TabIndex = 16;
            this.textBoxFindOnFirstLetter.TextChanged += new System.EventHandler(this.textBoxFindOnFirstLetter_TextChanged);
            // 
            // buttonBuildGisto
            // 
            this.buttonBuildGisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBuildGisto.Location = new System.Drawing.Point(12, 558);
            this.buttonBuildGisto.Name = "buttonBuildGisto";
            this.buttonBuildGisto.Size = new System.Drawing.Size(333, 104);
            this.buttonBuildGisto.TabIndex = 18;
            this.buttonBuildGisto.Text = "Построить Гистограмму";
            this.buttonBuildGisto.UseVisualStyleBackColor = true;
            this.buttonBuildGisto.Click += new System.EventHandler(this.buttonBuildGisto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 954);
            this.Controls.Add(this.buttonBuildGisto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxFindOnFirstLetter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxFindOnSurname);
            this.Controls.Add(this.selectorRequest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxRequestOutput);
            this.Controls.Add(this.textBoxOverWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxInputWeight);
            this.Controls.Add(this.textBoxFileOutput);
            this.Controls.Add(this.buttonFindPassanger);
            this.Controls.Add(this.buttonFileOutput);
            this.Controls.Add(this.textBoxInputCountItems);
            this.Controls.Add(this.textBoxInputSurname);
            this.Controls.Add(this.selectorFile);
            this.Controls.Add(this.buttonAddFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.ComboBox selectorFile;
        private System.Windows.Forms.TextBox textBoxInputSurname;
        private System.Windows.Forms.Button buttonFileOutput;
        private System.Windows.Forms.Button buttonFindPassanger;
        private System.Windows.Forms.TextBox textBoxFileOutput;
        private System.Windows.Forms.TextBox textBoxInputCountItems;
        private System.Windows.Forms.TextBox textBoxInputWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxOverWeight;
        private System.Windows.Forms.TextBox textBoxRequestOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox selectorRequest;
        private System.Windows.Forms.TextBox textBoxFindOnSurname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxFindOnFirstLetter;
        private System.Windows.Forms.Button buttonBuildGisto;
    }
}

