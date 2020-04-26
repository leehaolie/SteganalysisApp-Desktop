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
    public partial class ResultParagraphBorderGeneralScreen : Form
    {
        public ResultParagraphBorderGeneralScreen()
        {
            InitializeComponent();
        }

        public ResultParagraphBorderGeneralScreen(ResultValues resultValues)
        {
            InitializeComponent();

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
        }
    }
}