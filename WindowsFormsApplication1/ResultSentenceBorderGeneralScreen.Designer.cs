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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultSentenceBorderGeneralScreen));
            this.sentence_border_left_group = new System.Windows.Forms.GroupBox();
            this.codedSentenceBorder_value = new System.Windows.Forms.Label();
            this.codedSentenceBorder_label = new System.Windows.Forms.Label();
            this.generalSentenceLeftBorderMap_table = new System.Windows.Forms.TableLayoutPanel();
            this.left_border_label = new System.Windows.Forms.Label();
            this.right_border_label = new System.Windows.Forms.Label();
            this.generalSentenceRightBorderMap_table = new System.Windows.Forms.TableLayoutPanel();
            this.sentence_border_left_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // sentence_border_left_group
            // 
            this.sentence_border_left_group.Controls.Add(this.generalSentenceRightBorderMap_table);
            this.sentence_border_left_group.Controls.Add(this.right_border_label);
            this.sentence_border_left_group.Controls.Add(this.left_border_label);
            this.sentence_border_left_group.Controls.Add(this.codedSentenceBorder_value);
            this.sentence_border_left_group.Controls.Add(this.codedSentenceBorder_label);
            this.sentence_border_left_group.Controls.Add(this.generalSentenceLeftBorderMap_table);
            this.sentence_border_left_group.Location = new System.Drawing.Point(12, 21);
            this.sentence_border_left_group.Name = "sentence_border_left_group";
            this.sentence_border_left_group.Size = new System.Drawing.Size(580, 550);
            this.sentence_border_left_group.TabIndex = 15;
            this.sentence_border_left_group.TabStop = false;
            this.sentence_border_left_group.Text = "Sentence Border (Left + Right)";
            // 
            // codedSentenceBorder_value
            // 
            this.codedSentenceBorder_value.AutoSize = true;
            this.codedSentenceBorder_value.Location = new System.Drawing.Point(530, 14);
            this.codedSentenceBorder_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codedSentenceBorder_value.Name = "codedSentenceBorder_value";
            this.codedSentenceBorder_value.Size = new System.Drawing.Size(42, 17);
            this.codedSentenceBorder_value.TabIndex = 14;
            this.codedSentenceBorder_value.Text = "value";
            // 
            // codedSentenceBorder_label
            // 
            this.codedSentenceBorder_label.AutoSize = true;
            this.codedSentenceBorder_label.Location = new System.Drawing.Point(304, 14);
            this.codedSentenceBorder_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codedSentenceBorder_label.Name = "codedSentenceBorder_label";
            this.codedSentenceBorder_label.Size = new System.Drawing.Size(228, 17);
            this.codedSentenceBorder_label.TabIndex = 13;
            this.codedSentenceBorder_label.Text = "Concrete sentence border method:";
            // 
            // generalSentenceLeftBorderMap_table
            // 
            this.generalSentenceLeftBorderMap_table.AutoScroll = true;
            this.generalSentenceLeftBorderMap_table.ColumnCount = 2;
            this.generalSentenceLeftBorderMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalSentenceLeftBorderMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalSentenceLeftBorderMap_table.Location = new System.Drawing.Point(16, 60);
            this.generalSentenceLeftBorderMap_table.Name = "generalSentenceLeftBorderMap_table";
            this.generalSentenceLeftBorderMap_table.RowCount = 1;
            this.generalSentenceLeftBorderMap_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalSentenceLeftBorderMap_table.Size = new System.Drawing.Size(250, 470);
            this.generalSentenceLeftBorderMap_table.TabIndex = 12;
            // 
            // left_border_label
            // 
            this.left_border_label.AutoSize = true;
            this.left_border_label.Location = new System.Drawing.Point(13, 31);
            this.left_border_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.left_border_label.Name = "left_border_label";
            this.left_border_label.Size = new System.Drawing.Size(78, 17);
            this.left_border_label.TabIndex = 15;
            this.left_border_label.Text = "Left border";
            // 
            // right_border_label
            // 
            this.right_border_label.AutoSize = true;
            this.right_border_label.Location = new System.Drawing.Point(304, 31);
            this.right_border_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.right_border_label.Name = "right_border_label";
            this.right_border_label.Size = new System.Drawing.Size(87, 17);
            this.right_border_label.TabIndex = 16;
            this.right_border_label.Text = "Right border";
            // 
            // generalSentenceRightBorderMap_table
            // 
            this.generalSentenceRightBorderMap_table.AutoScroll = true;
            this.generalSentenceRightBorderMap_table.ColumnCount = 2;
            this.generalSentenceRightBorderMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalSentenceRightBorderMap_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalSentenceRightBorderMap_table.Location = new System.Drawing.Point(307, 60);
            this.generalSentenceRightBorderMap_table.Name = "generalSentenceRightBorderMap_table";
            this.generalSentenceRightBorderMap_table.RowCount = 1;
            this.generalSentenceRightBorderMap_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalSentenceRightBorderMap_table.Size = new System.Drawing.Size(250, 470);
            this.generalSentenceRightBorderMap_table.TabIndex = 17;
            // 
            // ResultSentenceBorderGeneralScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 583);
            this.Controls.Add(this.sentence_border_left_group);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultSentenceBorderGeneralScreen";
            this.Text = "Steganalysis Result (Sentence Border - General)";
            this.Load += new System.EventHandler(this.ResultSentenceBorderGeneralScreen_Load);
            this.sentence_border_left_group.ResumeLayout(false);
            this.sentence_border_left_group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox sentence_border_left_group;
        private System.Windows.Forms.TableLayoutPanel generalSentenceLeftBorderMap_table;
        private System.Windows.Forms.Label codedSentenceBorder_value;
        private System.Windows.Forms.Label codedSentenceBorder_label;
        private System.Windows.Forms.Label left_border_label;
        private System.Windows.Forms.Label right_border_label;
        private System.Windows.Forms.TableLayoutPanel generalSentenceRightBorderMap_table;
    }
}

