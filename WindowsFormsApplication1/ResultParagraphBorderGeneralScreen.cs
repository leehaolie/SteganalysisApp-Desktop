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

            codedParagraphBorder_value.Text = (resultValues.codedParagraphBorder >= 5) ? "true" : "false";
            generalParagraphLeftBorderMap_table.Controls.Clear();
            generalParagraphLeftBorderMap_table.Controls.Add(new Label() { Text = "Border Style", Name = "generalParagraphLeftBorderMap_table_col0_header" }, 0, 0);
            generalParagraphLeftBorderMap_table.Controls.Add(new Label() { Text = "Frequency", Name = "generalParagraphLeftBorderMap_table_col1_header" }, 1, 0);
            generalParagraphLeftBorderMap_table.RowCount = 1;
            generalParagraphLeftBorderMap_table.RowStyles[0] = (new RowStyle(SizeType.Absolute, 16F));
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

                generalParagraphLeftBorderMap_table.RowCount = generalParagraphLeftBorderMap_table.RowCount + 1;
                generalParagraphLeftBorderMap_table.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
                generalParagraphLeftBorderMap_table.Controls.Add(new Label() { Text = generalParagraphLeftBorderMap_combinationName, Name = "generalParagraphLeftBorderMap_table_col0_row" + generalParagraphLeftBorderMap_table_row }, 0, generalParagraphLeftBorderMap_table_row);
                generalParagraphLeftBorderMap_table.Controls.Add(new Label() { Text = entry.Value.ToString(), Name = "generalParagraphLeftBorderMap_table_col1_row" + generalParagraphLeftBorderMap_table_row }, 1, generalParagraphLeftBorderMap_table_row);
                generalParagraphLeftBorderMap_table_row++;
            }

            generalParagraphRightBorderMap_table.Controls.Clear();
            generalParagraphRightBorderMap_table.Controls.Add(new Label() { Text = "Border Style", Name = "generalParagraphRightBorderMap_table_col0_header" }, 0, 0);
            generalParagraphRightBorderMap_table.Controls.Add(new Label() { Text = "Frequency", Name = "generalParagraphRightBorderMap_table_col1_header" }, 1, 0);
            generalParagraphRightBorderMap_table.RowCount = 1;
            generalParagraphRightBorderMap_table.RowStyles[0] = (new RowStyle(SizeType.Absolute, 16F));
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

                generalParagraphRightBorderMap_table.RowCount = generalParagraphRightBorderMap_table.RowCount + 1;
                generalParagraphRightBorderMap_table.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
                generalParagraphRightBorderMap_table.Controls.Add(new Label() { Text = generalParagraphRightBorderMap_combinationName, Name = "generalParagraphRightBorderMap_table_col0_row" + generalParagraphRightBorderMap_table_row }, 0, generalParagraphRightBorderMap_table_row);
                generalParagraphRightBorderMap_table.Controls.Add(new Label() { Text = entry.Value.ToString(), Name = "generalParagraphRightBorderMap_table_col1_row" + generalParagraphRightBorderMap_table_row }, 1, generalParagraphRightBorderMap_table_row);
                generalParagraphRightBorderMap_table_row++;
            }
        }
    }
}