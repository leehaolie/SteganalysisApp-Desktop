namespace WindowsFormsApplication1
{
    partial class ResultUnderlineGeneralScreen
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
            this.underline_group = new System.Windows.Forms.GroupBox();
            this.generalUnderlineMap_table = new System.Windows.Forms.TableLayoutPanel();
            this.underline_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // underline_group
            // 
            this.underline_group.Controls.Add(this.generalUnderlineMap_table);
            this.underline_group.Location = new System.Drawing.Point(22, 22);
            this.underline_group.Name = "underline_group";
            this.underline_group.Size = new System.Drawing.Size(282, 527);
            this.underline_group.TabIndex = 14;
            this.underline_group.TabStop = false;
            this.underline_group.Text = "Underline:";
            // 
            // generalUnderlineMap_table
            // 
            this.generalUnderlineMap_table.ColumnCount = 2;
            this.generalUnderlineMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalUnderlineMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalUnderlineMap_table.Location = new System.Drawing.Point(15, 31);
            this.generalUnderlineMap_table.Name = "generalUnderlineMap_table";
            this.generalUnderlineMap_table.RowCount = 1;
            this.generalUnderlineMap_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalUnderlineMap_table.Size = new System.Drawing.Size(250, 472);
            this.generalUnderlineMap_table.TabIndex = 12;
            // 
            // ResultUnderlineGeneralScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 584);
            this.Controls.Add(this.underline_group);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultUnderlineGeneralScreen";
            this.Text = "Steganalysis Result (Underline - General)";
            this.underline_group.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox underline_group;
        private System.Windows.Forms.TableLayoutPanel generalUnderlineMap_table;
    }
}

