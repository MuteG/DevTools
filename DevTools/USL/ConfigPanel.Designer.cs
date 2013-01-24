
namespace DevTools.USL
{
    partial class ConfigPanel
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.textBoxFont = new System.Windows.Forms.TextBox();
            this.buttonFont = new System.Windows.Forms.Button();
            this.labelFont = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(198, 62);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(38, 33);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(152, 20);
            this.comboBoxLanguage.TabIndex = 10;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(3, 37);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(29, 12);
            this.labelLanguage.TabIndex = 9;
            this.labelLanguage.Text = "语言";
            // 
            // textBoxFont
            // 
            this.textBoxFont.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFont.Location = new System.Drawing.Point(38, 4);
            this.textBoxFont.Name = "textBoxFont";
            this.textBoxFont.ReadOnly = true;
            this.textBoxFont.Size = new System.Drawing.Size(152, 21);
            this.textBoxFont.TabIndex = 8;
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(196, 3);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(75, 23);
            this.buttonFont.TabIndex = 7;
            this.buttonFont.Text = "选择字体";
            this.buttonFont.UseVisualStyleBackColor = true;
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(3, 8);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(29, 12);
            this.labelFont.TabIndex = 6;
            this.labelFont.Text = "字体";
            // 
            // ConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.textBoxFont);
            this.Controls.Add(this.buttonFont);
            this.Controls.Add(this.labelFont);
            this.Name = "ConfigPanel";
            this.Size = new System.Drawing.Size(276, 88);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.TextBox textBoxFont;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Button buttonSave;
    }
}
