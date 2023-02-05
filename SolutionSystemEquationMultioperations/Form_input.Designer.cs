namespace SolutionSystemEquationMultioperations
{
    partial class Form_Input
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
            this.textBox_Equation = new System.Windows.Forms.TextBox();
            this.label_leftSideEquation = new System.Windows.Forms.Label();
            this.label_resultEquation = new System.Windows.Forms.Label();
            this.textBox_resualEquation = new System.Windows.Forms.TextBox();
            this.button_getResualtEquation = new System.Windows.Forms.Button();
            this.label_multiopearions = new System.Windows.Forms.Label();
            this.textBox_Multioperations = new System.Windows.Forms.TextBox();
            this.textBox_coefficients = new System.Windows.Forms.TextBox();
            this.label_coefficients = new System.Windows.Forms.Label();
            this.textBox_unknows = new System.Windows.Forms.TextBox();
            this.label_unknows = new System.Windows.Forms.Label();
            this.label_conditions = new System.Windows.Forms.Label();
            this.textBox_conditions = new System.Windows.Forms.TextBox();
            this.groupBox_Equation = new System.Windows.Forms.GroupBox();
            this.groupBox_saveData = new System.Windows.Forms.GroupBox();
            this.button_saveData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nameFileSave = new System.Windows.Forms.TextBox();
            this.groupBox_uploadData = new System.Windows.Forms.GroupBox();
            this.label_nameFileUpload = new System.Windows.Forms.Label();
            this.textBox_nameFileUpload = new System.Windows.Forms.TextBox();
            this.button_uploadData = new System.Windows.Forms.Button();
            this.Rang = new System.Windows.Forms.Label();
            this.textBox_Rang = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox_format = new System.Windows.Forms.GroupBox();
            this.radioButton_horizontalFormat = new System.Windows.Forms.RadioButton();
            this.radioButton_verticalFormat = new System.Windows.Forms.RadioButton();
            this.button_longInstruction = new System.Windows.Forms.Button();
            this.groupBox_Equation.SuspendLayout();
            this.groupBox_saveData.SuspendLayout();
            this.groupBox_uploadData.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_format.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Equation
            // 
            this.textBox_Equation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Equation.Location = new System.Drawing.Point(6, 55);
            this.textBox_Equation.Multiline = true;
            this.textBox_Equation.Name = "textBox_Equation";
            this.textBox_Equation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Equation.Size = new System.Drawing.Size(536, 168);
            this.textBox_Equation.TabIndex = 1;
            this.textBox_Equation.Text = "g(h(z,c),s(c))<g(c,z)";
            this.textBox_Equation.WordWrap = false;
            // 
            // label_leftSideEquation
            // 
            this.label_leftSideEquation.AutoSize = true;
            this.label_leftSideEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_leftSideEquation.Location = new System.Drawing.Point(6, 27);
            this.label_leftSideEquation.Name = "label_leftSideEquation";
            this.label_leftSideEquation.Size = new System.Drawing.Size(120, 25);
            this.label_leftSideEquation.TabIndex = 3;
            this.label_leftSideEquation.Text = "Уравнение";
            // 
            // label_resultEquation
            // 
            this.label_resultEquation.AutoSize = true;
            this.label_resultEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_resultEquation.Location = new System.Drawing.Point(7, 27);
            this.label_resultEquation.Name = "label_resultEquation";
            this.label_resultEquation.Size = new System.Drawing.Size(115, 25);
            this.label_resultEquation.TabIndex = 4;
            this.label_resultEquation.Text = "Результат";
            // 
            // textBox_resualEquation
            // 
            this.textBox_resualEquation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_resualEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_resualEquation.Location = new System.Drawing.Point(6, 55);
            this.textBox_resualEquation.Multiline = true;
            this.textBox_resualEquation.Name = "textBox_resualEquation";
            this.textBox_resualEquation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_resualEquation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_resualEquation.Size = new System.Drawing.Size(533, 391);
            this.textBox_resualEquation.TabIndex = 5;
            this.textBox_resualEquation.WordWrap = false;
            // 
            // button_getResualtEquation
            // 
            this.button_getResualtEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_getResualtEquation.Location = new System.Drawing.Point(6, 524);
            this.button_getResualtEquation.Name = "button_getResualtEquation";
            this.button_getResualtEquation.Size = new System.Drawing.Size(257, 42);
            this.button_getResualtEquation.TabIndex = 6;
            this.button_getResualtEquation.Text = "Решение";
            this.button_getResualtEquation.UseVisualStyleBackColor = true;
            this.button_getResualtEquation.Click += new System.EventHandler(this.Button_getResualtEquation_Click);
            // 
            // label_multiopearions
            // 
            this.label_multiopearions.AutoSize = true;
            this.label_multiopearions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_multiopearions.Location = new System.Drawing.Point(6, 225);
            this.label_multiopearions.Name = "label_multiopearions";
            this.label_multiopearions.Size = new System.Drawing.Size(182, 25);
            this.label_multiopearions.TabIndex = 7;
            this.label_multiopearions.Text = "Мультиоперации";
            // 
            // textBox_Multioperations
            // 
            this.textBox_Multioperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Multioperations.Location = new System.Drawing.Point(6, 253);
            this.textBox_Multioperations.Multiline = true;
            this.textBox_Multioperations.Name = "textBox_Multioperations";
            this.textBox_Multioperations.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Multioperations.Size = new System.Drawing.Size(536, 161);
            this.textBox_Multioperations.TabIndex = 8;
            this.textBox_Multioperations.Text = "h=1332\r\ns=21\r\ng=1002";
            this.textBox_Multioperations.WordWrap = false;
            // 
            // textBox_coefficients
            // 
            this.textBox_coefficients.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_coefficients.Location = new System.Drawing.Point(556, 125);
            this.textBox_coefficients.Name = "textBox_coefficients";
            this.textBox_coefficients.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_coefficients.Size = new System.Drawing.Size(163, 31);
            this.textBox_coefficients.TabIndex = 9;
            this.textBox_coefficients.Text = "c";
            // 
            // label_coefficients
            // 
            this.label_coefficients.AutoSize = true;
            this.label_coefficients.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_coefficients.Location = new System.Drawing.Point(556, 97);
            this.label_coefficients.Name = "label_coefficients";
            this.label_coefficients.Size = new System.Drawing.Size(168, 25);
            this.label_coefficients.TabIndex = 10;
            this.label_coefficients.Text = "Коэффициенты";
            // 
            // textBox_unknows
            // 
            this.textBox_unknows.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_unknows.Location = new System.Drawing.Point(556, 192);
            this.textBox_unknows.Name = "textBox_unknows";
            this.textBox_unknows.Size = new System.Drawing.Size(163, 31);
            this.textBox_unknows.TabIndex = 11;
            this.textBox_unknows.Text = "z";
            // 
            // label_unknows
            // 
            this.label_unknows.AutoSize = true;
            this.label_unknows.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_unknows.Location = new System.Drawing.Point(556, 164);
            this.label_unknows.Name = "label_unknows";
            this.label_unknows.Size = new System.Drawing.Size(145, 25);
            this.label_unknows.TabIndex = 12;
            this.label_unknows.Text = "Неизвестные";
            // 
            // label_conditions
            // 
            this.label_conditions.AutoSize = true;
            this.label_conditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_conditions.Location = new System.Drawing.Point(556, 226);
            this.label_conditions.Name = "label_conditions";
            this.label_conditions.Size = new System.Drawing.Size(94, 25);
            this.label_conditions.TabIndex = 14;
            this.label_conditions.Text = "Условия";
            // 
            // textBox_conditions
            // 
            this.textBox_conditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_conditions.Location = new System.Drawing.Point(556, 253);
            this.textBox_conditions.Multiline = true;
            this.textBox_conditions.Name = "textBox_conditions";
            this.textBox_conditions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_conditions.Size = new System.Drawing.Size(168, 161);
            this.textBox_conditions.TabIndex = 13;
            this.textBox_conditions.Text = "!=|c_1,c_2";
            this.textBox_conditions.WordWrap = false;
            // 
            // groupBox_Equation
            // 
            this.groupBox_Equation.Controls.Add(this.groupBox_saveData);
            this.groupBox_Equation.Controls.Add(this.groupBox_uploadData);
            this.groupBox_Equation.Controls.Add(this.Rang);
            this.groupBox_Equation.Controls.Add(this.textBox_Rang);
            this.groupBox_Equation.Controls.Add(this.textBox_Equation);
            this.groupBox_Equation.Controls.Add(this.label_leftSideEquation);
            this.groupBox_Equation.Controls.Add(this.label_multiopearions);
            this.groupBox_Equation.Controls.Add(this.label_conditions);
            this.groupBox_Equation.Controls.Add(this.textBox_conditions);
            this.groupBox_Equation.Controls.Add(this.textBox_Multioperations);
            this.groupBox_Equation.Controls.Add(this.label_coefficients);
            this.groupBox_Equation.Controls.Add(this.textBox_unknows);
            this.groupBox_Equation.Controls.Add(this.label_unknows);
            this.groupBox_Equation.Controls.Add(this.textBox_coefficients);
            this.groupBox_Equation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Equation.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Equation.Name = "groupBox_Equation";
            this.groupBox_Equation.Size = new System.Drawing.Size(732, 581);
            this.groupBox_Equation.TabIndex = 17;
            this.groupBox_Equation.TabStop = false;
            this.groupBox_Equation.Text = "Входные параметры";
            // 
            // groupBox_saveData
            // 
            this.groupBox_saveData.Controls.Add(this.button_saveData);
            this.groupBox_saveData.Controls.Add(this.label1);
            this.groupBox_saveData.Controls.Add(this.textBox_nameFileSave);
            this.groupBox_saveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_saveData.Location = new System.Drawing.Point(371, 420);
            this.groupBox_saveData.Name = "groupBox_saveData";
            this.groupBox_saveData.Size = new System.Drawing.Size(355, 152);
            this.groupBox_saveData.TabIndex = 22;
            this.groupBox_saveData.TabStop = false;
            this.groupBox_saveData.Text = "Сохранение данных";
            // 
            // button_saveData
            // 
            this.button_saveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_saveData.Location = new System.Drawing.Point(11, 104);
            this.button_saveData.Name = "button_saveData";
            this.button_saveData.Size = new System.Drawing.Size(337, 42);
            this.button_saveData.TabIndex = 20;
            this.button_saveData.Text = "Сохранить данные в файл";
            this.button_saveData.UseVisualStyleBackColor = true;
            this.button_saveData.Click += new System.EventHandler(this.Button_saveData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Название файла";
            // 
            // textBox_nameFileSave
            // 
            this.textBox_nameFileSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_nameFileSave.Location = new System.Drawing.Point(11, 67);
            this.textBox_nameFileSave.Name = "textBox_nameFileSave";
            this.textBox_nameFileSave.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_nameFileSave.Size = new System.Drawing.Size(337, 31);
            this.textBox_nameFileSave.TabIndex = 17;
            // 
            // groupBox_uploadData
            // 
            this.groupBox_uploadData.Controls.Add(this.label_nameFileUpload);
            this.groupBox_uploadData.Controls.Add(this.textBox_nameFileUpload);
            this.groupBox_uploadData.Controls.Add(this.button_uploadData);
            this.groupBox_uploadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_uploadData.Location = new System.Drawing.Point(8, 420);
            this.groupBox_uploadData.Name = "groupBox_uploadData";
            this.groupBox_uploadData.Size = new System.Drawing.Size(357, 152);
            this.groupBox_uploadData.TabIndex = 18;
            this.groupBox_uploadData.TabStop = false;
            this.groupBox_uploadData.Text = "Загрузка данных";
            // 
            // label_nameFileUpload
            // 
            this.label_nameFileUpload.AutoSize = true;
            this.label_nameFileUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_nameFileUpload.Location = new System.Drawing.Point(6, 39);
            this.label_nameFileUpload.Name = "label_nameFileUpload";
            this.label_nameFileUpload.Size = new System.Drawing.Size(180, 25);
            this.label_nameFileUpload.TabIndex = 18;
            this.label_nameFileUpload.Text = "Название файла";
            // 
            // textBox_nameFileUpload
            // 
            this.textBox_nameFileUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_nameFileUpload.Location = new System.Drawing.Point(11, 67);
            this.textBox_nameFileUpload.Name = "textBox_nameFileUpload";
            this.textBox_nameFileUpload.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_nameFileUpload.Size = new System.Drawing.Size(340, 31);
            this.textBox_nameFileUpload.TabIndex = 17;
            // 
            // button_uploadData
            // 
            this.button_uploadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_uploadData.Location = new System.Drawing.Point(11, 104);
            this.button_uploadData.Name = "button_uploadData";
            this.button_uploadData.Size = new System.Drawing.Size(340, 42);
            this.button_uploadData.TabIndex = 21;
            this.button_uploadData.Text = "Загрузить данные из файла";
            this.button_uploadData.UseVisualStyleBackColor = true;
            this.button_uploadData.Click += new System.EventHandler(this.button_uploadData_Click);
            // 
            // Rang
            // 
            this.Rang.AutoSize = true;
            this.Rang.Location = new System.Drawing.Point(556, 27);
            this.Rang.Name = "Rang";
            this.Rang.Size = new System.Drawing.Size(58, 25);
            this.Rang.TabIndex = 16;
            this.Rang.Text = "Ранг";
            // 
            // textBox_Rang
            // 
            this.textBox_Rang.Location = new System.Drawing.Point(556, 55);
            this.textBox_Rang.Name = "textBox_Rang";
            this.textBox_Rang.Size = new System.Drawing.Size(53, 31);
            this.textBox_Rang.TabIndex = 15;
            this.textBox_Rang.Text = "2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox_format);
            this.groupBox2.Controls.Add(this.button_longInstruction);
            this.groupBox2.Controls.Add(this.textBox_resualEquation);
            this.groupBox2.Controls.Add(this.label_resultEquation);
            this.groupBox2.Controls.Add(this.button_getResualtEquation);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(750, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 581);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Решение программы";
            // 
            // groupBox_format
            // 
            this.groupBox_format.Controls.Add(this.radioButton_horizontalFormat);
            this.groupBox_format.Controls.Add(this.radioButton_verticalFormat);
            this.groupBox_format.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_format.Location = new System.Drawing.Point(6, 452);
            this.groupBox_format.Name = "groupBox_format";
            this.groupBox_format.Size = new System.Drawing.Size(533, 66);
            this.groupBox_format.TabIndex = 22;
            this.groupBox_format.TabStop = false;
            this.groupBox_format.Text = "Формат ответа";
            // 
            // radioButton_horizontalFormat
            // 
            this.radioButton_horizontalFormat.AutoSize = true;
            this.radioButton_horizontalFormat.Checked = true;
            this.radioButton_horizontalFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_horizontalFormat.Location = new System.Drawing.Point(6, 30);
            this.radioButton_horizontalFormat.Name = "radioButton_horizontalFormat";
            this.radioButton_horizontalFormat.Size = new System.Drawing.Size(182, 29);
            this.radioButton_horizontalFormat.TabIndex = 21;
            this.radioButton_horizontalFormat.TabStop = true;
            this.radioButton_horizontalFormat.Text = "Горизонтально";
            this.radioButton_horizontalFormat.UseVisualStyleBackColor = true;
            // 
            // radioButton_verticalFormat
            // 
            this.radioButton_verticalFormat.AutoSize = true;
            this.radioButton_verticalFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_verticalFormat.Location = new System.Drawing.Point(194, 31);
            this.radioButton_verticalFormat.Name = "radioButton_verticalFormat";
            this.radioButton_verticalFormat.Size = new System.Drawing.Size(160, 29);
            this.radioButton_verticalFormat.TabIndex = 20;
            this.radioButton_verticalFormat.Text = "Вертикально";
            this.radioButton_verticalFormat.UseVisualStyleBackColor = true;
            // 
            // button_longInstruction
            // 
            this.button_longInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_longInstruction.Location = new System.Drawing.Point(277, 524);
            this.button_longInstruction.Name = "button_longInstruction";
            this.button_longInstruction.Size = new System.Drawing.Size(263, 42);
            this.button_longInstruction.TabIndex = 0;
            this.button_longInstruction.Text = "Инструкция";
            this.button_longInstruction.UseVisualStyleBackColor = true;
            this.button_longInstruction.Click += new System.EventHandler(this.button_longInstruction_Click);
            // 
            // Form_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_Equation);
            this.Name = "Form_Input";
            this.Text = "Решение систем уравнения теории мультиопераций";
            this.Load += new System.EventHandler(this.Form_SolvingOfSystemEquationOfTheoryMultioperations_Load);
            this.groupBox_Equation.ResumeLayout(false);
            this.groupBox_Equation.PerformLayout();
            this.groupBox_saveData.ResumeLayout(false);
            this.groupBox_saveData.PerformLayout();
            this.groupBox_uploadData.ResumeLayout(false);
            this.groupBox_uploadData.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_format.ResumeLayout(false);
            this.groupBox_format.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Equation;
        private System.Windows.Forms.Label label_leftSideEquation;
        private System.Windows.Forms.Label label_resultEquation;
        private System.Windows.Forms.TextBox textBox_resualEquation;
        private System.Windows.Forms.Button button_getResualtEquation;
        private System.Windows.Forms.Label label_multiopearions;
        private System.Windows.Forms.TextBox textBox_Multioperations;
        private System.Windows.Forms.TextBox textBox_coefficients;
        private System.Windows.Forms.Label label_coefficients;
        private System.Windows.Forms.TextBox textBox_unknows;
        private System.Windows.Forms.Label label_unknows;
        private System.Windows.Forms.Label label_conditions;
        private System.Windows.Forms.TextBox textBox_conditions;
        private System.Windows.Forms.GroupBox groupBox_Equation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Rang;
        private System.Windows.Forms.TextBox textBox_Rang;
        private System.Windows.Forms.Button button_saveData;
        private System.Windows.Forms.GroupBox groupBox_saveData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nameFileSave;
        private System.Windows.Forms.GroupBox groupBox_uploadData;
        private System.Windows.Forms.Label label_nameFileUpload;
        private System.Windows.Forms.TextBox textBox_nameFileUpload;
        private System.Windows.Forms.Button button_uploadData;
        private System.Windows.Forms.GroupBox groupBox_format;
        private System.Windows.Forms.RadioButton radioButton_horizontalFormat;
        private System.Windows.Forms.RadioButton radioButton_verticalFormat;
        private System.Windows.Forms.Button button_longInstruction;
    }
}

