using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class DetectCoding : Form
    {
        public bool canChange;
        public string documentName = "No document chosen!";
        public string documentPath = "";
        public string fileTimeLogsName                                        = "Execution Time Logs.txt";
        public string documentTimeLogsPath = Directory.GetCurrentDirectory() + "/Execution Time Logs.txt";

        public bool enableConreteMethodsCheck = false;
        public bool enableTimeExecutionLog = true;

        public bool enableWordMapping = false;
        public bool enableColorQuantization = false;
        public bool enableUnicodes = false;

        #region check for paragraph border
        public WdLineStyle[] lineParagraphBorderStyleMap = new WdLineStyle[16];
        public Color[] colorParagraphBorderStyleMap = new Color[16];    //colorParagraphBorderStringMap values
        public string[] colorParagraphBorderStringMap = new string[16];
        #endregion
        #region check for sentence border
        public WdLineStyle[] lineSentenceBorderStyleMap = new WdLineStyle[16];
        public Color[] colorSentenceBorderStyleMap = new Color[16];    //colorSentenceBorderStringMap values
        public string[] colorSentenceBorderStringMap = new string[16];
        #endregion
        #region check for underline
        public WdUnderline[] lineUnderlineStyleMap = new WdUnderline[16];
        public Color[] colorUnderlineStyleMap = new Color[16];    //colorUnderlineStringMap values
        public string[] colorUnderlineStringMap = new string[16];
        #endregion
        #region check for open spaces
        int openSpacesWordsTotal = 0;
        int openSpacesWordsPotential = 0;
        int openSpacesSentencesTotal = 0;
        int openSpacesSentencesPotential = 0;
        #endregion
        #region check for word mapping
        int wordMappingOption1Total = 0;
        int wordMappingOption1Potential = 0;
        int wordMappingOption2Total = 0;
        int wordMappingOption2Potential = 0;
        String[] vowels = new String[] { "a", "e", "i", "o", "u" };
        #endregion
        #region check for font type
        int fontTypeTotal = 0;
        int fontTypePotential = 0;
        Dictionary<string, int> fontTypeDirectoryCount = new Dictionary<string, int>();
        #endregion
        object startTemp0 = null; object startTemp1 = null; object startTemp2 = null; object startTemp3 = null;
        #region check for color quantization
        int colorQuantizationTotal = 0;
        int colorQuantizationLight = 0;
        int colorQuantizationDark = 0;
        double[] colorQuantizationLightLevels = { 0 };
        double[] colorQuantizationDarkLevels = { 0 };
        #endregion
        #region check for invisible characters
        int invisibleCharactersTotal = 0;
        int invisibleCharactersPotential = 0;
        int[] invisibleCharASCII = new int[] { 9, 13, 32 }; //9 - tab;      //13 - new line     //32 - space
        Dictionary<string, int> invisibleCharactersThatTakesNoSpaceHexMap = new Dictionary<string, int>()
        {
            {"200B", 0},    //Zero width characters
            {"200C", 0},    //Zero width non-joiner
            {"200D", 0},    //Zero width joiner
            {"200E", 0},    //Right remark
            {"200F", 0}     //Left remark
        };
        #endregion
        #region check for unicode
        int unicodeNumberSymbols = 0;
        Dictionary<string, int> unicodeDirectoryMap = new Dictionary<string, int>()
        {
            {"A0041", 0}, {"A0391", 0}, {"A0410", 0}, {"A13AA", 0},
            {"B0042", 0}, {"B0392", 0}, {"B0412", 0}, {"B0181", 0},
            {"E0045", 0}, {"E0395", 0}, {"E0415", 0}, {"E13AC", 0},
            {"G0047", 0}, {"G050C", 0}, {"G13C0", 0}, {"G13B6", 0},
            {"H0048", 0}, {"H0397", 0}, {"H041D", 0}, {"H13BB", 0},
            {"I0049", 0}, {"I0399", 0}, {"I04C0", 0}, {"I0406", 0},
            {"M004D", 0}, {"M039C", 0}, {"M041C", 0}, {"M216F", 0},
            {"O004F", 0}, {"O039F", 0}, {"O041E", 0}, {"O0555", 0},
            {"P0050", 0}, {"P0420", 0}, {"P03A1", 0}, {"P01A4", 0},
            {"S0053", 0}, {"S0405", 0}, {"S054F", 0}, {"S13DA", 0},
            {"T0054", 0}, {"T0422", 0}, {"T03A4", 0}, {"T01AC", 0},
            {"j006A", 0}, {"j0458", 0}, {"j03F3", 0}, {"j029D", 0},
            {"o006F", 0}, {"o03BF", 0}, {"o1D0F", 0}, {"o043E", 0}
        };
        #endregion
        #region check for character scaling - general
        Dictionary<string, int> generalScalingMap = new Dictionary<string, int>();
        #endregion
        #region check for underline - general
        Dictionary<string, int> generalUnderlineMap = new Dictionary<string, int>();
        //Dictionary<string, int> generalUnderlineColorMap = new Dictionary<string, int>();
        //Dictionary<string, int> generalUnderlineStyleMap = new Dictionary<string, int>();
        String[] excludeUnderlineChars = new String[] { "g", "j", "p", "q", "y" };
        #endregion
        #region check for sentence border - general
        Dictionary<string, int> generalSentenceLeftBorderMap = new Dictionary<string, int>();
        Dictionary<string, int> generalSentenceRightBorderMap = new Dictionary<string, int>();
        //Dictionary<string, int> generalSentenceLeftBorderColorMap = new Dictionary<string, int>();
        //Dictionary<string, int> generalSentenceLeftBorderStyleMap = new Dictionary<string, int>();            
        #endregion
        #region check for paragraph border - general
        Dictionary<string, int> generalParagraphLeftBorderMap = new Dictionary<string, int>();
        //var generalParagraphLeftBorderColorMap = new Dictionary<string, int>();
        //var generalParagrahpLeftBorderStyleMap = new Dictionary<string, int>();
        Dictionary<string, int> generalParagraphRightBorderMap = new Dictionary<string, int>();
        //var generalParagraphRightBorderColorMap = new Dictionary<string, int>();
        //var generalParagraphRightBorderStyleMap = new Dictionary<string, int>();
        #endregion

        public DetectCoding()
        {
            InitializeComponent();
            canChange = false;
            detectAnyMethod.Enabled = false;
            chosenDocumentLabel.Text = documentName;

            int c250 = 250;
            int c251 = 251;
            int c252 = 252;
            int c253 = 253;
            int c254 = 254;
            int c255 = 255;

            #region check for paragraph border
            //mapping with styles
            lineParagraphBorderStyleMap[0] = WdLineStyle.wdLineStyleDashDot;           //0000
            lineParagraphBorderStyleMap[1] = WdLineStyle.wdLineStyleDashDotDot;        //0001
            lineParagraphBorderStyleMap[2] = WdLineStyle.wdLineStyleDashDotStroked;    //0010
            lineParagraphBorderStyleMap[3] = WdLineStyle.wdLineStyleDashLargeGap;      //0011
            lineParagraphBorderStyleMap[4] = WdLineStyle.wdLineStyleDashSmallGap;      //0100
            lineParagraphBorderStyleMap[5] = WdLineStyle.wdLineStyleDot;               //0101
            lineParagraphBorderStyleMap[6] = WdLineStyle.wdLineStyleDouble;            //0110
            lineParagraphBorderStyleMap[7] = WdLineStyle.wdLineStyleDoubleWavy;        //0111
            lineParagraphBorderStyleMap[8] = WdLineStyle.wdLineStyleInset;             //1000
            lineParagraphBorderStyleMap[9] = WdLineStyle.wdLineStyleOutset;            //1001
            lineParagraphBorderStyleMap[10] = WdLineStyle.wdLineStyleSingle;           //1010
            lineParagraphBorderStyleMap[11] = WdLineStyle.wdLineStyleSingleWavy;       //1011
            lineParagraphBorderStyleMap[12] = WdLineStyle.wdLineStyleThickThinLargeGap;//1100
            lineParagraphBorderStyleMap[13] = WdLineStyle.wdLineStyleThickThinMedGap;  //1101
            lineParagraphBorderStyleMap[14] = WdLineStyle.wdLineStyleThickThinSmallGap;//1110
            lineParagraphBorderStyleMap[15] = WdLineStyle.wdLineStyleTriple;           //1111

            //mapping with colors
            colorParagraphBorderStyleMap[0] = Color.FromArgb(c253, c254, c254);   //0000      0 - 16711421
            colorParagraphBorderStyleMap[1] = Color.FromArgb(c255, c255, c254);   //0001      1 - 16711679
            colorParagraphBorderStyleMap[2] = Color.FromArgb(c255, c254, c255);   //0010      2 - 16776959
            colorParagraphBorderStyleMap[3] = Color.FromArgb(c255, c254, c254);   //0011      3 - 16711423
            colorParagraphBorderStyleMap[4] = Color.FromArgb(c254, c255, c255);   //0100      4 - 16777214
            colorParagraphBorderStyleMap[5] = Color.FromArgb(c254, c255, c254);   //0101      5 - 16711678
            colorParagraphBorderStyleMap[6] = Color.FromArgb(c254, c254, c255);   //0110      6 - 16776958
            colorParagraphBorderStyleMap[7] = Color.FromArgb(c254, c254, c254);   //0111      7 - 16711422
            colorParagraphBorderStyleMap[8] = Color.FromArgb(c254, c254, c253);   //1000      8 - 16645886
            colorParagraphBorderStyleMap[9] = Color.FromArgb(c255, c255, c253);   //1001      9 - 16646143
            colorParagraphBorderStyleMap[10] = Color.FromArgb(c255, c253, c255);  //1010      10- 16776703
            colorParagraphBorderStyleMap[11] = Color.FromArgb(c255, c253, c253);  //1011      11- 16645631
            colorParagraphBorderStyleMap[12] = Color.FromArgb(c253, c255, c255);  //1100      12- 16777213
            colorParagraphBorderStyleMap[13] = Color.FromArgb(c253, c255, c253);  //1101      13- 16646141
            colorParagraphBorderStyleMap[14] = Color.FromArgb(c253, c253, c255);  //1110      14- 16776701
            colorParagraphBorderStyleMap[15] = Color.FromArgb(c253, c253, c253);  //1111      15- 16645629

            for (int k = 0; k < 16; k++)
            {
                var wdcParagraphBorderCOL = (Microsoft.Office.Interop.Word.WdColor)(colorParagraphBorderStyleMap[k].R + 0x100 * colorParagraphBorderStyleMap[k].G + 0x10000 * colorParagraphBorderStyleMap[k].B);
                colorParagraphBorderStringMap[k] = wdcParagraphBorderCOL.ToString();
            }
            #endregion
            #region check for sentence border
            //mapping with styles
            lineSentenceBorderStyleMap[0] = WdLineStyle.wdLineStyleDashDot;         //000
            lineSentenceBorderStyleMap[1] = WdLineStyle.wdLineStyleDashDotDot;      //001
            lineSentenceBorderStyleMap[2] = WdLineStyle.wdLineStyleDashLargeGap;    //010
            lineSentenceBorderStyleMap[3] = WdLineStyle.wdLineStyleDashSmallGap;    //011
            lineSentenceBorderStyleMap[4] = WdLineStyle.wdLineStyleDot;             //100
            lineSentenceBorderStyleMap[5] = WdLineStyle.wdLineStyleInset;           //101
            lineSentenceBorderStyleMap[6] = WdLineStyle.wdLineStyleOutset;          //110
            lineSentenceBorderStyleMap[7] = WdLineStyle.wdLineStyleSingle;          //111

            //mapping with colors
            colorSentenceBorderStyleMap[0] = Color.FromArgb(c250, c251, c251);   //0000      0 - 
            colorSentenceBorderStyleMap[1] = Color.FromArgb(c252, c252, c251);   //0001      1 - 
            colorSentenceBorderStyleMap[2] = Color.FromArgb(c252, c251, c252);   //0010      2 - 
            colorSentenceBorderStyleMap[3] = Color.FromArgb(c252, c251, c251);   //0011      3 - 
            colorSentenceBorderStyleMap[4] = Color.FromArgb(c251, c252, c252);   //0100      4 - 
            colorSentenceBorderStyleMap[5] = Color.FromArgb(c251, c252, c251);   //0101      5 - 
            colorSentenceBorderStyleMap[6] = Color.FromArgb(c251, c251, c252);   //0110      6 - 
            colorSentenceBorderStyleMap[7] = Color.FromArgb(c251, c251, c251);   //0111      7 - 
            colorSentenceBorderStyleMap[8] = Color.FromArgb(c251, c251, c250);   //1000      8 - 
            colorSentenceBorderStyleMap[9] = Color.FromArgb(c252, c252, c250);   //1001      9 - 
            colorSentenceBorderStyleMap[10] = Color.FromArgb(c252, c250, c252);  //1010      10- 
            colorSentenceBorderStyleMap[11] = Color.FromArgb(c252, c250, c250);  //1011      11- 
            colorSentenceBorderStyleMap[12] = Color.FromArgb(c250, c252, c252);  //1100      12- 
            colorSentenceBorderStyleMap[13] = Color.FromArgb(c250, c252, c250);  //1101      13- 
            colorSentenceBorderStyleMap[14] = Color.FromArgb(c250, c250, c252);  //1110      14- 
            colorSentenceBorderStyleMap[15] = Color.FromArgb(c250, c250, c250);  //1111      15- 

            for (int k = 0; k < 16; k++)
            {
                var wdcSentenceBorderCOL = (Microsoft.Office.Interop.Word.WdColor)(colorSentenceBorderStyleMap[k].R + 0x100 * colorSentenceBorderStyleMap[k].G + 0x10000 * colorSentenceBorderStyleMap[k].B);
                colorSentenceBorderStringMap[k] = wdcSentenceBorderCOL.ToString();
            }
            #endregion
            #region check for underline
            lineUnderlineStyleMap[0] = WdUnderline.wdUnderlineDash;           //0000
            lineUnderlineStyleMap[1] = WdUnderline.wdUnderlineDashHeavy;      //0001
            lineUnderlineStyleMap[2] = WdUnderline.wdUnderlineDashLong;       //0010
            lineUnderlineStyleMap[3] = WdUnderline.wdUnderlineDashLongHeavy;  //0011
            lineUnderlineStyleMap[4] = WdUnderline.wdUnderlineDotDash;        //0100
            lineUnderlineStyleMap[5] = WdUnderline.wdUnderlineDotDashHeavy;   //0101
            lineUnderlineStyleMap[6] = WdUnderline.wdUnderlineDotDotDash;     //0110
            lineUnderlineStyleMap[7] = WdUnderline.wdUnderlineDotDotDashHeavy;//0111
            lineUnderlineStyleMap[8] = WdUnderline.wdUnderlineDotted;         //1000
            lineUnderlineStyleMap[9] = WdUnderline.wdUnderlineDottedHeavy;    //1001
            lineUnderlineStyleMap[10] = WdUnderline.wdUnderlineDouble;        //1010
            lineUnderlineStyleMap[11] = WdUnderline.wdUnderlineSingle;        //1011
            lineUnderlineStyleMap[12] = WdUnderline.wdUnderlineThick;         //1100
            lineUnderlineStyleMap[13] = WdUnderline.wdUnderlineWavy;          //1101
            lineUnderlineStyleMap[14] = WdUnderline.wdUnderlineWavyDouble;    //1110
            lineUnderlineStyleMap[15] = WdUnderline.wdUnderlineWavyHeavy;     //1111

            //mapping with colors
            colorUnderlineStyleMap[0] = Color.FromArgb(c253, c254, c254);   //0000      0 - 16711421
            colorUnderlineStyleMap[1] = Color.FromArgb(c255, c255, c254);   //0001      1 - 16711679
            colorUnderlineStyleMap[2] = Color.FromArgb(c255, c254, c255);   //0010      2 - 16776959
            colorUnderlineStyleMap[3] = Color.FromArgb(c255, c254, c254);   //0011      3 - 16711423
            colorUnderlineStyleMap[4] = Color.FromArgb(c254, c255, c255);   //0100      4 - 16777214
            colorUnderlineStyleMap[5] = Color.FromArgb(c254, c255, c254);   //0101      5 - 16711678
            colorUnderlineStyleMap[6] = Color.FromArgb(c254, c254, c255);   //0110      6 - 16776958
            colorUnderlineStyleMap[7] = Color.FromArgb(c254, c254, c254);   //0111      7 - 16711422
            colorUnderlineStyleMap[8] = Color.FromArgb(c254, c254, c253);   //1000      8 - 16645886
            colorUnderlineStyleMap[9] = Color.FromArgb(c255, c255, c253);   //1001      9 - 16646143
            colorUnderlineStyleMap[10] = Color.FromArgb(c255, c253, c255);  //1010      10- 16776703
            colorUnderlineStyleMap[11] = Color.FromArgb(c255, c253, c253);  //1011      11- 16645631
            colorUnderlineStyleMap[12] = Color.FromArgb(c253, c255, c255);  //1100      12- 16777213
            colorUnderlineStyleMap[13] = Color.FromArgb(c253, c255, c253);  //1101      13- 16646141
            colorUnderlineStyleMap[14] = Color.FromArgb(c253, c253, c255);  //1110      14- 16776701
            colorUnderlineStyleMap[15] = Color.FromArgb(c253, c253, c253);  //1111      15- 16645629

            for (int k = 0; k < 16; k++)
            {
                var wdcUnderlineCOL = (Microsoft.Office.Interop.Word.WdColor)(colorUnderlineStyleMap[k].R + 0x100 * colorUnderlineStyleMap[k].G + 0x10000 * colorUnderlineStyleMap[k].B);
                colorUnderlineStringMap[k] = wdcUnderlineCOL.ToString();
            }
            #endregion
        }

        public void resetGlobalCounters()
        {
            //reset default values
            openSpacesWordsTotal = 0;
            openSpacesWordsPotential = 0;
            openSpacesSentencesTotal = 0;
            openSpacesSentencesPotential = 0;
            unicodeNumberSymbols = 0;
            unicodeDirectoryMap = new Dictionary<string, int>()
                {
                    {"A0041", 0}, {"A0391", 0}, {"A0410", 0}, {"A13AA", 0},
                    {"B0042", 0}, {"B0392", 0}, {"B0412", 0}, {"B0181", 0},
                    {"E0045", 0}, {"E0395", 0}, {"E0415", 0}, {"E13AC", 0},
                    {"G0047", 0}, {"G050C", 0}, {"G13C0", 0}, {"G13B6", 0},
                    {"H0048", 0}, {"H0397", 0}, {"H041D", 0}, {"H13BB", 0},
                    {"I0049", 0}, {"I0399", 0}, {"I04C0", 0}, {"I0406", 0},
                    {"M004D", 0}, {"M039C", 0}, {"M041C", 0}, {"M216F", 0},
                    {"O004F", 0}, {"O039F", 0}, {"O041E", 0}, {"O0555", 0},
                    {"P0050", 0}, {"P0420", 0}, {"P03A1", 0}, {"P01A4", 0},
                    {"S0053", 0}, {"S0405", 0}, {"S054F", 0}, {"S13DA", 0},
                    {"T0054", 0}, {"T0422", 0}, {"T03A4", 0}, {"T01AC", 0},
                    {"j006A", 0}, {"j0458", 0}, {"j03F3", 0}, {"j029D", 0},
                    {"o006F", 0}, {"o03BF", 0}, {"o1D0F", 0}, {"o043E", 0}
                };
            invisibleCharactersThatTakesNoSpaceHexMap = new Dictionary<string, int>()
                {                
                    {"200B", 0},    //Zero width characters
                    {"200C", 0},    //Zero width non-joiner
                    {"200D", 0},    //Zero width joiner
                    {"200E", 0},    //Right remark
                    {"200F", 0}     //Left remark
                };
            fontTypeTotal = 0;
            fontTypePotential = 0;
            fontTypeDirectoryCount = new Dictionary<string, int>();
            invisibleCharactersTotal = 0;
            invisibleCharactersPotential = 0;
            colorQuantizationTotal = 0;
            colorQuantizationLight = 0;
            colorQuantizationDark = 0;
            colorQuantizationLightLevels = new double[] { -1 };
            colorQuantizationDarkLevels = new double[] { -1 };
            wordMappingOption1Total = 0;
            wordMappingOption1Potential = 0;
            wordMappingOption2Total = 0;
            wordMappingOption2Potential = 0;
            generalParagraphLeftBorderMap = new Dictionary<string, int>();
            generalParagraphRightBorderMap = new Dictionary<string, int>();
            generalSentenceLeftBorderMap = new Dictionary<string, int>();
            generalSentenceRightBorderMap = new Dictionary<string, int>();
            generalScalingMap = new Dictionary<string, int>();
            generalUnderlineMap = new Dictionary<string, int>();

        }

        //detect steganography method
        private void button1_Click(object sender, EventArgs e)
        {
            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            Microsoft.Office.Interop.Word.Range rangeWords = word.ActiveDocument.Content;
            Microsoft.Office.Interop.Word.Range rangeSentences = word.ActiveDocument.Content;
            Microsoft.Office.Interop.Word.Range rangeSentenceBorderCountWords = word.ActiveDocument.Content;
            Microsoft.Office.Interop.Word.Range rangeSentenceBorderCountSentences = word.ActiveDocument.Content;
            Microsoft.Office.Interop.Word.Range rangeSentenceGeneralBorderCountSentences = word.ActiveDocument.Content;
            // Define a range of 1 character. 
            object start = 0; object startGeneral = 0; int startGeneralCount = 0;
            object end = 1; object endGeneral = 3; int endGeneralCount = 3;
            Microsoft.Office.Interop.Word.Range rngGeneralUnderline = docs.Range(ref start, ref end);
            Microsoft.Office.Interop.Word.Range rngGeneralUnderlineAll = docs.Range(ref start);
            Microsoft.Office.Interop.Word.Range rngUnderline = docs.Range(ref start, ref end);
            Microsoft.Office.Interop.Word.Range rngUnderlineAll = docs.Range(ref start);
            Microsoft.Office.Interop.Word.Range rngWhiteSpaces = word.ActiveDocument.Content;
            Microsoft.Office.Interop.Word.Range rngGeneralScaling = docs.Range(ref start, ref end);
            Microsoft.Office.Interop.Word.Range rngGeneralScalingAll = docs.Range(ref start);
            Microsoft.Office.Interop.Word.Range rngScaling = docs.Range(ref start, ref end);
            Microsoft.Office.Interop.Word.Range rngScalingAll = docs.Range(ref start);
            Microsoft.Office.Interop.Word.Range rngGeneral = docs.Range(ref startGeneral, ref endGeneral);
            Microsoft.Office.Interop.Word.Range rngGeneralAll = docs.Range(ref startGeneral);
            Microsoft.Office.Interop.Word.Range rngGeneralTemp1 = null; 
            Microsoft.Office.Interop.Word.Range rngGeneralTemp2 = null; 
            Microsoft.Office.Interop.Word.Range rngGeneralTemp3 = null;
            Microsoft.Office.Interop.Word.Range rngFirstLetter = word.ActiveDocument.Content;
            Microsoft.Office.Interop.Word.Range rngSecondLetter = word.ActiveDocument.Content;
            
            #region check for paragraph border
            //approach 1: first we check if our concrete algotirtam is used            
            int codedParagraphBorder = 0;
            int numCheckParagraphBorder = 0;
            if (enableConreteMethodsCheck == true)
            {
                foreach (Microsoft.Office.Interop.Word.Paragraph aPar in docs.Paragraphs)
                {
                    //if after 5 paragraphs a code is still not detected, then skip this coding check
                    numCheckParagraphBorder++;
                    if (numCheckParagraphBorder == 5)
                        break;

                    bool leftBorderParagraphBorderC = false;
                    bool leftBorderParagraphBorderS = false;
                    bool rightBorderParagraphBorderC = false;
                    bool rightBorderParagraphBorderS = false;

                    Microsoft.Office.Interop.Word.Range parRng = aPar.Range;
                    var leftBorderParagraph = WdBorderType.wdBorderLeft;
                    var rightBorderParagraph = WdBorderType.wdBorderRight;

                    string leftBordColor = parRng.Borders[leftBorderParagraph].Color.ToString();
                    string rightBordColor = parRng.Borders[rightBorderParagraph].Color.ToString();
                    //check if border colors are coded
                    for (int countColo = 0; countColo < colorParagraphBorderStringMap.Length; countColo++)
                    {
                        if (colorParagraphBorderStringMap[countColo] == leftBordColor)
                        {
                            leftBorderParagraphBorderC = true;
                        }
                        if (colorParagraphBorderStringMap[countColo] == rightBordColor)
                        {
                            rightBorderParagraphBorderC = true;
                        }
                    }

                    string leftBordStyle = parRng.Borders[leftBorderParagraph].LineStyle.ToString();
                    string rightBordStyle = parRng.Borders[rightBorderParagraph].LineStyle.ToString();
                    //check if border styles are coded
                    for (int countStyl = 0; countStyl < lineParagraphBorderStyleMap.Length; countStyl++)
                    {
                        if (lineParagraphBorderStyleMap[countStyl].ToString() == leftBordStyle)
                        {
                            leftBorderParagraphBorderS = true;
                        }
                        if (lineParagraphBorderStyleMap[countStyl].ToString() == rightBordStyle)
                        {
                            rightBorderParagraphBorderS = true;
                        }
                    }

                    //[4 bis for leftBorderColor][4 bits for leftBorderStyle][4 bis for rightBorderColor][4 bits for rightBorderStyle]
                    //ascii to char conversion (binary vo decimal vo ascii)

                    if (leftBorderParagraphBorderC == true && leftBorderParagraphBorderS == true &&
                        rightBorderParagraphBorderC == true && rightBorderParagraphBorderS == true)
                    {
                        codedParagraphBorder++;
                        break;
                    }
                }
            }
            //approach 2: then we are doing more general check if pargraph border is susposious
            foreach (Microsoft.Office.Interop.Word.Paragraph aGeneralPar in docs.Paragraphs)
            {
                Microsoft.Office.Interop.Word.Range parGeneralRng = aGeneralPar.Range;
                var leftBorderGeneralParagraph = WdBorderType.wdBorderLeft;
                var rightBorderGeneralParagraph = WdBorderType.wdBorderRight;

                string leftBordGeneralColor = parGeneralRng.Borders[leftBorderGeneralParagraph].Color.ToString();
                string leftBordGeneralStyle = parGeneralRng.Borders[leftBorderGeneralParagraph].LineStyle.ToString();
                //count left border color - left border style occurencies
                if (generalParagraphLeftBorderMap.ContainsKey(leftBordGeneralColor + "-" + leftBordGeneralStyle))
                {
                    int generalLeftBorderColorCount = generalParagraphLeftBorderMap[leftBordGeneralColor + "-" + leftBordGeneralStyle] + 1;
                    generalParagraphLeftBorderMap[leftBordGeneralColor + "-" + leftBordGeneralStyle] = generalLeftBorderColorCount;
                }
                else
                {
                    generalParagraphLeftBorderMap.Add(leftBordGeneralColor + "-" + leftBordGeneralStyle, 1);
                }

                /*string leftBordGeneralColor = parGeneralRng.Borders[leftBorderGeneralParagraph].Color.ToString();
                string leftBordGeneralStyle = parGeneralRng.Borders[leftBorderGeneralParagraph].LineStyle.ToString();
                //count left border color occurencies
                if (generalParagraphLeftBorderColorMap.ContainsKey(leftBordGeneralColor))
                {
                    int generalLeftBorderColorCount = generalParagraphLeftBorderColorMap[leftBordGeneralColor] + 1;
                    generalParagraphLeftBorderColorMap[leftBordGeneralColor] = generalLeftBorderColorCount;
                }
                else
                {
                    generalParagraphLeftBorderColorMap.Add(leftBordGeneralColor, 1);
                }
                //count left border style occurencies
                if (generalParagrahpLeftBorderStyleMap.ContainsKey(leftBordGeneralStyle))
                {
                    int generalLeftBorderStyleCount = generalParagrahpLeftBorderStyleMap[leftBordGeneralStyle] + 1;
                    generalParagrahpLeftBorderStyleMap[leftBordGeneralStyle] = generalLeftBorderStyleCount;
                }
                else
                {
                    generalParagrahpLeftBorderStyleMap.Add(leftBordGeneralStyle, 1);
                }*/


                string rightBordGeneralColor = parGeneralRng.Borders[rightBorderGeneralParagraph].Color.ToString();
                string rightBordGeneralStyle = parGeneralRng.Borders[rightBorderGeneralParagraph].LineStyle.ToString();
                //count right border color - right border style occurencies
                if (generalParagraphRightBorderMap.ContainsKey(rightBordGeneralColor + "-" + rightBordGeneralStyle))
                {
                    int generalLeftBorderColorCount = generalParagraphRightBorderMap[rightBordGeneralColor + "-" + rightBordGeneralStyle] + 1;
                    generalParagraphRightBorderMap[rightBordGeneralColor + "-" + rightBordGeneralStyle] = generalLeftBorderColorCount;
                }
                else
                {
                    generalParagraphRightBorderMap.Add(rightBordGeneralColor + "-" + rightBordGeneralStyle, 1);
                }                

                /*string rightBordGeneralColor = parGeneralRng.Borders[rightBorderGeneralParagraph].Color.ToString();
                string rightBordGeneralStyle = parGeneralRng.Borders[rightBorderGeneralParagraph].LineStyle.ToString();
                //count right border color occurencies
                if (generalParagraphRightBorderColorMap.ContainsKey(rightBordGeneralColor))
                {
                    int generalRightBorderColorCount = generalParagraphRightBorderColorMap[rightBordGeneralColor] + 1;
                    generalParagraphRightBorderColorMap[rightBordGeneralColor] = generalRightBorderColorCount;
                }
                else
                {
                    generalParagraphRightBorderColorMap.Add(rightBordGeneralColor, 1);
                }
                //count right border style occurencies
                if (generalParagraphRightBorderStyleMap.ContainsKey(rightBordGeneralStyle))
                {
                    int generalRightBorderStyleCount = generalParagraphRightBorderStyleMap[rightBordGeneralStyle] + 1;
                    generalParagraphRightBorderStyleMap[rightBordGeneralStyle] = generalRightBorderStyleCount;
                }
                else
                {
                    generalParagraphRightBorderStyleMap.Add(rightBordGeneralStyle, 1);
                }*/
            }

            /*int countPotetntialLeftBorderColors = 0;
            foreach (KeyValuePair<string, int> entry in generalParagraphLeftBorderColorMap)
            {
                //if the border color is automatic, then this is a common case, so do not count it in potential cases
                if (entry.Key != WdColor.wdColorAutomatic.ToString())
                {
                    if (entry.Value > 10)
                    {
                        countPotetntialLeftBorderColors++;
                    }
                }
            }
            int countPotetntialLeftBorderStyles = 0;
            foreach (KeyValuePair<string, int> entry in generalParagrahpLeftBorderStyleMap)
            {
                //if the border style is single line, then this is a common case, so do not count it in potential cases
                if (entry.Key != WdLineStyle.wdLineStyleSingle.ToString())
                {
                    if (entry.Value > 10)
                    {
                        countPotetntialLeftBorderStyles++;
                    }
                }
            }*/

            /*int countPotetntialRightBorderColors = 0;
            foreach (KeyValuePair<string, int> entry in generalParagraphRightBorderColorMap)
            {
                //if the border color is automatic, then this is a common case, so do not count it in potential cases
                if (entry.Key != WdColor.wdColorAutomatic.ToString())
                {
                    if (entry.Value > 10)
                    {
                        countPotetntialRightBorderColors++;
                    }
                }
            }
            int countPotetntialRightBorderStyles = 0;
            foreach (KeyValuePair<string, int> entry in generalParagraphRightBorderStyleMap)
            {
                //if the border style is single line, then this is a common case, so do not count it in potential cases
                if (entry.Key != WdLineStyle.wdLineStyleSingle.ToString())
                {
                    if (entry.Value > 10)
                    {
                        countPotetntialRightBorderStyles++;
                    }
                }
            }*/
            #endregion
            #region check for sentence border
            //approach 1: first we check if our concrete algotirtam is used    
            var leftBorderSentenceBorder = WdBorderType.wdBorderLeft;
            int codedSentenceBorder = 0;
            if (enableConreteMethodsCheck == true)
            {
                for (int k = 1; k <= rangeSentenceBorderCountSentences.Sentences.Count; k++)
                {
                    //if after 5 sentences a code is still not detected, then skip this coding check
                    if (k == 6)
                        break;

                    bool leftBorderSentenceBorderC = false;
                    bool leftBorderSentenceBorderS = false;

                    Microsoft.Office.Interop.Word.Range s1 = rangeSentenceBorderCountSentences.Sentences[k];
                    string bordColor = s1.Borders[leftBorderSentenceBorder].Color.ToString();
                    //decode border colors
                    for (int countColo = 0; countColo < colorSentenceBorderStringMap.Length; countColo++)
                    {
                        if (colorSentenceBorderStringMap[countColo] == bordColor)
                        {
                            leftBorderSentenceBorderC = true;
                        }
                    }

                    string bordStyle = s1.Borders[leftBorderSentenceBorder].LineStyle.ToString();
                    //decode border styles                
                    for (int countStyl = 0; countStyl < lineSentenceBorderStyleMap.Length; countStyl++)
                    {
                        if (lineSentenceBorderStyleMap[countStyl].ToString() == bordStyle)
                        {
                            leftBorderSentenceBorderS = true;
                        }
                    }

                    //[4 bis for BorderColor][3 bits for BorderStyle]
                    //ascii to char conversion (binary vo decimal vo ascii)

                    if (leftBorderSentenceBorderC == true && leftBorderSentenceBorderS == true)
                    {
                        codedSentenceBorder++;
                        break;
                    }
                }
            }
            //approach 2: then we are doing more general check if sentence border is susposious
            var leftBorderGeneralSentenceBorder = WdBorderType.wdBorderLeft;
            var rightBorderGeneralSentenceBorder = WdBorderType.wdBorderRight;

            for (int k = 1; k <= rangeSentenceGeneralBorderCountSentences.Sentences.Count; k++)
            {
                Microsoft.Office.Interop.Word.Range s1 = rangeSentenceGeneralBorderCountSentences.Sentences[k];

                string leftBordSentenceGeneralColor = s1.Borders[leftBorderGeneralSentenceBorder].Color.ToString();
                string leftBordSentenceGeneralStyle = s1.Borders[leftBorderGeneralSentenceBorder].LineStyle.ToString();
                if (generalSentenceLeftBorderMap.ContainsKey(leftBordSentenceGeneralColor + "-" + leftBordSentenceGeneralStyle))
                {
                    int generalLeftBorderCount = generalSentenceLeftBorderMap[leftBordSentenceGeneralColor + "-" + leftBordSentenceGeneralStyle] + 1;
                    generalSentenceLeftBorderMap[leftBordSentenceGeneralColor + "-" + leftBordSentenceGeneralStyle] = generalLeftBorderCount;
                }
                else
                {
                    generalSentenceLeftBorderMap.Add(leftBordSentenceGeneralColor + "-" + leftBordSentenceGeneralStyle, 1);
                }

                string rightBordSentenceGeneralColor = s1.Borders[rightBorderGeneralSentenceBorder].Color.ToString();
                string rightBordSentenceGeneralStyle = s1.Borders[rightBorderGeneralSentenceBorder].LineStyle.ToString();
                if (generalSentenceRightBorderMap.ContainsKey(rightBordSentenceGeneralColor + "-" + rightBordSentenceGeneralStyle))
                {
                    int generalRightBorderCount = generalSentenceRightBorderMap[rightBordSentenceGeneralColor + "-" + rightBordSentenceGeneralStyle] + 1;
                    generalSentenceRightBorderMap[rightBordSentenceGeneralColor + "-" + rightBordSentenceGeneralStyle] = generalRightBorderCount;
                }
                else
                {
                    generalSentenceRightBorderMap.Add(rightBordSentenceGeneralColor + "-" + rightBordSentenceGeneralStyle, 1);
                }

                /*string bordSentenceGeneralColor = s1.Borders[leftBorderGeneralSentenceBorder].Color.ToString();
                //count left border color occurencies
                if (generalSentenceLeftBorderColorMap.ContainsKey(bordSentenceGeneralColor))
                {
                    int generalSenLeftBorderColorCount = generalSentenceLeftBorderColorMap[bordSentenceGeneralColor] + 1;
                    generalSentenceLeftBorderColorMap[bordSentenceGeneralColor] = generalSenLeftBorderColorCount;
                }
                else
                {
                    generalSentenceLeftBorderColorMap.Add(bordSentenceGeneralColor, 1);
                }

                string bordSentenceGeneralStyle = s1.Borders[leftBorderGeneralSentenceBorder].LineStyle.ToString();
                //count left border style occurencies
                if (generalSentenceLeftBorderStyleMap.ContainsKey(bordSentenceGeneralStyle))
                {
                    int generalSenLeftBorderStyleCount = generalSentenceLeftBorderStyleMap[bordSentenceGeneralStyle] + 1;
                    generalSentenceLeftBorderStyleMap[bordSentenceGeneralStyle] = generalSenLeftBorderStyleCount;
                }
                else
                {
                    generalSentenceLeftBorderStyleMap.Add(bordSentenceGeneralStyle, 1);
                }*/
            }

            /*int countSentencePotetntialLeftBorderColors = 0;
            foreach (KeyValuePair<string, int> entry in generalSentenceLeftBorderColorMap)
            {
                //if the border color is automatic, then this is a common case, so do not count it in potential cases
                if (entry.Key != WdColor.wdColorAutomatic.ToString())
                {
                    if (entry.Value > 10)
                    {
                        countSentencePotetntialLeftBorderColors++;
                    }
                }
            }

            int countSentencePotetntialLeftBorderStyles = 0;
            foreach (KeyValuePair<string, int> entry in generalSentenceLeftBorderStyleMap)
            {
                //if the border style is single line, then this is a common case, so do not count it in potential cases
                if (entry.Key != WdLineStyle.wdLineStyleSingle.ToString())
                {
                    if (entry.Value > 10)
                    {
                        countSentencePotetntialLeftBorderStyles++;
                    }
                }
            }*/
            #endregion
            #region check for character scaling
            //approach 1: first we check if our concrete algotirtam is used
            int codedScaling = 0;
            int actualSizeScaling = rngScalingAll.Text.Length - 1;
            int numCheckScaling = 0;

            if (enableConreteMethodsCheck == true)
            {
                while ((rngScaling.End - 1) < actualSizeScaling)
                {
                    //if after 8 characters a code is still not detected, then skip this coding check
                    numCheckScaling++;
                    if (numCheckScaling == 9)
                        break;

                    string scaleStyle = rngScaling.Font.Scaling.ToString();
                    if (scaleStyle == "99")
                    {
                        codedScaling++;
                    }
                    else if (scaleStyle == "101")
                    {
                        codedScaling++;
                    }

                    //[scale = 99% if bit is 1, scale = 101% if bit is 0]
                    //ascii to char conversion (binary vo decimal vo ascii)

                    if (codedScaling == 8)
                        break;

                    rngScaling.Select();
                    // Move the start position 1 character.
                    rngScaling.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                    // Move the end position 1 character.
                    rngScaling.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                }
            }
            //approach 2: then we are doing more general check if character scaling is susposious
            int actualSizeGeneralScaling = rngGeneralScalingAll.Text.Length - 1;
            while ((rngGeneralScaling.End - 1) < actualSizeGeneralScaling)
            {
                string scaleStyle = rngGeneralScaling.Font.Scaling.ToString();
                if (generalScalingMap.ContainsKey(scaleStyle))
                {
                    int generalScalingSizeCount = generalScalingMap[scaleStyle] + 1;
                    generalScalingMap[scaleStyle] = generalScalingSizeCount;
                } else
                {
                    generalScalingMap.Add(scaleStyle, 1);
                }

                rngGeneralScaling.Select();
                // Move the start position 1 character.
                rngGeneralScaling.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                // Move the end position 1 character.
                rngGeneralScaling.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
            }

            /*int countPotetntialScaleSizes = 0;
            foreach (KeyValuePair<string, int> entry in generalScalingMap)
            {
                if (entry.Key != "100")
                {
                    if (entry.Value > 10)
                    {
                        countPotetntialScaleSizes++;
                    }
                }                
            }*/
            #endregion
            #region check for underline
            //approach 1: first we check if our concrete algotirtam is used
            int codedUnderline = 0;
            int actualSizeUnderline = rngUnderlineAll.Text.Length - 1;
            int numCheckUnderline = 0;

            if (enableConreteMethodsCheck == true)
            {
                while ((rngUnderline.End - 1) < actualSizeUnderline)
                {
                    if (Array.IndexOf(excludeUnderlineChars, rngUnderline.Text.Trim().ToLower()) > -1)
                    {
                        rngUnderline.Select();
                        // Move the start position 1 character
                        rngUnderline.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                        // Move the end position 1 character
                        rngUnderline.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                        continue;
                    }

                    //if after 5 characters a code is still not detected, then skip this coding check
                    numCheckUnderline++;
                    if (numCheckUnderline == 6)
                        break;

                    bool underlineC = false;
                    bool underlineS = false;

                    string underColor = rngUnderline.Font.UnderlineColor.ToString();
                    //decode underline color
                    for (int countColo = 0; countColo < colorUnderlineStringMap.Length; countColo++)
                    {
                        if (colorUnderlineStringMap[countColo] == underColor)
                        {
                            underlineC = true;
                        }
                    }

                    string underStyle = rngUnderline.Font.Underline.ToString();
                    //decode underline styles                
                    for (int countStyl = 0; countStyl < lineUnderlineStyleMap.Length; countStyl++)
                    {
                        if (lineUnderlineStyleMap[countStyl].ToString() == underStyle)
                        {
                            underlineS = true;
                        }
                    }

                    //[4 bis for UnderlineColor][4 bits for UnderlineStyle]
                    //ascii to char conversion (binary vo decimal vo ascii)

                    if (underlineC == true && underlineS == true)
                    {
                        codedUnderline++;
                        //break;
                    }

                    rngUnderline.Select();
                    // Move the start position 1 character
                    rngUnderline.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                    // Move the end position 1 character
                    rngUnderline.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                }
            }
            //approach 2: then we are doing more general check if character underline is susposious
            int actualSizeGeneralUnderline = rngGeneralUnderlineAll.Text.Length - 1;

            while ((rngGeneralUnderline.End - 1) < actualSizeGeneralUnderline)
            {
                if (Array.IndexOf(excludeUnderlineChars, rngUnderline.Text.Trim().ToLower()) > -1)
                {
                    rngUnderline.Select();
                    // Move the start position 1 character
                    rngUnderline.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                    // Move the end position 1 character
                    rngUnderline.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                    continue;
                }

                string underColor = rngGeneralUnderline.Font.UnderlineColor.ToString();
                string underStyle = rngGeneralUnderline.Font.Underline.ToString();
                if (generalUnderlineMap.ContainsKey(underColor + "-" + underStyle))
                {
                    int generalUnderlineColorCount = generalUnderlineMap[underColor + "-" + underStyle] + 1;
                    generalUnderlineMap[underColor + "-" + underStyle] = generalUnderlineColorCount;
                }
                else
                {
                    generalUnderlineMap.Add(underColor + "-" + underStyle, 1);
                }

                /*string underColor = rngGeneralUnderline.Font.UnderlineColor.ToString();
                if (generalUnderlineColorMap.ContainsKey(underColor))
                {
                    int generalUnderlineColorCount = generalUnderlineColorMap[underColor] + 1;
                    generalUnderlineColorMap[underColor] = generalUnderlineColorCount;
                }
                else
                {
                    generalUnderlineColorMap.Add(underColor, 1);
                }

                string underStyle = rngGeneralUnderline.Font.Underline.ToString();
                if (generalUnderlineStyleMap.ContainsKey(underStyle))
                {
                    int generalUnderlineStyleCount = generalUnderlineStyleMap[underStyle] + 1;
                    generalUnderlineStyleMap[underStyle] = generalUnderlineStyleCount;
                }
                else
                {
                    generalUnderlineStyleMap.Add(underStyle, 1);
                }*/

                rngGeneralUnderline.Select();
                // Move the start position 1 character
                rngGeneralUnderline.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                // Move the end position 1 character
                rngGeneralUnderline.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
            }

            /*int countPotetntialColors = 0;
            foreach (KeyValuePair<string, int> entry in generalUnderlineColorMap)
            {
                //if the underline color is automatic, then this is a common case, so do not count it in potential cases
                if (entry.Key != WdColor.wdColorAutomatic.ToString())
                {
                    if (entry.Value > 10)
                    {
                        countPotetntialColors++;
                    }
                }
            }
            int countPotetntialStyles = 0;
            foreach (KeyValuePair<string, int> entry in generalUnderlineStyleMap)
            {
                if (entry.Key != WdUnderline.wdUnderlineNone.ToString())
                {
                    if (entry.Value > 10)
                    {
                        countPotetntialStyles++;
                    }
                }
            }*/
            #endregion
            #region check for white spaces
            int codedWhiteSpaces = 0;
            if (enableConreteMethodsCheck == true)
            {
                //not sure if works well
                int[] arrayNulls = new int[rngWhiteSpaces.End]; int countNulls = 0;
                int[] arrayOnes = new int[rngWhiteSpaces.End]; int countOnes = 0;
                bool foundDigitZeroes = false;
                bool foundDigitOnes = false;

                //poziciite na sekoi prazni mesta so sina pozadina ke se zacuvuvaat vo nizata arrayNulls
                Microsoft.Office.Interop.Word.Range rangeNulls = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNulls = rangeNulls.Find;
                findNulls.ClearFormatting();
                findNulls.Font.Color = WdColor.wdColorBlack;
                findNulls.Text = " ";
                rangeNulls.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                while (rangeNulls.Find.Found)
                {
                    arrayNulls[countNulls] = rangeNulls.Start;
                    countNulls++;
                    rangeNulls.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                }

                //poziciite na sekoi prazni mesta so crvena pozadina ke se zacuvuvaat vo nizata arrayOnes
                Microsoft.Office.Interop.Word.Range rangeOnes = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findOnes = rangeOnes.Find;
                findOnes.ClearFormatting();
                findOnes.Font.Color = WdColor.wdColorGray90;
                findOnes.Text = " ";
                rangeOnes.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                while (rangeOnes.Find.Found)
                {
                    arrayOnes[countOnes] = rangeOnes.Start;
                    countOnes++;
                    rangeOnes.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                }

                //ke se formira soedineta niza (array) on 1-ovi i 0-li vo zavisnost od poziciite
                int count0 = 0;
                int count1 = 0;
                int count = 0;
                int[] array = new int[countNulls + countOnes];
                while ((count0 < countNulls) && (count1 < countOnes))
                {
                    if (arrayNulls[count0] < arrayOnes[count1])
                    {
                        array[count] = 0;
                        count++;
                        count0++;
                    }
                    else if (arrayNulls[count0] > arrayOnes[count1])
                    {
                        array[count] = 1;
                        count++;
                        count1++;
                    }
                }
                while (count0 < countNulls)
                {
                    array[count] = 0;
                    count++;
                    count0++;
                }
                while (count1 < countOnes)
                {
                    array[count] = 1;
                    count++;
                    count1++;
                }

                string niza = "";
                for (int brojac = 0; brojac < array.Length; brojac++)
                {
                    niza = niza + array[brojac].ToString();
                }
                //stringot da se podeli na po 8 karakteri i dobienite broevi da se pretvorat od ascii vo karakteri
                int dolzinaKrajnaNiza0i1 = niza.Length;
                int kolkuZnaciIma = dolzinaKrajnaNiza0i1 / 8;
                string dekodiranaNiza = "";
                string konkretnaVrednostBinarna;
                int odBinarnoVoDecimalno;

                for (int brojacZemajOsumZnaci = 0; brojacZemajOsumZnaci < kolkuZnaciIma; brojacZemajOsumZnaci++)
                {
                    konkretnaVrednostBinarna = niza.Substring(brojacZemajOsumZnaci * 8, 8);
                    //  odBinarnoVoDecimalno = Convert.ToInt32(konkretnaVrednostBinarna, 2); decimalna vrednost na ascii kodot
                    dekodiranaNiza = dekodiranaNiza + Char.ConvertFromUtf32(Convert.ToInt32(konkretnaVrednostBinarna, 2));
                }

                //proverka dali brojot na znaci odgovara so brojot na znaci vnesen na krajot vo zigot           
                //boite i poziciite na sekoi prazni mesta so odredena boja na pozadina ke se zacuvuvaat vo nizite arrayColor i arrayPos
                Microsoft.Office.Interop.Word.Range rangeNums0 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums0 = rangeNums0.Find;
                Microsoft.Office.Interop.Word.Range rangeNums1 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums1 = rangeNums1.Find;
                Microsoft.Office.Interop.Word.Range rangeNums2 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums2 = rangeNums2.Find;
                Microsoft.Office.Interop.Word.Range rangeNums3 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums3 = rangeNums3.Find;
                Microsoft.Office.Interop.Word.Range rangeNums4 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums4 = rangeNums4.Find;
                Microsoft.Office.Interop.Word.Range rangeNums5 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums5 = rangeNums5.Find;
                Microsoft.Office.Interop.Word.Range rangeNums6 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums6 = rangeNums6.Find;
                Microsoft.Office.Interop.Word.Range rangeNums7 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums7 = rangeNums7.Find;
                Microsoft.Office.Interop.Word.Range rangeNums8 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums8 = rangeNums8.Find;
                Microsoft.Office.Interop.Word.Range rangeNums9 = word.ActiveDocument.Content;
                Microsoft.Office.Interop.Word.Find findNums9 = rangeNums9.Find;

                int[] arrayPos = new int[6]; int countNums = 0;
                int[] arrayColor = new int[6];

                int brojac6 = 6; //
                                 // while (brojac6 > 0)
                {
                    findNums0.ClearFormatting();
                    findNums0.Font.Color = WdColor.wdColorGray05;
                    findNums0.Text = " ";
                    rangeNums0.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums0.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums0.Start;
                        arrayColor[countNums] = 0;
                        countNums++;
                        rangeNums0.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }
                    findNums1.ClearFormatting();
                    findNums1.Font.Color = WdColor.wdColorGray15;
                    findNums1.Text = " ";
                    rangeNums1.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums1.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums1.Start;
                        arrayColor[countNums] = 1;
                        countNums++;
                        rangeNums1.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }
                    findNums2.ClearFormatting();
                    findNums2.Font.Color = WdColor.wdColorGray25;
                    findNums2.Text = " ";
                    rangeNums2.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums2.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums2.Start;
                        arrayColor[countNums] = 2;
                        countNums++;
                        rangeNums2.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }
                    findNums3.ClearFormatting();
                    findNums3.Font.Color = WdColor.wdColorGray35;
                    findNums3.Text = " ";
                    rangeNums3.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums3.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums3.Start;
                        arrayColor[countNums] = 3;
                        countNums++;
                        rangeNums3.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }
                    findNums4.ClearFormatting();
                    findNums4.Font.Color = WdColor.wdColorGray45;
                    findNums4.Text = " ";
                    rangeNums4.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums4.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums4.Start;
                        arrayColor[countNums] = 4;
                        countNums++;
                        rangeNums4.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }
                    findNums5.ClearFormatting();
                    findNums5.Font.Color = WdColor.wdColorGray55;
                    findNums5.Text = " ";
                    rangeNums5.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums5.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums5.Start;
                        arrayColor[countNums] = 5;
                        countNums++;
                        rangeNums5.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }
                    findNums6.ClearFormatting();
                    findNums6.Font.Color = WdColor.wdColorGray65;
                    findNums6.Text = " ";
                    rangeNums6.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums6.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums6.Start;
                        arrayColor[countNums] = 6;
                        countNums++;
                        rangeNums6.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }
                    findNums7.ClearFormatting();
                    findNums7.Font.Color = WdColor.wdColorGray75;
                    findNums7.Text = " ";
                    rangeNums7.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums7.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums7.Start;
                        arrayColor[countNums] = 7;
                        countNums++;
                        rangeNums7.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }
                    findNums8.ClearFormatting();
                    findNums8.Font.Color = WdColor.wdColorGray85;
                    findNums8.Text = " ";
                    rangeNums8.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums8.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums8.Start;
                        arrayColor[countNums] = 8;
                        countNums++;
                        rangeNums8.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }
                    findNums9.ClearFormatting();
                    findNums9.Font.Color = WdColor.wdColorGray95;
                    findNums9.Text = " ";
                    rangeNums9.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    while (rangeNums9.Find.Found)
                    {
                        arrayPos[countNums] = rangeNums9.Start;
                        arrayColor[countNums] = 9;
                        countNums++;
                        rangeNums9.Find.Execute(ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                    }

                    brojac6--;
                }
                /*
                            string test1 = "";
                            for (int index = 0; index < arrayPos.Length; index++)
                            {
                                test1 = test1 + " pozicija: " + arrayPos[index].ToString() + " boja: " + arrayColor[index].ToString() + "\n";
                            }
                            MessageBox.Show(test1);
                */
                //sortiranje na nizite
                int i, j, vrednostPos, vrednostCol, numLength = arrayPos.Length;
                for (j = 1; j < numLength; j++)
                {
                    vrednostPos = arrayPos[j];
                    vrednostCol = arrayColor[j];
                    for (i = j - 1; (i >= 0) && (arrayPos[i] > vrednostPos); i--)
                    {
                        arrayPos[i + 1] = arrayPos[i];
                        arrayColor[i + 1] = arrayColor[i];
                    }
                    arrayPos[i + 1] = vrednostPos;
                    arrayColor[i + 1] = vrednostCol;
                }
                /*
                            string test = "";
                            for (int index = 0; index < arrayPos.Length; index++)
                            {
                                test = test + " pozicija: " + arrayPos[index].ToString() + " boja: " + arrayColor[index].ToString() + "\n";
                            } 
                            MessageBox.Show(test);
                */
                string kodiranBroj = "";
                //nizata arrayColor go sodrzi kodiraniot broj na znaci
                for (int index = 0; index < arrayColor.Length; index++)
                {
                    kodiranBroj = kodiranBroj + arrayColor[index].ToString();
                }

                //ureduvanje na formatot na kodiranBroj da se sovpaga so formatot sto e na krajot od zigot
                int countElements = countNulls + countOnes;
                string countElementsSting = countElements.ToString();
                int kolkuNuliPlusElements = 0;
                int proverkaElements = countElements;
                while (proverkaElements > 0)
                {
                    kolkuNuliPlusElements++;
                    proverkaElements = proverkaElements / 10;
                }
                int brojNaNenultiCifriElements = kolkuNuliPlusElements; //primer za 1234, brojNaNenultiCifriElements = 4 cifri
                kolkuNuliPlusElements = 6 - kolkuNuliPlusElements;      //primer za 1234 treba da se dodade 001234, pa = 2
                while (kolkuNuliPlusElements > 0)
                {
                    countElementsSting = "0" + countElementsSting;
                    kolkuNuliPlusElements--;
                }

                if (niza != "" && countElementsSting == kodiranBroj)
                {
                    codedWhiteSpaces++;
                }
            }
            #endregion
            #region check for open spaces (words + sentences)
            for (int k = 1; k <= rangeWords.Words.Count; k++)
            {
                Microsoft.Office.Interop.Word.Range w1 = rangeWords.Words[k];
                string wordsText = w1.Text.TrimEnd('\r');
                if (wordsText.Length > 0)
                {
                    openSpacesWordsTotal++;
                    string trimmedWordsText = wordsText.TrimEnd(' ');
                    if (wordsText.Length - trimmedWordsText.Length > 1)
                    {
                        openSpacesWordsPotential++;
                    }
                }
            }
            for (int k = 1; k <= rangeSentences.Sentences.Count; k++)
            {                
                Microsoft.Office.Interop.Word.Range s1 = rangeSentences.Sentences[k];
                string sentencesText = s1.Text.TrimEnd('\r');
                if (sentencesText.Length > 0)
                {
                    openSpacesSentencesTotal++;
                    string trimmedSentencesText = sentencesText.TrimEnd(' ');
                    if (sentencesText.Length - trimmedSentencesText.Length > 1)
                    {
                        openSpacesSentencesPotential++;
                    }
                }
            }
            #endregion
            #region check for invisible characters and for color quantization and for unicode and for invisible characters that does not takes space (MS Word Symbols[9])
            //get each sequences of each 3 characters and: do the check if the middle character is invisible + on each new sequence check the brigthness
            //for example: 123456, invisible characters loops throught 123, 234, 234, 456;
            //                     color quantizations, unicode and MS Word Symbols[9] loops throught every third sequence 123, 456
            int actualSizeGeneral = rngGeneralAll.Text.Length - 1;

            int checkEachCharacterIndividually = 0;

            while ((rngGeneral.End - 1) < actualSizeGeneral)
            {
                rngGeneral.Select();

                startTemp0 = (object)(startGeneralCount);
                startTemp1 = (object)(startGeneralCount + 1);
                startTemp2 = (object)(startGeneralCount + 2);
                startTemp3 = (object)(startGeneralCount + 3);
                rngGeneralTemp1 = docs.Range(ref startTemp0, ref startTemp1);
                rngGeneralTemp2 = docs.Range(ref startTemp1, ref startTemp2);
                rngGeneralTemp3 = docs.Range(ref startTemp2, ref startTemp3);                
                string color1 = rngGeneralTemp1.Font.Color.ToString();
                string color2 = rngGeneralTemp2.Font.Color.ToString();
                string color3 = rngGeneralTemp3.Font.Color.ToString();

                bool byte1proceed = true;
                if (rngGeneralTemp1 == null || rngGeneralTemp1.Text == null)
                    byte1proceed = false;
                bool byte2proceed = true;
                if (rngGeneralTemp2 == null || rngGeneralTemp2.Text == null)
                    byte2proceed = false;
                bool byte3proceed = true;
                if (rngGeneralTemp3 == null || rngGeneralTemp3.Text == null)
                    byte3proceed = false;

                byte[] asciiBytes1 = null;
                byte[] asciiBytes2 = null;
                byte[] asciiBytes3 = null;

                //for each third sequence, calculate the brigtness based on RGB values 
                //https://stackoverflow.com/questions/596216/formula-to-determine-brightness-of-rgb-color
                //for each third sequence, calculate the UNICODE value for each character + count and update the unicodeDirectoryMap
                //for each third sequence, check and count the invisible symbols that do not takes space (MS Word Symbols[9])
                if (checkEachCharacterIndividually == 0 || (checkEachCharacterIndividually) % 3 == 0)
                {
                    if (byte1proceed == true)
                    {
                        colorQuantizationTotal += 1;
                        asciiBytes1 = Encoding.ASCII.GetBytes(rngGeneralTemp1.Text);

                        if (enableColorQuantization == true)
                        {
                            var systemColor1 = ColorTranslator.FromWin32((int)rngGeneralTemp1.Font.Color);
                            var brigthness1 = (0.2126 * (systemColor1.R / 255.0) + 0.7152 * (systemColor1.G / 255.0) + 0.0722 * (systemColor1.B / 255.0));

                            if (rngGeneralTemp1.Font.Color != WdColor.wdColorAutomatic)
                            {
                                if (brigthness1 < 0.5)
                                {
                                    colorQuantizationDark++;
                                    if (Array.IndexOf(colorQuantizationDarkLevels, brigthness1) == -1)
                                    {
                                        //push into array
                                        Array.Resize(ref colorQuantizationDarkLevels, colorQuantizationDarkLevels.Length + 1);
                                        colorQuantizationDarkLevels[colorQuantizationDarkLevels.GetUpperBound(0)] = brigthness1;
                                    }
                                }
                                else
                                {
                                    colorQuantizationLight++;
                                    if (Array.IndexOf(colorQuantizationLightLevels, brigthness1) == -1)
                                    {
                                        //push into array
                                        Array.Resize(ref colorQuantizationLightLevels, colorQuantizationLightLevels.Length + 1);
                                        colorQuantizationLightLevels[colorQuantizationLightLevels.GetUpperBound(0)] = brigthness1;
                                    }
                                }
                            }
                        }

                        //convert to unicodes and increase the dictionary where the current character is a key
                        String unicodeVal1 = rngGeneralTemp1.Text + asciiBytes1[0].ToString("X4");
                        //check and count occrencies for the unicode approach
                        if (enableUnicodes == true && unicodeDirectoryMap.ContainsKey(unicodeVal1))
                        {
                            int unicodeCount1 = unicodeDirectoryMap[unicodeVal1] + 1;
                            unicodeDirectoryMap[unicodeVal1] = unicodeCount1;
                        }
                        //check and count occrencies for the invisible symbols that do not takes space (MS Word Symbols[9]) approach
                        if (invisibleCharactersThatTakesNoSpaceHexMap.ContainsKey(unicodeVal1))
                        {
                            int wordSymbols1 = invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal1] + 1;
                            invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal1] = wordSymbols1;
                        }
                    }

                    if (byte2proceed == true)
                    {
                        colorQuantizationTotal += 1;
                        asciiBytes2 = Encoding.ASCII.GetBytes(rngGeneralTemp2.Text);

                        if (enableColorQuantization == true)
                        {
                            var systemColor2 = ColorTranslator.FromWin32((int)rngGeneralTemp2.Font.Color);
                            var brigthness2 = (0.2126 * (systemColor2.R / 255.0) + 0.7152 * (systemColor2.G / 255.0) + 0.0722 * (systemColor2.B / 255.0));
                            if (rngGeneralTemp2.Font.Color != WdColor.wdColorAutomatic)
                            {
                                if (brigthness2 < 0.5)
                                {
                                    colorQuantizationDark++;
                                    if (Array.IndexOf(colorQuantizationDarkLevels, brigthness2) == -1)
                                    {
                                        //push into array
                                        Array.Resize(ref colorQuantizationDarkLevels, colorQuantizationDarkLevels.Length + 1);
                                        colorQuantizationDarkLevels[colorQuantizationDarkLevels.GetUpperBound(0)] = brigthness2;
                                    }
                                }
                                else
                                {
                                    colorQuantizationLight++;
                                    if (Array.IndexOf(colorQuantizationLightLevels, brigthness2) == -1)
                                    {
                                        //push into array
                                        Array.Resize(ref colorQuantizationLightLevels, colorQuantizationLightLevels.Length + 1);
                                        colorQuantizationLightLevels[colorQuantizationLightLevels.GetUpperBound(0)] = brigthness2;
                                    }
                                }
                            }
                        }

                        //convert to unicodes and increase the dictionary where the current character is a key
                        String unicodeVal2 = rngGeneralTemp2.Text + asciiBytes2[0].ToString("X4");
                        //check and count occrencies for the unicode approach
                        if (enableUnicodes == true && unicodeDirectoryMap.ContainsKey(unicodeVal2))
                        {
                            int unicodeCount2 = unicodeDirectoryMap[unicodeVal2] + 1;
                            unicodeDirectoryMap[unicodeVal2] = unicodeCount2;
                        }
                        //check and count occrencies for the invisible symbols that do not takes space (MS Word Symbols[9]) approach
                        if (invisibleCharactersThatTakesNoSpaceHexMap.ContainsKey(unicodeVal2))
                        {
                            int wordSymbols2 = invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal2] + 1;
                            invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal2] = wordSymbols2;
                        }
                    }

                    if (byte3proceed == true)
                    {
                        colorQuantizationTotal += 1;
                        asciiBytes3 = Encoding.ASCII.GetBytes(rngGeneralTemp3.Text);

                        if (enableColorQuantization == true)
                        {
                            var systemColor3 = ColorTranslator.FromWin32((int)rngGeneralTemp3.Font.Color);
                            var brigthness3 = (0.2126 * (systemColor3.R / 255.0) + 0.7152 * (systemColor3.G / 255.0) + 0.0722 * (systemColor3.B / 255.0));
                            if (rngGeneralTemp3.Font.Color != WdColor.wdColorAutomatic)
                            {
                                if (brigthness3 < 0.5)
                                {
                                    colorQuantizationDark++;
                                    if (Array.IndexOf(colorQuantizationDarkLevels, brigthness3) == -1)
                                    {
                                        //push into array
                                        Array.Resize(ref colorQuantizationDarkLevels, colorQuantizationDarkLevels.Length + 1);
                                        colorQuantizationDarkLevels[colorQuantizationDarkLevels.GetUpperBound(0)] = brigthness3;
                                    }
                                }
                                else
                                {
                                    colorQuantizationLight++;
                                    if (Array.IndexOf(colorQuantizationLightLevels, brigthness3) == -1)
                                    {
                                        //push into array
                                        Array.Resize(ref colorQuantizationLightLevels, colorQuantizationLightLevels.Length + 1);
                                        colorQuantizationLightLevels[colorQuantizationLightLevels.GetUpperBound(0)] = brigthness3;
                                    }
                                }
                            }
                        }

                        //convert to unicodes and increase the dictionary where the current character is a key
                        String unicodeVal3 = rngGeneralTemp3.Text + asciiBytes3[0].ToString("X4");
                        //check and count occrencies for the unicode approach
                        if (enableUnicodes == true && unicodeDirectoryMap.ContainsKey(unicodeVal3))
                        {
                            int unicodeCount3 = unicodeDirectoryMap[unicodeVal3] + 1;
                            unicodeDirectoryMap[unicodeVal3] = unicodeCount3;
                        }
                        //check and count occrencies for the invisible symbols that do not takes space (MS Word Symbols[9]) approach
                        if (invisibleCharactersThatTakesNoSpaceHexMap.ContainsKey(unicodeVal3))
                        {
                            int wordSymbols3 = invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal3] + 1;
                            invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal3] = wordSymbols3;
                        }
                    }                    
                }
                checkEachCharacterIndividually++;

                //if the middle character is invisible, then count this situation in total cases
                if (byte2proceed == true && asciiBytes2 != null && asciiBytes2.Length == 1 && Array.IndexOf(invisibleCharASCII, asciiBytes2[0]) > -1)
                {
                    invisibleCharactersTotal++;
                    //if the 1st and 3th character are with the same color and if
                    //if the color of the middle character is different then the color of the 1st and 3th character then this is potential case
                    if (color1 == color3 && color1 != color2)
                    {
                        invisibleCharactersPotential++;
                    }
                }
                
                // Move the start position 1 character
                rngGeneral.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                // Move the end position 1 character
                rngGeneral.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                startGeneralCount++;
                endGeneralCount++;
            }

            if (enableUnicodes == true)
            {
                //check if there are occurencies for the same character but different encodings and if there are more then 0 occurencies, get a note of this
                //for example: differentOccurencies_A will hold the cout of how many different encodings for character A are present in the doc
                int differentOccurencies_A = 0;
                if (unicodeDirectoryMap["A0041"] > 0)
                    differentOccurencies_A++;
                if (unicodeDirectoryMap["A0391"] > 0)
                    differentOccurencies_A++;
                if (unicodeDirectoryMap["A0410"] > 0)
                    differentOccurencies_A++;
                if (unicodeDirectoryMap["A13AA"] > 0)
                    differentOccurencies_A++;

                int differentOccurencies_B = 0;
                if (unicodeDirectoryMap["B0042"] > 0)
                    differentOccurencies_B++;
                if (unicodeDirectoryMap["B0392"] > 0)
                    differentOccurencies_B++;
                if (unicodeDirectoryMap["B0412"] > 0)
                    differentOccurencies_B++;
                if (unicodeDirectoryMap["B0181"] > 0)
                    differentOccurencies_B++;

                int differentOccurencies_E = 0;
                if (unicodeDirectoryMap["E0045"] > 0)
                    differentOccurencies_E++;
                if (unicodeDirectoryMap["E0395"] > 0)
                    differentOccurencies_E++;
                if (unicodeDirectoryMap["E0415"] > 0)
                    differentOccurencies_E++;
                if (unicodeDirectoryMap["E13AC"] > 0)
                    differentOccurencies_E++;

                int differentOccurencies_G = 0;
                if (unicodeDirectoryMap["G0047"] > 0)
                    differentOccurencies_G++;
                if (unicodeDirectoryMap["G050C"] > 0)
                    differentOccurencies_G++;
                if (unicodeDirectoryMap["G13C0"] > 0)
                    differentOccurencies_G++;
                if (unicodeDirectoryMap["G13B6"] > 0)
                    differentOccurencies_G++;

                int differentOccurencies_H = 0;
                if (unicodeDirectoryMap["H0048"] > 0)
                    differentOccurencies_H++;
                if (unicodeDirectoryMap["H0397"] > 0)
                    differentOccurencies_H++;
                if (unicodeDirectoryMap["H041D"] > 0)
                    differentOccurencies_H++;
                if (unicodeDirectoryMap["H13BB"] > 0)
                    differentOccurencies_H++;

                int differentOccurencies_I = 0;
                if (unicodeDirectoryMap["I0049"] > 0)
                    differentOccurencies_I++;
                if (unicodeDirectoryMap["I0399"] > 0)
                    differentOccurencies_I++;
                if (unicodeDirectoryMap["I04C0"] > 0)
                    differentOccurencies_I++;
                if (unicodeDirectoryMap["I0406"] > 0)
                    differentOccurencies_I++;

                int differentOccurencies_M = 0;
                if (unicodeDirectoryMap["M004D"] > 0)
                    differentOccurencies_M++;
                if (unicodeDirectoryMap["M039C"] > 0)
                    differentOccurencies_M++;
                if (unicodeDirectoryMap["M041C"] > 0)
                    differentOccurencies_M++;
                if (unicodeDirectoryMap["M216F"] > 0)
                    differentOccurencies_M++;

                int differentOccurencies_O = 0;
                if (unicodeDirectoryMap["O004F"] > 0)
                    differentOccurencies_O++;
                if (unicodeDirectoryMap["O039F"] > 0)
                    differentOccurencies_O++;
                if (unicodeDirectoryMap["O041E"] > 0)
                    differentOccurencies_O++;
                if (unicodeDirectoryMap["O0555"] > 0)
                    differentOccurencies_O++;

                int differentOccurencies_P = 0;
                if (unicodeDirectoryMap["P0050"] > 0)
                    differentOccurencies_P++;
                if (unicodeDirectoryMap["P0420"] > 0)
                    differentOccurencies_P++;
                if (unicodeDirectoryMap["P03A1"] > 0)
                    differentOccurencies_P++;
                if (unicodeDirectoryMap["P01A4"] > 0)
                    differentOccurencies_P++;

                int differentOccurencies_S = 0;
                if (unicodeDirectoryMap["S0053"] > 0)
                    differentOccurencies_S++;
                if (unicodeDirectoryMap["S0405"] > 0)
                    differentOccurencies_S++;
                if (unicodeDirectoryMap["S054F"] > 0)
                    differentOccurencies_S++;
                if (unicodeDirectoryMap["S13DA"] > 0)
                    differentOccurencies_S++;

                int differentOccurencies_T = 0;
                if (unicodeDirectoryMap["T0054"] > 0)
                    differentOccurencies_T++;
                if (unicodeDirectoryMap["T0422"] > 0)
                    differentOccurencies_T++;
                if (unicodeDirectoryMap["T03A4"] > 0)
                    differentOccurencies_T++;
                if (unicodeDirectoryMap["T01AC"] > 0)
                    differentOccurencies_T++;

                int differentOccurencies_j = 0;
                if (unicodeDirectoryMap["j006A"] > 0)
                    differentOccurencies_j++;
                if (unicodeDirectoryMap["j0458"] > 0)
                    differentOccurencies_j++;
                if (unicodeDirectoryMap["j03F3"] > 0)
                    differentOccurencies_j++;
                if (unicodeDirectoryMap["j029D"] > 0)
                    differentOccurencies_j++;

                int differentOccurencies_o = 0;
                if (unicodeDirectoryMap["o006F"] > 0)
                    differentOccurencies_o++;
                if (unicodeDirectoryMap["o03BF"] > 0)
                    differentOccurencies_o++;
                if (unicodeDirectoryMap["o1D0F"] > 0)
                    differentOccurencies_o++;
                if (unicodeDirectoryMap["o043E"] > 0)
                    differentOccurencies_o++;

                //there are 13 characters that can be used for this steganography method, so in this case, we need to cound for each of them
                //how many characters have more then one encodings (for the same character used)
                //for example: if only A and B are present with different encodings, then unicodeNumberSymbols will hold the value 2
                if (differentOccurencies_A > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_B > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_E > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_G > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_H > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_I > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_M > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_O > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_P > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_S > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_T > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_j > 1)
                    unicodeNumberSymbols++;
                if (differentOccurencies_o > 1)
                    unicodeNumberSymbols++;
            }

            #endregion
            #region check for word mapping and for font type
            //get each sequences of each 2 adjective words and check the word mapping technique
            int countWord = 1;
            String word1 = String.Empty;
            String word2 = String.Empty;
            
            foreach (Microsoft.Office.Interop.Word.Range r in docs.Words)
            {
                if (enableWordMapping == true)
                {
                    if (countWord == 1)
                    {
                        word1 = r.Text;
                        word2 = r.Text;
                        countWord++;
                    }
                    else if (countWord > 1)
                    {
                        word1 = word2;
                        word2 = r.Text;
                        countWord++;

                        string word1Temp = word1.Trim();
                        string word2Temp = word2.Trim();
                        //check if the first word is 'a' or 'an' and if that's the case, check the first letter of the second word
                        if (word1Temp.ToLower() == "a" || word1Temp.ToLower() == "an")
                        {
                            wordMappingOption1Total++;
                            if (word1Temp.ToLower() == "a" && Array.IndexOf(vowels, word2.ToLower().Substring(0, 1)) > -1)
                            {
                                wordMappingOption1Potential++;
                            }
                            else if (word1Temp.ToLower() == "an" && Array.IndexOf(vowels, word2.ToLower().Substring(0, 1)) == -1)
                            {
                                wordMappingOption1Potential++;
                            }
                        }

                        //check if the both word have even or odd lengths, and if that's the case, check if there are multiple characters between those words
                        if (word1Temp.Length > 0 && word2Temp.Length > 0)
                        {
                            if ((word1Temp.Length % 2 == 0 && word2Temp.Length % 2 == 0) || (word1Temp.Length % 2 != 0 && word2Temp.Length % 2 != 0))
                            {
                                wordMappingOption2Total++;
                                if (word1.Length - word1Temp.Length > 1)
                                {
                                    wordMappingOption2Potential++;
                                }
                            }
                        }
                    }
                }
                
                //check fpr the font type stegangraphy                
                if (r.Text.Trim().Length > 0)
                {
                    char firstLetter = r.Text.Trim().ToCharArray()[0];
                    byte[] asciiFirstLetter = Encoding.ASCII.GetBytes(firstLetter.ToString());
                    //check if the first letter of the words is UPPER letter and if it is, then check the fonts of the first and the second letter in the word
                    if (asciiFirstLetter[0] >= 65 && asciiFirstLetter[0] <= 90)
                    {
                        int wordStartIndex = r.Start;
                        r.SetRange(wordStartIndex, wordStartIndex + 1);
                        string fontFamilyFirstLetter = (r.Font).Name;
                        r.SetRange(wordStartIndex + 1, wordStartIndex + 2);
                        string fontFamilySecondLetter = null;
                        if (r.Text.Trim().Length > 0)
                        {
                            fontFamilySecondLetter = (r.Font).Name;
                        }

                        fontTypeTotal++;
                        //if the first two letters of the word has different fonts, then this is a potential case
                        if (fontFamilySecondLetter != null && fontFamilyFirstLetter != fontFamilySecondLetter)
                        {
                            fontTypePotential++;
                        }

                        //if the word has one letter OR is the fonts of the two letters are different, then count the occurencies of the font types
                        if ((fontFamilySecondLetter != null && fontFamilyFirstLetter != fontFamilySecondLetter) || fontFamilySecondLetter == null)
                        {
                            if (fontTypeDirectoryCount.ContainsKey(fontFamilyFirstLetter))
                            {
                                int value = fontTypeDirectoryCount[fontFamilyFirstLetter] + 1;
                                fontTypeDirectoryCount[fontFamilyFirstLetter] = value;
                            }
                            else
                            {
                                fontTypeDirectoryCount.Add(fontFamilyFirstLetter, 1);
                            }
                        }
                    }
                }
            }
            #endregion
            ResultValues resultValues = new ResultValues();
            //resultValues.countPotetntialScaleSizes = countPotetntialScaleSizes;
            resultValues.openSpacesWordsTotal = openSpacesWordsTotal;
            resultValues.openSpacesWordsPotential = openSpacesWordsPotential;
            resultValues.openSpacesSentencesTotal = openSpacesSentencesTotal;
            resultValues.openSpacesSentencesPotential = openSpacesSentencesPotential;
            resultValues.unicodeNumberSymbols = unicodeNumberSymbols;
            resultValues.unicodeDirectoryMap = unicodeDirectoryMap;
            resultValues.invisibleCharactersThatTakesNoSpaceHexMap = invisibleCharactersThatTakesNoSpaceHexMap;
            resultValues.fontTypeTotal = fontTypeTotal;
            resultValues.fontTypePotential = fontTypePotential;
            resultValues.fontTypeDirectoryCount = fontTypeDirectoryCount;
            resultValues.invisibleCharactersTotal = invisibleCharactersTotal;
            resultValues.invisibleCharactersPotential = invisibleCharactersPotential;
            resultValues.colorQuantizationTotal = colorQuantizationTotal;
            resultValues.colorQuantizationLight = colorQuantizationLight;
            resultValues.colorQuantizationDark = colorQuantizationDark;
            resultValues.colorQuantizationDarkLevels = colorQuantizationDarkLevels;
            resultValues.colorQuantizationLightLevels = colorQuantizationLightLevels;
            resultValues.wordMappingOption1Total = wordMappingOption1Total;
            resultValues.wordMappingOption1Potential = wordMappingOption1Potential;
            resultValues.wordMappingOption2Total = wordMappingOption2Total;
            resultValues.wordMappingOption2Potential = wordMappingOption2Potential;
            resultValues.codedParagraphBorder = codedParagraphBorder;            
            resultValues.generalParagraphLeftBorderMap = generalParagraphLeftBorderMap;
            //resultValues.generalParagraphLeftBorderColorMap = generalParagraphLeftBorderColorMap;
            //resultValues.generalParagrahpLeftBorderStyleMap = generalParagrahpLeftBorderStyleMap;
            resultValues.generalParagraphRightBorderMap = generalParagraphRightBorderMap;
            //resultValues.generalParagraphRightBorderColorMap = generalParagraphRightBorderColorMap;
            //resultValues.generalParagraphRightBorderStyleMap = generalParagraphRightBorderStyleMap;
            resultValues.codedSentenceBorder = codedSentenceBorder;
            resultValues.generalSentenceLeftBorderMap = generalSentenceLeftBorderMap;
            resultValues.generalSentenceRightBorderMap = generalSentenceRightBorderMap;
            //resultValues.generalSentenceLeftBorderColorMap = generalSentenceLeftBorderColorMap;
            //resultValues.generalSentenceLeftBorderStyleMap = generalSentenceLeftBorderStyleMap;
            resultValues.codedScaling = codedScaling;
            resultValues.generalScalingMap = generalScalingMap;
            resultValues.codedUnderline = codedUnderline;
            resultValues.generalUnderlineMap = generalUnderlineMap;
            //resultValues.generalUnderlineColorMap = generalUnderlineColorMap;
            //resultValues.generalUnderlineStyleMap = generalUnderlineStyleMap;
            resultValues.codedWhiteSpaces = codedWhiteSpaces;
            resultValues.enableConreteMethodsCheck = enableConreteMethodsCheck;
            resultValues.enableWordMapping = enableWordMapping;
            resultValues.enableColorQuantization = enableColorQuantization;
            resultValues.enableUnicodes = enableUnicodes;
            
            docs.Close();
            word.Quit();

            (new ResultScreen(resultValues)).ShowDialog();
        }

        //chose a document and (if later chosen) make a copy of it before adding tradingmark
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Docx Files|*.docx";          //open.Filter = "Docx Files|*.docx|All Files|*.*";
            open.Title = "Open a Word Document File";
            open.InitialDirectory = Directory.GetCurrentDirectory();
            if (open.ShowDialog() == DialogResult.OK)
            {
                var fileName = open.FileName;
                //ako izbraniot dokument se naoga vo folderot bin samo treba da go otovrime
                if (Directory.GetCurrentDirectory() == Path.GetDirectoryName(fileName))
                {
                    documentPath = Directory.GetCurrentDirectory() + "/" + Path.GetFileNameWithoutExtension(fileName) + "" + Path.GetExtension(fileName);
                    canChange = true;
                    documentName = Path.GetFileNameWithoutExtension(fileName) + "" + Path.GetExtension(fileName);
                    chosenDocumentLabel.Text = documentName;
                    detectAnyMethod.Enabled = true;
                }
                //ako izbraniot dokument ne se naoga vo folderot bin treba da go postavime tamu
                else
                {
                    documentPath = Directory.GetCurrentDirectory() + "/" + Path.GetFileNameWithoutExtension(fileName) + "" + Path.GetExtension(fileName);
                    //ako postoi dokument so imeto so koe ke se kreira kodiraniot dokument, izbrisi go i napravi kopija od originalot
                    if (File.Exists(documentPath))
                    {
                        File.Delete(documentPath);
                    }
                    System.IO.File.Copy(fileName, Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(fileName) + "" + Path.GetExtension(fileName)));
                    canChange = true;
                    documentName = Path.GetFileNameWithoutExtension(fileName) + "" + Path.GetExtension(fileName);
                    chosenDocumentLabel.Text = documentName;
                    detectAnyMethod.Enabled = true;
                }

                resetGlobalCounters();
            }
        }

        private void detectAnyMethod_EnabledChanged(object sender, EventArgs e)
        {
            detectOpenSpacesMethods.Enabled = detectAnyMethod.Enabled;
            detectWordMappingsMethods.Enabled = detectAnyMethod.Enabled;
            detectFontTypeMethod.Enabled = detectAnyMethod.Enabled;
            detectColorQuantizationMethod.Enabled = detectAnyMethod.Enabled;
            detectInvisibleCharactesMethods.Enabled = detectAnyMethod.Enabled;
            detectUnicodesMethod.Enabled = detectAnyMethod.Enabled;
            detectCharactersScaleGeneralMethod.Enabled = detectAnyMethod.Enabled;
            detectUnderlineGeneralMethod.Enabled = detectAnyMethod.Enabled;
            detectSentenceBorderGeneralMethod.Enabled = detectAnyMethod.Enabled;
            detectParagraphBorderGeneralMethod.Enabled = detectAnyMethod.Enabled;
        }

        private void detectOpenSpacesMethods_Click(object sender, EventArgs e)
        {
            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            Microsoft.Office.Interop.Word.Range rangeWords = word.ActiveDocument.Content;
            Microsoft.Office.Interop.Word.Range rangeSentences = word.ActiveDocument.Content;

            #region check for open spaces (words + sentences)
            var watchOpenSpacesWords = new System.Diagnostics.Stopwatch();
            watchOpenSpacesWords.Start();
            for (int k = 1; k <= rangeWords.Words.Count; k++)
            {
                Microsoft.Office.Interop.Word.Range w1 = rangeWords.Words[k];
                string wordsText = w1.Text.TrimEnd('\r');
                if (wordsText.Length > 0)
                {
                    openSpacesWordsTotal++;
                    string trimmedWordsText = wordsText.TrimEnd(' ');
                    if (wordsText.Length - trimmedWordsText.Length > 1)
                    {
                        openSpacesWordsPotential++;
                    }
                }
            }
            watchOpenSpacesWords.Stop();
            LogExecutionTime("OpenSpacesWords", watchOpenSpacesWords);

            var watchOpenSpacesSentences = new System.Diagnostics.Stopwatch();
            watchOpenSpacesSentences.Start();
            for (int k = 1; k <= rangeSentences.Sentences.Count; k++)
            {
                Microsoft.Office.Interop.Word.Range s1 = rangeSentences.Sentences[k];
                string sentencesText = s1.Text.TrimEnd('\r');
                if (sentencesText.Length > 0)
                {
                    openSpacesSentencesTotal++;
                    string trimmedSentencesText = sentencesText.TrimEnd(' ');
                    if (sentencesText.Length - trimmedSentencesText.Length > 1)
                    {
                        openSpacesSentencesPotential++;
                    }
                }
            }
            watchOpenSpacesSentences.Stop();
            LogExecutionTime("OpenSpacesSentences", watchOpenSpacesSentences);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.openSpacesWordsTotal = openSpacesWordsTotal;
            resultValues.openSpacesWordsPotential = openSpacesWordsPotential;
            resultValues.openSpacesSentencesTotal = openSpacesSentencesTotal;
            resultValues.openSpacesSentencesPotential = openSpacesSentencesPotential;

            docs.Close();
            word.Quit();

            (new ResultOpenSpacesScreen(resultValues)).ShowDialog();
        }

        private void detectWordMappingsMethods_Click(object sender, EventArgs e)
        {
            if (enableWordMapping == false)
                return;

            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);

            #region check for word mapping
            //get each sequences of each 2 adjective words and check the word mapping technique
            int countWord = 1;
            String word1 = String.Empty;
            String word2 = String.Empty;

            var watchWordMappingA_AN = new System.Diagnostics.Stopwatch();
            watchWordMappingA_AN.Start();
            var watchWordMappingInvChars = new System.Diagnostics.Stopwatch();
            watchWordMappingInvChars.Start();
            foreach (Microsoft.Office.Interop.Word.Range r in docs.Words)
            {
                if (countWord == 1)
                {
                    word1 = r.Text;
                    word2 = r.Text;
                    countWord++;
                }
                else if (countWord > 1)
                {
                    word1 = word2;
                    word2 = r.Text;
                    countWord++;

                    string word1Temp = word1.Trim();
                    string word2Temp = word2.Trim();

                    if (!watchWordMappingA_AN.IsRunning)
                        watchWordMappingA_AN.Start();
                    if (watchWordMappingInvChars.IsRunning)
                        watchWordMappingInvChars.Stop();
                    //check if the first word is 'a' or 'an' and if that's the case, check the first letter of the second word
                    if (word1Temp.ToLower() == "a" || word1Temp.ToLower() == "an")
                    {
                        wordMappingOption1Total++;
                        if (word1Temp.ToLower() == "a" && Array.IndexOf(vowels, word2.ToLower().Substring(0, 1)) > -1)
                        {
                            wordMappingOption1Potential++;
                        }
                        else if (word1Temp.ToLower() == "an" && Array.IndexOf(vowels, word2.ToLower().Substring(0, 1)) == -1)
                        {
                            wordMappingOption1Potential++;
                        }
                    }

                    if (!watchWordMappingInvChars.IsRunning)
                        watchWordMappingInvChars.Start();
                    if (watchWordMappingA_AN.IsRunning)
                        watchWordMappingA_AN.Stop();
                    //check if the both word have even or odd lengths, and if that's the case, check if there are multiple characters between those words
                    if (word1Temp.Length > 0 && word2Temp.Length > 0)
                    {
                        if ((word1Temp.Length % 2 == 0 && word2Temp.Length % 2 == 0) || (word1Temp.Length % 2 != 0 && word2Temp.Length % 2 != 0))
                        {
                            wordMappingOption2Total++;
                            if (word1.Length - word1Temp.Length > 1)
                            {
                                wordMappingOption2Potential++;
                            }
                        }
                    }
                }
            }

            if (watchWordMappingA_AN.IsRunning)
                watchWordMappingA_AN.Stop();
            LogExecutionTime("WordMapping A / AN", watchWordMappingA_AN);
            if (watchWordMappingInvChars.IsRunning)
                watchWordMappingInvChars.Stop();
            LogExecutionTime("WordMapping Inv. Chars.", watchWordMappingInvChars);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.wordMappingOption1Total = wordMappingOption1Total;
            resultValues.wordMappingOption1Potential = wordMappingOption1Potential;
            resultValues.wordMappingOption2Total = wordMappingOption2Total;
            resultValues.wordMappingOption2Potential = wordMappingOption2Potential;

            docs.Close();
            word.Quit();

            (new ResultWordMappingScreen(resultValues)).ShowDialog();
        }

        private void detectFontTypeMethod_Click(object sender, EventArgs e)
        {
            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);

            #region check for font type
            var watchFontTypes = new System.Diagnostics.Stopwatch();
            watchFontTypes.Start();
            //get each sequences of each 2 adjective words and check the word mapping technique
            foreach (Microsoft.Office.Interop.Word.Range r in docs.Words)
            {
                //check fpr the font type stegangraphy                
                if (r.Text.Trim().Length > 0)
                {
                    char firstLetter = r.Text.Trim().ToCharArray()[0];
                    byte[] asciiFirstLetter = Encoding.ASCII.GetBytes(firstLetter.ToString());
                    //check if the first letter of the words is UPPER letter and if it is, then check the fonts of the first and the second letter in the word
                    if (asciiFirstLetter[0] >= 65 && asciiFirstLetter[0] <= 90)
                    {
                        int wordStartIndex = r.Start;
                        r.SetRange(wordStartIndex, wordStartIndex + 1);
                        string fontFamilyFirstLetter = (r.Font).Name;
                        r.SetRange(wordStartIndex + 1, wordStartIndex + 2);
                        string fontFamilySecondLetter = null;
                        if (r.Text.Trim().Length > 0)
                        {
                            fontFamilySecondLetter = (r.Font).Name;
                        }

                        fontTypeTotal++;
                        //if the first two letters of the word has different fonts, then this is a potential case
                        if (fontFamilySecondLetter != null && fontFamilyFirstLetter != fontFamilySecondLetter)
                        {
                            fontTypePotential++;
                        }

                        //if the word has one letter OR is the fonts of the two letters are different, then count the occurencies of the font types
                        if ((fontFamilySecondLetter != null && fontFamilyFirstLetter != fontFamilySecondLetter) || fontFamilySecondLetter == null)
                        {
                            if (fontTypeDirectoryCount.ContainsKey(fontFamilyFirstLetter))
                            {
                                int value = fontTypeDirectoryCount[fontFamilyFirstLetter] + 1;
                                fontTypeDirectoryCount[fontFamilyFirstLetter] = value;
                            }
                            else
                            {
                                fontTypeDirectoryCount.Add(fontFamilyFirstLetter, 1);
                            }
                        }
                    }
                }
            }
            watchFontTypes.Stop();
            LogExecutionTime("FontTypes", watchFontTypes);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.fontTypeTotal = fontTypeTotal;
            resultValues.fontTypePotential = fontTypePotential;
            resultValues.fontTypeDirectoryCount = fontTypeDirectoryCount;

            docs.Close();
            word.Quit();

            (new ResultFontTypeScreen(resultValues)).ShowDialog();
        }

        private void detectColorQuantizationMethod_Click(object sender, EventArgs e)
        {
            if (enableColorQuantization == false)
                return;

            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            // Define a range of 1 character. 
            object start = 0; object startGeneral = 0; int startGeneralCount = 0;
            object end = 1; object endGeneral = 3; int endGeneralCount = 3;
            Microsoft.Office.Interop.Word.Range rngGeneral = docs.Range(ref startGeneral, ref endGeneral);
            Microsoft.Office.Interop.Word.Range rngGeneralAll = docs.Range(ref startGeneral);
            Microsoft.Office.Interop.Word.Range rngGeneralTemp1 = null;
            Microsoft.Office.Interop.Word.Range rngGeneralTemp2 = null;
            Microsoft.Office.Interop.Word.Range rngGeneralTemp3 = null;

            #region check for color quantization)
            //get each sequences of each 3 characters and: do the check if the middle character is invisible + on each new sequence check the brigthness
            //for example: 123456, invisible characters loops throught 123, 234, 234, 456;
            //                     color quantizations, unicode and MS Word Symbols[9] loops throught every third sequence 123, 456
            int actualSizeGeneral = rngGeneralAll.Text.Length - 1;

            int checkEachCharacterIndividually = 0;

            var watchColorQuantization = new System.Diagnostics.Stopwatch();
            watchColorQuantization.Start();
            while ((rngGeneral.End - 1) < actualSizeGeneral)
            {
                rngGeneral.Select();

                startTemp0 = (object)(startGeneralCount);
                startTemp1 = (object)(startGeneralCount + 1);
                startTemp2 = (object)(startGeneralCount + 2);
                startTemp3 = (object)(startGeneralCount + 3);
                rngGeneralTemp1 = docs.Range(ref startTemp0, ref startTemp1);
                rngGeneralTemp2 = docs.Range(ref startTemp1, ref startTemp2);
                rngGeneralTemp3 = docs.Range(ref startTemp2, ref startTemp3);
                string color1 = rngGeneralTemp1.Font.Color.ToString();
                string color2 = rngGeneralTemp2.Font.Color.ToString();
                string color3 = rngGeneralTemp3.Font.Color.ToString();

                bool byte1proceed = true;
                if (rngGeneralTemp1 == null || rngGeneralTemp1.Text == null)
                    byte1proceed = false;
                bool byte2proceed = true;
                if (rngGeneralTemp2 == null || rngGeneralTemp2.Text == null)
                    byte2proceed = false;
                bool byte3proceed = true;
                if (rngGeneralTemp3 == null || rngGeneralTemp3.Text == null)
                    byte3proceed = false;

                byte[] asciiBytes1 = null;
                byte[] asciiBytes2 = null;
                byte[] asciiBytes3 = null;

                //for each third sequence, calculate the brigtness based on RGB values 
                //https://stackoverflow.com/questions/596216/formula-to-determine-brightness-of-rgb-color
                //for each third sequence, calculate the UNICODE value for each character + count and update the unicodeDirectoryMap
                //for each third sequence, check and count the invisible symbols that do not takes space (MS Word Symbols[9])
                if (checkEachCharacterIndividually == 0 || (checkEachCharacterIndividually) % 3 == 0)
                {
                    if (byte1proceed == true)
                    {
                        asciiBytes1 = Encoding.ASCII.GetBytes(rngGeneralTemp1.Text);
                        var systemColor1 = ColorTranslator.FromWin32((int)rngGeneralTemp1.Font.Color);
                        var brigthness1 = (0.2126 * (systemColor1.R / 255.0) + 0.7152 * (systemColor1.G / 255.0) + 0.0722 * (systemColor1.B / 255.0));
                        colorQuantizationTotal++;

                        if (rngGeneralTemp1.Font.Color != WdColor.wdColorAutomatic)
                        {
                            if (brigthness1 < 0.5)
                            {
                                colorQuantizationDark++;
                                if (Array.IndexOf(colorQuantizationDarkLevels, brigthness1) == -1)
                                {
                                    //push into array
                                    Array.Resize(ref colorQuantizationDarkLevels, colorQuantizationDarkLevels.Length + 1);
                                    colorQuantizationDarkLevels[colorQuantizationDarkLevels.GetUpperBound(0)] = brigthness1;
                                }
                            }
                            else
                            {
                                colorQuantizationLight++;
                                if (Array.IndexOf(colorQuantizationLightLevels, brigthness1) == -1)
                                {
                                    //push into array
                                    Array.Resize(ref colorQuantizationLightLevels, colorQuantizationLightLevels.Length + 1);
                                    colorQuantizationLightLevels[colorQuantizationLightLevels.GetUpperBound(0)] = brigthness1;
                                }
                            }
                        }
                    }

                    if (byte2proceed == true)
                    {
                        asciiBytes2 = Encoding.ASCII.GetBytes(rngGeneralTemp2.Text);
                        var systemColor2 = ColorTranslator.FromWin32((int)rngGeneralTemp2.Font.Color);
                        var brigthness2 = (0.2126 * (systemColor2.R / 255.0) + 0.7152 * (systemColor2.G / 255.0) + 0.0722 * (systemColor2.B / 255.0));
                        colorQuantizationTotal++;

                        if (rngGeneralTemp2.Font.Color != WdColor.wdColorAutomatic)
                        {
                            if (brigthness2 < 0.5)
                            {
                                colorQuantizationDark++;
                                if (Array.IndexOf(colorQuantizationDarkLevels, brigthness2) == -1)
                                {
                                    //push into array
                                    Array.Resize(ref colorQuantizationDarkLevels, colorQuantizationDarkLevels.Length + 1);
                                    colorQuantizationDarkLevels[colorQuantizationDarkLevels.GetUpperBound(0)] = brigthness2;
                                }
                            }
                            else
                            {
                                colorQuantizationLight++;
                                if (Array.IndexOf(colorQuantizationLightLevels, brigthness2) == -1)
                                {
                                    //push into array
                                    Array.Resize(ref colorQuantizationLightLevels, colorQuantizationLightLevels.Length + 1);
                                    colorQuantizationLightLevels[colorQuantizationLightLevels.GetUpperBound(0)] = brigthness2;
                                }
                            }
                        }
                    }

                    if (byte3proceed == true)
                    {
                        asciiBytes3 = Encoding.ASCII.GetBytes(rngGeneralTemp3.Text);
                        var systemColor3 = ColorTranslator.FromWin32((int)rngGeneralTemp3.Font.Color);
                        var brigthness3 = (0.2126 * (systemColor3.R / 255.0) + 0.7152 * (systemColor3.G / 255.0) + 0.0722 * (systemColor3.B / 255.0));
                        colorQuantizationTotal++;

                        if (rngGeneralTemp3.Font.Color != WdColor.wdColorAutomatic)
                        {
                            if (brigthness3 < 0.5)
                            {
                                colorQuantizationDark++;
                                if (Array.IndexOf(colorQuantizationDarkLevels, brigthness3) == -1)
                                {
                                    //push into array
                                    Array.Resize(ref colorQuantizationDarkLevels, colorQuantizationDarkLevels.Length + 1);
                                    colorQuantizationDarkLevels[colorQuantizationDarkLevels.GetUpperBound(0)] = brigthness3;
                                }
                            }
                            else
                            {
                                colorQuantizationLight++;
                                if (Array.IndexOf(colorQuantizationLightLevels, brigthness3) == -1)
                                {
                                    //push into array
                                    Array.Resize(ref colorQuantizationLightLevels, colorQuantizationLightLevels.Length + 1);
                                    colorQuantizationLightLevels[colorQuantizationLightLevels.GetUpperBound(0)] = brigthness3;
                                }
                            }
                        }
                    }
                }
                checkEachCharacterIndividually++;

                // Move the start position 1 character
                rngGeneral.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                // Move the end position 1 character
                rngGeneral.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                startGeneralCount++;
                endGeneralCount++;
            }
            watchColorQuantization.Stop();
            LogExecutionTime("ColorQuantization", watchColorQuantization);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.colorQuantizationTotal = colorQuantizationTotal;
            resultValues.colorQuantizationLight = colorQuantizationLight;
            resultValues.colorQuantizationDark = colorQuantizationDark;
            resultValues.colorQuantizationDarkLevels = colorQuantizationDarkLevels;
            resultValues.colorQuantizationLightLevels = colorQuantizationLightLevels;

            docs.Close();
            word.Quit();

            (new ResultColorQuantizationScreen(resultValues)).ShowDialog();            
        }

        private void detectInvisibleCharactesMethods_Click(object sender, EventArgs e)
        {
            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            // Define a range of 1 character. 
            object start = 0; object startGeneral = 0; int startGeneralCount = 0;
            object end = 1; object endGeneral = 3; int endGeneralCount = 3;
            Microsoft.Office.Interop.Word.Range rngGeneral = docs.Range(ref startGeneral, ref endGeneral);
            Microsoft.Office.Interop.Word.Range rngGeneralAll = docs.Range(ref startGeneral);
            Microsoft.Office.Interop.Word.Range rngGeneralTemp1 = null;
            Microsoft.Office.Interop.Word.Range rngGeneralTemp2 = null;
            Microsoft.Office.Interop.Word.Range rngGeneralTemp3 = null;

            #region check for invisible characters and for invisible characters that does not takes space (MS Word Symbols[9])
            //get each sequences of each 3 characters and: do the check if the middle character is invisible + on each new sequence check the brigthness
            //for example: 123456, invisible characters loops throught 123, 234, 234, 456;
            //                     color quantizations, unicode and MS Word Symbols[9] loops throught every third sequence 123, 456
            int actualSizeGeneral = rngGeneralAll.Text.Length - 1;

            int checkEachCharacterIndividually = 0;

            var watchInvCharsNoSpace = new System.Diagnostics.Stopwatch();
            watchInvCharsNoSpace.Start();
            var watchInvCharsColors = new System.Diagnostics.Stopwatch();
            watchInvCharsColors.Start();
            while ((rngGeneral.End - 1) < actualSizeGeneral)
            {
                rngGeneral.Select();

                startTemp0 = (object)(startGeneralCount);
                startTemp1 = (object)(startGeneralCount + 1);
                startTemp2 = (object)(startGeneralCount + 2);
                startTemp3 = (object)(startGeneralCount + 3);
                rngGeneralTemp1 = docs.Range(ref startTemp0, ref startTemp1);
                rngGeneralTemp2 = docs.Range(ref startTemp1, ref startTemp2);
                rngGeneralTemp3 = docs.Range(ref startTemp2, ref startTemp3);
                string color1 = rngGeneralTemp1.Font.Color.ToString();
                string color2 = rngGeneralTemp2.Font.Color.ToString();
                string color3 = rngGeneralTemp3.Font.Color.ToString();

                bool byte1proceed = true;
                if (rngGeneralTemp1 == null || rngGeneralTemp1.Text == null)
                    byte1proceed = false;
                bool byte2proceed = true;
                if (rngGeneralTemp2 == null || rngGeneralTemp2.Text == null)
                    byte2proceed = false;
                bool byte3proceed = true;
                if (rngGeneralTemp3 == null || rngGeneralTemp3.Text == null)
                    byte3proceed = false;

                byte[] asciiBytes1 = null;
                byte[] asciiBytes2 = null;
                byte[] asciiBytes3 = null;

                if (!watchInvCharsNoSpace.IsRunning)
                    watchInvCharsNoSpace.Start();
                if (watchInvCharsColors.IsRunning)
                    watchInvCharsColors.Stop();
                //for each third sequence, calculate the brigtness based on RGB values 
                //https://stackoverflow.com/questions/596216/formula-to-determine-brightness-of-rgb-color
                //for each third sequence, calculate the UNICODE value for each character + count and update the unicodeDirectoryMap
                //for each third sequence, check and count the invisible symbols that do not takes space (MS Word Symbols[9])
                if (checkEachCharacterIndividually == 0 || (checkEachCharacterIndividually) % 3 == 0)
                {
                    if (byte1proceed == true)
                    {
                        //convert to unicodes and increase the dictionary where the current character is a key
                        asciiBytes1 = Encoding.ASCII.GetBytes(rngGeneralTemp1.Text);
                        String unicodeVal1 = rngGeneralTemp1.Text + asciiBytes1[0].ToString("X4");
                        //check and count occrencies for the invisible symbols that do not takes space (MS Word Symbols[9]) approach
                        if (invisibleCharactersThatTakesNoSpaceHexMap.ContainsKey(unicodeVal1))
                        {
                            int wordSymbols1 = invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal1] + 1;
                            invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal1] = wordSymbols1;
                        }
                    }

                    if (byte2proceed == true)
                    {
                        //convert to unicodes and increase the dictionary where the current character is a key
                        asciiBytes2 = Encoding.ASCII.GetBytes(rngGeneralTemp2.Text);
                        String unicodeVal2 = rngGeneralTemp2.Text + asciiBytes2[0].ToString("X4");
                        //check and count occrencies for the invisible symbols that do not takes space (MS Word Symbols[9]) approach
                        if (invisibleCharactersThatTakesNoSpaceHexMap.ContainsKey(unicodeVal2))
                        {
                            int wordSymbols2 = invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal2] + 1;
                            invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal2] = wordSymbols2;
                        }
                    }

                    if (byte3proceed == true)
                    {
                        //convert to unicodes and increase the dictionary where the current character is a key
                        asciiBytes3 = Encoding.ASCII.GetBytes(rngGeneralTemp3.Text);
                        String unicodeVal3 = rngGeneralTemp3.Text + asciiBytes3[0].ToString("X4");
                        //check and count occrencies for the invisible symbols that do not takes space (MS Word Symbols[9]) approach
                        if (invisibleCharactersThatTakesNoSpaceHexMap.ContainsKey(unicodeVal3))
                        {
                            int wordSymbols3 = invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal3] + 1;
                            invisibleCharactersThatTakesNoSpaceHexMap[unicodeVal3] = wordSymbols3;
                        }
                    }
                }
                checkEachCharacterIndividually++;

                if (!watchInvCharsColors.IsRunning)
                    watchInvCharsColors.Start();
                if (watchInvCharsNoSpace.IsRunning)
                    watchInvCharsNoSpace.Stop();
                //if the middle character is invisible, then count this situation in total cases
                if (asciiBytes2 != null && asciiBytes2.Length == 1 && Array.IndexOf(invisibleCharASCII, asciiBytes2[0]) > -1)
                {
                    invisibleCharactersTotal++;
                    //if the 1st and 3th character are with the same color and if
                    //if the color of the middle character is different then the color of the 1st and 3th character then this is potential case
                    if (color1 == color3 && color1 != color2)
                    {
                        invisibleCharactersPotential++;
                    }
                }

                // Move the start position 1 character
                rngGeneral.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                // Move the end position 1 character
                rngGeneral.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                startGeneralCount++;
                endGeneralCount++;
            }

            if (watchInvCharsNoSpace.IsRunning)
                watchInvCharsNoSpace.Stop();
            LogExecutionTime("InvisibleCharactersNoSpace", watchInvCharsNoSpace);
            if (watchInvCharsColors.IsRunning)
                watchInvCharsColors.Stop();
            LogExecutionTime("InvisibleCharactersColors", watchInvCharsColors);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.invisibleCharactersThatTakesNoSpaceHexMap = invisibleCharactersThatTakesNoSpaceHexMap;
            resultValues.invisibleCharactersTotal = invisibleCharactersTotal;
            resultValues.invisibleCharactersPotential = invisibleCharactersPotential;

            docs.Close();
            word.Quit();

            (new ResultInvisibleCharactersScreen(resultValues)).ShowDialog();            
        }

        private void detectUnicodesMethod_Click(object sender, EventArgs e)
        {
            if (enableUnicodes == false)
                return;

            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            // Define a range of 1 character. 
            object start = 0; object startGeneral = 0; int startGeneralCount = 0;
            object end = 1; object endGeneral = 3; int endGeneralCount = 3;
            Microsoft.Office.Interop.Word.Range rngGeneral = docs.Range(ref startGeneral, ref endGeneral);
            Microsoft.Office.Interop.Word.Range rngGeneralAll = docs.Range(ref startGeneral);
            Microsoft.Office.Interop.Word.Range rngGeneralTemp1 = null;
            Microsoft.Office.Interop.Word.Range rngGeneralTemp2 = null;
            Microsoft.Office.Interop.Word.Range rngGeneralTemp3 = null;

            #region check for unicode
            var watchUnicodes = new System.Diagnostics.Stopwatch();
            watchUnicodes.Start();
            //get each sequences of each 3 characters and: do the check if the middle character is invisible + on each new sequence check the brigthness
            //for example: 123456, invisible characters loops throught 123, 234, 234, 456;
            //                     color quantizations, unicode and MS Word Symbols[9] loops throught every third sequence 123, 456
            int actualSizeGeneral = rngGeneralAll.Text.Length - 1;

            int checkEachCharacterIndividually = 0;

            //check unicodes, add unicode code in WordDocument, select it and press alt + x

            while ((rngGeneral.End - 1) < actualSizeGeneral)
            {
                rngGeneral.Select();

                startTemp0 = (object)(startGeneralCount);
                startTemp1 = (object)(startGeneralCount + 1);
                startTemp2 = (object)(startGeneralCount + 2);
                startTemp3 = (object)(startGeneralCount + 3);
                rngGeneralTemp1 = docs.Range(ref startTemp0, ref startTemp1);
                rngGeneralTemp2 = docs.Range(ref startTemp1, ref startTemp2);
                rngGeneralTemp3 = docs.Range(ref startTemp2, ref startTemp3);
                string color1 = rngGeneralTemp1.Font.Color.ToString();
                string color2 = rngGeneralTemp2.Font.Color.ToString();
                string color3 = rngGeneralTemp3.Font.Color.ToString();

                bool byte1proceed = true;
                if (rngGeneralTemp1 == null || rngGeneralTemp1.Text == null)
                    byte1proceed = false;
                bool byte2proceed = true;
                if (rngGeneralTemp2 == null || rngGeneralTemp2.Text == null)
                    byte2proceed = false;
                bool byte3proceed = true;
                if (rngGeneralTemp3 == null || rngGeneralTemp3.Text == null)
                    byte3proceed = false;

                byte[] asciiBytes1 = null;
                byte[] asciiBytes2 = null;
                byte[] asciiBytes3 = null;

                //byte[] asciiBytes11 = Encoding.ASCII.GetBytes(rngGeneralTemp2.Text);
                //byte[] asciiBytes12 = Encoding.BigEndianUnicode.GetBytes(rngGeneralTemp2.Text);
                //byte[] asciiBytes13 = Encoding.Default.GetBytes(rngGeneralTemp2.Text);
                //byte[] asciiBytes14 = Encoding.Unicode.GetBytes(rngGeneralTemp2.Text);
                //byte[] asciiBytes15 = Encoding.UTF32.GetBytes(rngGeneralTemp2.Text);
                //byte[] asciiBytes16 = Encoding.UTF7.GetBytes(rngGeneralTemp2.Text);
                //byte[] asciiBytes17 = Encoding.UTF8.GetBytes(rngGeneralTemp2.Text);

                //for each third sequence, calculate the brigtness based on RGB values 
                //https://stackoverflow.com/questions/596216/formula-to-determine-brightness-of-rgb-color
                //for each third sequence, calculate the UNICODE value for each character + count and update the unicodeDirectoryMap
                //for each third sequence, check and count the invisible symbols that do not takes space (MS Word Symbols[9])
                if (checkEachCharacterIndividually == 0 || (checkEachCharacterIndividually) % 3 == 0)
                {
                    if (byte1proceed == true)
                    {
                        asciiBytes1 = Encoding.ASCII.GetBytes(rngGeneralTemp1.Text);
                        //convert to unicodes and increase the dictionary where the current character is a key
                        String unicodeVal1 = rngGeneralTemp1.Text + asciiBytes1[0].ToString("X4");
                        //check and count occrencies for the unicode approach
                        if (unicodeDirectoryMap.ContainsKey(unicodeVal1))
                        {
                            int unicodeCount1 = unicodeDirectoryMap[unicodeVal1] + 1;
                            unicodeDirectoryMap[unicodeVal1] = unicodeCount1;
                        }
                    }

                    if (byte2proceed == true)
                    {
                        asciiBytes2 = Encoding.ASCII.GetBytes(rngGeneralTemp2.Text);
                        //convert to unicodes and increase the dictionary where the current character is a key
                        String unicodeVal2 = rngGeneralTemp2.Text + asciiBytes2[0].ToString("X4");
                        if (unicodeDirectoryMap.ContainsKey(unicodeVal2))
                        {
                            int unicodeCount2 = unicodeDirectoryMap[unicodeVal2] + 1;
                            unicodeDirectoryMap[unicodeVal2] = unicodeCount2;
                        }
                    }

                    if (byte3proceed == true)
                    {
                        asciiBytes3 = Encoding.ASCII.GetBytes(rngGeneralTemp3.Text);
                        //convert to unicodes and increase the dictionary where the current character is a key
                        String unicodeVal3 = rngGeneralTemp3.Text + asciiBytes3[0].ToString("X4");
                        if (unicodeDirectoryMap.ContainsKey(unicodeVal3))
                        {
                            int unicodeCount3 = unicodeDirectoryMap[unicodeVal3] + 1;
                            unicodeDirectoryMap[unicodeVal3] = unicodeCount3;
                        }
                    }

                    //String unicodeVal11 = rngGeneralTemp2.Text + asciiBytes11[0].ToString("X4");
                    //String unicodeVal12 = rngGeneralTemp2.Text + asciiBytes12[0].ToString("X4");
                    //String unicodeVal13 = rngGeneralTemp2.Text + asciiBytes13[0].ToString("X4");
                    //String unicodeVal14 = rngGeneralTemp2.Text + asciiBytes14[0].ToString("X4");
                    //String unicodeVal15 = rngGeneralTemp2.Text + asciiBytes15[0].ToString("X4");
                    //String unicodeVal16 = rngGeneralTemp2.Text + asciiBytes16[0].ToString("X4");
                    //String unicodeVal17 = rngGeneralTemp2.Text + asciiBytes17[0].ToString("X4");
                    //unicodeVal11 + " " + unicodeVal12 + " " + unicodeVal13 + " " + unicodeVal14 + " " + unicodeVal15 + " " + unicodeVal16 + " " + unicodeVal17
                }
                checkEachCharacterIndividually++;

                // Move the start position 1 character
                rngGeneral.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                // Move the end position 1 character
                rngGeneral.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                startGeneralCount++;
                endGeneralCount++;
            }
            //check if there are occurencies for the same character but different encodings and if there are more then 0 occurencies, get a note of this
            //for example: differentOccurencies_A will hold the cout of how many different encodings for character A are present in the doc
            int differentOccurencies_A = 0;
            if (unicodeDirectoryMap["A0041"] > 0)
                differentOccurencies_A++;
            if (unicodeDirectoryMap["A0391"] > 0)
                differentOccurencies_A++;
            if (unicodeDirectoryMap["A0410"] > 0)
                differentOccurencies_A++;
            if (unicodeDirectoryMap["A13AA"] > 0)
                differentOccurencies_A++;

            int differentOccurencies_B = 0;
            if (unicodeDirectoryMap["B0042"] > 0)
                differentOccurencies_B++;
            if (unicodeDirectoryMap["B0392"] > 0)
                differentOccurencies_B++;
            if (unicodeDirectoryMap["B0412"] > 0)
                differentOccurencies_B++;
            if (unicodeDirectoryMap["B0181"] > 0)
                differentOccurencies_B++;

            int differentOccurencies_E = 0;
            if (unicodeDirectoryMap["E0045"] > 0)
                differentOccurencies_E++;
            if (unicodeDirectoryMap["E0395"] > 0)
                differentOccurencies_E++;
            if (unicodeDirectoryMap["E0415"] > 0)
                differentOccurencies_E++;
            if (unicodeDirectoryMap["E13AC"] > 0)
                differentOccurencies_E++;

            int differentOccurencies_G = 0;
            if (unicodeDirectoryMap["G0047"] > 0)
                differentOccurencies_G++;
            if (unicodeDirectoryMap["G050C"] > 0)
                differentOccurencies_G++;
            if (unicodeDirectoryMap["G13C0"] > 0)
                differentOccurencies_G++;
            if (unicodeDirectoryMap["G13B6"] > 0)
                differentOccurencies_G++;

            int differentOccurencies_H = 0;
            if (unicodeDirectoryMap["H0048"] > 0)
                differentOccurencies_H++;
            if (unicodeDirectoryMap["H0397"] > 0)
                differentOccurencies_H++;
            if (unicodeDirectoryMap["H041D"] > 0)
                differentOccurencies_H++;
            if (unicodeDirectoryMap["H13BB"] > 0)
                differentOccurencies_H++;

            int differentOccurencies_I = 0;
            if (unicodeDirectoryMap["I0049"] > 0)
                differentOccurencies_I++;
            if (unicodeDirectoryMap["I0399"] > 0)
                differentOccurencies_I++;
            if (unicodeDirectoryMap["I04C0"] > 0)
                differentOccurencies_I++;
            if (unicodeDirectoryMap["I0406"] > 0)
                differentOccurencies_I++;

            int differentOccurencies_M = 0;
            if (unicodeDirectoryMap["M004D"] > 0)
                differentOccurencies_M++;
            if (unicodeDirectoryMap["M039C"] > 0)
                differentOccurencies_M++;
            if (unicodeDirectoryMap["M041C"] > 0)
                differentOccurencies_M++;
            if (unicodeDirectoryMap["M216F"] > 0)
                differentOccurencies_M++;

            int differentOccurencies_O = 0;
            if (unicodeDirectoryMap["O004F"] > 0)
                differentOccurencies_O++;
            if (unicodeDirectoryMap["O039F"] > 0)
                differentOccurencies_O++;
            if (unicodeDirectoryMap["O041E"] > 0)
                differentOccurencies_O++;
            if (unicodeDirectoryMap["O0555"] > 0)
                differentOccurencies_O++;

            int differentOccurencies_P = 0;
            if (unicodeDirectoryMap["P0050"] > 0)
                differentOccurencies_P++;
            if (unicodeDirectoryMap["P0420"] > 0)
                differentOccurencies_P++;
            if (unicodeDirectoryMap["P03A1"] > 0)
                differentOccurencies_P++;
            if (unicodeDirectoryMap["P01A4"] > 0)
                differentOccurencies_P++;

            int differentOccurencies_S = 0;
            if (unicodeDirectoryMap["S0053"] > 0)
                differentOccurencies_S++;
            if (unicodeDirectoryMap["S0405"] > 0)
                differentOccurencies_S++;
            if (unicodeDirectoryMap["S054F"] > 0)
                differentOccurencies_S++;
            if (unicodeDirectoryMap["S13DA"] > 0)
                differentOccurencies_S++;

            int differentOccurencies_T = 0;
            if (unicodeDirectoryMap["T0054"] > 0)
                differentOccurencies_T++;
            if (unicodeDirectoryMap["T0422"] > 0)
                differentOccurencies_T++;
            if (unicodeDirectoryMap["T03A4"] > 0)
                differentOccurencies_T++;
            if (unicodeDirectoryMap["T01AC"] > 0)
                differentOccurencies_T++;

            int differentOccurencies_j = 0;
            if (unicodeDirectoryMap["j006A"] > 0)
                differentOccurencies_j++;
            if (unicodeDirectoryMap["j0458"] > 0)
                differentOccurencies_j++;
            if (unicodeDirectoryMap["j03F3"] > 0)
                differentOccurencies_j++;
            if (unicodeDirectoryMap["j029D"] > 0)
                differentOccurencies_j++;

            int differentOccurencies_o = 0;
            if (unicodeDirectoryMap["o006F"] > 0)
                differentOccurencies_o++;
            if (unicodeDirectoryMap["o03BF"] > 0)
                differentOccurencies_o++;
            if (unicodeDirectoryMap["o1D0F"] > 0)
                differentOccurencies_o++;
            if (unicodeDirectoryMap["o043E"] > 0)
                differentOccurencies_o++;

            //there are 13 characters that can be used for this steganography method, so in this case, we need to cound for each of them
            //how many characters have more then one encodings (for the same character used)
            //for example: if only A and B are present with different encodings, then unicodeNumberSymbols will hold the value 2
            if (differentOccurencies_A > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_B > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_E > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_G > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_H > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_I > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_M > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_O > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_P > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_S > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_T > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_j > 1)
                unicodeNumberSymbols++;
            if (differentOccurencies_o > 1)
                unicodeNumberSymbols++;

            watchUnicodes.Stop();
            LogExecutionTime("Unicodes", watchUnicodes);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.unicodeNumberSymbols = unicodeNumberSymbols;
            resultValues.unicodeDirectoryMap = unicodeDirectoryMap;

            docs.Close();
            word.Quit();

            (new ResultUnicodeScreen(resultValues)).ShowDialog();
        }

        private void detectCharactersScaleMethods_Click(object sender, EventArgs e)
        {
            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            // Define a range of 1 character. 
            object start = 0; object startGeneral = 0; int startGeneralCount = 0;
            object end = 1; object endGeneral = 3; int endGeneralCount = 3;
            Microsoft.Office.Interop.Word.Range rngGeneralScaling = docs.Range(ref start, ref end);
            Microsoft.Office.Interop.Word.Range rngGeneralScalingAll = docs.Range(ref start);
            Microsoft.Office.Interop.Word.Range rngScaling = docs.Range(ref start, ref end);
            Microsoft.Office.Interop.Word.Range rngScalingAll = docs.Range(ref start);

            #region check for character scaling
            //approach 1: first we check if our concrete algotirtam is used
            int codedScaling = 0;
            int actualSizeScaling = rngScalingAll.Text.Length - 1;
            int numCheckScaling = 0;
            if (enableConreteMethodsCheck == true)
            {
                while ((rngScaling.End - 1) < actualSizeScaling)
                {
                    //if after 8 characters a code is still not detected, then skip this coding check
                    numCheckScaling++;
                    if (numCheckScaling == 9)
                        break;

                    string scaleStyle = rngScaling.Font.Scaling.ToString();
                    if (scaleStyle == "99")
                    {
                        codedScaling++;
                    }
                    else if (scaleStyle == "101")
                    {
                        codedScaling++;
                    }

                    //[scale = 99% if bit is 1, scale = 101% if bit is 0]
                    //ascii to char conversion (binary vo decimal vo ascii)

                    if (codedScaling == 8)
                        break;

                    rngScaling.Select();
                    // Move the start position 1 character.
                    rngScaling.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                    // Move the end position 1 character.
                    rngScaling.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                }
            }
            //approach 2: then we are doing more general check if character scaling is susposious
            int actualSizeGeneralScaling = rngGeneralScalingAll.Text.Length - 1;

            var watchCharactersScale = new System.Diagnostics.Stopwatch();
            watchCharactersScale.Start();
            while ((rngGeneralScaling.End - 1) < actualSizeGeneralScaling)
            {
                string scaleStyle = rngGeneralScaling.Font.Scaling.ToString();
                if (generalScalingMap.ContainsKey(scaleStyle))
                {
                    int generalScalingSizeCount = generalScalingMap[scaleStyle] + 1;
                    generalScalingMap[scaleStyle] = generalScalingSizeCount;
                }
                else
                {
                    generalScalingMap.Add(scaleStyle, 1);
                }

                rngGeneralScaling.Select();
                // Move the start position 1 character.
                rngGeneralScaling.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                // Move the end position 1 character.
                rngGeneralScaling.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
            }
            watchCharactersScale.Stop();
            LogExecutionTime("CharactersScale", watchCharactersScale);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.codedScaling = codedScaling;
            resultValues.generalScalingMap = generalScalingMap;
            resultValues.enableConreteMethodsCheck = enableConreteMethodsCheck;

            docs.Close();
            word.Quit();

            (new ResultCharacterScaleGeneralScreen(resultValues)).ShowDialog();
        }

        private void detectUnderlineMethods_Click(object sender, EventArgs e)
        {
            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            // Define a range of 1 character. 
            object start = 0; object startGeneral = 0; int startGeneralCount = 0;
            object end = 1; object endGeneral = 3; int endGeneralCount = 3;
            Microsoft.Office.Interop.Word.Range rngGeneralUnderline = docs.Range(ref start, ref end);
            Microsoft.Office.Interop.Word.Range rngGeneralUnderlineAll = docs.Range(ref start);
            Microsoft.Office.Interop.Word.Range rngUnderline = docs.Range(ref start, ref end);
            Microsoft.Office.Interop.Word.Range rngUnderlineAll = docs.Range(ref start);

            #region check for underline
            //approach 1: first we check if our concrete algotirtam is used
            int codedUnderline = 0;
            int actualSizeUnderline = rngUnderlineAll.Text.Length - 1;
            int numCheckUnderline = 0;

            if (enableConreteMethodsCheck == true)
            {
                while ((rngUnderline.End - 1) < actualSizeUnderline)
                {
                    if (Array.IndexOf(excludeUnderlineChars, rngUnderline.Text.Trim().ToLower()) > -1)
                    {
                        rngUnderline.Select();
                        // Move the start position 1 character
                        rngUnderline.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                        // Move the end position 1 character
                        rngUnderline.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                        continue;
                    }

                    //if after 5 characters a code is still not detected, then skip this coding check
                    numCheckUnderline++;
                    if (numCheckUnderline == 6)
                        break;

                    bool underlineC = false;
                    bool underlineS = false;

                    string underColor = rngUnderline.Font.UnderlineColor.ToString();
                    //decode underline color
                    for (int countColo = 0; countColo < colorUnderlineStringMap.Length; countColo++)
                    {
                        if (colorUnderlineStringMap[countColo] == underColor)
                        {
                            underlineC = true;
                        }
                    }

                    string underStyle = rngUnderline.Font.Underline.ToString();
                    //decode underline styles                
                    for (int countStyl = 0; countStyl < lineUnderlineStyleMap.Length; countStyl++)
                    {
                        if (lineUnderlineStyleMap[countStyl].ToString() == underStyle)
                        {
                            underlineS = true;
                        }
                    }

                    //[4 bis for UnderlineColor][4 bits for UnderlineStyle]
                    //ascii to char conversion (binary vo decimal vo ascii)

                    if (underlineC == true && underlineS == true)
                    {
                        codedUnderline++;
                        //break;
                    }

                    rngUnderline.Select();
                    // Move the start position 1 character
                    rngUnderline.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                    // Move the end position 1 character
                    rngUnderline.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                }
            }
            //approach 2: then we are doing more general check if character underline is susposious
            int actualSizeGeneralUnderline = rngGeneralUnderlineAll.Text.Length - 1;

            var watchUnderline = new System.Diagnostics.Stopwatch();
            watchUnderline.Start();
            while ((rngGeneralUnderline.End - 1) < actualSizeGeneralUnderline)
            {
                if (Array.IndexOf(excludeUnderlineChars, rngUnderline.Text.Trim().ToLower()) > -1)
                {
                    rngUnderline.Select();
                    // Move the start position 1 character
                    rngUnderline.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                    // Move the end position 1 character
                    rngUnderline.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                    continue;
                }

                string underColor = rngGeneralUnderline.Font.UnderlineColor.ToString();
                string underStyle = rngGeneralUnderline.Font.Underline.ToString();
                if (generalUnderlineMap.ContainsKey(underColor + "-" + underStyle))
                {
                    int generalUnderlineColorCount = generalUnderlineMap[underColor + "-" + underStyle] + 1;
                    generalUnderlineMap[underColor + "-" + underStyle] = generalUnderlineColorCount;
                }
                else
                {
                    generalUnderlineMap.Add(underColor + "-" + underStyle, 1);
                }

                rngGeneralUnderline.Select();
                // Move the start position 1 character
                rngGeneralUnderline.MoveStart(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
                // Move the end position 1 character
                rngGeneralUnderline.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, 1);
            }
            watchUnderline.Stop();
            LogExecutionTime("Underline", watchUnderline);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.codedUnderline = codedUnderline;
            resultValues.generalUnderlineMap = generalUnderlineMap;
            resultValues.enableConreteMethodsCheck = enableConreteMethodsCheck;

            docs.Close();
            word.Quit();

            (new ResultUnderlineGeneralScreen(resultValues)).ShowDialog();
        }

        private void detectSentenceBorderMethods_Click(object sender, EventArgs e)
        {
            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            Microsoft.Office.Interop.Word.Range rangeSentenceGeneralBorderCountSentences = word.ActiveDocument.Content;
            Microsoft.Office.Interop.Word.Range rangeSentenceBorderCountSentences = word.ActiveDocument.Content;

            #region check for sentence border
            //approach 1: first we check if our concrete algotirtam is used    
            var leftBorderSentenceBorder = WdBorderType.wdBorderLeft;
            int codedSentenceBorder = 0;
            if (enableConreteMethodsCheck == true)
            {
                for (int k = 1; k <= rangeSentenceBorderCountSentences.Sentences.Count; k++)
                {
                    //if after 5 sentences a code is still not detected, then skip this coding check
                    if (k == 6)
                        break;

                    bool leftBorderSentenceBorderC = false;
                    bool leftBorderSentenceBorderS = false;

                    Microsoft.Office.Interop.Word.Range s1 = rangeSentenceBorderCountSentences.Sentences[k];
                    string bordColor = s1.Borders[leftBorderSentenceBorder].Color.ToString();
                    //decode border colors
                    for (int countColo = 0; countColo < colorSentenceBorderStringMap.Length; countColo++)
                    {
                        if (colorSentenceBorderStringMap[countColo] == bordColor)
                        {
                            leftBorderSentenceBorderC = true;
                        }
                    }

                    string bordStyle = s1.Borders[leftBorderSentenceBorder].LineStyle.ToString();
                    //decode border styles                
                    for (int countStyl = 0; countStyl < lineSentenceBorderStyleMap.Length; countStyl++)
                    {
                        if (lineSentenceBorderStyleMap[countStyl].ToString() == bordStyle)
                        {
                            leftBorderSentenceBorderS = true;
                        }
                    }

                    //[4 bis for BorderColor][3 bits for BorderStyle]
                    //ascii to char conversion (binary vo decimal vo ascii)

                    if (leftBorderSentenceBorderC == true && leftBorderSentenceBorderS == true)
                    {
                        codedSentenceBorder++;
                        break;
                    }
                }
            }
            //approach 2: then we are doing more general check if sentence border is susposious
            var leftBorderGeneralSentenceBorder = WdBorderType.wdBorderLeft;
            var rightBorderGeneralSentenceBorder = WdBorderType.wdBorderRight;
            //count left border color - left border style occurencies
            var watchSentenceBorder = new System.Diagnostics.Stopwatch();
            watchSentenceBorder.Start();
            for (int k = 1; k <= rangeSentenceGeneralBorderCountSentences.Sentences.Count; k++)
            {
                Microsoft.Office.Interop.Word.Range s1 = rangeSentenceGeneralBorderCountSentences.Sentences[k];

                string leftBordSentenceGeneralColor = s1.Borders[leftBorderGeneralSentenceBorder].Color.ToString();
                string leftBordSentenceGeneralStyle = s1.Borders[leftBorderGeneralSentenceBorder].LineStyle.ToString();
                if (generalSentenceLeftBorderMap.ContainsKey(leftBordSentenceGeneralColor + "-" + leftBordSentenceGeneralStyle))
                {
                    int generalLeftBorderCount = generalSentenceLeftBorderMap[leftBordSentenceGeneralColor + "-" + leftBordSentenceGeneralStyle] + 1;
                    generalSentenceLeftBorderMap[leftBordSentenceGeneralColor + "-" + leftBordSentenceGeneralStyle] = generalLeftBorderCount;
                }
                else
                {
                    generalSentenceLeftBorderMap.Add(leftBordSentenceGeneralColor + "-" + leftBordSentenceGeneralStyle, 1);
                }

                string rightBordSentenceGeneralColor = s1.Borders[rightBorderGeneralSentenceBorder].Color.ToString();
                string rightBordSentenceGeneralStyle = s1.Borders[rightBorderGeneralSentenceBorder].LineStyle.ToString();
                if (generalSentenceRightBorderMap.ContainsKey(rightBordSentenceGeneralColor + "-" + rightBordSentenceGeneralStyle))
                {
                    int generalRightBorderCount = generalSentenceRightBorderMap[rightBordSentenceGeneralColor + "-" + rightBordSentenceGeneralStyle] + 1;
                    generalSentenceRightBorderMap[rightBordSentenceGeneralColor + "-" + rightBordSentenceGeneralStyle] = generalRightBorderCount;
                }
                else
                {
                    generalSentenceRightBorderMap.Add(rightBordSentenceGeneralColor + "-" + rightBordSentenceGeneralStyle, 1);
                }
            }
            watchSentenceBorder.Stop();
            LogExecutionTime("SentenceBorder", watchSentenceBorder);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.codedSentenceBorder = codedSentenceBorder;
            resultValues.generalSentenceLeftBorderMap = generalSentenceLeftBorderMap;
            resultValues.generalSentenceRightBorderMap = generalSentenceRightBorderMap;
            resultValues.enableConreteMethodsCheck = enableConreteMethodsCheck;

            docs.Close();
            word.Quit();

            (new ResultSentenceBorderGeneralScreen(resultValues)).ShowDialog();
        }

        private void detectParagraphBorderGeneralMethod_Click(object sender, EventArgs e)
        {
            resetGlobalCounters();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = documentPath;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);

            #region check for paragraph border
            //approach 1: first we check if our concrete algotirtam is used            
            int codedParagraphBorder = 0;
            int numCheckParagraphBorder = 0;
            if (enableConreteMethodsCheck == true)
            {
                foreach (Microsoft.Office.Interop.Word.Paragraph aPar in docs.Paragraphs)
                {
                    //if after 5 paragraphs a code is still not detected, then skip this coding check
                    numCheckParagraphBorder++;
                    if (numCheckParagraphBorder == 5)
                        break;

                    bool leftBorderParagraphBorderC = false;
                    bool leftBorderParagraphBorderS = false;
                    bool rightBorderParagraphBorderC = false;
                    bool rightBorderParagraphBorderS = false;

                    Microsoft.Office.Interop.Word.Range parRng = aPar.Range;
                    var leftBorderParagraph = WdBorderType.wdBorderLeft;
                    var rightBorderParagraph = WdBorderType.wdBorderRight;

                    string leftBordColor = parRng.Borders[leftBorderParagraph].Color.ToString();
                    string rightBordColor = parRng.Borders[rightBorderParagraph].Color.ToString();
                    //check if border colors are coded
                    for (int countColo = 0; countColo < colorParagraphBorderStringMap.Length; countColo++)
                    {
                        if (colorParagraphBorderStringMap[countColo] == leftBordColor)
                        {
                            leftBorderParagraphBorderC = true;
                        }
                        if (colorParagraphBorderStringMap[countColo] == rightBordColor)
                        {
                            rightBorderParagraphBorderC = true;
                        }
                    }

                    string leftBordStyle = parRng.Borders[leftBorderParagraph].LineStyle.ToString();
                    string rightBordStyle = parRng.Borders[rightBorderParagraph].LineStyle.ToString();
                    //check if border styles are coded
                    for (int countStyl = 0; countStyl < lineParagraphBorderStyleMap.Length; countStyl++)
                    {
                        if (lineParagraphBorderStyleMap[countStyl].ToString() == leftBordStyle)
                        {
                            leftBorderParagraphBorderS = true;
                        }
                        if (lineParagraphBorderStyleMap[countStyl].ToString() == rightBordStyle)
                        {
                            rightBorderParagraphBorderS = true;
                        }
                    }

                    //[4 bis for leftBorderColor][4 bits for leftBorderStyle][4 bis for rightBorderColor][4 bits for rightBorderStyle]
                    //ascii to char conversion (binary vo decimal vo ascii)

                    if (leftBorderParagraphBorderC == true && leftBorderParagraphBorderS == true &&
                        rightBorderParagraphBorderC == true && rightBorderParagraphBorderS == true)
                    {
                        codedParagraphBorder++;
                        break;
                    }
                }
            }
            //approach 2: then we are doing more general check if pargraph border is susposious
            var watchParagraphBorder = new System.Diagnostics.Stopwatch();
            watchParagraphBorder.Start();
            foreach (Microsoft.Office.Interop.Word.Paragraph aGeneralPar in docs.Paragraphs)
            {
                Microsoft.Office.Interop.Word.Range parGeneralRng = aGeneralPar.Range;
                var leftBorderGeneralParagraph = WdBorderType.wdBorderLeft;
                var rightBorderGeneralParagraph = WdBorderType.wdBorderRight;

                string leftBordGeneralColor = parGeneralRng.Borders[leftBorderGeneralParagraph].Color.ToString();
                string leftBordGeneralStyle = parGeneralRng.Borders[leftBorderGeneralParagraph].LineStyle.ToString();
                //count left border color - left border style occurencies
                if (generalParagraphLeftBorderMap.ContainsKey(leftBordGeneralColor + "-" + leftBordGeneralStyle))
                {
                    int generalLeftBorderColorCount = generalParagraphLeftBorderMap[leftBordGeneralColor + "-" + leftBordGeneralStyle] + 1;
                    generalParagraphLeftBorderMap[leftBordGeneralColor + "-" + leftBordGeneralStyle] = generalLeftBorderColorCount;
                }
                else
                {
                    generalParagraphLeftBorderMap.Add(leftBordGeneralColor + "-" + leftBordGeneralStyle, 1);
                }

                string rightBordGeneralColor = parGeneralRng.Borders[rightBorderGeneralParagraph].Color.ToString();
                string rightBordGeneralStyle = parGeneralRng.Borders[rightBorderGeneralParagraph].LineStyle.ToString();
                //count right border color - right border style occurencies
                if (generalParagraphRightBorderMap.ContainsKey(rightBordGeneralColor + "-" + rightBordGeneralStyle))
                {
                    int generalLeftBorderColorCount = generalParagraphRightBorderMap[rightBordGeneralColor + "-" + rightBordGeneralStyle] + 1;
                    generalParagraphRightBorderMap[rightBordGeneralColor + "-" + rightBordGeneralStyle] = generalLeftBorderColorCount;
                }
                else
                {
                    generalParagraphRightBorderMap.Add(rightBordGeneralColor + "-" + rightBordGeneralStyle, 1);
                }
            }
            watchParagraphBorder.Stop();
            LogExecutionTime("ParagraphBorder", watchParagraphBorder);
            #endregion

            ResultValues resultValues = new ResultValues();
            resultValues.codedParagraphBorder = codedParagraphBorder;
            resultValues.generalParagraphLeftBorderMap = generalParagraphLeftBorderMap;
            resultValues.generalParagraphRightBorderMap = generalParagraphRightBorderMap;
            resultValues.enableConreteMethodsCheck = enableConreteMethodsCheck;

            docs.Close();
            word.Quit();

            (new ResultParagraphBorderGeneralScreen(resultValues)).ShowDialog();
        }

        private void DetectCoding_Load(object sender, EventArgs e)
        {
            detectWordMappingsMethods.Visible = enableWordMapping;
            detectColorQuantizationMethod.Visible = enableColorQuantization;
            detectUnicodesMethod.Visible = enableUnicodes;

            if (!System.IO.File.Exists(documentTimeLogsPath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(documentTimeLogsPath)) { }
                using (System.IO.StreamWriter fileTimeLog = new System.IO.StreamWriter(documentTimeLogsPath, true))
                {
                    fileTimeLog.WriteLine("-----------------------");
                }
            }
        }

        public void LogExecutionTime(string methodName, System.Diagnostics.Stopwatch watchTimer)
        {
            if (enableTimeExecutionLog == false)
                return;

            using (System.IO.StreamWriter fileTimeLog = new System.IO.StreamWriter(documentTimeLogsPath, true))
            {                
                fileTimeLog.WriteLine("Method: " + methodName);
                fileTimeLog.WriteLine("Document: " + chosenDocumentLabel.Text);
                fileTimeLog.WriteLine("Execution Time: " + watchTimer.ElapsedMilliseconds + " milliseconds / " + (decimal)(watchTimer.ElapsedMilliseconds / 1000.0) + " seconds / " + (decimal)(watchTimer.ElapsedMilliseconds / 60000.0) + " minutes");
                fileTimeLog.WriteLine("-----------------------");
                watchTimer.Reset();
            }
        }
    }
}