namespace WindowsFormsApplication1
{
    partial class ResultCharacterScaleGeneralScreen
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
            this.character_scale_group = new System.Windows.Forms.GroupBox();
            this.generalScalingMap_table = new System.Windows.Forms.TableLayoutPanel();
            this.character_scale_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // character_scale_group
            // 
            this.character_scale_group.Controls.Add(this.generalScalingMap_table);
            this.character_scale_group.Location = new System.Drawing.Point(22, 22);
            this.character_scale_group.Name = "character_scale_group";
            this.character_scale_group.Size = new System.Drawing.Size(280, 530);
            this.character_scale_group.TabIndex = 13;
            this.character_scale_group.TabStop = false;
            this.character_scale_group.Text = "Character Scale:";
            // 
            // generalScalingMap_table
            // 
            this.generalScalingMap_table.ColumnCount = 2;
            this.generalScalingMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalScalingMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalScalingMap_table.Location = new System.Drawing.Point(6, 34);
            this.generalScalingMap_table.Name = "generalScalingMap_table";
            this.generalScalingMap_table.RowCount = 1;
            this.generalScalingMap_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalScalingMap_table.Size = new System.Drawing.Size(250, 470);
            this.generalScalingMap_table.TabIndex = 11;
            // 
            // ResultCharacterScaleGeneralScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 583);
            this.Controls.Add(this.character_scale_group);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultCharacterScaleGeneralScreen";
            this.Text = "Steganalysis Result (Character Scale - General)";
            this.character_scale_group.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox character_scale_group;
        private System.Windows.Forms.TableLayoutPanel generalScalingMap_table;
    }
}

