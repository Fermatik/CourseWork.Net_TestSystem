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
    public partial class AddEditUser : Form
    {   
        IGenericRepository<User> repoUsers;

        public User startUser;
        public User currentUser;
        public AddEditUser(User user, IGenericRepository<User> repoUser)
        {
            InitializeComponent();
            this.repoUsers = repoUser;
            if (user == null)
            {
                startUser = new User();
                currentUser = (User)startUser.Clone();                
            }
            else
            {
                startUser = user;
                currentUser = (User)startUser.Clone();                

                textBoxId.Text = currentUser.Id.ToString();
                textBoxFirstName.Text = currentUser.FirstName;
                textBoxLastName.Text = currentUser.LastName;
                textBoxLogin.Text = currentUser.Login;
                textBoxPassword.Text = currentUser.Password;
                checkBox1.Checked = currentUser.IsAdmin;

                buttonSave.Enabled = false;
            }


        }

        private bool IsCorrectLogin(User user)
        {
            var otherUsers = repoUsers.FindAll( x => x.Id != user.Id).ToList();
            foreach (var item in otherUsers)
                if (item.Login == user.Login) return false;
            
            return true;
        }
        private void CheckData()
        {
            if (currentUser.Equals(startUser))
                buttonSave.Enabled = false;
            else
            {
                if (textBoxFirstName.Text.Trim() == String.Empty ||
                    textBoxLastName.Text.Trim() == String.Empty ||
                    textBoxLogin.Text.Trim() == String.Empty ||
                    textBoxPassword.Text.Trim() == String.Empty)
                    buttonSave.Enabled = false;
                else
                    buttonSave.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            startUser.FirstName = currentUser.FirstName;
            startUser.LastName = currentUser.LastName;
            startUser.Login = currentUser.Login;
            startUser.Password = currentUser.Password;
            startUser.IsAdmin = currentUser.IsAdmin;
        }


        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            currentUser.FirstName = textBoxFirstName.Text.Trim();
            CheckData();
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            currentUser.LastName = textBoxLastName.Text.Trim();
            CheckData();
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            textBoxLogin.Text = textBoxLogin.Text.Trim();
            currentUser.Login = textBoxLogin.Text;
            if (IsCorrectLogin(currentUser))
            {
                textBoxLogin.BackColor = Color.White;
                CheckData();
            }
            else
            {
                textBoxLogin.BackColor = Color.Red;
                buttonSave.Enabled = false;
            }

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            currentUser.Password = textBoxPassword.Text.Trim();
            CheckData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            currentUser.IsAdmin = checkBox1.Checked;
            CheckData();
        }
    }
}
