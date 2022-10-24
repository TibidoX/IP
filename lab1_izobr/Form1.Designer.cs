namespace lab1_izobr
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoContrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.медианныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гауссаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.арифметическоеСреднееToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.геометрическоеСреднееToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.максимумаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бинаризацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точечнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.глобальнаяпоГистограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сравнениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSNRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шумToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.райлиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.нелокальногоСреднегоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гистограммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрыToolStripMenuItem,
            this.бинаризацияToolStripMenuItem,
            this.сравнениеToolStripMenuItem,
            this.шумToolStripMenuItem,
            this.гистограммаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1081, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayScaleToolStripMenuItem,
            this.averageToolStripMenuItem,
            this.autoContrastToolStripMenuItem,
            this.медианныйToolStripMenuItem,
            this.гауссаToolStripMenuItem,
            this.арифметическоеСреднееToolStripMenuItem,
            this.геометрическоеСреднееToolStripMenuItem,
            this.максимумаToolStripMenuItem,
            this.нелокальногоСреднегоToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.grayScaleToolStripMenuItem.Text = "GrayScale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.grayScaleToolStripMenuItem_Click);
            // 
            // averageToolStripMenuItem
            // 
            this.averageToolStripMenuItem.Name = "averageToolStripMenuItem";
            this.averageToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.averageToolStripMenuItem.Text = "Average";
            this.averageToolStripMenuItem.Click += new System.EventHandler(this.averageToolStripMenuItem_Click);
            // 
            // autoContrastToolStripMenuItem
            // 
            this.autoContrastToolStripMenuItem.Name = "autoContrastToolStripMenuItem";
            this.autoContrastToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.autoContrastToolStripMenuItem.Text = "AutoContrast";
            this.autoContrastToolStripMenuItem.Click += new System.EventHandler(this.autoContrastToolStripMenuItem_Click);
            // 
            // медианныйToolStripMenuItem
            // 
            this.медианныйToolStripMenuItem.Name = "медианныйToolStripMenuItem";
            this.медианныйToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.медианныйToolStripMenuItem.Text = "Медианный";
            this.медианныйToolStripMenuItem.Click += new System.EventHandler(this.медианныйToolStripMenuItem_Click);
            // 
            // гауссаToolStripMenuItem
            // 
            this.гауссаToolStripMenuItem.Name = "гауссаToolStripMenuItem";
            this.гауссаToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.гауссаToolStripMenuItem.Text = "Гаусса";
            this.гауссаToolStripMenuItem.Click += new System.EventHandler(this.гауссаToolStripMenuItem_Click);
            // 
            // арифметическоеСреднееToolStripMenuItem
            // 
            this.арифметическоеСреднееToolStripMenuItem.Name = "арифметическоеСреднееToolStripMenuItem";
            this.арифметическоеСреднееToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.арифметическоеСреднееToolStripMenuItem.Text = "Арифметическое среднее";
            this.арифметическоеСреднееToolStripMenuItem.Click += new System.EventHandler(this.арифметическоеСреднееToolStripMenuItem_Click);
            // 
            // геометрическоеСреднееToolStripMenuItem
            // 
            this.геометрическоеСреднееToolStripMenuItem.Name = "геометрическоеСреднееToolStripMenuItem";
            this.геометрическоеСреднееToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.геометрическоеСреднееToolStripMenuItem.Text = "Геометрическое среднее";
            this.геометрическоеСреднееToolStripMenuItem.Click += new System.EventHandler(this.геометрическоеСреднееToolStripMenuItem_Click);
            // 
            // максимумаToolStripMenuItem
            // 
            this.максимумаToolStripMenuItem.Name = "максимумаToolStripMenuItem";
            this.максимумаToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.максимумаToolStripMenuItem.Text = "Максимума";
            this.максимумаToolStripMenuItem.Click += new System.EventHandler(this.максимумаToolStripMenuItem_Click);
            // 
            // бинаризацияToolStripMenuItem
            // 
            this.бинаризацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.точечнаяToolStripMenuItem,
            this.глобальнаяпоГистограммеToolStripMenuItem});
            this.бинаризацияToolStripMenuItem.Name = "бинаризацияToolStripMenuItem";
            this.бинаризацияToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.бинаризацияToolStripMenuItem.Text = "Бинаризация";
            // 
            // точечнаяToolStripMenuItem
            // 
            this.точечнаяToolStripMenuItem.Name = "точечнаяToolStripMenuItem";
            this.точечнаяToolStripMenuItem.Size = new System.Drawing.Size(300, 26);
            this.точечнаяToolStripMenuItem.Text = "Точечная";
            this.точечнаяToolStripMenuItem.Click += new System.EventHandler(this.точечнаяToolStripMenuItem_Click);
            // 
            // глобальнаяпоГистограммеToolStripMenuItem
            // 
            this.глобальнаяпоГистограммеToolStripMenuItem.Name = "глобальнаяпоГистограммеToolStripMenuItem";
            this.глобальнаяпоГистограммеToolStripMenuItem.Size = new System.Drawing.Size(300, 26);
            this.глобальнаяпоГистограммеToolStripMenuItem.Text = "Глобальная (по гистограмме)";
            this.глобальнаяпоГистограммеToolStripMenuItem.Click += new System.EventHandler(this.глобальнаяпоГистограммеToolStripMenuItem_Click);
            // 
            // сравнениеToolStripMenuItem
            // 
            this.сравнениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pSNRToolStripMenuItem,
            this.sSIMToolStripMenuItem});
            this.сравнениеToolStripMenuItem.Name = "сравнениеToolStripMenuItem";
            this.сравнениеToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.сравнениеToolStripMenuItem.Text = "Сравнение";
            // 
            // pSNRToolStripMenuItem
            // 
            this.pSNRToolStripMenuItem.Name = "pSNRToolStripMenuItem";
            this.pSNRToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.pSNRToolStripMenuItem.Text = "PSNR";
            this.pSNRToolStripMenuItem.Click += new System.EventHandler(this.pSNRToolStripMenuItem_Click);
            // 
            // sSIMToolStripMenuItem
            // 
            this.sSIMToolStripMenuItem.Name = "sSIMToolStripMenuItem";
            this.sSIMToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.sSIMToolStripMenuItem.Text = "SSIM";
            this.sSIMToolStripMenuItem.Click += new System.EventHandler(this.sSIMToolStripMenuItem_Click);
            // 
            // шумToolStripMenuItem
            // 
            this.шумToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uniformToolStripMenuItem,
            this.райлиToolStripMenuItem});
            this.шумToolStripMenuItem.Name = "шумToolStripMenuItem";
            this.шумToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.шумToolStripMenuItem.Text = "Шум";
            // 
            // uniformToolStripMenuItem
            // 
            this.uniformToolStripMenuItem.Name = "uniformToolStripMenuItem";
            this.uniformToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.uniformToolStripMenuItem.Text = "Uniform";
            this.uniformToolStripMenuItem.Click += new System.EventHandler(this.uniformToolStripMenuItem_Click);
            // 
            // райлиToolStripMenuItem
            // 
            this.райлиToolStripMenuItem.Name = "райлиToolStripMenuItem";
            this.райлиToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.райлиToolStripMenuItem.Text = "Райли";
            this.райлиToolStripMenuItem.Click += new System.EventHandler(this.райлиToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1081, 482);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(210, 65);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // нелокальногоСреднегоToolStripMenuItem
            // 
            this.нелокальногоСреднегоToolStripMenuItem.Name = "нелокальногоСреднегоToolStripMenuItem";
            this.нелокальногоСреднегоToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.нелокальногоСреднегоToolStripMenuItem.Text = "Нелокального среднего";
            this.нелокальногоСреднегоToolStripMenuItem.Click += new System.EventHandler(this.нелокальногоСреднегоToolStripMenuItem_Click);
            // 
            // гистограммаToolStripMenuItem
            // 
            this.гистограммаToolStripMenuItem.Name = "гистограммаToolStripMenuItem";
            this.гистограммаToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.гистограммаToolStripMenuItem.Text = "Гистограмма";
            this.гистограммаToolStripMenuItem.Click += new System.EventHandler(this.гистограммаToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 510);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoContrastToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem бинаризацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem точечнаяToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolStripMenuItem глобальнаяпоГистограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem медианныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гауссаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сравнениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pSNRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSIMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шумToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uniformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem арифметическоеСреднееToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem геометрическоеСреднееToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem райлиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem максимумаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нелокальногоСреднегоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гистограммаToolStripMenuItem;
    }
}

