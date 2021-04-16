
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
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonMoveImage = new System.Windows.Forms.Button();
            this.buttonStretching = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownStretchingY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStretchingX = new System.Windows.Forms.NumericUpDown();
            this.buttonnCompression = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownCompressionY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCompressionX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngel = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonRotate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStretchingY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStretchingX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompressionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompressionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngel)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(728, 554);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(905, 12);
            this.numericUpDownX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(55, 22);
            this.numericUpDownX.TabIndex = 1;
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(905, 40);
            this.numericUpDownY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(55, 22);
            this.numericUpDownY.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(797, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Двигатся по X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(797, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Двигатся по Y";
            // 
            // buttonMoveImage
            // 
            this.buttonMoveImage.Location = new System.Drawing.Point(800, 68);
            this.buttonMoveImage.Name = "buttonMoveImage";
            this.buttonMoveImage.Size = new System.Drawing.Size(160, 49);
            this.buttonMoveImage.TabIndex = 5;
            this.buttonMoveImage.Text = "Двигать";
            this.buttonMoveImage.UseVisualStyleBackColor = true;
            this.buttonMoveImage.Click += new System.EventHandler(this.buttonMoveImage_Click);
            // 
            // buttonStretching
            // 
            this.buttonStretching.Location = new System.Drawing.Point(800, 184);
            this.buttonStretching.Name = "buttonStretching";
            this.buttonStretching.Size = new System.Drawing.Size(160, 49);
            this.buttonStretching.TabIndex = 10;
            this.buttonStretching.Text = "Растянуть";
            this.buttonStretching.UseVisualStyleBackColor = true;
            this.buttonStretching.Click += new System.EventHandler(this.buttonStretching_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(790, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Растянуть по Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(790, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Растянуть по X";
            // 
            // numericUpDownStretchingY
            // 
            this.numericUpDownStretchingY.Location = new System.Drawing.Point(905, 156);
            this.numericUpDownStretchingY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStretchingY.Name = "numericUpDownStretchingY";
            this.numericUpDownStretchingY.Size = new System.Drawing.Size(55, 22);
            this.numericUpDownStretchingY.TabIndex = 7;
            this.numericUpDownStretchingY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownStretchingX
            // 
            this.numericUpDownStretchingX.Location = new System.Drawing.Point(905, 128);
            this.numericUpDownStretchingX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStretchingX.Name = "numericUpDownStretchingX";
            this.numericUpDownStretchingX.Size = new System.Drawing.Size(55, 22);
            this.numericUpDownStretchingX.TabIndex = 6;
            this.numericUpDownStretchingX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonnCompression
            // 
            this.buttonnCompression.Location = new System.Drawing.Point(800, 300);
            this.buttonnCompression.Name = "buttonnCompression";
            this.buttonnCompression.Size = new System.Drawing.Size(160, 49);
            this.buttonnCompression.TabIndex = 15;
            this.buttonnCompression.Text = "Сжать";
            this.buttonnCompression.UseVisualStyleBackColor = true;
            this.buttonnCompression.Click += new System.EventHandler(this.buttonnCompression_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(818, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Сжать по Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(818, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Сжать по X";
            // 
            // numericUpDownCompressionY
            // 
            this.numericUpDownCompressionY.Location = new System.Drawing.Point(905, 272);
            this.numericUpDownCompressionY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCompressionY.Name = "numericUpDownCompressionY";
            this.numericUpDownCompressionY.Size = new System.Drawing.Size(55, 22);
            this.numericUpDownCompressionY.TabIndex = 12;
            this.numericUpDownCompressionY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownCompressionX
            // 
            this.numericUpDownCompressionX.Location = new System.Drawing.Point(905, 244);
            this.numericUpDownCompressionX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCompressionX.Name = "numericUpDownCompressionX";
            this.numericUpDownCompressionX.Size = new System.Drawing.Size(55, 22);
            this.numericUpDownCompressionX.TabIndex = 11;
            this.numericUpDownCompressionX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownAngel
            // 
            this.numericUpDownAngel.Location = new System.Drawing.Point(905, 355);
            this.numericUpDownAngel.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownAngel.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownAngel.Name = "numericUpDownAngel";
            this.numericUpDownAngel.Size = new System.Drawing.Size(55, 22);
            this.numericUpDownAngel.TabIndex = 16;
            this.numericUpDownAngel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(769, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Повернуть на угол";
            // 
            // buttonRotate
            // 
            this.buttonRotate.Location = new System.Drawing.Point(800, 383);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(160, 49);
            this.buttonRotate.TabIndex = 18;
            this.buttonRotate.Text = "Повернуть";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 578);
            this.Controls.Add(this.buttonRotate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownAngel);
            this.Controls.Add(this.buttonnCompression);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownCompressionY);
            this.Controls.Add(this.numericUpDownCompressionX);
            this.Controls.Add(this.buttonStretching);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownStretchingY);
            this.Controls.Add(this.numericUpDownStretchingX);
            this.Controls.Add(this.buttonMoveImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownY);
            this.Controls.Add(this.numericUpDownX);
            this.Controls.Add(this.mainPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStretchingY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStretchingX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompressionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompressionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonMoveImage;
        private System.Windows.Forms.Button buttonStretching;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownStretchingY;
        private System.Windows.Forms.NumericUpDown numericUpDownStretchingX;
        private System.Windows.Forms.Button buttonnCompression;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownCompressionY;
        private System.Windows.Forms.NumericUpDown numericUpDownCompressionX;
        private System.Windows.Forms.NumericUpDown numericUpDownAngel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonRotate;
    }
}

