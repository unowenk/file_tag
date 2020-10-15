
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
   
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_input_tags = new System.Windows.Forms.Button();
            this.listBox_filename = new System.Windows.Forms.ListBox();
            this.button_reverse = new System.Windows.Forms.Button();
            this.button_del_select_filename = new System.Windows.Forms.Button();
            this.listBox_tag = new System.Windows.Forms.ListBox();
            this.listBox_has_tag = new System.Windows.Forms.ListBox();
            this.button_has2now = new System.Windows.Forms.Button();
            this.textBox_input_tags = new System.Windows.Forms.TextBox();
            this.button_move = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.tag_path = new System.Windows.Forms.TextBox();
            this.base_dir = new System.Windows.Forms.TextBox();
            this.del_tag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_input_tags
            // 
            this.button_input_tags.Location = new System.Drawing.Point(221, 211);
            this.button_input_tags.Name = "button_input_tags";
            this.button_input_tags.Size = new System.Drawing.Size(208, 37);
            this.button_input_tags.TabIndex = 9;
            this.button_input_tags.Text = "🡅添加tags，#号分割🡅";
            this.button_input_tags.UseVisualStyleBackColor = true;
            this.button_input_tags.Click += new System.EventHandler(this.button_input_tags_Click);
            // 
            // listBox_filename
            // 
            this.listBox_filename.AllowDrop = true;
            this.listBox_filename.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox_filename.HorizontalScrollbar = true;
            this.listBox_filename.ItemHeight = 24;
            this.listBox_filename.Location = new System.Drawing.Point(13, 71);
            this.listBox_filename.Name = "listBox_filename";
            this.listBox_filename.ScrollAlwaysVisible = true;
            this.listBox_filename.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_filename.Size = new System.Drawing.Size(178, 124);
            this.listBox_filename.TabIndex = 1;
            // 
            // button_reverse
            // 
            this.button_reverse.AllowDrop = true;
            this.button_reverse.Enabled = false;
            this.button_reverse.Location = new System.Drawing.Point(13, 30);
            this.button_reverse.Name = "button_reverse";
            this.button_reverse.Size = new System.Drawing.Size(66, 34);
            this.button_reverse.TabIndex = 3;
            this.button_reverse.Text = "反选";
            this.button_reverse.UseVisualStyleBackColor = true;
            // 
            // button_del_select_filename
            // 
            this.button_del_select_filename.Enabled = false;
            this.button_del_select_filename.Location = new System.Drawing.Point(116, 30);
            this.button_del_select_filename.Name = "button_del_select_filename";
            this.button_del_select_filename.Size = new System.Drawing.Size(66, 34);
            this.button_del_select_filename.TabIndex = 4;
            this.button_del_select_filename.Text = "删除";
            this.button_del_select_filename.UseVisualStyleBackColor = true;
            // 
            // listBox_tag
            // 
            this.listBox_tag.FormattingEnabled = true;
            this.listBox_tag.ItemHeight = 24;
            this.listBox_tag.Location = new System.Drawing.Point(237, 71);
            this.listBox_tag.Name = "listBox_tag";
            this.listBox_tag.ScrollAlwaysVisible = true;
            this.listBox_tag.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_tag.Size = new System.Drawing.Size(180, 124);
            this.listBox_tag.TabIndex = 5;
            // 
            // listBox_has_tag
            // 
            this.listBox_has_tag.Enabled = false;
            this.listBox_has_tag.FormattingEnabled = true;
            this.listBox_has_tag.ItemHeight = 24;
            this.listBox_has_tag.Location = new System.Drawing.Point(504, 71);
            this.listBox_has_tag.Name = "listBox_has_tag";
            this.listBox_has_tag.ScrollAlwaysVisible = true;
            this.listBox_has_tag.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_has_tag.Size = new System.Drawing.Size(180, 124);
            this.listBox_has_tag.TabIndex = 6;
            // 
            // button_has2now
            // 
            this.button_has2now.Enabled = false;
            this.button_has2now.Location = new System.Drawing.Point(426, 138);
            this.button_has2now.Name = "button_has2now";
            this.button_has2now.Size = new System.Drawing.Size(61, 34);
            this.button_has2now.TabIndex = 7;
            this.button_has2now.Text = "<<";
            this.button_has2now.UseVisualStyleBackColor = true;
            // 
            // textBox_input_tags
            // 
            this.textBox_input_tags.Location = new System.Drawing.Point(242, 254);
            this.textBox_input_tags.Name = "textBox_input_tags";
            this.textBox_input_tags.Size = new System.Drawing.Size(150, 30);
            this.textBox_input_tags.TabIndex = 8;
            // 
            // button_move
            // 
            this.button_move.Enabled = false;
            this.button_move.Location = new System.Drawing.Point(193, 309);
            this.button_move.Name = "button_move";
            this.button_move.Size = new System.Drawing.Size(135, 34);
            this.button_move.TabIndex = 10;
            this.button_move.Text = "移入(暂时禁用";
            this.button_move.UseVisualStyleBackColor = true;
            this.button_move.Click += new System.EventHandler(this.button_move_Click);
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(354, 309);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(112, 34);
            this.button_copy.TabIndex = 11;
            this.button_copy.Text = "复制入";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // tag_path
            // 
            this.tag_path.Location = new System.Drawing.Point(13, 309);
            this.tag_path.Name = "tag_path";
            this.tag_path.Size = new System.Drawing.Size(150, 30);
            this.tag_path.TabIndex = 12;
            // 
            // base_dir
            // 
            this.base_dir.Location = new System.Drawing.Point(242, 34);
            this.base_dir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.base_dir.Name = "base_dir";
            this.base_dir.Size = new System.Drawing.Size(155, 30);
            this.base_dir.TabIndex = 13;
            this.base_dir.Text = "D:\\tagfilerepos";
            this.base_dir.TextChanged += new System.EventHandler(this.base_dir_TextChanged);
            // 
            // del_tag
            // 
            this.del_tag.Location = new System.Drawing.Point(426, 99);
            this.del_tag.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.del_tag.Name = "del_tag";
            this.del_tag.Size = new System.Drawing.Size(71, 32);
            this.del_tag.TabIndex = 14;
            this.del_tag.Text = "删除";
            this.del_tag.UseVisualStyleBackColor = true;
            this.del_tag.Click += new System.EventHandler(this.del_tag_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 354);
            this.Controls.Add(this.del_tag);
            this.Controls.Add(this.base_dir);
            this.Controls.Add(this.tag_path);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.button_move);
            this.Controls.Add(this.button_input_tags);
            this.Controls.Add(this.textBox_input_tags);
            this.Controls.Add(this.button_has2now);
            this.Controls.Add(this.listBox_has_tag);
            this.Controls.Add(this.listBox_tag);
            this.Controls.Add(this.button_del_select_filename);
            this.Controls.Add(this.button_reverse);
            this.Controls.Add(this.listBox_filename);
            this.Name = "Form1";
            this.Text = "添加标签";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ListBox_filename_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ListBox listBox_filename;
        private System.Windows.Forms.Button button_reverse;
        private System.Windows.Forms.Button button_del_select_filename;
        private System.Windows.Forms.ListBox listBox_tag;
        private System.Windows.Forms.ListBox listBox_has_tag;
        private System.Windows.Forms.Button button_has2now;
        private System.Windows.Forms.TextBox textBox_input_tags;
        private System.Windows.Forms.Button button_move;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Button button_input_tags;
        private System.Windows.Forms.TextBox tag_path;
        private System.Windows.Forms.TextBox base_dir;
        private System.Windows.Forms.Button del_tag;
    }
}

