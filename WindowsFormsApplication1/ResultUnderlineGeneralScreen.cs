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
    public partial class ResultUnderlineGeneralScreen : Form
    {
        public ResultUnderlineGeneralScreen()
        {
            InitializeComponent();
        }

        public ResultUnderlineGeneralScreen(ResultValues resultValues)
        {
            InitializeComponent();

            codedUnderline_value.Text = (resultValues.codedUnderline >= 5) ? "true" : "false";
            if (resultValues.enableConreteMethodsCheck == false)
            {
                codedUnderline_label.Visible = false;
                codedUnderline_value.Visible = false;
            }

            generalUnderlineMap_table.Controls.Clear();
            generalUnderlineMap_table.Controls.Add(new Label() { Text = "Underline Style", Name = "generalUnderlineMap_table_col0_header" }, 0, 0);
            generalUnderlineMap_table.Controls.Add(new Label() { Text = "Frequency", Name = "generalUnderlineMap_table_col1_header" }, 1, 0);
            generalUnderlineMap_table.RowCount = 1;
            generalUnderlineMap_table.RowStyles[0] = (new RowStyle(SizeType.Absolute, 16F));
            int generalUnderlineMap_table_row = 1;
            int generalUnderlineMap_combinationNumber = 1;
            foreach (KeyValuePair<string, int> entry in resultValues.generalUnderlineMap)
            {
                string generalUnderlineMap_combinationName = "";
                if (entry.Key == (WdColor.wdColorAutomatic.ToString() + "-" + WdUnderline.wdUnderlineNone.ToString()))
                {
                    generalUnderlineMap_combinationName = "default";
                }
                else
                {
                    generalUnderlineMap_combinationName = "comb " + generalUnderlineMap_combinationNumber;
                    generalUnderlineMap_combinationNumber++;
                }

                generalUnderlineMap_table.RowCount = generalUnderlineMap_table.RowCount + 1;
                generalUnderlineMap_table.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
                generalUnderlineMap_table.Controls.Add(new Label() { Text = generalUnderlineMap_combinationName, Name = "generalUnderlineMap_table_col0_row" + generalUnderlineMap_table_row }, 0, generalUnderlineMap_table_row);
                generalUnderlineMap_table.Controls.Add(new Label() { Text = entry.Value.ToString(), Name = "generalUnderlineMap_table_col1_row" + generalUnderlineMap_table_row }, 1, generalUnderlineMap_table_row);
                generalUnderlineMap_table_row++;
            }
        }

        private void ResultUnderlineGeneralScreen_Load(object sender, EventArgs e)
        {

        }
    }
}