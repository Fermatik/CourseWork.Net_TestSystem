
namespace TestConstructor
{
    partial class AddEditAnswer
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
            this.textBoxAnswerText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxIsTrue = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAnswerText
            // 
            this.textBoxAnswerText.Location = new System.Drawing.Point(12, 33);
            this.textBoxAnswerText.Multiline = true;
            this.textBoxAnswerText.Name = "textBoxAnswerText";
            this.textBoxAnswerText.Size = new System.Drawing.Size(500, 108);
            this.textBoxAnswerText.TabIndex = 0;
            this.textBoxAnswerText.TextChanged += new System.EventHandler(this.textBoxAnswerText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Answer:";
            // 
            // checkBoxIsTrue
            // 
            this.checkBoxIsTrue.AutoSize = true;
            this.checkBoxIsTrue.Location = new System.Drawing.Point(12, 147);
            this.checkBoxIsTrue.Name = "checkBoxIsTrue";
            this.checkBoxIsTrue.Size = new System.Drawing.Size(118, 21);
            this.checkBoxIsTrue.TabIndex = 2;
            this.checkBoxIsTrue.Text = "is true answer";
            this.checkBoxIsTrue.UseVisualStyleBackColor = true;
            this.checkBoxIsTrue.CheckedChanged += new System.EventHandler(this.checkBoxIsTrue_CheckedChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.Color.Green;
            this.buttonSave.Location = new System.Drawing.Point(12, 174);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(242, 31);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(270, 174);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(242, 31);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AddEditAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 225);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkBoxIsTrue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAnswerText);
            this.Name = "AddEditAnswer";
            this.Text = "AddEditAnswer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        internal System.Windows.Forms.TextBox textBoxAnswerText;
        internal System.Windows.Forms.CheckBox checkBoxIsTrue;
    }
}