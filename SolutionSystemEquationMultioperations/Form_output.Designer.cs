namespace SolutionSystemEquationMultioperations
{
    partial class Form_Output
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
            this.textBox_resualEquation = new System.Windows.Forms.TextBox();
            this.label_resultEquation = new System.Windows.Forms.Label();
            this.textBox_equation = new System.Windows.Forms.TextBox();
            this.label_equation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_resualEquation
            // 
            this.textBox_resualEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_resualEquation.Location = new System.Drawing.Point(17, 123);
            this.textBox_resualEquation.Multiline = true;
            this.textBox_resualEquation.Name = "textBox_resualEquation";
            this.textBox_resualEquation.Size = new System.Drawing.Size(684, 285);
            this.textBox_resualEquation.TabIndex = 7;
            // 
            // label_resultEquation
            // 
            this.label_resultEquation.AutoSize = true;
            this.label_resultEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_resultEquation.Location = new System.Drawing.Point(12, 95);
            this.label_resultEquation.Name = "label_resultEquation";
            this.label_resultEquation.Size = new System.Drawing.Size(115, 25);
            this.label_resultEquation.TabIndex = 6;
            this.label_resultEquation.Text = "Результат";
            // 
            // textBox_equation
            // 
            this.textBox_equation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_equation.Location = new System.Drawing.Point(17, 37);
            this.textBox_equation.Multiline = true;
            this.textBox_equation.Name = "textBox_equation";
            this.textBox_equation.Size = new System.Drawing.Size(771, 46);
            this.textBox_equation.TabIndex = 9;
            // 
            // label_equation
            // 
            this.label_equation.AutoSize = true;
            this.label_equation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_equation.Location = new System.Drawing.Point(12, 9);
            this.label_equation.Name = "label_equation";
            this.label_equation.Size = new System.Drawing.Size(120, 25);
            this.label_equation.TabIndex = 8;
            this.label_equation.Text = "Уравнение";
            // 
            // Form_Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_equation);
            this.Controls.Add(this.label_equation);
            this.Controls.Add(this.textBox_resualEquation);
            this.Controls.Add(this.label_resultEquation);
            this.Name = "Form_Output";
            this.Text = "Form_output";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_resualEquation;
        private System.Windows.Forms.Label label_resultEquation;
        private System.Windows.Forms.TextBox textBox_equation;
        private System.Windows.Forms.Label label_equation;
    }
}