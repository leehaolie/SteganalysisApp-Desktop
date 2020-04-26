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
    }
}