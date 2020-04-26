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
    public partial class ResultSentenceBorderGeneralScreen : Form
    {
        public ResultSentenceBorderGeneralScreen()
        {
            InitializeComponent();
        }

        public ResultSentenceBorderGeneralScreen(ResultValues resultValues)
        {
            InitializeComponent();

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
        }
    }
}