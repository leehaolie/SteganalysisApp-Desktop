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
    public partial class ResultUnicodeScreen : Form
    {
        public ResultUnicodeScreen()
        {
            InitializeComponent();
        }

        public ResultUnicodeScreen(ResultValues resultValues)
        {
            InitializeComponent();

            //MessageBox.Show("unicodeNumberSymbols = " + resultValues.unicodeNumberSymbols);
            unicodeNumberSymbols_value.Text = resultValues.unicodeNumberSymbols.ToString();

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "Symbol" }, 0, 0);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "enc 1" }, 1, 0);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "enc 2" }, 2, 0);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "enc 3" }, 3, 0);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "enc 4" }, 4, 0);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "A" }, 0, 1);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["A0041"].ToString() }, 1, 1);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["A0391"].ToString() }, 2, 1);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["A0410"].ToString() }, 3, 1);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["A13AA"].ToString() }, 4, 1);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "B" }, 0, 2);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["B0042"].ToString() }, 1, 2);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["B0392"].ToString() }, 2, 2);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["B0412"].ToString() }, 3, 2);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["B0181"].ToString() }, 4, 2);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "E" }, 0, 3);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["E0045"].ToString() }, 1, 3);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["E0395"].ToString() }, 2, 3);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["E0415"].ToString() }, 3, 3);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["E13AC"].ToString() }, 4, 3);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "G" }, 0, 4);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["G0047"].ToString() }, 1, 4);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["G050C"].ToString() }, 2, 4);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["G13C0"].ToString() }, 3, 4);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["G13B6"].ToString() }, 4, 4);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "H" }, 0, 5);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["H0048"].ToString() }, 1, 5);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["H0397"].ToString() }, 2, 5);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["H041D"].ToString() }, 3, 5);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["H13BB"].ToString() }, 4, 5);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "I" }, 0, 6);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["I0049"].ToString() }, 1, 6);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["I0399"].ToString() }, 2, 6);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["I04C0"].ToString() }, 3, 6);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["I0406"].ToString() }, 4, 6);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "M" }, 0, 7);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["M004D"].ToString() }, 1, 7);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["M039C"].ToString() }, 2, 7);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["M041C"].ToString() }, 3, 7);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["M216F"].ToString() }, 4, 7);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "O" }, 0, 8);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["O004F"].ToString() }, 1, 8);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["O039F"].ToString() }, 2, 8);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["O041E"].ToString() }, 3, 8);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["O0555"].ToString() }, 4, 8);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "P" }, 0, 9);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["P0050"].ToString() }, 1, 9);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["P0420"].ToString() }, 2, 9);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["P03A1"].ToString() }, 3, 9);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["P01A4"].ToString() }, 4, 9);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "S" }, 0, 10);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["S0053"].ToString() }, 1, 10);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["S0405"].ToString() }, 2, 10);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["S054F"].ToString() }, 3, 10);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["S13DA"].ToString() }, 4, 10);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "T" }, 0, 11);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["T0054"].ToString() }, 1, 11);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["T0422"].ToString() }, 2, 11);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["T03A4"].ToString() }, 3, 11);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["T01AC"].ToString() }, 4, 11);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "j" }, 0, 12);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["j006A"].ToString() }, 1, 12);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["j0458"].ToString() }, 2, 12);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["j03F3"].ToString() }, 3, 12);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["j029D"].ToString() }, 4, 12);

            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = "o" }, 0, 13);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["o006F"].ToString() }, 1, 13);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["o03BF"].ToString() }, 2, 13);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["o1D0F"].ToString() }, 3, 13);
            unicodeNumberSymbols_table.Controls.Add(new Label() { Text = resultValues.unicodeDirectoryMap["o043E"].ToString() }, 4, 13);
        }
    }
}