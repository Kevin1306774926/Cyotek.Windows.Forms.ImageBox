using Cyotek.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    private void Form1_Load(object sender, EventArgs e)
    {
      // set a default selection
      imageBox.SelectionRegion = new RectangleF(0, 0, 64, 64);

      // apply a minimum selection size for resize operations
      //imageBox.MinimumSelectionSize = new Size(8, 8);
    }
  }
}
