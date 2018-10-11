using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PCSApplication.Controls
{
    public class CustomEntry : Entry
    {
        #region BorderColorProperty
        public static BindableProperty BorderColorProperty = BindableProperty.Create(
                                                        propertyName: nameof(BorderColor),
                                                        returnType: typeof(Color),
                                                        declaringType: typeof(CustomEntry),
                                                        defaultValue: Color.White,
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: null);

        public Color BorderColor
        {
            get { return (Color)base.GetValue(BorderColorProperty); }
            set { base.SetValue(BorderColorProperty, value); }
        }
        #endregion

        #region LeftIconImageProperty
        public static BindableProperty LeftIconImageProperty = BindableProperty.Create(
                                                        propertyName: nameof(LeftIconImage),
                                                        returnType: typeof(string),
                                                        declaringType: typeof(CustomEntry),
                                                        defaultValue: null,
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: null);

        public string LeftIconImage
        {
            get { return base.GetValue(LeftIconImageProperty).ToString(); }
            set { base.SetValue(LeftIconImageProperty, value); }
        }
        #endregion
        
        #region RightIconImageProperty
        public static BindableProperty RightIconImageProperty = BindableProperty.Create(
                                                        propertyName: nameof(RightIconImage),
                                                        returnType: typeof(string),
                                                        declaringType: typeof(CustomEntry),
                                                        defaultValue: string.Empty,
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: null);

        public string RightIconImage
        {
            get { return base.GetValue(RightIconImageProperty).ToString(); }
            set { base.SetValue(RightIconImageProperty, value); }
        }
        #endregion
        
    }
}
