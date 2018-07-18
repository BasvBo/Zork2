using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.ViewModels
{
    public class PrintViewModel
    {
        public string Text { get; set; }

        public PrintViewModel(string text)
        {
            this.Text = text + Environment.NewLine;
        }
    }
}