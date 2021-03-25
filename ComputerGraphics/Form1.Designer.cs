
namespace ComputerGraphics
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
            this.uxPictureBox = new System.Windows.Forms.PictureBox();
            this.IncreaseButton = new System.Windows.Forms.Button();
            this.ReduceButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.valueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // uxPictureBox
            // 
            this.uxPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uxPictureBox.Location = new System.Drawing.Point(408, 153);
            this.uxPictureBox.Name = "uxPictureBox";
            this.uxPictureBox.Size = new System.Drawing.Size(200, 200);
            this.uxPictureBox.TabIndex = 0;
            this.uxPictureBox.TabStop = false;
            this.uxPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uxPictureBox_MouseDown);
            this.uxPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uxPictureBox_MouseMove);
            // 
            // IncreaseButton
            // 
            this.IncreaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.IncreaseButton.Location = new System.Drawing.Point(842, 327);
            this.IncreaseButton.Name = "IncreaseButton";
            this.IncreaseButton.Size = new System.Drawing.Size(128, 54);
            this.IncreaseButton.TabIndex = 1;
            this.IncreaseButton.Text = "Увеличить";
            this.IncreaseButton.UseVisualStyleBackColor = true;
            this.IncreaseButton.Click += new System.EventHandler(this.IncreaseButton_Click);
            // 
            // ReduceButton
            // 
            this.ReduceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReduceButton.Location = new System.Drawing.Point(842, 387);
            this.ReduceButton.Name = "ReduceButton";
            this.ReduceButton.Size = new System.Drawing.Size(128, 54);
            this.ReduceButton.TabIndex = 2;
            this.ReduceButton.Text = "Уменьшить";
            this.ReduceButton.UseVisualStyleBackColor = true;
            this.ReduceButton.Click += new System.EventHandler(this.ReduceButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Яркий",
            "Нормальный"});
            this.listBox1.Location = new System.Drawing.Point(842, 257);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(128, 36);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // valueNumericUpDown
            // 
            this.valueNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.valueNumericUpDown.Location = new System.Drawing.Point(842, 299);
            this.valueNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.valueNumericUpDown.Name = "valueNumericUpDown";
            this.valueNumericUpDown.Size = new System.Drawing.Size(128, 22);
            this.valueNumericUpDown.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.valueNumericUpDown);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ReduceButton);
            this.Controls.Add(this.IncreaseButton);
            this.Controls.Add(this.uxPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox uxPictureBox;
        private System.Windows.Forms.Button IncreaseButton;
        private System.Windows.Forms.Button ReduceButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown valueNumericUpDown;
    }
}

