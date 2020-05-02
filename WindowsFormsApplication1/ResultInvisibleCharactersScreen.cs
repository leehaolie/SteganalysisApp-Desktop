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
    public partial class ResultInvisibleCharactersScreen : Form
    {
        public ResultInvisibleCharactersScreen()
        {
            InitializeComponent();
        }

        public ResultInvisibleCharactersScreen(ResultValues resultValues)
        {
            InitializeComponent();

            //MessageBox.Show("invisibleCharactersTotal = " + resultValues.invisibleCharactersTotal + " / invisibleCharactersPotential = " + resultValues.invisibleCharactersPotential);
            invisibleCharactersTotal_value.Text = resultValues.invisibleCharactersTotal.ToString();
            invisibleCharactersPotential_value.Text = resultValues.invisibleCharactersPotential.ToString();

            //invisibleCharactersThatTakesNoSpaceHexMap     
            invisibleCharactersThatTakesNoSpaceHexMap_table.Controls.Clear();
            invisibleCharactersThatTakesNoSpaceHexMap_table.Controls.Add(new Label() { Text = "Hex Code", Name = "invisibleCharactersThatTakesNoSpaceHexMap_table_col0_header" }, 0, 0);
            invisibleCharactersThatTakesNoSpaceHexMap_table.Controls.Add(new Label() { Text = "Frequency", Name = "Frequency_col1_header" }, 1, 0);
            invisibleCharactersThatTakesNoSpaceHexMap_table.RowCount = 1;
            invisibleCharactersThatTakesNoSpaceHexMap_table.RowStyles[0] = (new RowStyle(SizeType.Absolute, 16F));
            int invisibleCharactersThatTakesNoSpaceHexMap_table_row = 1;
            foreach (KeyValuePair<string, int> entry in resultValues.invisibleCharactersThatTakesNoSpaceHexMap)
            {
                invisibleCharactersThatTakesNoSpaceHexMap_table.RowCount = invisibleCharactersThatTakesNoSpaceHexMap_table.RowCount + 1;
                invisibleCharactersThatTakesNoSpaceHexMap_table.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
                invisibleCharactersThatTakesNoSpaceHexMap_table.Controls.Add(new Label() { Text = entry.Key, Name = "invisibleCharactersThatTakesNoSpaceHexMap_table_col0_row" + invisibleCharactersThatTakesNoSpaceHexMap_table_row }, 0, invisibleCharactersThatTakesNoSpaceHexMap_table_row);
                invisibleCharactersThatTakesNoSpaceHexMap_table.Controls.Add(new Label() { Text = entry.Value.ToString(), Name = "invisibleCharactersThatTakesNoSpaceHexMap_table_col1_row" + invisibleCharactersThatTakesNoSpaceHexMap_table_row }, 1, invisibleCharactersThatTakesNoSpaceHexMap_table_row);
                invisibleCharactersThatTakesNoSpaceHexMap_table_row++;
            }
        }
    }
}