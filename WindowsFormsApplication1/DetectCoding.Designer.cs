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
            this.detectOpenSpacesMethods = new System.Windows.Forms.Button();
            this.detectWordMappingsMethods = new System.Windows.Forms.Button();
            this.detectFontTypeMethod = new System.Windows.Forms.Button();
            this.detectColorQuantizationMethod = new System.Windows.Forms.Button();
            this.detectInvisibleCharactesMethods = new System.Windows.Forms.Button();
            this.detectUnicodesMethod = new System.Windows.Forms.Button();
            this.detectCharactersScaleMethods = new System.Windows.Forms.Button();
            this.detectUnderlineMethods = new System.Windows.Forms.Button();
            this.detectSentenceBorderMethods = new System.Windows.Forms.Button();
            this.detectParagraphBorderMethods = new System.Windows.Forms.Button();
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
            this.detectAnyMethod.EnabledChanged += new System.EventHandler(this.detectAnyMethod_EnabledChanged);
            this.detectAnyMethod.Click += new System.EventHandler(this.button1_Click);
            // 
            // detectOpenSpacesMethods
            // 
            this.detectOpenSpacesMethods.Location = new System.Drawing.Point(299, 71);
            this.detectOpenSpacesMethods.Margin = new System.Windows.Forms.Padding(4);
            this.detectOpenSpacesMethods.Name = "detectOpenSpacesMethods";
            this.detectOpenSpacesMethods.Size = new System.Drawing.Size(265, 28);
            this.detectOpenSpacesMethods.TabIndex = 6;
            this.detectOpenSpacesMethods.Text = "Detect open spaces methods";
            this.detectOpenSpacesMethods.UseVisualStyleBackColor = true;
            this.detectOpenSpacesMethods.Click += new System.EventHandler(this.detectOpenSpacesMethods_Click);
            // 
            // detectWordMappingsMethods
            // 
            this.detectWordMappingsMethods.Location = new System.Drawing.Point(299, 107);
            this.detectWordMappingsMethods.Margin = new System.Windows.Forms.Padding(4);
            this.detectWordMappingsMethods.Name = "detectWordMappingsMethods";
            this.detectWordMappingsMethods.Size = new System.Drawing.Size(265, 28);
            this.detectWordMappingsMethods.TabIndex = 7;
            this.detectWordMappingsMethods.Text = "Detect word mappings methods";
            this.detectWordMappingsMethods.UseVisualStyleBackColor = true;
            this.detectWordMappingsMethods.Click += new System.EventHandler(this.detectWordMappingsMethods_Click);
            // 
            // detectFontTypeMethod
            // 
            this.detectFontTypeMethod.Location = new System.Drawing.Point(299, 143);
            this.detectFontTypeMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectFontTypeMethod.Name = "detectFontTypeMethod";
            this.detectFontTypeMethod.Size = new System.Drawing.Size(265, 28);
            this.detectFontTypeMethod.TabIndex = 8;
            this.detectFontTypeMethod.Text = "Detect font type method";
            this.detectFontTypeMethod.UseVisualStyleBackColor = true;
            // 
            // detectColorQuantizationMethod
            // 
            this.detectColorQuantizationMethod.Location = new System.Drawing.Point(299, 179);
            this.detectColorQuantizationMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectColorQuantizationMethod.Name = "detectColorQuantizationMethod";
            this.detectColorQuantizationMethod.Size = new System.Drawing.Size(265, 28);
            this.detectColorQuantizationMethod.TabIndex = 9;
            this.detectColorQuantizationMethod.Text = "Detect color quantization method";
            this.detectColorQuantizationMethod.UseVisualStyleBackColor = true;
            // 
            // detectInvisibleCharactesMethods
            // 
            this.detectInvisibleCharactesMethods.Location = new System.Drawing.Point(299, 215);
            this.detectInvisibleCharactesMethods.Margin = new System.Windows.Forms.Padding(4);
            this.detectInvisibleCharactesMethods.Name = "detectInvisibleCharactesMethods";
            this.detectInvisibleCharactesMethods.Size = new System.Drawing.Size(265, 28);
            this.detectInvisibleCharactesMethods.TabIndex = 10;
            this.detectInvisibleCharactesMethods.Text = "Detect invisible characters methods";
            this.detectInvisibleCharactesMethods.UseVisualStyleBackColor = true;
            // 
            // detectUnicodesMethod
            // 
            this.detectUnicodesMethod.Location = new System.Drawing.Point(299, 251);
            this.detectUnicodesMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectUnicodesMethod.Name = "detectUnicodesMethod";
            this.detectUnicodesMethod.Size = new System.Drawing.Size(265, 28);
            this.detectUnicodesMethod.TabIndex = 11;
            this.detectUnicodesMethod.Text = "Detect unicodes method";
            this.detectUnicodesMethod.UseVisualStyleBackColor = true;
            // 
            // detectCharactersScaleMethods
            // 
            this.detectCharactersScaleMethods.Location = new System.Drawing.Point(299, 287);
            this.detectCharactersScaleMethods.Margin = new System.Windows.Forms.Padding(4);
            this.detectCharactersScaleMethods.Name = "detectCharactersScaleMethods";
            this.detectCharactersScaleMethods.Size = new System.Drawing.Size(265, 28);
            this.detectCharactersScaleMethods.TabIndex = 12;
            this.detectCharactersScaleMethods.Text = "Detect characters scale methods";
            this.detectCharactersScaleMethods.UseVisualStyleBackColor = true;
            // 
            // detectUnderlineMethods
            // 
            this.detectUnderlineMethods.Location = new System.Drawing.Point(299, 323);
            this.detectUnderlineMethods.Margin = new System.Windows.Forms.Padding(4);
            this.detectUnderlineMethods.Name = "detectUnderlineMethods";
            this.detectUnderlineMethods.Size = new System.Drawing.Size(265, 28);
            this.detectUnderlineMethods.TabIndex = 13;
            this.detectUnderlineMethods.Text = "Detect underline methods";
            this.detectUnderlineMethods.UseVisualStyleBackColor = true;
            // 
            // detectSentenceBorderMethods
            // 
            this.detectSentenceBorderMethods.Location = new System.Drawing.Point(299, 359);
            this.detectSentenceBorderMethods.Margin = new System.Windows.Forms.Padding(4);
            this.detectSentenceBorderMethods.Name = "detectSentenceBorderMethods";
            this.detectSentenceBorderMethods.Size = new System.Drawing.Size(265, 28);
            this.detectSentenceBorderMethods.TabIndex = 14;
            this.detectSentenceBorderMethods.Text = "Detect sentence border methods";
            this.detectSentenceBorderMethods.UseVisualStyleBackColor = true;
            // 
            // detectParagraphBorderMethods
            // 
            this.detectParagraphBorderMethods.Location = new System.Drawing.Point(299, 398);
            this.detectParagraphBorderMethods.Margin = new System.Windows.Forms.Padding(4);
            this.detectParagraphBorderMethods.Name = "detectParagraphBorderMethods";
            this.detectParagraphBorderMethods.Size = new System.Drawing.Size(265, 28);
            this.detectParagraphBorderMethods.TabIndex = 15;
            this.detectParagraphBorderMethods.Text = "Detect paragraph border methods";
            this.detectParagraphBorderMethods.UseVisualStyleBackColor = true;
            // 
            // DetectCoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 462);
            this.Controls.Add(this.detectParagraphBorderMethods);
            this.Controls.Add(this.detectSentenceBorderMethods);
            this.Controls.Add(this.detectUnderlineMethods);
            this.Controls.Add(this.detectCharactersScaleMethods);
            this.Controls.Add(this.detectUnicodesMethod);
            this.Controls.Add(this.detectInvisibleCharactesMethods);
            this.Controls.Add(this.detectColorQuantizationMethod);
            this.Controls.Add(this.detectFontTypeMethod);
            this.Controls.Add(this.detectWordMappingsMethods);
            this.Controls.Add(this.detectOpenSpacesMethods);
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
        private System.Windows.Forms.Button detectOpenSpacesMethods;
        private System.Windows.Forms.Button detectWordMappingsMethods;
        private System.Windows.Forms.Button detectFontTypeMethod;
        private System.Windows.Forms.Button detectColorQuantizationMethod;
        private System.Windows.Forms.Button detectInvisibleCharactesMethods;
        private System.Windows.Forms.Button detectUnicodesMethod;
        private System.Windows.Forms.Button detectCharactersScaleMethods;
        private System.Windows.Forms.Button detectUnderlineMethods;
        private System.Windows.Forms.Button detectSentenceBorderMethods;
        private System.Windows.Forms.Button detectParagraphBorderMethods;
    }
}

