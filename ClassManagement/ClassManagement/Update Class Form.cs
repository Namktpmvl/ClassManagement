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
    public partial class Update_Class_Form : Form
    {
        private int ClassId;
        private ClassManagement Business;
        public Update_Class_Form(int id)
        {
            InitializeComponent();
            this.ClassId = id;
            this.Business = new ClassManagement();
            this.btnSave.Click +=btnSave_Click;
            this.btnCancel.Click +=btnCancel_Click;
            this.Load += Update_Class_Form_Load;
        }

        void Update_Class_Form_Load(object sender, EventArgs e)
        {
            var oldClass = this.Business.GetClass(this.ClassId);
            this.textName.Text = oldClass.Name;
            this.textDescription.Text = oldClass.Description;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var name = this.textName.Text;
            var description = this.textDescription.Text;
            this.Business.EditClass(this.ClassId,name,description);
            MessageBox.Show("Update Successfully");
        }
    }
}
