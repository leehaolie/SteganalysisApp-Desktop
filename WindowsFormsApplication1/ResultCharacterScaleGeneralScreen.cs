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
        }
    }
}