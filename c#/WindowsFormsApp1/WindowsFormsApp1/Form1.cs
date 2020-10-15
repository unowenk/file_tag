using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using System.Drawing.Printing;
using System.Text.Json;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listBox_filename.AllowDrop = true;
            this.listBox_filename.DragDrop += new DragEventHandler(this.listBox_filename_DragDrop);
            this.listBox_filename.DragEnter += new DragEventHandler(this.listBox_filename_DragEnter);
        }

        private void listBox_filename_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox_filename_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];
            //listBox_filename.Items.AddRange(files);
            foreach(String filename in files)
            {
                if (listBox_filename.Items.IndexOf(filename) != -1) continue;
                listBox_filename.Items.Add(filename);
            }

        }
        System.Collections.Generic.SortedSet<string> sortSet = new System.Collections.Generic.SortedSet<string>();
        private void tag_path_flush()
        {
            tag_path.Text = base_hash(base_dir.Text, string.Join("_",  sortSet.ToArray()));
        }
        private void base_dir_TextChanged(object sender, EventArgs e)
        {
            tag_path_flush();
        }
        private void button_input_tags_Click(object sender, EventArgs e)
        {
            //System.Collections.Generic.SortedList<string, object> STK= new System.Collections.Generic.SortedList<double, object>();
            //System.Collections.Generic.SortedDictionary;
            //ListSortDescriptionCollection;
            String[] tags = textBox_input_tags.Text.Split('#');
            //foreach (String tag in tags)
            //{
            //    if (tag.Trim() == "" || listBox_tag.Items.IndexOf(tag) != -1) continue;
            //    listBox_tag.Items.Add(tag);
            //}
            foreach (String tag in tags)
            {
                sortSet.Add(tag);
            }
            tags = sortSet.ToArray();
            listBox_tag.Items.Clear();
            listBox_tag.Items.AddRange(tags);
            tag_path_flush();
        }

        private String base_hash(String pathBase, String str)
        {
            //SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            byte[] h5 = SHA512.Create().ComputeHash(buffer);
            String result;
            //result = BitConverter.ToString(h5).Replace("-", string.Empty).Replace("/", "(");
            result = Convert.ToBase64String(h5).Replace("/", "(").Replace("+", ")");
            return Path.Combine(pathBase, result);
        }

        private void del_tag_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(listBox_tag.SelectedItems);
            foreach (var item in arrayList)
            {
                sortSet.Remove(item as string);
                listBox_tag.Items.Remove(item);
            }
            tag_path_flush();
        }
        public void saveConfig()
        {

        }
        public void readConfig()
        {
            //JsonElement;
        }
        public void maintain_dirlink()
        {

            foreach (var item in listBox_filename.Items)
            {
                Directory.CreateDirectory(tag_path.Text);
                string filename = item as string;
                string out_name = Path.Combine(tag_path.Text, Path.GetFileName(filename));
                if (File.Exists(out_name))
                    if (MessageBox.Show("文件已存在,覆盖吗?", "文件已存在",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                        continue;
                File.Move(filename, out_name, true);
            }
        }

        private void button_move_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox_filename.Items)
            {
                Directory.CreateDirectory(tag_path.Text);
                string filename = item as string;
                string out_name = Path.Combine(tag_path.Text, Path.GetFileName(filename));
                if (File.Exists(out_name))
                    if (MessageBox.Show("文件已存在,覆盖吗?", "文件已存在",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                        continue;
                File.Move(filename, out_name, true);
            }
        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox_filename.Items)
            {
                Directory.CreateDirectory(tag_path.Text);
                string filename = item as string;
                string out_name = Path.Combine(tag_path.Text, Path.GetFileName(filename));
                if (File.Exists(out_name))
                    if (MessageBox.Show("文件已存在,覆盖吗?", "文件已存在", 
                        MessageBoxButtons.YesNo) == DialogResult.No) 
                        continue;
                File.Copy(filename, out_name, true);
            }
        }

    }
}
