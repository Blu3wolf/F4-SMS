﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F4SMS
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // will eventually load the specific behavior for the simulation from a text file depending which tape is chosen
        private void tapeLoadButton_Click(object sender, EventArgs e)
        {
            // Create a new instance of the SMSDisplay class and show it
            DisplayForm formSMS = new DisplayForm();
            formSMS.Show();
        }

		private void richTextBoxIssues_LinkClicked(System.Object sender, System.Windows.Forms.LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);

		}
	}
}
