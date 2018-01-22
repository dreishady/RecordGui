//Author: Andrei Rico
//Purpose: Main form
//Known bugs: None
//Date: 21/11/2017


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entities;
using System.IO;
using System.Linq;

namespace RecordGUI
{
    public partial class FrmMain : Form
    {
        public LinkedList<Employee> employees;
        public LinkedListNode<Employee> currentNode;

        public Form Window;
        public static FrmMain Instance;
        public FrmMain()
        {
            // reads data from txtfile
            InitializeComponent();
            Instance = this;
            employees = new LinkedList<Employee>();

            using (var reader = new StreamReader(File.OpenRead("Records/Records.txt")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var information = line.Split('|');

                    if (information.Length <= 3) continue;

                    var firstName = information[0];
                    var lastName = information[1];
                    int.TryParse(information[2], out var employeeId);
                    var departmentType = information[3];

                    employees.AddLast(new Employee
                    {
                        firstName = firstName,
                        lastName = lastName,
                        employeeId = employeeId,
                        departmentType = departmentType,
                    });
                }
            }
            var size = employees.Count() / 2;
            SetCurrent(employees.First);
            for (var i = 0; i < size; i++)
                SetCurrent(currentNode.Next);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

        // set current node
        private void SetCurrent(LinkedListNode<Employee> node)
        {
            previousTextBox.Text = node?.Previous?.Value?.ToString();
            currentTextBox.Text = node?.Value?.ToString();
            nextTextBox.Text = node?.Next?.Value?.ToString();
            currentNode = node;
        }

        // next button
        private void moveNextButton_Click(object sender, System.EventArgs e)
        {
            if (currentNode.Next == null)
            {
               moveNextButton.Enabled = false;
                MessageBox.Show("You have reached the end of the Link List", "");
                return;
            }
            if (!movePreviousButton.Enabled)
            {
                movePreviousButton.Enabled = true;
            }
            SetCurrent(currentNode.Next);
        }

        // previous button
        private void movePreviousButton_Click(object sender, System.EventArgs e)
        {
            if (currentNode.Previous == null)
            {
                movePreviousButton.Enabled = false;
                MessageBox.Show("You have reached the end of the Link List", "");
                return;
            }
            if (!moveNextButton.Enabled)
            {
                moveNextButton.Enabled = true;
            }
            SetCurrent(currentNode?.Previous);
        }

        // removes employee from the lists
        private void removeButton_Click(object sender, System.EventArgs e)
        {
            DeleteEmployee();
        }

        // add to the lists
        private void addButton_Click(object sender, System.EventArgs e)
        {
           
            
            Add add = new Add();
           
             add.ShowDialog();
        }
        // method for delete employee
        private void DeleteEmployee()
        {
            if (currentNode == null) return;

            LinkedListNode<Employee> node = null;

            if (currentNode.Previous.Previous != null) node = currentNode.Previous;
            else if (currentNode.Next.Next != null) node = currentNode.Next;

            employees.Remove(currentNode);
            SetCurrent(node);
        }
            //deletes employees
            private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
        }

        // sort by department alphabetically
        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sort = employees.OrderBy(v => v.departmentType.ToString()).ToList();

            var old = employees;
            employees = new LinkedList<Employee>();

            foreach (var node in sort) employees.AddLast(node);
            SetCurrent(employees?.First?.Next ?? employees?.First);

            old.Clear();
        }
            // search for last name
            private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.ShowDialog();
           
        }

        // exits application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        // add new employee
        public void AddRecord(string FirstName, string LastName, int EmployeeID, string RoleType)
        {
            var firstName = FirstName;
            var lastName = LastName;
            int.TryParse(EmployeeID.ToString(), out var employeeId);
            var Type = RoleType;

            employees.AddAfter(currentNode.Previous, new Employee
            {
                firstName = firstName,
                lastName = lastName,
                employeeId = employeeId,
                departmentType = Type,
            });

            SetCurrent(currentNode?.Previous);
        }
        public void SearchNodeSetPosition(string name)
        {
            try
            {
                var node = employees.First(n => n.lastName.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (node == null)
                {
                    return;
                }
                SetCurrent(employees.Find(node));
            }
            catch (Exception )
            {

            }
        }
    }
}