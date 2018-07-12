using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public int pos = 0;
        public string outputfile = "";
        public string outputfile2 = "";
        public string id;
        public int line = 0;
        public int errorcount = 0;
        List<data> data1 = new List<data>();     
        List<string> errorlist = new List<string>();
        List<string> log = new List<string>();
        string[] folders;
        public string err = "Error Count:";
        public int foldernum = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button7.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
        }

        private void findids(string urlPattern, string[] fileContent, string phonenum)
        {
            try
            {
                Regex regex = null;
                regex = new Regex(urlPattern);

                foreach (string item in fileContent)
                {

                    Match match = regex.Match(item);
                    if (match.Success)
                    {
                        if (item.Contains(phonenum))
                        {
                            data1.Add(new data { number = phonenum, id = item.Substring(32, 32), log = item, line = ++pos });
                        }

                    }

                    pos++;

                }
            }

            catch (ExceptionOverFlowException hata1)
            {
                textBox1.AppendText("Taşıma hatası meydana geldi." + hata1);
            }
            catch (ArithmeticException hata2)
            {
                textBox1.AppendText("Mantıksal hatası meydana geldi." + hata2);
            }
            catch (OutOfMemoryException hata3)
            {
                textBox1.AppendText("Memoryi geçtin hatası meydana geldi." + hata3);
            }
        }
        private void findnum(string urlPattern, string[] fileContent, string id)
        {
            try
            {
                Regex regex = null;
                regex = new Regex(urlPattern);
                foreach (string item in fileContent)
                {
                    Match match = regex.Match(item);
                    if (match.Success)
                    {
                        if (item.Contains(id))
                        {
                            data1.Add(new data { number = item.Substring(138, 11), id = id, log = item, line = ++pos });
                            textBox1.AppendText("Number:  " + item.Substring(138, 11) + Environment.NewLine);
                            break;
                        }
                    }
                    pos++;
                }
            }
            catch (ExceptionOverFlowException hata1)
            {
                textBox1.AppendText("Taşıma hatası meydana geldi." + hata1);
            }
            catch (ArithmeticException hata2)
            {
                textBox1.AppendText("Mantıksal hatası meydana geldi." + hata2);
            }
            catch (OutOfMemoryException hata3)
            {
                textBox1.AppendText("Memoryi geçtin hatası meydana geldi." + hata3);
            }
        }
        private void findlog(string[] fileContent, string id)
        {
            int tempnum = 0;
            int size=0;
            try
            {
                foreach (string item in fileContent)
                {
                    if (item.Contains(id))
                    {
                        if (fileContent.Length > pos + 1)
                        {
                            if (fileContent[1 + pos].Length > 30)
                            {
                                if (fileContent[1 + pos].Substring(30, 1) != "-")
                                {

                                    while (true)
                                    {

                                        if (fileContent[1 + tempnum + pos] == "") { }
                                        else if (fileContent[2 +tempnum+ pos].Length > 30)
                                        {
                                            if (fileContent[2 + tempnum + pos].Substring(30, 1) != "-")
                                            {
                                                textBox5.AppendText("------" + (pos+4 + tempnum).ToString() + "  " + fileContent[1 + tempnum + pos] + Environment.NewLine);

                                            }
                                            else
                                                break;
                                        }
                                        else
                                        {
                                            textBox5.AppendText("------" + (pos+4 + tempnum).ToString() + "  " + fileContent[1 + tempnum + pos] + Environment.NewLine);

                                        }
                                        size--;
                                        
                                        tempnum++;
                                    }
                                }
                                else
                                {
                                    log.Add(item);
                                    pos++;
                                    ++tempnum;
                                }
                            }
                            else
                            {
                                while (true)
                                {

                                    if (fileContent[1 + tempnum + pos] == "") { }
                                    else if (fileContent[2 + tempnum + pos].Length > 30)
                                    {
                                        if (fileContent[2 + tempnum + pos].Substring(30, 1) != "-")
                                        {
                                            textBox5.AppendText("------" + (pos+4+ tempnum).ToString() + "  " + fileContent[1 + tempnum + pos] + Environment.NewLine);
                                        }
                                        else
                                        {
                                            
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        textBox5.AppendText("------" + (pos+4 + tempnum).ToString() + "  " + fileContent[1 + tempnum + pos] + Environment.NewLine);

                                    }
                                    size--;
                                    tempnum++;

                                }
                            }
                            size--;
                            tempnum++;
                        }
                        else
                        {
                            log.Add(item);
                            pos++;
                        }
                    }
                    else
                    {
                        pos++;
                    }
                    tempnum = 0; 
                }
                pos = 0;
            }
            catch (ExceptionOverFlowException hata1)
            {
                textBox1.AppendText("Taşıma hatası meydana geldi." + hata1);
            }
            catch (ArithmeticException hata2)
            {
                textBox1.AppendText("Mantıksal hatası meydana geldi." + hata2);
            }
            catch (OutOfMemoryException hata3)
            {
                textBox1.AppendText("Memoryi geçtin hatası meydana geldi." + hata3);
            }
        }
        private void findfullnums(string urlPattern, string[] fileContent)
        {
            try
            {
                Regex regex = null;
                regex = new Regex(urlPattern);

                foreach (string item in fileContent)
                {
                    Match match = regex.Match(item);
                    if (match.Success)
                    {

                        if (item.Length > 149)
                            data1.Add(new data { number = item.Substring(138, 11), id = item.Substring(32, 32), log = item, line = ++pos });

                    }
                    pos++;
                }
            }

            catch (ExceptionOverFlowException hata1)
            {
                textBox1.AppendText("Taşıma hatası meydana geldi." + hata1);
            }
            catch (ArithmeticException hata2)
            {
                textBox1.AppendText("Mantıksal hatası meydana geldi." + hata2);
            }
            catch (OutOfMemoryException hata3)
            {
                textBox1.AppendText("Memoryi geçtin hatası meydana geldi." + hata3);
            }
        }
        private string findid(string urlPattern, string[] fileContent, string phonenum)
        {
            string idnum = "error";
            try
            {
                Regex regex = null;
                regex = new Regex(urlPattern);

                foreach (string item in fileContent)
                {
                    Match match = regex.Match(item);
                    if (match.Success)
                    {
                        if (item.Contains(phonenum))
                        {

                            return item.Substring(32, 32);

                        }
                    }
                    pos++;
                }

            }

            catch (ExceptionOverFlowException hata1)
            {
                textBox1.AppendText("Taşıma hatası meydana geldi." + hata1);
            }
            catch (ArithmeticException hata2)
            {
                textBox1.AppendText("Mantıksal hatası meydana geldi." + hata2);
            }
            catch (OutOfMemoryException hata3)
            {
                textBox1.AppendText("Memoryi geçtin hatası meydana geldi." + hata3);
            }
            return idnum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cleaning();   
                    foreach (string fol in folders)
                    {
                        string[] tmp = File.ReadAllLines(fol);                       
                        string urlPattern = @"ani to complex: session:ani  as(.*)";
                        string phonenum = textBox2.Text;
                        findids(urlPattern, tmp, phonenum);
                        foreach (data mal in data1)
                        {
                            textBox1.AppendText("Number: " + mal.number + "  ID: " + mal.id + "  Log:    \"" + mal.log + "\"          Line: " + mal.line + Environment.NewLine);
                        }
                    }
            textBox1.AppendText(Environment.NewLine + Environment.NewLine + "Finish" + Environment.NewLine);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cleaning();
            textBox1.AppendText(Environment.NewLine + Environment.NewLine + "Searching..." + Environment.NewLine);
            foreach (string fol in folders)
            {
                string[] tmp = File.ReadAllLines(fol);               
                string urlPattern = @"ani to complex: session:ani  as(.*)";
                string searchid = textBox3.Text;
                if (searchid == null)
                {
                    textBox1.AppendText("Please enter valid number first box.");
                }
                findnum(urlPattern, tmp, searchid);
                foreach (data mal in data1)
                {
                    textBox1.AppendText("Number: " + mal.number + "  ID: " + mal.id + "  Log:    \"" + mal.log + "\"          Line: " + mal.line + Environment.NewLine);
                }
            }
            
            textBox1.AppendText(Environment.NewLine + Environment.NewLine + "Finish..." + Environment.NewLine);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            cleaning();
            textBox1.AppendText(Environment.NewLine + Environment.NewLine + "Searching..." + Environment.NewLine);

            string id = textBox3.Text;
            
                    foreach (string fol in folders)
                    {
                        string[] tmp = File.ReadAllLines(fol);
                        

                        findlog(tmp, id);
                        foreach (string logline in log)
                        {
                            textBox1.AppendText(logline + Environment.NewLine);
                        }

                    }
                
            textBox1.AppendText(Environment.NewLine + Environment.NewLine + "Finish..." + Environment.NewLine);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            cleaning();
            textBox1.AppendText(Environment.NewLine + Environment.NewLine + "Searching..." + Environment.NewLine);
                    foreach (string fol in folders)
                    {
                        string[] tmp = File.ReadAllLines(fol);
                        
                        string urlPattern = @"ani to complex: session:ani  as(.*)";

                        findfullnums(urlPattern, tmp);

                    }
            dataGridView1.DataSource = data1.ToList();
            dataGridView1.Update();
            textBox1.AppendText(Environment.NewLine + Environment.NewLine + "Finish..." + Environment.NewLine);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.DefaultExt = "txt";
                sfd.Filter = "Text files (*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    outputfile = sfd.FileName;
                    File.WriteAllText(sfd.FileName, textBox1.Text);

                }
            }
            button7.Enabled = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {

            Process.Start("notepad++.exe", outputfile);
        }
        private void button8_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    folders = ofd.FileNames;

                }
            }
            if (folders == null)
                textBox5.AppendText("Folders not valid!");
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button12.Enabled = true;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.DefaultExt = "txt";
                sfd.Filter = "Text files (*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    outputfile2 = sfd.FileName;
                    File.WriteAllText(sfd.FileName, textBox5.Text);

                }
            }
            button11.Enabled = true;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }
        private void button11_Click(object sender, EventArgs e)
        {

            Process.Start("notepad++.exe", outputfile2);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            cleaning();
            string id;
            string urlPattern = @"ani to complex: session:ani  as(.*)";
            textBox1.AppendText(Environment.NewLine + Environment.NewLine + "Searching..." + Environment.NewLine);
            string phonenum = textBox2.Text;
            foreach (string fol in folders)
            {
                string[] tmp = File.ReadAllLines(fol);
                id = findid(urlPattern, tmp, phonenum);
                findlog(tmp, id);
            }

            foreach (var item in log)
            {
                textBox1.AppendText(item + Environment.NewLine);
            }
        }

        private void cleaning()
        {
            int identificador = GC.GetGeneration(data1);
            GC.Collect(identificador, GCCollectionMode.Forced);
            identificador = GC.GetGeneration(log);
            GC.Collect(identificador, GCCollectionMode.Forced);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cleaning();
            string id;
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }

            string urlPattern = @"ani to complex: session:ani  as(.*)";
            textBox1.AppendText(Environment.NewLine + Environment.NewLine + "Searching..." + Environment.NewLine);
            string phonenum = dataGridView1.CurrentCell.Value.ToString();
            foreach (string fol in folders)
            {
                string[] tmp = File.ReadAllLines(fol);
                id = findid(urlPattern, tmp, phonenum);
                findlog(tmp, id);
            }

            foreach (var item in log)
            {
                textBox1.AppendText(item + Environment.NewLine);
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void findingnum(string fol)
        {
            string[] tmp = File.ReadAllLines(fol);
            string urlPattern = @"ani to complex: session:ani  as(.*)";
            string phonenum = textBox2.Text;
            findids(urlPattern, tmp, phonenum);
            foreach (data mal in data1)
            {
                textBox1.AppendText("Number: " + mal.number + "  ID: " + mal.id + "  Log:    \"" + mal.log + "\"          Line: " + mal.line + Environment.NewLine);
            }
        }
       


       
    }
}