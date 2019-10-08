using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DAL.Utils
{
    public static class Extensions
    {
        public static void ShowMessage(string text, string cancel = "Cancel")
        {
            MessageBox.Show(text,cancel);
        }
    }
}
