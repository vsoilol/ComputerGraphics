
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.gradient = new System.Windows.Forms.CheckBox();
            this.simpleColor = new System.Windows.Forms.CheckBox();
            this.numberColor = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(29, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 332);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(590, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 74);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "4 Стрелки",
            "Произвольная фигура",
            "Прямоугольник",
            "Параллелограмм",
            "Перевернутая трапеция",
            "Равнобедренный треугольник",
            "3 Стрелки",
            "Шестиугольник"});
            this.listBox1.Location = new System.Drawing.Point(521, 98);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 148);
            this.listBox1.TabIndex = 2;
            // 
            // gradient
            // 
            this.gradient.AutoSize = true;
            this.gradient.Location = new System.Drawing.Point(521, 32);
            this.gradient.Name = "gradient";
            this.gradient.Size = new System.Drawing.Size(93, 21);
            this.gradient.TabIndex = 4;
            this.gradient.Text = "Градиент";
            this.gradient.UseVisualStyleBackColor = true;
            // 
            // simpleColor
            // 
            this.simpleColor.AutoSize = true;
            this.simpleColor.Location = new System.Drawing.Point(521, 60);
            this.simpleColor.Name = "simpleColor";
            this.simpleColor.Size = new System.Drawing.Size(127, 21);
            this.simpleColor.TabIndex = 5;
            this.simpleColor.Text = "Обычный цвет";
            this.simpleColor.UseVisualStyleBackColor = true;
            // 
            // numberColor
            // 
            this.numberColor.Location = new System.Drawing.Point(683, 43);
            this.numberColor.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numberColor.Name = "numberColor";
            this.numberColor.Size = new System.Drawing.Size(78, 22);
            this.numberColor.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numberColor);
            this.Controls.Add(this.simpleColor);
            this.Controls.Add(this.gradient);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox gradient;
        private System.Windows.Forms.CheckBox simpleColor;
        private System.Windows.Forms.NumericUpDown numberColor;
    }
}

