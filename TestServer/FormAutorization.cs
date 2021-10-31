using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestServer
{
    public partial class FormAutorization : Form
    {
        
        public User currentUser;
        GenericUnitOfWork work;
        IGenericRepository<User> repoUsers;
        public FormAutorization()
        {
            
            InitializeComponent();
            work = new GenericUnitOfWork(new Context(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));
            repoUsers = work.Repository<User>();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            //currentUser = repoUsers.FindAll(x => x.Login == this.textBoxLogin.Text).FirstOrDefault();
            currentUser = repoUsers.FirstOrDefault(x => x.Login == this.textBoxLogin.Text);
            
            if (currentUser == null)
            {
                MessageBox.Show("Invalid login!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textBoxLogin.Focus();
                this.textBoxLogin.SelectAll();
                return;
            }
            else
            {
                if (currentUser.Password != this.textBoxPassword.Text)
                {
                    MessageBox.Show("Invalid password!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.textBoxPassword.Focus();
                    this.textBoxPassword.SelectAll();
                    return;
                }

                if (currentUser.IsAdmin)
                {
                    this.Visible = false;
                    FormMain formMain = new FormMain(currentUser);
                    formMain.ShowDialog(this);                    
                }
                else
                {
                    MessageBox.Show("Access denied!\nOnly users with admin rights can log into the server!", "Autorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.textBoxLogin.Text = String.Empty;
                    this.textBoxPassword.Text = String.Empty;
                    this.textBoxLogin.Focus();
                }
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            CheckDataForm();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CheckDataForm();
        }

        private void CheckDataForm()
        {
            if (this.textBoxPassword.Text == String.Empty || this.textBoxLogin.Text == String.Empty)
                this.buttonLogIn.Enabled = false;
            else
                this.buttonLogIn.Enabled = true;
        }
    }
}
