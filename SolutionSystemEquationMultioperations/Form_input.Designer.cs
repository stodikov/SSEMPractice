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
            this.Rang = new System.Windows.Forms.Label();
            this.textBox_Rang = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_saveData = new System.Windows.Forms.Button();
            this.groupBox_Equation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Equation
            // 
            this.textBox_Equation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Equation.Location = new System.Drawing.Point(6, 55);
            this.textBox_Equation.Multiline = true;
            this.textBox_Equation.Name = "textBox_Equation";
            this.textBox_Equation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Equation.Size = new System.Drawing.Size(536, 168);
            this.textBox_Equation.TabIndex = 1;
            this.textBox_Equation.Text = "g(h(z,c),s(c))<g(c,z)";
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
            this.textBox_resualEquation.Size = new System.Drawing.Size(622, 442);
            this.textBox_resualEquation.TabIndex = 5;
            this.textBox_resualEquation.WordWrap = false;
            // 
            // button_getResualtEquation
            // 
            this.button_getResualtEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_getResualtEquation.Location = new System.Drawing.Point(12, 442);
            this.button_getResualtEquation.Name = "button_getResualtEquation";
            this.button_getResualtEquation.Size = new System.Drawing.Size(171, 67);
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
            this.textBox_conditions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_conditions.Size = new System.Drawing.Size(168, 161);
            this.textBox_conditions.TabIndex = 13;
            this.textBox_conditions.Text = "!=|a,b";
            // 
            // groupBox_Equation
            // 
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
            this.groupBox_Equation.Size = new System.Drawing.Size(732, 424);
            this.groupBox_Equation.TabIndex = 17;
            this.groupBox_Equation.TabStop = false;
            this.groupBox_Equation.Text = "Входные параметры";
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
            this.groupBox2.Controls.Add(this.textBox_resualEquation);
            this.groupBox2.Controls.Add(this.label_resultEquation);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(750, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 506);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Решение программы";
            // 
            // button_saveData
            // 
            this.button_saveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_saveData.Location = new System.Drawing.Point(545, 439);
            this.button_saveData.Name = "button_saveData";
            this.button_saveData.Size = new System.Drawing.Size(199, 70);
            this.button_saveData.TabIndex = 20;
            this.button_saveData.Text = "Сохранить данные в файл";
            this.button_saveData.UseVisualStyleBackColor = true;
            this.button_saveData.Click += new System.EventHandler(this.Button_saveData_Click);
            // 
            // Form_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 533);
            this.Controls.Add(this.button_saveData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_Equation);
            this.Controls.Add(this.button_getResualtEquation);
            this.Name = "Form_Input";
            this.Text = "Решение систем уравнения теории мультиопераций";
            this.Load += new System.EventHandler(this.Form_SolvingOfSystemEquationOfTheoryMultioperations_Load);
            this.groupBox_Equation.ResumeLayout(false);
            this.groupBox_Equation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}

