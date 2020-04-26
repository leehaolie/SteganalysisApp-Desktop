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
    public partial class ResultOpenSpacesScreen : Form
    {
        public ResultOpenSpacesScreen()
        {
            InitializeComponent();
        }

        public ResultOpenSpacesScreen(ResultValues resultValues)
        {
            InitializeComponent();

            //MessageBox.Show("openSpacesSentencesTotal = " + resultValues.openSpacesSentencesTotal + " / openSpacesSentencesPotential = " + resultValues.openSpacesSentencesPotential);
            openSpacesSentencesTotal_value.Text = resultValues.openSpacesSentencesTotal.ToString();
            openSpacesSentencesPotential_value.Text = resultValues.openSpacesSentencesPotential.ToString();

            //MessageBox.Show("openSpacesWordsTotal = " + resultValues.openSpacesWordsTotal + " / openSpacesWordsPotential = " + resultValues.openSpacesWordsPotential);
            openSpacesWordsTotal_value.Text = resultValues.openSpacesWordsTotal.ToString();
            openSpacesWordsPotential_value.Text = resultValues.openSpacesWordsPotential.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}