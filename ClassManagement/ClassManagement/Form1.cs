using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassManagement
{
    public partial class Form1 : Form
    {
        private ClassManagement Business;
        public Form1()
        {
            InitializeComponent();
            this.Business = new ClassManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
           var name = this.textName.Text;
           var description = this.textDescription.Text;

           this.Business.AddClass(name, description);
           MessageBox.Show("Add new class successfully");
           this.Close();
        }

    }
}
