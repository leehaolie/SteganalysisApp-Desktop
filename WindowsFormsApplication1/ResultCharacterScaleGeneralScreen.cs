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
    public partial class ResultCharacterScaleGeneralScreen : Form
    {
        public ResultCharacterScaleGeneralScreen()
        {
            InitializeComponent();
        }

        public ResultCharacterScaleGeneralScreen(ResultValues resultValues)
        {
            InitializeComponent();

            generalScalingMap_table.Controls.Clear();
            generalScalingMap_table.Controls.Add(new Label() { Text = "Scale Size", Name = "generalScalingMap_table_col0_header" }, 0, 0);
            generalScalingMap_table.Controls.Add(new Label() { Text = "Frequency", Name = "generalScalingMap_table_col0_header" }, 1, 0);
            generalScalingMap_table.RowCount = 1;
            generalScalingMap_table.RowStyles[0] = (new RowStyle(SizeType.Absolute, 16F));
            int generalScalingMap_table_row = 1;
            foreach (KeyValuePair<string, int> entry in resultValues.generalScalingMap)
            {
                string scaleSize = entry.Key.ToString();
                if (entry.Key.ToString() == "100")
                {
                    scaleSize = "default";
                }

                generalScalingMap_table.RowCount = generalScalingMap_table.RowCount + 1;
                generalScalingMap_table.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
                generalScalingMap_table.Controls.Add(new Label() { Text = scaleSize, Name = "generalScalingMap_table_col0_row" + generalScalingMap_table_row }, 0, generalScalingMap_table_row);
                generalScalingMap_table.Controls.Add(new Label() { Text = entry.Value.ToString(), Name = "generalScalingMap_table_col1_row" + generalScalingMap_table_row }, 1, generalScalingMap_table_row);
                generalScalingMap_table_row++;
            }
        }
    }
}