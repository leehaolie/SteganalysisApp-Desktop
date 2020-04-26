namespace WindowsFormsApplication1
{
    partial class DetectCoding
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
            this.choseDocument = new System.Windows.Forms.Button();
            this.chosenDocumentLabel = new System.Windows.Forms.Label();
            this.detectAnyMethod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // choseDocument
            // 
            this.choseDocument.Location = new System.Drawing.Point(56, 35);
            this.choseDocument.Margin = new System.Windows.Forms.Padding(4);
            this.choseDocument.Name = "choseDocument";
            this.choseDocument.Size = new System.Drawing.Size(185, 28);
            this.choseDocument.TabIndex = 4;
            this.choseDocument.Text = "Chose document (Word)";
            this.choseDocument.UseVisualStyleBackColor = true;
            this.choseDocument.Click += new System.EventHandler(this.button4_Click);
            // 
            // chosenDocumentLabel
            // 
            this.chosenDocumentLabel.AutoSize = true;
            this.chosenDocumentLabel.Location = new System.Drawing.Point(53, 67);
            this.chosenDocumentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chosenDocumentLabel.Name = "chosenDocumentLabel";
            this.chosenDocumentLabel.Size = new System.Drawing.Size(145, 17);
            this.chosenDocumentLabel.TabIndex = 5;
            this.chosenDocumentLabel.Text = "No document chosen!";
            // 
            // detectAnyMethod
            // 
            this.detectAnyMethod.Location = new System.Drawing.Point(299, 35);
            this.detectAnyMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectAnyMethod.Name = "detectAnyMethod";
            this.detectAnyMethod.Size = new System.Drawing.Size(265, 28);
            this.detectAnyMethod.TabIndex = 0;
            this.detectAnyMethod.Text = "Detect any steganography method";
            this.detectAnyMethod.UseVisualStyleBackColor = true;
            this.detectAnyMethod.Click += new System.EventHandler(this.button1_Click);
            // 
            // DetectCoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 286);
            this.Controls.Add(this.chosenDocumentLabel);
            this.Controls.Add(this.choseDocument);
            this.Controls.Add(this.detectAnyMethod);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DetectCoding";
            this.Text = "Detect the method of steganography used in the document (Word)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button choseDocument;
        private System.Windows.Forms.Label chosenDocumentLabel;
        private System.Windows.Forms.Button detectAnyMethod;
    }
}

