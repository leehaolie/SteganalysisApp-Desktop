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
    public partial class ResultFontTypeScreen : Form
    {
        public ResultFontTypeScreen()
        {
            InitializeComponent();
        }

        public ResultFontTypeScreen(ResultValues resultValues)
        {
            InitializeComponent();

            //MessageBox.Show("fontTypeTotal = " + resultValues.fontTypeTotal + " / fontTypePotential = " + resultValues.fontTypePotential + " / fontTypeDirectoryCount.Keys.Count = " + resultValues.fontTypeDirectoryCount.Keys.Count);
            fontTypeTotal_value.Text = resultValues.fontTypeTotal.ToString();
            fontTypePotential_value.Text = resultValues.fontTypePotential.ToString();
            fontTypeDirectoryCount_value.Text = resultValues.fontTypeDirectoryCount.Keys.Count.ToString();
        }
    }
}