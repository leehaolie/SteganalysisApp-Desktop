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
    public partial class ResultScreen : Form
    {
        public ResultScreen()
        {
            InitializeComponent();
        }

        public ResultScreen(ResultValues resultValues)
        {
            InitializeComponent();

            //MessageBox.Show("openSpacesSentencesTotal = " + resultValues.openSpacesSentencesTotal + " / openSpacesSentencesPotential = " + resultValues.openSpacesSentencesPotential);
            openSpacesSentencesTotal_value.Text = resultValues.openSpacesSentencesTotal.ToString();
            openSpacesSentencesPotential_value.Text = resultValues.openSpacesSentencesPotential.ToString();

            //MessageBox.Show("openSpacesWordsTotal = " + resultValues.openSpacesWordsTotal + " / openSpacesWordsPotential = " + resultValues.openSpacesWordsPotential);
            openSpacesWordsTotal_value.Text = resultValues.openSpacesWordsTotal.ToString();
            openSpacesWordsPotential_value.Text = resultValues.openSpacesWordsPotential.ToString();

            //MessageBox.Show("wordMappingOption1Total = " + resultValues.wordMappingOption1Total + " / wordMappingOption1Potential = " + resultValues.wordMappingOption1Potential);
            wordMappingOption1Total_value.Text = resultValues.wordMappingOption1Total.ToString();
            wordMappingOption1Potential_value.Text = resultValues.wordMappingOption1Potential.ToString();

            //MessageBox.Show("wordMappingOption2Total = " + resultValues.wordMappingOption2Total + " / wordMappingOption2Potential = " + resultValues.wordMappingOption2Potential);
            wordMappingOption2Total_value.Text = resultValues.wordMappingOption2Total.ToString();
            wordMappingOption2Potential_value.Text = resultValues.wordMappingOption2Potential.ToString();

            //MessageBox.Show("invisibleCharactersTotal = " + resultValues.invisibleCharactersTotal + " / invisibleCharactersPotential = " + resultValues.invisibleCharactersPotential);
            invisibleCharactersTotal_value.Text = resultValues.invisibleCharactersTotal.ToString();
            invisibleCharactersPotential_value.Text = resultValues.invisibleCharactersPotential.ToString();
            /*
            if (resultValues.codedWhiteSpaces > 0)
                MessageBox.Show("Steganography method is 'Word Spacing'");
            else
                MessageBox.Show("Steganography method is NOT 'Word Spacing'");
            */
            codedWhiteSpaces_value.Text = (resultValues.codedWhiteSpaces > 0) ? "true" : "false";

            //MessageBox.Show("colorQuantizationTotal = " + resultValues.colorQuantizationTotal + " / colorQuantizationLight = " + resultValues.colorQuantizationLight + " / colorQuantizationDark = " + resultValues.colorQuantizationDark);
            colorQuantizationTotal_value.Text = resultValues.colorQuantizationTotal.ToString();
            colorQuantizationLight_value.Text = resultValues.colorQuantizationLight.ToString();
            colorQuantizationLight_levels_value.Text = "(levels: " + (resultValues.colorQuantizationLightLevels.Length - 1).ToString() + ")";
            colorQuantizationDark_value.Text = resultValues.colorQuantizationDark.ToString();
            colorQuantizationDark_levels_value.Text = "(levels: " + (resultValues.colorQuantizationDarkLevels.Length - 1).ToString() + ")";

            //MessageBox.Show("fontTypeTotal = " + resultValues.fontTypeTotal + " / fontTypePotential = " + resultValues.fontTypePotential + " / fontTypeDirectoryCount.Keys.Count = " + resultValues.fontTypeDirectoryCount.Keys.Count);
            fontTypeTotal_value.Text = resultValues.fontTypeTotal.ToString();
            fontTypePotential_value.Text = resultValues.fontTypePotential.ToString();
            fontTypeDirectoryCount_value.Text = resultValues.fontTypeDirectoryCount.Keys.Count.ToString();

            //MessageBox.Show("unicodeNumberSymbols = " + resultValues.unicodeNumberSymbols);
            unicodeNumberSymbols_value.Text = resultValues.unicodeNumberSymbols.ToString();

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "Symbol" }, 0, 0);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "enc 1" }, 1, 0);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "enc 2" }, 2, 0);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "enc 3" }, 3, 0);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "enc 4" }, 4, 0);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "A" }, 0, 1);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["A0041"].ToString() }, 1, 1);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["A0391"].ToString() }, 2, 1);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["A0410"].ToString() }, 3, 1);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["A13AA"].ToString() }, 4, 1);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "B" }, 0, 2);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["B0042"].ToString() }, 1, 2);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["B0392"].ToString() }, 2, 2);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["B0412"].ToString() }, 3, 2);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["B0181"].ToString() }, 4, 2);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "E" }, 0, 3);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["E0045"].ToString() }, 1, 3);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["E0395"].ToString() }, 2, 3);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["E0415"].ToString() }, 3, 3);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["E13AC"].ToString() }, 4, 3);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "G" }, 0, 4);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["G0047"].ToString() }, 1, 4);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["G050C"].ToString() }, 2, 4);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["G13C0"].ToString() }, 3, 4);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["G13B6"].ToString() }, 4, 4);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "H" }, 0, 5);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["H0048"].ToString() }, 1, 5);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["H0397"].ToString() }, 2, 5);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["H041D"].ToString() }, 3, 5);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["H13BB"].ToString() }, 4, 5);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "I" }, 0, 6);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["I0049"].ToString() }, 1, 6);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["I0399"].ToString() }, 2, 6);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["I04C0"].ToString() }, 3, 6);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["I0406"].ToString() }, 4, 6);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "M" }, 0, 7);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["M004D"].ToString() }, 1, 7);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["M039C"].ToString() }, 2, 7);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["M041C"].ToString() }, 3, 7);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["M216F"].ToString() }, 4, 7);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "O" }, 0, 8);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["O004F"].ToString() }, 1, 8);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["O039F"].ToString() }, 2, 8);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["O041E"].ToString() }, 3, 8);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["O0555"].ToString() }, 4, 8);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "P" }, 0, 9);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["P0050"].ToString() }, 1, 9);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["P0420"].ToString() }, 2, 9);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["P03A1"].ToString() }, 3, 9);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["P01A4"].ToString() }, 4, 9);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "S" }, 0, 10);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["S0053"].ToString() }, 1, 10);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["S0405"].ToString() }, 2, 10);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["S054F"].ToString() }, 3, 10);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["S13DA"].ToString() }, 4, 10);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "T" }, 0, 11);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["T0054"].ToString() }, 1, 11);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["T0422"].ToString() }, 2, 11);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["T03A4"].ToString() }, 3, 11);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["T01AC"].ToString() }, 4, 11);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "j" }, 0, 12);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["j006A"].ToString() }, 1, 12);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["j0458"].ToString() }, 2, 12);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["j03F3"].ToString() }, 3, 12);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["j029D"].ToString() }, 4, 12);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "o" }, 0, 13);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["o006F"].ToString() }, 1, 13);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["o03BF"].ToString() }, 2, 13);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["o1D0F"].ToString() }, 3, 13);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["o043E"].ToString() }, 4, 13);

            /*
            if (resultValues.codedScaling == 8)
                MessageBox.Show("Steganography method is 'Scaling Character'");
            else
                MessageBox.Show("Steganography method is NOT 'Scaling Character'");
            */
            codedScaling_value.Text = (resultValues.codedScaling >= 8) ? "true" : "false";
            generalScalingMap_table.Controls.Add(new Label() { Text = "Scale Size" }, 0, 0);
            generalScalingMap_table.Controls.Add(new Label() { Text = "Frequency" }, 1, 0);
            int generalScalingMap_table_row = 1;
            foreach (KeyValuePair<string, int> entry in resultValues.generalScalingMap)
            {
                string scaleSize = entry.Key.ToString();
                if (entry.Key.ToString() == "100")
                {
                    scaleSize = "default";
                }

                generalScalingMap_table.Controls.Add(new Label() { Text = scaleSize }, 0, generalScalingMap_table_row);
                generalScalingMap_table.Controls.Add(new Label() { Text = entry.Value.ToString() }, 1, generalScalingMap_table_row);
                generalScalingMap_table_row++;
            }
            generalScalingMap_table.Height += resultValues.generalScalingMap.Keys.Count * 16;
            character_scale_group.Height += resultValues.generalScalingMap.Keys.Count * 16;

            /*
            if (resultValues.codedUnderline > 0)
                MessageBox.Show("Steganography method is 'Underline Character'");
            else
                MessageBox.Show("Steganography method is NOT 'Underline Character'");
            */
            codedUnderline_value.Text = (resultValues.codedUnderline >= 5) ? "true" : "false";
            generalUnderlineMap_table.Controls.Add(new Label() { Text = "Underline Style" }, 0, 0);
            generalUnderlineMap_table.Controls.Add(new Label() { Text = "Frequency" }, 1, 0);
            int generalUnderlineMap_table_row = 1;
            int generalUnderlineMap_combinationNumber = 1;
            foreach (KeyValuePair<string, int> entry in resultValues.generalUnderlineMap)
            {
                string generalUnderlineMap_combinationName = "";
                if (entry.Key == (WdColor.wdColorAutomatic.ToString() + "-" + WdUnderline.wdUnderlineSingle.ToString()))
                {
                    generalUnderlineMap_combinationName = "default";
                }
                else
                {
                    generalUnderlineMap_combinationName = "comb " + generalUnderlineMap_combinationNumber;
                    generalUnderlineMap_combinationNumber++;
                }
                
                generalUnderlineMap_table.Controls.Add(new Label() { Text = generalUnderlineMap_combinationName }, 0, generalUnderlineMap_table_row);
                generalUnderlineMap_table.Controls.Add(new Label() { Text = entry.Value.ToString() }, 1, generalUnderlineMap_table_row);
                generalUnderlineMap_table_row++;
            }
            generalUnderlineMap_table.Height += resultValues.generalUnderlineMap.Keys.Count * 16;
            underline_group.Height += resultValues.generalUnderlineMap.Keys.Count * 16;

            /*
            if (resultValues.codedSentenceBorder > 0)
                MessageBox.Show("Steganography method is 'Sentence Border'");
            else
                MessageBox.Show("Steganography method is NOT 'Sentence Border'");
            */
            codedSentenceBorder_value.Text = (resultValues.codedSentenceBorder >= 5) ? "true" : "false";
            generalSentenceLeftBorderMap_table.Controls.Add(new Label() { Text = "Border Style" }, 0, 0);
            generalSentenceLeftBorderMap_table.Controls.Add(new Label() { Text = "Frequency" }, 1, 0);
            int generalSentenceLeftBorderMap_table_row = 1;
            int generalSentenceLeftBorderMap_combinationNumber = 1;
            foreach (KeyValuePair<string, int> entry in resultValues.generalSentenceLeftBorderMap)
            {
                string generalSentenceLeftBorderMap_combinationName = "";
                if (entry.Key == (WdColor.wdColorAutomatic.ToString() + "-" + WdLineStyle.wdLineStyleNone.ToString()))
                {
                    generalSentenceLeftBorderMap_combinationName = "default";
                }
                else
                {
                    generalSentenceLeftBorderMap_combinationName = "comb " + generalSentenceLeftBorderMap_combinationNumber;
                    generalSentenceLeftBorderMap_combinationNumber++;
                }

                generalSentenceLeftBorderMap_table.Controls.Add(new Label() { Text = generalSentenceLeftBorderMap_combinationName }, 0, generalSentenceLeftBorderMap_table_row);
                generalSentenceLeftBorderMap_table.Controls.Add(new Label() { Text = entry.Value.ToString() }, 1, generalSentenceLeftBorderMap_table_row);
                generalSentenceLeftBorderMap_table_row++;
            }
            generalSentenceLeftBorderMap_table.Height += resultValues.generalSentenceLeftBorderMap.Keys.Count * 16;
            sentence_border_left_group.Height += resultValues.generalSentenceLeftBorderMap.Keys.Count * 16;

            /*
            if (resultValues.codedParagraphBorder > 0)
                MessageBox.Show("Steganography method is 'Paragraph Border'");
            else
                MessageBox.Show("Steganography method is NOT 'Paragraph Border'");
            */
            codedParagraphBorder_value.Text = (resultValues.codedParagraphBorder >= 5) ? "true" : "false";

            generalParagraphLeftBorderMap_table.Controls.Add(new Label() { Text = "Border Style" }, 0, 0);
            generalParagraphLeftBorderMap_table.Controls.Add(new Label() { Text = "Frequency" }, 1, 0);
            int generalParagraphLeftBorderMap_table_row = 1;
            int generalParagraphLeftBorderMap_table_row_combinationNumber = 1;
            foreach (KeyValuePair<string, int> entry in resultValues.generalParagraphLeftBorderMap)
            {
                string generalParagraphLeftBorderMap_combinationName = "";
                if (entry.Key == (WdColor.wdColorAutomatic.ToString() + "-" + WdLineStyle.wdLineStyleNone.ToString()))
                {
                    generalParagraphLeftBorderMap_combinationName = "default";
                }
                else
                {
                    generalParagraphLeftBorderMap_combinationName = "comb " + generalParagraphLeftBorderMap_table_row_combinationNumber;
                    generalParagraphLeftBorderMap_table_row_combinationNumber++;
                }

                generalParagraphLeftBorderMap_table.Controls.Add(new Label() { Text = generalParagraphLeftBorderMap_combinationName }, 0, generalParagraphLeftBorderMap_table_row);
                generalParagraphLeftBorderMap_table.Controls.Add(new Label() { Text = entry.Value.ToString() }, 1, generalParagraphLeftBorderMap_table_row);
                generalParagraphLeftBorderMap_table_row++;
            }
            generalParagraphLeftBorderMap_table.Height += resultValues.generalParagraphLeftBorderMap.Keys.Count * 16;

            generalParagraphRightBorderMap_table.Controls.Add(new Label() { Text = "Border Style" }, 0, 0);
            generalParagraphRightBorderMap_table.Controls.Add(new Label() { Text = "Frequency" }, 1, 0);
            int generalParagraphRightBorderMap_table_row = 1;
            int generalParagraphRightBorderMap_table_row_combinationNumber = 1;
            foreach (KeyValuePair<string, int> entry in resultValues.generalParagraphRightBorderMap)
            {
                string generalParagraphRightBorderMap_combinationName = "";
                if (entry.Key == (WdColor.wdColorAutomatic.ToString() + "-" + WdLineStyle.wdLineStyleNone.ToString()))
                {
                    generalParagraphRightBorderMap_combinationName = "default";
                }
                else
                {
                    generalParagraphRightBorderMap_combinationName = "comb " + generalParagraphRightBorderMap_table_row_combinationNumber;
                    generalParagraphRightBorderMap_table_row_combinationNumber++;
                }

                generalParagraphRightBorderMap_table.Controls.Add(new Label() { Text = generalParagraphRightBorderMap_combinationName }, 0, generalParagraphRightBorderMap_table_row);
                generalParagraphRightBorderMap_table.Controls.Add(new Label() { Text = entry.Value.ToString() }, 1, generalParagraphRightBorderMap_table_row);
                generalParagraphRightBorderMap_table_row++;
            }
            generalParagraphRightBorderMap_table.Height += resultValues.generalParagraphRightBorderMap.Keys.Count * 16;

            paragraph_border_group.Height += Math.Max(resultValues.generalParagraphLeftBorderMap.Keys.Count, resultValues.generalParagraphRightBorderMap.Keys.Count) * 16;
            paragraph_border_group.Top = Math.Max(underline_group.Bottom, sentence_border_left_group.Bottom) + 20;

            //invisibleCharactersThatTakesNoSpaceHexMap            
            invisibleCharactersThatTakesNoSpaceHexMap_table.Controls.Add(new Label() { Text = "Hex Code" }, 0, 0);
            invisibleCharactersThatTakesNoSpaceHexMap_table.Controls.Add(new Label() { Text = "Frequency" }, 1, 0);
            int invisibleCharactersThatTakesNoSpaceHexMap_table_row = 1;
            foreach (KeyValuePair<string, int> entry in resultValues.invisibleCharactersThatTakesNoSpaceHexMap)
            {
                invisibleCharactersThatTakesNoSpaceHexMap_table.Controls.Add(new Label() { Text = entry.Key }, 0, invisibleCharactersThatTakesNoSpaceHexMap_table_row);
                invisibleCharactersThatTakesNoSpaceHexMap_table.Controls.Add(new Label() { Text = entry.Value.ToString() }, 1, invisibleCharactersThatTakesNoSpaceHexMap_table_row);
                invisibleCharactersThatTakesNoSpaceHexMap_table_row++;
            }
            invisibleCharactersThatTakesNoSpaceHexMap_table.Height += resultValues.invisibleCharactersThatTakesNoSpaceHexMap.Keys.Count * 16;
            invisible_characters_nospace_group.Height += resultValues.invisibleCharactersThatTakesNoSpaceHexMap.Keys.Count * 16;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}