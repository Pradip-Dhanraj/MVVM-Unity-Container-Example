using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCSApplication.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PdfPage : ContentPage
	{
		public PdfPage (object obj)
		{
			InitializeComponent ();
            //pdfview.Uri = obj as string;

        }
	}
}