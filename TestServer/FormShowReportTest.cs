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
    public partial class FormShowReportTest : Form
    {
        
        public FormShowReportTest(string stringReport, DAL.User user)
        {
            InitializeComponent();
            textBoxReport.Text = stringReport;
            this.Text = $"Report result test for user: {user.ToString()}";
        }
    }
}
