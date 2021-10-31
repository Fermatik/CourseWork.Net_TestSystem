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
    public partial class UpdateUserGroups : Form
    {
        IGenericRepository<User> repoUsers;
        IGenericRepository<Group> repoGroups;
        public User currentUser;
        List<User> users;
        BindingList<Group> userGroups;
        BindingList<Group> otherGroups;

        public UpdateUserGroups(User currentUser, IGenericRepository<Group> repoGroups, IGenericRepository<User> repoUsers)
        {
            InitializeComponent();
            this.repoGroups = repoGroups;
            this.repoUsers = repoUsers;
            this.currentUser = currentUser;

            users = repoUsers.GetAllData().ToList();
            comboBoxUsers.DataSource = users;
            comboBoxUsers.SelectedItem = currentUser;
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentUser = users[comboBoxUsers.SelectedIndex];
            textBoxId.Text = currentUser.Id.ToString();
            textBoxFirstName.Text = currentUser.FirstName;
            textBoxLastName.Text = currentUser.FirstName;
            checkBoxIsAdmin.Checked = currentUser.IsAdmin;
            InitDataGridViewUserGroups(currentUser.Groups);
            InitDataGridViewOtherGroups(currentUser);
        }

        private void InitDataGridViewOtherGroups(User user)
        {
            List<Group> allGroups = repoGroups.GetAllData().ToList();
            otherGroups = new BindingList<Group>();
            foreach (var group in allGroups)
            {
                if (!group.Users.Contains(user))
                {
                    otherGroups.Add(group);
                }
            }

            dataGridViewOtherGroups.DataSource = otherGroups;
            dataGridViewOtherGroups.Columns["Users"].Visible = false;

            dataGridViewOtherGroups.ClearSelection();
        }

        private void InitDataGridViewUserGroups(ICollection<Group> groups)
        {
            if (groups == null)
            {
                this.userGroups = null;
                dataGridViewUsersGroups.DataSource = null;
            }

            else
            {
                this.userGroups = new BindingList<Group>(groups.ToList());
                dataGridViewUsersGroups.DataSource = this.userGroups;
                dataGridViewUsersGroups.Columns["Users"].Visible = false;                

                dataGridViewUsersGroups.ClearSelection();
            }
        }

        private void dataGridViewUsersGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsersGroups.SelectedRows.Count > 0)
            {
                buttonRemoveGroup.Enabled = true;
            }
            else
            {
                buttonRemoveGroup.Enabled = false;
            }
        }

        private void dataGridViewOtherGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOtherGroups.SelectedRows.Count > 0)
            {
                buttonAddGroup.Enabled = true;
            }
            else
            {
                buttonAddGroup.Enabled = false;
            }
        }

        private void buttonRemoveGroup_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewUsersGroups.SelectedRows.Count; i++)
            {
                int index = dataGridViewUsersGroups.SelectedRows[i].Index;
                Group group = userGroups[index];
                group.Users.Remove(currentUser);
                repoGroups.Update(group);
            }

            InitDataGridViewUserGroups(currentUser.Groups);
            InitDataGridViewOtherGroups(currentUser);
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewOtherGroups.SelectedRows.Count; i++)
            {
                int index = dataGridViewOtherGroups.SelectedRows[i].Index;
                Group group = otherGroups[index];
                group.Users.Add(currentUser);
                repoGroups.Update(group);
            }
            
            InitDataGridViewUserGroups(currentUser.Groups);
            InitDataGridViewOtherGroups(currentUser);
        }
    }
}
