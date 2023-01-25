namespace Traffic
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
            this.create = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Next = new System.Windows.Forms.Button();
            this.state_timer = new System.Windows.Forms.Timer(this.components);
            this.mode0 = new System.Windows.Forms.RadioButton();
            this.mode1 = new System.Windows.Forms.RadioButton();
            this.mode2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(713, 30);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 0;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.Create_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 426);
            this.panel1.TabIndex = 4;
            // 
            // Next
            // 
            this.Next.Enabled = false;
            this.Next.Location = new System.Drawing.Point(713, 73);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 5;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // state_timer
            // 
            this.state_timer.Interval = 500;
            this.state_timer.Tick += new System.EventHandler(this.state_timer_Tick);
            // 
            // mode0
            // 
            this.mode0.AutoSize = true;
            this.mode0.Enabled = false;
            this.mode0.Location = new System.Drawing.Point(704, 113);
            this.mode0.Name = "mode0";
            this.mode0.Size = new System.Drawing.Size(73, 20);
            this.mode0.TabIndex = 6;
            this.mode0.TabStop = true;
            this.mode0.Text = "mode 0";
            this.mode0.UseVisualStyleBackColor = true;
            this.mode0.CheckedChanged += new System.EventHandler(this.mode0_CheckedChanged);
            // 
            // mode1
            // 
            this.mode1.AutoSize = true;
            this.mode1.Enabled = false;
            this.mode1.Location = new System.Drawing.Point(704, 139);
            this.mode1.Name = "mode1";
            this.mode1.Size = new System.Drawing.Size(73, 20);
            this.mode1.TabIndex = 7;
            this.mode1.TabStop = true;
            this.mode1.Text = "mode 1";
            this.mode1.UseVisualStyleBackColor = true;
            this.mode1.CheckedChanged += new System.EventHandler(this.mode1_CheckedChanged);
            // 
            // mode2
            // 
            this.mode2.AutoSize = true;
            this.mode2.Enabled = false;
            this.mode2.Location = new System.Drawing.Point(704, 165);
            this.mode2.Name = "mode2";
            this.mode2.Size = new System.Drawing.Size(73, 20);
            this.mode2.TabIndex = 8;
            this.mode2.TabStop = true;
            this.mode2.Text = "mode 2";
            this.mode2.UseVisualStyleBackColor = true;
            this.mode2.CheckedChanged += new System.EventHandler(this.mode2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.mode2);
            this.Controls.Add(this.mode1);
            this.Controls.Add(this.mode0);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.create);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Timer state_timer;
        private System.Windows.Forms.RadioButton mode0;
        private System.Windows.Forms.RadioButton mode1;
        private System.Windows.Forms.RadioButton mode2;
    }
}

