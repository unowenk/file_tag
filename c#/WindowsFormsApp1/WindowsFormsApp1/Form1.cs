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
using System.Text.Json.Serialization;
using System.Xml;
using System.Text.Unicode;
using System.Diagnostics;
using System.DirectoryServices;

//using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string[] args = new string[0];
        public string configfile_name = "tag_file_config.config";
        public string tagfile_name = "tag_file_config.json";
        public string link_sym = "#";
        public Hashtable hashtable = new Hashtable();
        public ArrayList tag_list = new ArrayList();
        System.Collections.Generic.SortedSet<string> sortSet = new System.Collections.Generic.SortedSet<string>();
        public Form1()
        {
            InitializeComponent();
            this.listBox_filename.AllowDrop = true;
            this.listBox_filename.DragDrop += new DragEventHandler(this.listBox_filename_DragDrop);
            this.listBox_filename.DragEnter += new DragEventHandler(this.listBox_filename_DragEnter);
            base_dir.Text = @"D:\tagfilerepos";
            readConfig();
        }
        public Form1(string[] args_)
        {
            args = args_;
            InitializeComponent();
            this.listBox_filename.AllowDrop = true;
            this.listBox_filename.DragDrop += new DragEventHandler(this.listBox_filename_DragDrop);
            this.listBox_filename.DragEnter += new DragEventHandler(this.listBox_filename_DragEnter);
            base_dir.Text = @"D:\tagfilerepos";
            readConfig();
        }
        public static string GetCurrentDirectory() { return System.Environment.CurrentDirectory; }
        public static string GetCurrentAppDirectory() { return System.AppDomain.CurrentDomain.BaseDirectory; }
        public static void SetCurrentDirectory(string path) { System.Environment.CurrentDirectory = path; }

        public void saveConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                WriteIndented = true
            };
            options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All); //解决中文序列化被编码的问题
            //options.Converters.Add(new DateTimeConverter()); //解决时间格式序列化的问题
            string jsonStr = JsonSerializer.Serialize(hashtable, options);
            System.IO.File.WriteAllText(Path.Combine(base_dir.Text, tagfile_name), jsonStr);
            //Debug.WriteLine(jsonStr);
            ////Debug.WriteLine("信息")
            //Hashtable ee=JsonSerializer.Deserialize<Hashtable>(jsonStr, options);
            //foreach (DictionaryEntry item in ee)
            //{
            //    Debug.WriteLine(item.Key);
            //    Debug.WriteLine(item.Value);
            //}
        }
        //~Form1() { saveConfig(); }

        void hashtable_to_taglist()
        {
            tag_list.Clear();
            foreach (string item in hashtable.Keys)
            {
                if (item.IndexOf(link_sym) != -1)
                    continue;
                tag_list.Add(item);
            }
            //tag_list.AddRange(hashtable.Keys);
            taglist_to_listBox_has_tag();
        }
        void taglist_to_listBox_has_tag()
        {
            listBox_has_tag.Items.Clear();
            foreach (string item in tag_list)
            {
                if (item.IndexOf(textBox_search.Text) == -1)
                    continue;
                listBox_has_tag.Items.Add(item);
            }
        }
        void sortSet_to_listBox_tag()
        {
            String[] tags;
            tags = sortSet.ToArray();
            listBox_tag.Items.Clear();
            listBox_tag.Items.AddRange(tags);
            tag_path_flush();
        }
        public void readConfig()
        {
            //MessageBox.Show(Directory.Exists(".").ToString());
            //MessageBox.Show(Path.GetFullPath(".").ToString());
            for (int i = 0; i < args.Length; ++i)
            {
                if (i > 0)
                    break;
                string param = args[i];
                if (Directory.Exists(param))//param == "."
                {
                    base_dir.Text = "";
                    string cwd = Path.GetFullPath(param);
                    while (cwd != "")
                    {
                        if (System.IO.File.Exists(Path.Combine(cwd, configfile_name)))
                        {
                            base_dir.Text = cwd;
                            break;
                        }
                        cwd = Path.GetDirectoryName(cwd);
                    }
                    if (base_dir.Text == "")
                        throw new Exception("怎么处理？");
                }
                else if (Path.GetFileName(param) == configfile_name)
                {
                    base_dir.Text = Path.GetDirectoryName(param);
                }
                else
                {
                    //string cwd = System.AppDomain.CurrentDomain.BaseDirectory;
                    //base_dir.Text = cwd;
                    throw new Exception("怎么处理？");
                }
            }
            if (!System.IO.File.Exists(Path.Combine(base_dir.Text, configfile_name)))
            {
                //creat_config();
            }
            else
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true,
                    WriteIndented = true
                };
                string jsonStr;
                jsonStr = System.IO.File.ReadAllText(Path.Combine(base_dir.Text, tagfile_name));
                hashtable = JsonSerializer.Deserialize<Hashtable>(jsonStr, options);
                //foreach (DictionaryEntry item in hashtable)
                //{
                //    MessageBox.Show(item.Value.ToString());
                //}
                hashtable_to_taglist();
            }
        }
        //public void creat_config()
        //{
        //    //base_dir.Text = Path.Combine(base_dir.Text, "存储");
        //    base_dir.Text = base_dir.Text;
        //    string link_dir_path = Path.Combine(base_dir.Text, "一级标签");
        //    Directory.CreateDirectory(Path.Combine(base_dir.Text, "存储"));
        //    Directory.CreateDirectory(link_dir_path);
        //    FileStream f;
        //    f = System.IO.File.Create(Path.Combine(base_dir.Text, configfile_name));
        //    f.Close();
        //    f = System.IO.File.Create(Path.Combine(base_dir.Text, tagfile_name));
        //    f.Close();
        //    saveConfig();
        //}


        //public void maintain_dirlink()
        //{
        //}


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
            foreach (String filename in files)
            {
                if (listBox_filename.Items.IndexOf(filename) != -1) continue;
                listBox_filename.Items.Add(filename);
            }

        }


        private void tag_path_flush()
        {
            if (sortSet.Count == 0)
            {
                tag_path.Text = "";
                return;
            }
            tag_path.Text = base_hash(base_dir.Text, string.Join(link_sym, sortSet.ToArray())); 
        }
        private void base_dir_TextChanged(object sender, EventArgs e) { tag_path_flush(); }
        private void button_input_tags_Click(object sender, EventArgs e)
        {
            //System.Collections.Generic.SortedList<string, object> STK= new System.Collections.Generic.SortedList<double, object>();
            //System.Collections.Generic.SortedDictionary;
            //ListSortDescriptionCollection;
            String[] tags = textBox_input_tags.Text.Split(link_sym);
            //foreach (String tag in tags)
            //{
            //    if (tag.Trim() == "" || listBox_tag.Items.IndexOf(tag) != -1) continue;
            //    listBox_tag.Items.Add(tag);
            //}
            foreach (String tag in tags)
            {
                if (tag.Trim() == "") continue;
                sortSet.Add(tag);
            }
            sortSet_to_listBox_tag();
        }


        private String base_hash(String pathBase, String str)
        {
            string hashcode;
            if (!hashtable.ContainsKey(str))
            {
                hashcode = base_hash__(Path.Combine(pathBase, "存储"), str);
            }
            else
            {
                hashcode = hashtable[str].ToString();
            }
            return hashcode;
        }
        private String base_hash__(String pathBase, String str)
        {
            //SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            byte[] h5 = SHA512.Create().ComputeHash(buffer);
            String result;
            //result = BitConverter.ToString(h5).Replace("-", string.Empty).Replace("/", "(");
            result = Convert.ToBase64String(h5).Replace("/", "(").Replace("+", ")");
            return Path.Combine(pathBase, result);
        }
        void listBox_has_tag_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // get index Clicked & DoubleClick BlankSpace return NoMatches
            int index = this.listBox_has_tag.IndexFromPoint(e.Location);
            if (index == System.Windows.Forms.ListBox.NoMatches)
            {
                return;
            }
            //do what you wanna do
            //MessageBox.Show("sdd");
            sortSet.Add(listBox_has_tag.SelectedItem.ToString());
            sortSet_to_listBox_tag();
        }
        private void del_tag_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(listBox_tag.SelectedItems);
            foreach (var item in arrayList)
            {
                sortSet.Remove(item.ToString());
            }
            sortSet_to_listBox_tag();
        }




        public int CopyFolder(string sourceFolder, string destFolder)
        {
            //https://www.cnblogs.com/wangjianhui008/p/3234519.html
            //如果目标路径不存在,则创建目标路径
            System.IO.Directory.CreateDirectory(destFolder);
            //得到原文件根目录下的所有文件
            foreach (string file in System.IO.Directory.GetFiles(sourceFolder))
            {
                string name = System.IO.Path.GetFileName(file);
                string dest = System.IO.Path.Combine(destFolder, name);
                System.IO.File.Copy(file, dest);//复制文件
            }
            //得到原文件根目录下的所有文件夹
            foreach (string folder in System.IO.Directory.GetDirectories(sourceFolder))
            {
                string name = System.IO.Path.GetFileName(folder);
                string dest = System.IO.Path.Combine(destFolder, name);
                CopyFolder(folder, dest);//构建目标路径,递归复制文件
            }
            return 1;
        }
        public object[] detect_Directory(string dirpath)
        {
            ArrayList arrayList_file = new ArrayList();
            ArrayList arrayList_folder = new ArrayList();
            string[] files = System.IO.Directory.GetFiles(dirpath);
            string[] folders = System.IO.Directory.GetDirectories(dirpath);
            arrayList_file.AddRange(files);
            arrayList_folder.AddRange(folders);
            foreach (string folder in folders)
            {
                object[] objs = detect_Directory(folder);
                ArrayList _arrayList_file = objs[0] as ArrayList;
                ArrayList _arrayList_folder = objs[1] as ArrayList;
                arrayList_file.AddRange(_arrayList_file);
                arrayList_folder.AddRange(_arrayList_folder);
            }
            return new object[] { arrayList_file, arrayList_folder };
        }

        void CreateDirectory1_(string path, string str)
        {
            Directory.CreateDirectory(path);
            FileStream f = File.Create(Path.Combine(path, "_tag.txt"));
            StreamWriter f_ = new StreamWriter(f);
            f_.Write(str);
            f_.Close();
        }

        void creatSaveDirectory__(SortedSet<string> set)
        {
            string str = string.Join(link_sym, set);
            string path_0 = base_hash(base_dir.Text, string.Join(link_sym, set));
            if (!hashtable.ContainsKey(str))
            {
                hashtable.Add(str, path_0);
                saveConfig();
                hashtable_to_taglist();
            }
            if (set.Count == 1)
            {
                string tag1_dir = Path.Combine(base_dir.Text, "一级标签");
                Directory.CreateDirectory(tag1_dir);
                MyLibrary.ShortcutCreator.CreateShortcut(tag1_dir, set.ToArray()[0], path_0);
                return;
            }
            foreach (string tag in set)
            {
                SortedSet<string> set_ = new SortedSet<string>(set);
                set_.Remove(tag);
                string path = base_hash(base_dir.Text, string.Join(link_sym, set_));
                //if (!Directory.Exists(path))
                //{
                CreateDirectory1_(path, string.Join(link_sym, set_));
                MyLibrary.ShortcutCreator.CreateShortcut(path, tag, path_0);
                creatSaveDirectory__(set_);
                //}
            }
        }

        //Directory.CreateDirectory(tag_path.Text);
        //tag_path.Text = base_hash(base_dir.Text, string.Join(link_sym, sortSet.ToArray()));
        //ArrayList arrayList = new ArrayList();
        //ArrayList copy;
        //ArrayList __new;
        //foreach (string tag in sortSet)
        //{
        //    copy = arrayList.Clone() as ArrayList;
        //    for (int i = 0; i < arrayList.Count; i++)
        //    {
        //        (arrayList[i] as ArrayList).Add(tag);
        //    }
        //    __new = new ArrayList();
        //    __new.Add(tag);
        //    arrayList.Add(__new);
        //}
        void creatSaveDirectory()
        {

            System.Collections.Generic.SortedSet<string> set = new System.Collections.Generic.SortedSet<string>(sortSet);
            string path = base_hash(base_dir.Text, string.Join(link_sym, set));
            if (!Directory.Exists(path))
            {
                CreateDirectory1_(path, string.Join(link_sym, set));
                creatSaveDirectory__(set);

            }
        }
        void copy_or_move(bool ismove)
        {
            //Clipboard
            //System.Windows.Forms.Clipboard.P
            //https://stackoverflow.com/questions/9972419/is-there-a-difference-between-system-windows-clipboard-and-system-windows-forms
            //https://www.cnblogs.com/springsnow/p/13282029.html
            //http://www.mamicode.com/info-detail-1161148.html

            //System.UnauthorizedAccessException解析
            //在VS默认的解释是： path 指定了一个只读文件。-或 - 在当前平台上不支持此操作。
            //-或 - path 指定了一个目录。-或 - 调用方没有所要求的权限。
            try
            {
                if (listBox_filename.Items.Count == 0)
                    return;
                creatSaveDirectory();
                ArrayList arrayList_file = new ArrayList();
                ArrayList arrayList_outfile = new ArrayList();
                foreach (var item in listBox_filename.Items)
                {
                    string filename = item as string;
                    if (Directory.Exists(filename))
                    {
                        string directoryName = Path.GetDirectoryName(filename);
                        Directory.CreateDirectory(Path.Combine(tag_path.Text, Path.GetRelativePath(directoryName, filename)));
                        object[] objs = detect_Directory(filename);
                        ArrayList _arrayList_file = objs[0] as ArrayList;
                        ArrayList _arrayList_folder = objs[1] as ArrayList;
                        foreach (string _file in _arrayList_file)
                        {
                            arrayList_file.Add(_file);
                            arrayList_outfile.Add(Path.Combine(tag_path.Text, Path.GetRelativePath(directoryName, _file)));
                        }
                        foreach (string _folder in _arrayList_folder)
                        {
                            Directory.CreateDirectory(Path.Combine(tag_path.Text, Path.GetRelativePath(directoryName, _folder)));
                        }
                    }
                    else if (System.IO.File.Exists(filename))
                    {
                        arrayList_file.Add(filename);
                        arrayList_outfile.Add(Path.Combine(tag_path.Text, Path.GetFileName(filename)));
                    }
                }



                int flag = 0;
                for (int i = 0; i < arrayList_file.Count; ++i)
                {
                    string src_file = arrayList_file[i] as string;
                    string out_file = arrayList_outfile[i] as string;
                    if (System.IO.File.Exists(out_file))
                    {
                        if (flag == 0)
                        {
                            DialogResult ret = MessageBox.Show("文件已存在,覆盖吗?确定，后续将全覆盖,否将全跳过", "文件已存在",
                                   MessageBoxButtons.YesNoCancel);
                            //MessageBox.Show(DialogResult.GetName(typeof(DialogResult), ret));
                            if (ret == DialogResult.Yes)
                                flag = 1;
                            else if (ret == DialogResult.No)
                                flag = -1;
                            else if (ret == DialogResult.Cancel)
                                return;
                        }
                        if (flag == -1)
                            continue;
                    }
                    if (ismove)
                    {
                        System.IO.File.Move(src_file, out_file, true);
                    }
                    else
                    {
                        System.IO.File.Copy(src_file, out_file, true);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            copy_or_move(false);
        }

        private void button_move_Click(object sender, EventArgs e)
        {
            copy_or_move(true);
        }

        private void button_del_select_filename_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(listBox_filename.SelectedItems);
            foreach (var item in arrayList)
            {
                listBox_filename.Items.Remove(item);
            }
        }

        private void button_reverse_Click(object sender, EventArgs e)
        {
            bool b;
            for (int i = 0; i < listBox_filename.Items.Count; i++)
            {
                b = !listBox_filename.GetSelected(i);
                listBox_filename.SetSelected(i, b);
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            taglist_to_listBox_has_tag();
        }


    }
}
