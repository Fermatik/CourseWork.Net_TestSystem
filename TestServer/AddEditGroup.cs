using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestServer
{
    public partial class AddEditGroup : Form
    {
        public Group currentGroup;
        public AddEditGroup(Group currentGroup)
        {
            InitializeComponent();
            if (currentGroup == null)
                this.currentGroup = new Group();
            else
            {
                this.currentGroup = currentGroup;
                textBoxName.Text = currentGroup.Name;
                textBoxId.Text = currentGroup.Id.ToString();
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (currentGroup.Name != textBoxName.Text.Trim())
            {
                if (textBoxName.Text.Trim() == String.Empty)
                    buttonSave.Enabled = false;
                else
                    buttonSave.Enabled = true;
            }
            else
                buttonSave.Enabled = false;

        }
    }
}
