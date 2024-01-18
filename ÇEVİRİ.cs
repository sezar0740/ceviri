using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebBrowser ceviri = new WebBrowser();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ceviri.Navigate("https://www.bing.com/translator/?from=tr&to=en&toWww=1&redig=E3B008DFE5604850A49FC3FD64AE0569");
                    ceviri.ScriptErrorsSuppressed = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ceviri.Document.GetElementById("tta_input_ta").InnerText = textBox1.Text;
            timer1.Start();
        }

        int say = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if(say == 2) timer1.Stop();
                textBox2.Text = ceviri.Document.GetElementById("tta_output_ta").InnerText;
                say++;
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                
                ceviri.Document.GetElementById("tta_playiconsrc").InvokeMember("click");
            }
            catch 
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ceviri.Document.GetElementById("tta_playicontgt").InvokeMember("click");
            }
            catch
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text == "Türkçe") { label1.Text = "İngilizce"; label2.Text = "Türkçe"; }
                else { label2.Text = "İngilizce"; label1.Text = "Türkçe"; }
               
                ceviri.Document.GetElementById("tta_revIcon").InvokeMember("click");
            }
            catch
            { }
        }
    }
}
