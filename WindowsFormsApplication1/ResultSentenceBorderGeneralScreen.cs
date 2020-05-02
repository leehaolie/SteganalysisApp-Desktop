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

            codedSentenceBorder_value.Text = (resultValues.codedSentenceBorder >= 5) ? "true" : "false";
            generalSentenceLeftBorderMap_table.Controls.Clear();
            generalSentenceLeftBorderMap_table.Controls.Add(new Label() { Text = "Border Style", Name = "generalSentenceLeftBorderMap_table_col0_header" }, 0, 0);
            generalSentenceLeftBorderMap_table.Controls.Add(new Label() { Text = "Frequency", Name = "generalSentenceLeftBorderMap_table_col1_header" }, 1, 0);
            generalSentenceLeftBorderMap_table.RowCount = 1;
            generalSentenceLeftBorderMap_table.RowStyles[0] = (new RowStyle(SizeType.Absolute, 16F));
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

                generalSentenceLeftBorderMap_table.RowCount = generalSentenceLeftBorderMap_table.RowCount + 1;
                generalSentenceLeftBorderMap_table.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
                generalSentenceLeftBorderMap_table.Controls.Add(new Label() { Text = generalSentenceLeftBorderMap_combinationName, Name = "generalSentenceLeftBorderMap_table_col0_row" + generalSentenceLeftBorderMap_table_row }, 0, generalSentenceLeftBorderMap_table_row);
                generalSentenceLeftBorderMap_table.Controls.Add(new Label() { Text = entry.Value.ToString(), Name = "generalSentenceLeftBorderMap_table_col1_row" + generalSentenceLeftBorderMap_table_row }, 1, generalSentenceLeftBorderMap_table_row);
                generalSentenceLeftBorderMap_table_row++;
            }
        }
    }
}