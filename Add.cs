//Author: Andrei Rico
//Purpose: Add Form
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
    public partial class Add : Form
    {
        public FrmMain Main;
        public Form Window;

        public Add()

       
        {
           
            InitializeComponent();
        }

        // add button / add new employee
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var FirstName_ = txtFirstName.Text;
            var LastName_ = txtLastName.Text;
            var EmployeeID_ = txtID.Text;
            var EmployeeRole_ = txtDepartment.Text;
            if (int.TryParse(EmployeeID_, out int result))
            {
                FrmMain.Instance.AddRecord(FirstName_, LastName_, result, EmployeeRole_);
                this.Close();
            }
            else
            {
                MessageBox.Show("The Employee # Must be a valid Number.");
                
            }
        }
        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
