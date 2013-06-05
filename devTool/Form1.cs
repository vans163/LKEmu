using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace devTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool inthead { get { return checkBox1.Checked; } }
        private void button1_Click(object sender, EventArgs e)
        {
            //  var nospace = textBox1.Text;
            var nospace = richTextBox1.Text;
            nospace = System.Text.RegularExpressions.Regex.Replace(nospace, @"\s+", "");

            Byte[] arr = new Byte[nospace.Count() / 2];
            for (var i = 0; i < nospace.Count(); i += 2)
                arr[i / 2] = Convert.ToByte(nospace.Substring(i, 2), 16);

            if (inthead)
            {
                arr[0] = Convert.ToByte(nospace.Substring(0, 2));
            }
            foreach (var ioc in Program._server.OnlineConnections)
            {
             //   this.dataGridView1.Rows.Add(new Object[] { BitConverter.ToString(arr), DateTime.Now.TimeOfDay });
                ioc.Client.SendPacket(new Generic(arr).Compile());
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            var nospace = richTextBox1.Text;
            nospace = System.Text.RegularExpressions.Regex.Replace(nospace, @"\s+", "");
            label1.Text = (nospace.Count() / 2).ToString();
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
  /*          var nospace = richTextBox1.Text;
            var sel = richTextBox1.SelectionStart;
            nospace = System.Text.RegularExpressions.Regex.Replace(nospace, @"\s+", "");
            label1.Text = sel.ToString();*/
        }
    }
}
