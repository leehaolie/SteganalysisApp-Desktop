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
    public partial class ResultWordMappingScreen : Form
    {
        public ResultWordMappingScreen()
        {
            InitializeComponent();
        }

        public ResultWordMappingScreen(ResultValues resultValues)
        {
            InitializeComponent();

            //MessageBox.Show("wordMappingOption1Total = " + resultValues.wordMappingOption1Total + " / wordMappingOption1Potential = " + resultValues.wordMappingOption1Potential);
            wordMappingOption1Total_value.Text = resultValues.wordMappingOption1Total.ToString();
            wordMappingOption1Potential_value.Text = resultValues.wordMappingOption1Potential.ToString();

            //MessageBox.Show("wordMappingOption2Total = " + resultValues.wordMappingOption2Total + " / wordMappingOption2Potential = " + resultValues.wordMappingOption2Potential);
            wordMappingOption2Total_value.Text = resultValues.wordMappingOption2Total.ToString();
            wordMappingOption2Potential_value.Text = resultValues.wordMappingOption2Potential.ToString();
        }
    }
}