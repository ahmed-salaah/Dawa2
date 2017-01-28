using System;
using System.Collections.Generic;

namespace Models
{
    public delegate void UnAuthroirzedChangedEventHandler(object sender, UnAuthroirzedChangedEventArgs e);

    public class UnAuthroirzedChangedEventArgs : EventArgs
    {
        public string URL { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
