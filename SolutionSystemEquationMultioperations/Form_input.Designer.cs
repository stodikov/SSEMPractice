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
            this.textBox_constants = new System.Windows.Forms.TextBox();
            this.label_constants = new System.Windows.Forms.Label();
            this.textBox_unknows = new System.Windows.Forms.TextBox();
            this.label_unknows = new System.Windows.Forms.Label();
            this.label_conditions = new System.Windows.Forms.Label();
            this.textBox_conditions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_Equation
            // 
            this.textBox_Equation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Equation.Location = new System.Drawing.Point(38, 37);
            this.textBox_Equation.Multiline = true;
            this.textBox_Equation.Name = "textBox_Equation";
            this.textBox_Equation.Size = new System.Drawing.Size(264, 180);
            this.textBox_Equation.TabIndex = 1;
            this.textBox_Equation.Text = "g(h(z,c),s(c))<g(c,z)";
            // 
            // label_leftSideEquation
            // 
            this.label_leftSideEquation.AutoSize = true;
            this.label_leftSideEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_leftSideEquation.Location = new System.Drawing.Point(33, 9);
            this.label_leftSideEquation.Name = "label_leftSideEquation";
            this.label_leftSideEquation.Size = new System.Drawing.Size(120, 25);
            this.label_leftSideEquation.TabIndex = 3;
            this.label_leftSideEquation.Text = "Уравнение";
            // 
            // label_resultEquation
            // 
            this.label_resultEquation.AutoSize = true;
            this.label_resultEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_resultEquation.Location = new System.Drawing.Point(467, 9);
            this.label_resultEquation.Name = "label_resultEquation";
            this.label_resultEquation.Size = new System.Drawing.Size(115, 25);
            this.label_resultEquation.TabIndex = 4;
            this.label_resultEquation.Text = "Результат";
            // 
            // textBox_resualEquation
            // 
            this.textBox_resualEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_resualEquation.Location = new System.Drawing.Point(472, 37);
            this.textBox_resualEquation.Multiline = true;
            this.textBox_resualEquation.Name = "textBox_resualEquation";
            this.textBox_resualEquation.Size = new System.Drawing.Size(264, 180);
            this.textBox_resualEquation.TabIndex = 5;
            // 
            // button_getResualtEquation
            // 
            this.button_getResualtEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_getResualtEquation.Location = new System.Drawing.Point(331, 37);
            this.button_getResualtEquation.Name = "button_getResualtEquation";
            this.button_getResualtEquation.Size = new System.Drawing.Size(113, 44);
            this.button_getResualtEquation.TabIndex = 6;
            this.button_getResualtEquation.Text = "Решение";
            this.button_getResualtEquation.UseVisualStyleBackColor = true;
            this.button_getResualtEquation.Click += new System.EventHandler(this.button_getResualtEquation_Click);
            // 
            // label_multiopearions
            // 
            this.label_multiopearions.AutoSize = true;
            this.label_multiopearions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_multiopearions.Location = new System.Drawing.Point(33, 237);
            this.label_multiopearions.Name = "label_multiopearions";
            this.label_multiopearions.Size = new System.Drawing.Size(182, 25);
            this.label_multiopearions.TabIndex = 7;
            this.label_multiopearions.Text = "Мультиоперации";
            // 
            // textBox_Multioperations
            // 
            this.textBox_Multioperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Multioperations.Location = new System.Drawing.Point(38, 265);
            this.textBox_Multioperations.Multiline = true;
            this.textBox_Multioperations.Name = "textBox_Multioperations";
            this.textBox_Multioperations.Size = new System.Drawing.Size(264, 180);
            this.textBox_Multioperations.TabIndex = 8;
            this.textBox_Multioperations.Text = "h=1332\r\ns=21\r\ng=1002";
            // 
            // textBox_constants
            // 
            this.textBox_constants.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_constants.Location = new System.Drawing.Point(472, 265);
            this.textBox_constants.Multiline = true;
            this.textBox_constants.Name = "textBox_constants";
            this.textBox_constants.Size = new System.Drawing.Size(264, 61);
            this.textBox_constants.TabIndex = 9;
            this.textBox_constants.Text = "c|a,b";
            // 
            // label_constants
            // 
            this.label_constants.AutoSize = true;
            this.label_constants.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_constants.Location = new System.Drawing.Point(467, 237);
            this.label_constants.Name = "label_constants";
            this.label_constants.Size = new System.Drawing.Size(120, 25);
            this.label_constants.TabIndex = 10;
            this.label_constants.Text = "Константы";
            // 
            // textBox_unknows
            // 
            this.textBox_unknows.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_unknows.Location = new System.Drawing.Point(472, 384);
            this.textBox_unknows.Multiline = true;
            this.textBox_unknows.Name = "textBox_unknows";
            this.textBox_unknows.Size = new System.Drawing.Size(264, 61);
            this.textBox_unknows.TabIndex = 11;
            this.textBox_unknows.Text = "z|x,y";
            // 
            // label_unknows
            // 
            this.label_unknows.AutoSize = true;
            this.label_unknows.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_unknows.Location = new System.Drawing.Point(467, 356);
            this.label_unknows.Name = "label_unknows";
            this.label_unknows.Size = new System.Drawing.Size(145, 25);
            this.label_unknows.TabIndex = 12;
            this.label_unknows.Text = "Неизвестные";
            // 
            // label_conditions
            // 
            this.label_conditions.AutoSize = true;
            this.label_conditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_conditions.Location = new System.Drawing.Point(33, 469);
            this.label_conditions.Name = "label_conditions";
            this.label_conditions.Size = new System.Drawing.Size(94, 25);
            this.label_conditions.TabIndex = 14;
            this.label_conditions.Text = "Условия";
            // 
            // textBox_conditions
            // 
            this.textBox_conditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_conditions.Location = new System.Drawing.Point(38, 497);
            this.textBox_conditions.Multiline = true;
            this.textBox_conditions.Name = "textBox_conditions";
            this.textBox_conditions.Size = new System.Drawing.Size(264, 61);
            this.textBox_conditions.TabIndex = 13;
            this.textBox_conditions.Text = "!=|a,b";
            // 
            // Form_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 596);
            this.Controls.Add(this.label_conditions);
            this.Controls.Add(this.textBox_conditions);
            this.Controls.Add(this.label_unknows);
            this.Controls.Add(this.textBox_unknows);
            this.Controls.Add(this.label_constants);
            this.Controls.Add(this.textBox_constants);
            this.Controls.Add(this.textBox_Multioperations);
            this.Controls.Add(this.label_multiopearions);
            this.Controls.Add(this.button_getResualtEquation);
            this.Controls.Add(this.textBox_resualEquation);
            this.Controls.Add(this.label_resultEquation);
            this.Controls.Add(this.label_leftSideEquation);
            this.Controls.Add(this.textBox_Equation);
            this.Name = "Form_Input";
            this.Text = "Решение систем уравнения теории мультиопераций";
            this.Load += new System.EventHandler(this.Form_SolvingOfSystemEquationOfTheoryMultioperations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Equation;
        private System.Windows.Forms.Label label_leftSideEquation;
        private System.Windows.Forms.Label label_resultEquation;
        private System.Windows.Forms.TextBox textBox_resualEquation;
        private System.Windows.Forms.Button button_getResualtEquation;
        private System.Windows.Forms.Label label_multiopearions;
        private System.Windows.Forms.TextBox textBox_Multioperations;
        private System.Windows.Forms.TextBox textBox_constants;
        private System.Windows.Forms.Label label_constants;
        private System.Windows.Forms.TextBox textBox_unknows;
        private System.Windows.Forms.Label label_unknows;
        private System.Windows.Forms.Label label_conditions;
        private System.Windows.Forms.TextBox textBox_conditions;
    }
}

