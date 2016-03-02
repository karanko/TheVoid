
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid
{

    public class Utility
    {

        public static ObservableCollection<string> Messages;
        public static void Print(string prefix, object message)
        {
            Print(prefix + message.ToString());
        }
        public static void Print(object message)
        {

          //  Console.WriteLine(message.ToString());
            System.Diagnostics.Debug.WriteLine(message.ToString());

            try
            {
                if (Messages == null)
                {
                    Messages = new ObservableCollection<string>();
                }
              
                    foreach (var msg in message.ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        Messages.Add(msg);
                    }
                
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine(ex);
            }

        }
        public static bool GetConfigSettingBool(string key, bool result = false)
        {
            return Convert.ToBoolean(GetConfigSettingString(key, result.ToString()));

        }
       
        public static string GetConfigSettingString(string key, string result = "")
        {

            try
            {
                //will change this to read keys from config xml live to save restarting app and possibly move to read some settings from webservice
                string value = ConfigurationManager.AppSettings[key];
                if (!String.IsNullOrEmpty(value))
                {
                    result = value;
                }

            }
            catch (Exception e)
            {
                Print(e.Message);
            }
            return result;
        }
    }


}

