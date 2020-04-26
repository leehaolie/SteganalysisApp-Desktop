namespace WindowsFormsApplication1
{
    partial class ResultFontTypeScreen
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
            this.font_types_group = new System.Windows.Forms.GroupBox();
            this.fontTypeDirectoryCount_value = new System.Windows.Forms.Label();
            this.fontTypeDirectoryCount_label = new System.Windows.Forms.Label();
            this.fontTypePotential_value = new System.Windows.Forms.Label();
            this.fontTypeTotal_value = new System.Windows.Forms.Label();
            this.fontTypePotential_label = new System.Windows.Forms.Label();
            this.fontTypeTotal_label = new System.Windows.Forms.Label();
            this.font_types_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // font_types_group
            // 
            this.font_types_group.Controls.Add(this.fontTypeDirectoryCount_value);
            this.font_types_group.Controls.Add(this.fontTypeDirectoryCount_label);
            this.font_types_group.Controls.Add(this.fontTypePotential_value);
            this.font_types_group.Controls.Add(this.fontTypeTotal_value);
            this.font_types_group.Controls.Add(this.fontTypePotential_label);
            this.font_types_group.Controls.Add(this.fontTypeTotal_label);
            this.font_types_group.Location = new System.Drawing.Point(12, 12);
            this.font_types_group.Name = "font_types_group";
            this.font_types_group.Size = new System.Drawing.Size(233, 115);
            this.font_types_group.TabIndex = 10;
            this.font_types_group.TabStop = false;
            this.font_types_group.Text = "Font Type:";
            // 
            // fontTypeDirectoryCount_value
            // 
            this.fontTypeDirectoryCount_value.AutoSize = true;
            this.fontTypeDirectoryCount_value.Location = new System.Drawing.Point(129, 85);
            this.fontTypeDirectoryCount_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fontTypeDirectoryCount_value.Name = "fontTypeDirectoryCount_value";
            this.fontTypeDirectoryCount_value.Size = new System.Drawing.Size(42, 17);
            this.fontTypeDirectoryCount_value.TabIndex = 10;
            this.fontTypeDirectoryCount_value.Text = "value";
            // 
            // fontTypeDirectoryCount_label
            // 
            this.fontTypeDirectoryCount_label.AutoSize = true;
            this.fontTypeDirectoryCount_label.Location = new System.Drawing.Point(7, 85);
            this.fontTypeDirectoryCount_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fontTypeDirectoryCount_label.Name = "fontTypeDirectoryCount_label";
            this.fontTypeDirectoryCount_label.Size = new System.Drawing.Size(124, 17);
            this.fontTypeDirectoryCount_label.TabIndex = 9;
            this.fontTypeDirectoryCount_label.Text = "Count Font Types:";
            // 
            // fontTypePotential_value
            // 
            this.fontTypePotential_value.AutoSize = true;
            this.fontTypePotential_value.Location = new System.Drawing.Point(78, 57);
            this.fontTypePotential_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fontTypePotential_value.Name = "fontTypePotential_value";
            this.fontTypePotential_value.Size = new System.Drawing.Size(42, 17);
            this.fontTypePotential_value.TabIndex = 8;
            this.fontTypePotential_value.Text = "value";
            // 
            // fontTypeTotal_value
            // 
            this.fontTypeTotal_value.AutoSize = true;
            this.fontTypeTotal_value.Location = new System.Drawing.Point(78, 28);
            this.fontTypeTotal_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fontTypeTotal_value.Name = "fontTypeTotal_value";
            this.fontTypeTotal_value.Size = new System.Drawing.Size(42, 17);
            this.fontTypeTotal_value.TabIndex = 7;
            this.fontTypeTotal_value.Text = "value";
            // 
            // fontTypePotential_label
            // 
            this.fontTypePotential_label.AutoSize = true;
            this.fontTypePotential_label.Location = new System.Drawing.Point(7, 57);
            this.fontTypePotential_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fontTypePotential_label.Name = "fontTypePotential_label";
            this.fontTypePotential_label.Size = new System.Drawing.Size(67, 17);
            this.fontTypePotential_label.TabIndex = 6;
            this.fontTypePotential_label.Text = "Potential:";
            // 
            // fontTypeTotal_label
            // 
            this.fontTypeTotal_label.AutoSize = true;
            this.fontTypeTotal_label.Location = new System.Drawing.Point(7, 28);
            this.fontTypeTotal_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fontTypeTotal_label.Name = "fontTypeTotal_label";
            this.fontTypeTotal_label.Size = new System.Drawing.Size(48, 17);
            this.fontTypeTotal_label.TabIndex = 5;
            this.fontTypeTotal_label.Text = "Total: ";
            // 
            // ResultFontTypeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 144);
            this.Controls.Add(this.font_types_group);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultFontTypeScreen";
            this.Text = "Steganalysis Result (Font Types)";
            this.font_types_group.ResumeLayout(false);
            this.font_types_group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox font_types_group;
        private System.Windows.Forms.Label fontTypePotential_value;
        private System.Windows.Forms.Label fontTypeTotal_value;
        private System.Windows.Forms.Label fontTypePotential_label;
        private System.Windows.Forms.Label fontTypeTotal_label;
        private System.Windows.Forms.Label fontTypeDirectoryCount_value;
        private System.Windows.Forms.Label fontTypeDirectoryCount_label;
    }
}

