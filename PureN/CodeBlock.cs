﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PureN
{
    public partial class CodeBlock : UserControl
    {
        public CodeBlock()
        {
            InitializeComponent();
        }
        public string Value
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
    }
}
