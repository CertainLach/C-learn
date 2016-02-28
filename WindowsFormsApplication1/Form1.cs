using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private CheckBox[,] box=new CheckBox[5,5];

        public Form1()
        {
             for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    box[y,x] = new CheckBox();
                    box[y, x].Tag = y.ToString()+x.ToString();
                    box[y, x].Text = "";
                    box[y, x].AutoSize = true;
                    box[y, x].Location = new Point(1+x*15, 1+y * 15);
                    box[y, x].Click += new System.EventHandler(onChecked);

                    this.Controls.Add(box[y, x]);
                }
            }
            InitializeComponent();
            codeGen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text += "\n"+richTextBox1.Text;
            richTextBox1.Text = "";
            codeGen();
        }

        private void onChecked(object sender, EventArgs e)
        {
            codeGen();
        }

        private void codeGen()
        {
            int maxInd = 0;
            richTextBox1.Text = "alphabet.put(\'\', new int[][] {\n";
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (box[y, x].Checked && x > maxInd)
                        maxInd = x;
                }
            }
            for (int y = 0; y < 5; y++)
            {
                richTextBox1.Text += "    {";
                for (int x = 0; x <= maxInd; x++)
                {
                    richTextBox1.Text += (box[y, x].Checked ? "1" : "0") + (x == maxInd ? "}" : "")+(y==4?(x == maxInd?"":",") :",")+(x == maxInd?"\n":"");
                }
            }
            richTextBox1.Text += "});\n";
        }
    }
}
