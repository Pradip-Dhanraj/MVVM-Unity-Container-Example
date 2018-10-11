using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using PCSApplication.Controls;
using PCSApplication.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace PCSApplication.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntry entry { get; private set; }
        public Context _context { get; private set; }

        public CustomEntryRenderer(Context context): base(context)
        {
            _context = context;
        }

        

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            entry = Element as CustomEntry;

            if (Control == null)
                return;

            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(Android.Graphics.Color.FloralWhite);
          //  gd.SetColor(Android.Graphics.Color.Firebrick);
            gd.SetCornerRadius(20);
            gd.SetStroke(2, entry.BorderColor.ToAndroid());
            Control.SetBackgroundDrawable(gd);
            Control.CompoundDrawablePadding = 25;
            if (entry.RightIconImage == null & entry.LeftIconImage != null)
            {
                Control.SetCompoundDrawablesWithIntrinsicBounds(GetImageResID(entry.LeftIconImage), null, null, null);
            }
            else if (entry.RightIconImage != null & entry.LeftIconImage != null)
            {
                Control.SetCompoundDrawablesWithIntrinsicBounds(GetImageResID(entry.LeftIconImage), null, GetImageResID(entry.RightIconImage), null);
            }
            //Control.GetCompoundDrawables().Select(x=>x.Equals(GetImageResID(entry.RightIconImage)));

            //if (Control != null)
            //{
            //    GradientDrawable gd = new GradientDrawable();
            //    //Below line is useful to give border color
            //    gd.SetColor(global::Android.Graphics.Color.Red);
            //    this.Control.SetBackgroundDrawable(gd);
            //    this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
            //    Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.White));
            //}
        }

        private Drawable GetImageResID(string icons)
        {
            return Resources.GetDrawable(icons);
            //int resID = getResources().getIdentifier(rightIconImage, "drawable", getPackageName());
        }
        
    }
    }