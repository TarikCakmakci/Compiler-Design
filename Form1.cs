using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            int counter = 0;
            string s = File.ReadAllText(fileName1);
            string[] words = s.Split(' ','\n');
            string[] degiskenTipleri = { "int", "double", "boolean" };
            string[] operatorler = { "=", "(", ")" ,"+","-","*"};
            string[] prgDilineAitKelimeler = { "for", "if","else", "while", "switch", "case", "try", "catch","int","float","double","var","char" };
            foreach (string word in words)
            {
                
                // show the resulting string in textbox2
                listBox1.Items.Add(counter+ ". kelime : "+word);
                counter += 1;
            }
            var regex = new Regex("[0-9]");
            for (int i = 0; i < words.Length; i++)
            {
                for (int k = 0; k < degiskenTipleri.Length; k++)
                {
                    if (words[i]==degiskenTipleri[k])
                    {
                        listBox1.Items.Add(i + ". satırda " + degiskenTipleri[k] + " bulundu.");
                        if (regex.IsMatch(words[i+1].Substring(0,1))==true)
                        {
                            listBox1.Items.Add((i + 1) + ".kelime sayı ile başlayamaz");

                        }     
                    }

                    for (int z = 0; z < prgDilineAitKelimeler.Length; z++)
                    {
                        if (words[i] == degiskenTipleri[k])
                        {
                            if (words[i + 1] == prgDilineAitKelimeler[z])
                            {
                                listBox1.Items.Add((i+1)+". satırda Programlama diline ait kelimeler değişken ismi olamaz");
                            }
                        }
                    }
                    
                   
                }
                for (int z = 0; z < operatorler.Length; z++)
                {
                    if (words[i]==operatorler[z])
                    {
                        listBox1.Items.Add(i + ". satırda " + operatorler[z] + " bulundu.");
                    }
                  
                }

            }
            //işlem operatörler
            for (int i = 0; i < words.Length; i++)
            {
                for (int k = 0; k < degiskenTipleri.Length; k++)
                {
                    for (int z = 0; z < operatorler.Length; z++)
                    {
                        for (int p = 0; p < prgDilineAitKelimeler.Length; p++)
                        {
                            if (words[i]==degiskenTipleri[0])
                            {
                                if (regex.IsMatch(words[i + 1].Substring(0, 1)) == true && words[i + 1] == prgDilineAitKelimeler[p])
                                {
                                    if (words[i+2] == operatorler[0])
                                    {
                                        if (regex.IsMatch(words[i + 3])== true)
                                        {
                                            int sayi = Convert.ToInt32(words[i + 3]);
                                            listBox1.Items.Add(i + ". satırda "+words[i+1]+" adlı değişkene " + words[i + 3] + " değeri atandı. Atanan değer :" + sayi);
                                            break;
                                            

                                        }
                                    }
                                }
                            }
                            break;
                        }
                        break;
                    }
                    break;
                }
               
            }

            

           
        }
    }
}
