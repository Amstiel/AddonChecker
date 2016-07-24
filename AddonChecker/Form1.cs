using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AddonChecker
{
    public partial class MainForm : Form
    {
        static String DefaultPath = @"C:\Games\World of Warcraft\Interface\AddOns";
        DirectoryInfo DirInfo = new DirectoryInfo(DefaultPath);
        ArrayList ListItems = new ArrayList();
        public MainForm()
        {
            InitializeComponent();
            if (DirInfo.Exists)
            {
                string[] Dirs = Directory.GetDirectories(DefaultPath);
                int YOffset = 10;
                foreach (string s in Dirs)
                {
                    if (s.Contains("Blizzard")) continue;
                    if (s.Contains("DBM-")) continue; //ingoring DBM addon
                    Label lb = new Label();
                    lb.Text = s;
                    lb.AutoSize = true;
                    lb.Left = 10;
                    ListItems.Add(lb);
                }

                for (int i = 0; i < ListItems.Count; i++)
                {
                    ((Label)ListItems[i]).Top = 15 * i + YOffset;
                    this.Controls.Add((Label)(ListItems[i]));
                }
            }
        }
    }
}
