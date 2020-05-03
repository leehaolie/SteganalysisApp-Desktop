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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectCoding));
            this.choseDocument = new System.Windows.Forms.Button();
            this.chosenDocumentLabel = new System.Windows.Forms.Label();
            this.detectAnyMethod = new System.Windows.Forms.Button();
            this.detectOpenSpacesMethods = new System.Windows.Forms.Button();
            this.detectWordMappingsMethods = new System.Windows.Forms.Button();
            this.detectFontTypeMethod = new System.Windows.Forms.Button();
            this.detectColorQuantizationMethod = new System.Windows.Forms.Button();
            this.detectInvisibleCharactesMethods = new System.Windows.Forms.Button();
            this.detectUnicodesMethod = new System.Windows.Forms.Button();
            this.detectCharactersScaleGeneralMethod = new System.Windows.Forms.Button();
            this.detectUnderlineGeneralMethod = new System.Windows.Forms.Button();
            this.detectSentenceBorderGeneralMethod = new System.Windows.Forms.Button();
            this.detectParagraphBorderGeneralMethod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // choseDocument
            // 
            this.choseDocument.Location = new System.Drawing.Point(95, 34);
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
            this.chosenDocumentLabel.Location = new System.Drawing.Point(92, 66);
            this.chosenDocumentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chosenDocumentLabel.Name = "chosenDocumentLabel";
            this.chosenDocumentLabel.Size = new System.Drawing.Size(145, 17);
            this.chosenDocumentLabel.TabIndex = 5;
            this.chosenDocumentLabel.Text = "No document chosen!";
            // 
            // detectAnyMethod
            // 
            this.detectAnyMethod.Location = new System.Drawing.Point(338, 34);
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
            this.detectOpenSpacesMethods.Location = new System.Drawing.Point(338, 70);
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
            this.detectWordMappingsMethods.Location = new System.Drawing.Point(338, 106);
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
            this.detectFontTypeMethod.Location = new System.Drawing.Point(338, 142);
            this.detectFontTypeMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectFontTypeMethod.Name = "detectFontTypeMethod";
            this.detectFontTypeMethod.Size = new System.Drawing.Size(265, 28);
            this.detectFontTypeMethod.TabIndex = 8;
            this.detectFontTypeMethod.Text = "Detect font type method";
            this.detectFontTypeMethod.UseVisualStyleBackColor = true;
            this.detectFontTypeMethod.Click += new System.EventHandler(this.detectFontTypeMethod_Click);
            // 
            // detectColorQuantizationMethod
            // 
            this.detectColorQuantizationMethod.Location = new System.Drawing.Point(338, 178);
            this.detectColorQuantizationMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectColorQuantizationMethod.Name = "detectColorQuantizationMethod";
            this.detectColorQuantizationMethod.Size = new System.Drawing.Size(265, 28);
            this.detectColorQuantizationMethod.TabIndex = 9;
            this.detectColorQuantizationMethod.Text = "Detect color quantization method";
            this.detectColorQuantizationMethod.UseVisualStyleBackColor = true;
            this.detectColorQuantizationMethod.Click += new System.EventHandler(this.detectColorQuantizationMethod_Click);
            // 
            // detectInvisibleCharactesMethods
            // 
            this.detectInvisibleCharactesMethods.Location = new System.Drawing.Point(338, 214);
            this.detectInvisibleCharactesMethods.Margin = new System.Windows.Forms.Padding(4);
            this.detectInvisibleCharactesMethods.Name = "detectInvisibleCharactesMethods";
            this.detectInvisibleCharactesMethods.Size = new System.Drawing.Size(265, 28);
            this.detectInvisibleCharactesMethods.TabIndex = 10;
            this.detectInvisibleCharactesMethods.Text = "Detect invisible characters methods";
            this.detectInvisibleCharactesMethods.UseVisualStyleBackColor = true;
            this.detectInvisibleCharactesMethods.Click += new System.EventHandler(this.detectInvisibleCharactesMethods_Click);
            // 
            // detectUnicodesMethod
            // 
            this.detectUnicodesMethod.Location = new System.Drawing.Point(338, 250);
            this.detectUnicodesMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectUnicodesMethod.Name = "detectUnicodesMethod";
            this.detectUnicodesMethod.Size = new System.Drawing.Size(265, 28);
            this.detectUnicodesMethod.TabIndex = 11;
            this.detectUnicodesMethod.Text = "Detect unicodes method";
            this.detectUnicodesMethod.UseVisualStyleBackColor = true;
            this.detectUnicodesMethod.Click += new System.EventHandler(this.detectUnicodesMethod_Click);
            // 
            // detectCharactersScaleGeneralMethod
            // 
            this.detectCharactersScaleGeneralMethod.Location = new System.Drawing.Point(338, 286);
            this.detectCharactersScaleGeneralMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectCharactersScaleGeneralMethod.Name = "detectCharactersScaleGeneralMethod";
            this.detectCharactersScaleGeneralMethod.Size = new System.Drawing.Size(265, 28);
            this.detectCharactersScaleGeneralMethod.TabIndex = 12;
            this.detectCharactersScaleGeneralMethod.Text = "Detect characters scale methods";
            this.detectCharactersScaleGeneralMethod.UseVisualStyleBackColor = true;
            this.detectCharactersScaleGeneralMethod.Click += new System.EventHandler(this.detectCharactersScaleMethods_Click);
            // 
            // detectUnderlineGeneralMethod
            // 
            this.detectUnderlineGeneralMethod.Location = new System.Drawing.Point(338, 322);
            this.detectUnderlineGeneralMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectUnderlineGeneralMethod.Name = "detectUnderlineGeneralMethod";
            this.detectUnderlineGeneralMethod.Size = new System.Drawing.Size(265, 28);
            this.detectUnderlineGeneralMethod.TabIndex = 13;
            this.detectUnderlineGeneralMethod.Text = "Detect underline methods";
            this.detectUnderlineGeneralMethod.UseVisualStyleBackColor = true;
            this.detectUnderlineGeneralMethod.Click += new System.EventHandler(this.detectUnderlineMethods_Click);
            // 
            // detectSentenceBorderGeneralMethod
            // 
            this.detectSentenceBorderGeneralMethod.Location = new System.Drawing.Point(338, 358);
            this.detectSentenceBorderGeneralMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectSentenceBorderGeneralMethod.Name = "detectSentenceBorderGeneralMethod";
            this.detectSentenceBorderGeneralMethod.Size = new System.Drawing.Size(265, 28);
            this.detectSentenceBorderGeneralMethod.TabIndex = 14;
            this.detectSentenceBorderGeneralMethod.Text = "Detect sentence border methods";
            this.detectSentenceBorderGeneralMethod.UseVisualStyleBackColor = true;
            this.detectSentenceBorderGeneralMethod.Click += new System.EventHandler(this.detectSentenceBorderMethods_Click);
            // 
            // detectParagraphBorderGeneralMethod
            // 
            this.detectParagraphBorderGeneralMethod.Location = new System.Drawing.Point(338, 397);
            this.detectParagraphBorderGeneralMethod.Margin = new System.Windows.Forms.Padding(4);
            this.detectParagraphBorderGeneralMethod.Name = "detectParagraphBorderGeneralMethod";
            this.detectParagraphBorderGeneralMethod.Size = new System.Drawing.Size(265, 28);
            this.detectParagraphBorderGeneralMethod.TabIndex = 15;
            this.detectParagraphBorderGeneralMethod.Text = "Detect paragraph border methods";
            this.detectParagraphBorderGeneralMethod.UseVisualStyleBackColor = true;
            this.detectParagraphBorderGeneralMethod.Click += new System.EventHandler(this.detectParagraphBorderGeneralMethod_Click);
            // 
            // DetectCoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 462);
            this.Controls.Add(this.detectParagraphBorderGeneralMethod);
            this.Controls.Add(this.detectSentenceBorderGeneralMethod);
            this.Controls.Add(this.detectUnderlineGeneralMethod);
            this.Controls.Add(this.detectCharactersScaleGeneralMethod);
            this.Controls.Add(this.detectUnicodesMethod);
            this.Controls.Add(this.detectInvisibleCharactesMethods);
            this.Controls.Add(this.detectColorQuantizationMethod);
            this.Controls.Add(this.detectFontTypeMethod);
            this.Controls.Add(this.detectWordMappingsMethods);
            this.Controls.Add(this.detectOpenSpacesMethods);
            this.Controls.Add(this.chosenDocumentLabel);
            this.Controls.Add(this.choseDocument);
            this.Controls.Add(this.detectAnyMethod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button detectCharactersScaleGeneralMethod;
        private System.Windows.Forms.Button detectUnderlineGeneralMethod;
        private System.Windows.Forms.Button detectSentenceBorderGeneralMethod;
        private System.Windows.Forms.Button detectParagraphBorderGeneralMethod;
    }
}

