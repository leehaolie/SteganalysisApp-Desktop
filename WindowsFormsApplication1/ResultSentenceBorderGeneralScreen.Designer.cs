namespace WindowsFormsApplication1
{
    partial class ResultSentenceBorderGeneralScreen
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
            this.sentence_border_left_group = new System.Windows.Forms.GroupBox();
            this.generalSentenceLeftBorderMap_table = new System.Windows.Forms.TableLayoutPanel();
            this.sentence_border_left_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // sentence_border_left_group
            // 
            this.sentence_border_left_group.Controls.Add(this.generalSentenceLeftBorderMap_table);
            this.sentence_border_left_group.Location = new System.Drawing.Point(12, 21);
            this.sentence_border_left_group.Name = "sentence_border_left_group";
            this.sentence_border_left_group.Size = new System.Drawing.Size(280, 530);
            this.sentence_border_left_group.TabIndex = 15;
            this.sentence_border_left_group.TabStop = false;
            this.sentence_border_left_group.Text = "Sentence Border (Left)";
            // 
            // generalSentenceLeftBorderMap_table
            // 
            this.generalSentenceLeftBorderMap_table.AutoScroll = true;
            this.generalSentenceLeftBorderMap_table.ColumnCount = 2;
            this.generalSentenceLeftBorderMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalSentenceLeftBorderMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalSentenceLeftBorderMap_table.Location = new System.Drawing.Point(16, 31);
            this.generalSentenceLeftBorderMap_table.Name = "generalSentenceLeftBorderMap_table";
            this.generalSentenceLeftBorderMap_table.RowCount = 1;
            this.generalSentenceLeftBorderMap_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalSentenceLeftBorderMap_table.Size = new System.Drawing.Size(250, 470);
            this.generalSentenceLeftBorderMap_table.TabIndex = 12;
            // 
            // ResultSentenceBorderGeneralScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 583);
            this.Controls.Add(this.sentence_border_left_group);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultSentenceBorderGeneralScreen";
            this.Text = "Steganalysis Result (Sentence Border - General)";
            this.sentence_border_left_group.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox sentence_border_left_group;
        private System.Windows.Forms.TableLayoutPanel generalSentenceLeftBorderMap_table;
    }
}

