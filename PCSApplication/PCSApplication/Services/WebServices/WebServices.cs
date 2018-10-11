using Newtonsoft.Json;
using PCSApplication.Models;
using PCSApplication.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCSApplication.Services.WebServices
{
    public class WebServices : IWebServices
    {
        public async Task<List<T>> GetListDetailsAsync<T>(string param) where T : new()
        {
            List<T> l = new List<T>();
            for (int i = 0; i < 10; i++)
            {
                T o = new T();
                if (o is ItemDetailsModel)
                {
                    var obj = o as ItemDetailsModel;
                    obj.linkforpdf = "http://www.africau.edu/images/default/sample.pdf";
                    obj.vessel_name = "demo vessel";
                    obj.vessel_type = "demo vessel type";
                    obj.imono = "123";
                    obj.action = "eye.png";
                    obj.call_sign = "demo call sign";
                }
                l.Add(o);
            }
            var jsonlist = JsonConvert.SerializeObject(l);
            return JsonConvert.DeserializeObject<List<T>>(jsonlist);
        }

        //public async Task<List<T>> GetListHomeMenuAsync<T>()
        //{
        //    try
        //    {
        //        //await Task.Delay(5000);
        //        return JsonConvert.DeserializeObject<List<T>>("[\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n]");
        //    }
        //    catch (Exception e)
        //    {
        //        return default(List<T>);
        //    }
        //    finally
        //    {
        //    }
        //}

        public async Task<List<T>> GetListHomeMenuAsync<T>()
        {
            try
            {
                var l = new List<HomeMenuModel>();
                //await Task.Delay(5000);
                for (int i = 0; i < 10; i++)
                {
                    var o = new HomeMenuModel();
                    o.base64 = "https://png.icons8.com/metro/1600/home.png";
                    o.Menu_name = "Goku";
                    o.sub_menu = new List<string> { "Submenu 1", "Submenu 2", "Submenu 3" };
                    if (i % 2 == 1)
                    {
                        o.banner_list = "http://artificial-intelligence.biz/images/joomlart/article/banner5.jpg";
                    }
                    else
                    {
                        o.banner_list = "https://previews.123rf.com/images/arrow/arrow1508/arrow150800013/43834604-mobile-marketing-flat-design-concept-banner-background.jpg";
                    }
                    l.Add(o);
                }
                var jsonlist = JsonConvert.SerializeObject(l);
                return JsonConvert.DeserializeObject<List<T>>(jsonlist);
                //return JsonConvert.DeserializeObject<List<T>>("[\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n{\r\n\'Menu_name\' : \'Vessel\',\r\n\'base64\':\'https://vignette.wikia.nocookie.net/dbz-dokkanbattle/images/6/68/Leaping_Even_Higher_Super_Saiyan_Goku.png/revision/latest?cb=20160830122933\',\r\n\'sub_menu\':[\'submenu1\',\'submenu2\',\'submenu3\']\r\n},\r\n]");
            }
            catch (Exception e)
            {
                return default(List<T>);
            }
            finally
            {
            }
        }

        public async Task<List<T>> GetListSubHomeMenuAsync<T>(string p)
        {
            //await Task.Delay(5000);
            try
            {
                return JsonConvert.DeserializeObject<List<T>>("[{\r\n\t'menu': 'Vessel Activity',\r\n\t'submenu': ['Vessel Profile', 'Vessel Registration',\r\n\t\t'Berth Request', 'Berthing Schedule', 'Passenger Crew List', 'Stowage Plan', 'Bay Plan'\r\n\t]\r\n},\r\n{\r\n\t'menu': 'Vessel Activity',\r\n\t'submenu': ['Vessel Profile', 'Vessel Registration',\r\n\t\t'Berth Request', 'Berthing Schedule', 'Passenger Crew List', 'Stowage Plan', 'Bay Plan'\r\n\t]\r\n},\r\n{\r\n\t'menu': 'Vessel Activity',\r\n\t'submenu': ['Vessel Profile', 'Vessel Registration',\r\n\t\t'Berth Request', 'Berthing Schedule', 'Passenger Crew List', 'Stowage Plan', 'Bay Plan'\r\n\t]\r\n}]");
            }
            catch (Exception)
            {
                return default(List<T>);
            }
        }

        public async Task<T> GetLoginDetailsAsync<T>(string _userData)
        {
            try
            {
                //await Task.Delay(5000);
                //var jsonString = "{'Password':'123', 'Mpin':'123', 'Name' : '123'}";
                return JsonConvert.DeserializeObject<T>(_userData);
            }
            catch (Exception e)
            {
                return default(T);
            }finally
            {
            }
        }

        //public List<T> GetDataForList<T>() where T : new()
        //{
        //    var l = new List<T>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        T o = new T();
        //        if (o is ItemDetailsModel)
        //        {
        //            var obj = o as ItemDetailsModel;
        //            obj.linkforpdf = "http://www.pdf995.com/samples/pdf.pdf";
        //            obj.vessel_name = "demo vessel";
        //            obj.vessel_type = "demo vessel type";
        //            obj.imono = "123";
        //            obj.action = "view.png";
        //            obj.call_sign = "demo call sign";
        //        }
        //        l.Add(o);
        //    }
        //    return l;
        //}
    }
}
