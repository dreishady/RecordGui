//Author: Andrei Rico
//Purpose: Search Form
//Known bugs: None
//Date: 21/11/2017

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RecordGUI
{
    public partial class Search : Form
    {
        public FrmMain Main;
        public Form Window;
        public static Search Instance;
        public Search()
        {
            Instance = this;
        
            InitializeComponent();
        }

        // search button 
        private void btnSearch_Click(object sender, EventArgs e)
        {


            FrmMain.Instance.SearchNodeSetPosition(txtLastName.Text.ToString());
            
        
            this.Close();

        }

        private void Search_Load(object sender, EventArgs e)
        {


        }
       
    }
}
