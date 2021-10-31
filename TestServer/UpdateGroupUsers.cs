using DAL;
using Repository;
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

    public partial class UpdateGroupUsers : Form
    {
        IGenericRepository<User> repoUsers;
        IGenericRepository<Group> repoGroups;
        public Group currentGroup;
        List<Group> groups;
        BindingList<User> groupUsers;
        BindingList<User> otherUsers;
        public UpdateGroupUsers(Group currentGroup, IGenericRepository<Group> repoGroups, IGenericRepository<User> repoUsers )
        {
            InitializeComponent();
            this.repoGroups = repoGroups;
            this.repoUsers = repoUsers;
            this.currentGroup = currentGroup;

            groups = repoGroups.GetAllData().ToList();
            comboBoxGroups.DataSource = groups;            
            comboBoxGroups.SelectedItem = currentGroup;
        }

        private void comboBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentGroup = groups[comboBoxGroups.SelectedIndex];
            textBoxIdGroup.Text = currentGroup.Id.ToString();
            textBoxNameGroup.Text = currentGroup.Name;
            InitDataGridViewGroupUsers(currentGroup.Users);
            InitDataGridViewOtherUsers(currentGroup);            
        }

        private void InitDataGridViewGroupUsers(ICollection<User> users)
        {
            if (users == null)
            {
                this.groupUsers = null;
                dataGridViewGroupUsers.DataSource = null;
            }

            else
            {
                this.groupUsers = new BindingList<User>(users.ToList());
                dataGridViewGroupUsers.DataSource = this.groupUsers;
                dataGridViewGroupUsers.Columns["Groups"].Visible = false;
                dataGridViewGroupUsers.Columns["Login"].Visible = false;
                dataGridViewGroupUsers.Columns["Password"].Visible = false;

                dataGridViewGroupUsers.ClearSelection();
            }
        }

        private void InitDataGridViewOtherUsers(Group group)
        {   
            List<User> allUsers = repoUsers.GetAllData().ToList();
            otherUsers = new BindingList<User>();
            foreach (var user in allUsers)
            {
                if (!user.Groups.Contains(group))
                {
                    otherUsers.Add(user);
                }
            }

            dataGridViewOtherUsers.DataSource = otherUsers;
            dataGridViewOtherUsers.Columns["Groups"].Visible = false;
            dataGridViewOtherUsers.Columns["Login"].Visible = false;
            dataGridViewOtherUsers.Columns["Password"].Visible = false;

            dataGridViewOtherUsers.ClearSelection();
        }

        private void dataGridViewGroupUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewGroupUsers.SelectedRows.Count > 0)
            {
                buttonRemoveUser.Enabled = true;
            }
            else
            {
                buttonRemoveUser.Enabled = false;
            }
        }

        private void dataGridViewOtherUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOtherUsers.SelectedRows.Count > 0)
            {
                buttonAddUser.Enabled = true;
            }
            else
            {
                buttonAddUser.Enabled = false;
            }
        }

        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewGroupUsers.SelectedRows.Count; i++)
            {
                int index = dataGridViewGroupUsers.SelectedRows[i].Index;
                User user = groupUsers[index];
                user.Groups.Remove(currentGroup);
                repoUsers.Update(user);                
            }

            InitDataGridViewGroupUsers(currentGroup.Users);
            InitDataGridViewOtherUsers(currentGroup);

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewOtherUsers.SelectedRows.Count; i++)
            {
                int index = dataGridViewOtherUsers.SelectedRows[i].Index;
                User user = otherUsers[index];
                user.Groups.Add(currentGroup);
                repoUsers.Update(user);                
            }
            InitDataGridViewGroupUsers(currentGroup.Users);
            InitDataGridViewOtherUsers(currentGroup);
        }
    }
}
