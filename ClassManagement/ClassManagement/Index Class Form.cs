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
    public partial class Index_Class_Form : Form
    {
        private ClassManagement Business;
        public Index_Class_Form()
        {
            InitializeComponent();
            this.Business = new ClassManagement();
            this.Load += Index_Class_Form_Load; // show classes
            this.btnAddClass.Click += btnAddClass_Click; //add a class
            this.btnDelete.Click += btnDelete_Click; // del a class
            this.GridClass.DoubleClick += GridClass_DoubleClick; // edit a class
        }

        private void LoadAllClasses()
        {
            var classes = this.Business.GetClass();
            this.GridClass.DataSource = classes;
        }

        void GridClass_DoubleClick(object sender, EventArgs e)
        {
            if(this.GridClass.SelectedRows.Count == 1 )
            {
                var @class = (Class)this.GridClass.SelectedRows[0].DataBoundItem;

                var UpdateForm = new Update_Class_Form(@class.id);
                UpdateForm.ShowDialog();
                this.LoadAllClasses();
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
           if(this.GridClass.SelectedRows.Count == 1)
           {
               if (MessageBox.Show("Wanna delete this ??", "Confirm",MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
               {
                   var @class = (Class)this.GridClass.SelectedRows[0].DataBoundItem;
                   this.Business.DeleteClass(@class.id);
                   MessageBox.Show("Delete Class Successfully");
                   this.LoadAllClasses();
               }
           }
        }

        void btnAddClass_Click(object sender, EventArgs e)
        {
            var createForm = new Form1();
            createForm.ShowDialog();
            this.LoadAllClasses();
        }

        void Index_Class_Form_Load(object sender, EventArgs e)
        {
            this.LoadAllClasses();
        }

    }
}
