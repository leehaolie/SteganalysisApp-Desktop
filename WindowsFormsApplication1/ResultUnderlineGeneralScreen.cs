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

            generalUnderlineMap_table.Controls.Add(new Label() { Text = "Underline Style" }, 0, 0);
            generalUnderlineMap_table.Controls.Add(new Label() { Text = "Frequency" }, 1, 0);
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
                
                generalUnderlineMap_table.Controls.Add(new Label() { Text = generalUnderlineMap_combinationName }, 0, generalUnderlineMap_table_row);
                generalUnderlineMap_table.Controls.Add(new Label() { Text = entry.Value.ToString() }, 1, generalUnderlineMap_table_row);
                generalUnderlineMap_table_row++;
            }
            generalUnderlineMap_table.Height += resultValues.generalUnderlineMap.Keys.Count * 16;
            underline_group.Height += resultValues.generalUnderlineMap.Keys.Count * 16;
        }
    }
}