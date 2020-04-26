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
    public partial class ResultColorQuantizationScreen : Form
    {
        public ResultColorQuantizationScreen()
        {
            InitializeComponent();
        }

        public ResultColorQuantizationScreen(ResultValues resultValues)
        {
            InitializeComponent();

            //MessageBox.Show("colorQuantizationTotal = " + resultValues.colorQuantizationTotal + " / colorQuantizationLight = " + resultValues.colorQuantizationLight + " / colorQuantizationDark = " + resultValues.colorQuantizationDark);
            colorQuantizationTotal_value.Text = resultValues.colorQuantizationTotal.ToString();
            colorQuantizationLight_value.Text = resultValues.colorQuantizationLight.ToString();
            colorQuantizationLight_levels_value.Text = "(levels: " + (resultValues.colorQuantizationLightLevels.Length - 1).ToString() + ")";
            colorQuantizationDark_value.Text = resultValues.colorQuantizationDark.ToString();
            colorQuantizationDark_levels_value.Text = "(levels: " + (resultValues.colorQuantizationDarkLevels.Length - 1).ToString() + ")";
        }
    }
}