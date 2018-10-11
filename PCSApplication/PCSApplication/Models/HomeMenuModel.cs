using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PCSApplication.Models
{
    public class HomeMenuModel
    {
        public string Menu_name { get; set; }
        public string base64 { get; set; }
        public List<string> sub_menu { get; set; }

        public string banner_list { get; set; }

        //public ImageSource Icon
        //{
        //    get { return Xamarin.Forms.ImageSource.FromStream(
        //    () => new MemoryStream(Convert.FromBase64String(base64))); ; }
        //}

    }
}
