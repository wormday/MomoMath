using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wormday.MomoMath.Biz;

namespace Wormday.MomoMath.WinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            QuestionSetter q = new QuestionSetter();
            var items = q.Create(100);
            foreach (var item in items)
            {
                textBox1.AppendText(string.Format("{0}{1}",item.Problem,item.ExpectedAnswer) + System.Environment.NewLine);
            }
        }
    }
}
