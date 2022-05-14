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

namespace Compiler_Design_Project
{
    public partial class Form1 : Form
    {
        
        
        public static string fileName1;
        public Form1()
        {
            InitializeComponent();
        }
        //Dosya Yolu Alma
        private void Dosya_Yolu_Al(object sender, EventArgs e)
        {
            
            //dosya1 seçim
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                fileName1 = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                textBox1.Text = fileName1;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Dosya_Oku(object sender, EventArgs e)
        {
             int counter = 1;
            string s = File.ReadAllText(fileName1);
            string[] words = s.Split(' ',';');
            foreach (string word in words)
            {
                
                // show the resulting string in textbox2
                listBox1.Items.Add(counter+ ". kelime : "+word);
                counter += 1;
            }
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "int" && words[i+1] == "x")
                {
                    listBox1.Items.Add(i+". satırda bulundu int bulundu ve intten sonraki değişken x olarak atandı");
                    listBox1.Items.Add(words[i]);
                    listBox1.Items.Add(words[i + 1]);
                    
                }
            }
           // using (StreamReader file = new StreamReader(fileName1))
           // {
           //
           //     string ln;
           //     while ((ln = file.ReadLine()) != null)
           //     {
           //
           //         listBox1.Items.Add(ln);
           //
           //     }
           //     file.Close();
           //
           // }
        }
    }
}
