using System;
using System.Collections.Generic;
using System.Text;

namespace PCSApplication.Controls
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string _message, object _customdata)
        {
            Message = _message;
            Customdata = _customdata;
        }

        public string Message { get; private set; }
        public object Customdata { get; private set; }
    }
}
