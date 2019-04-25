using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_GeneralDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Client Code
            btnOpen.Click += BtnOpen_Click;
            btnSave.Click += BtnSave_Click;
            btnFont.Click += BtnFont_Click;
            btnColor.Click += BtnColor_Click;
            textBox1.ScrollBars = ScrollBars.Vertical;//прокрутка
            textBox1.WordWrap = true;//перенос слов
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog.Color;
            }
        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog.Font;                
                if (fontDialog.ShowColor == true)
                {
                    textBox1.ForeColor = fontDialog.Color;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            InitialFilter(saveFileDialog);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                File.WriteAllText(fileName, textBox1.Text);
            }
            else
            {
                return;
            }
        }

        private void InitialFilter(FileDialog dialog)
        {
            dialog.Filter = "Веб-страница(*.html)|*.html|Text Files(*.txt)|*.txt|C# Code(*.cs)|*.cs|All Files(*.*)|*.*";
            dialog.FilterIndex = 3;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            InitialFilter(openFileDialog);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
    }
}