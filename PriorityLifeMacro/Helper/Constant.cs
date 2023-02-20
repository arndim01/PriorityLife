using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeMacro.Helper
{
    public static class Constant
    {

        public static string DOWNLOAD_DIR = AppDomain.CurrentDomain.BaseDirectory + "Downloads";
        public static string MACRO_DIR = AppDomain.CurrentDomain.BaseDirectory + "MacroCodes";
        public static string DESKTOP_DOWNLOAD_DIR = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
        public static string GENERATEDMACRO_DIR = AppDomain.CurrentDomain.BaseDirectory + "GeneratedMacro";
        public static string CHROME_PROFILE_DIR = AppDomain.CurrentDomain.BaseDirectory + "ChromePriorityLifeProfile";
        public static string LOGS_DIR = AppDomain.CurrentDomain.BaseDirectory + "Logs";
        public static string FILEUPLOAD_LOGS_DIR = AppDomain.CurrentDomain.BaseDirectory + "Logs/FileUploadLogs";
        public static string CHROME_PROFILE = AppDomain.CurrentDomain.BaseDirectory + "ChromeProfile";
        public static string CHROME_MACRO_HTM(string command)
        {
            return @"<!DOCTYPE html PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"">" + "\n" +
                 "<html>\n" +
                 "<head>\n" +
                 @"<meta content =""text/html; charset=UTF-8"" http-equiv =""content-type"" >" + "\n" +
                 "<title> Iim Launch </title>\n" +
                 "</head>\n" +
                 @"<body onload = ""window.setTimeout('document.getElementById(\'criimlaunch\').click();', 5000);"">" + "\n" +
                 "<script> \n" +
                    "var myIimMacro = " + command + "\n" +
                    "var myMacro = window.btoa(encodeURIComponent(myIimMacro));\n" +
                 "</script>\n" +
                 @"<a id = ""criimlaunch"" href = ""javascript:(function() {try{var e_m64 = myMacro, n64 = 'bWFjcm8uaWlt'; if(!/^(?:chrome|https?|file)/.test(location)){alert('iMacros: Open webpage to run a macro.');return;}var macro = {}; macro.source = decodeURIComponent(atob(e_m64));macro.name = decodeURIComponent(atob(n64));var evt = document.createEvent('CustomEvent');evt.initCustomEvent('iMacrosRunMacro', true, true, macro);window.dispatchEvent(evt);}catch(e){alert('iMacros Bookmarklet error: '+e.toString());}}) ();"">Launch CR iMacros</a>" + "\n" +
                 "</body>\n" +
                 "</html>\n";
        }
        public static string CHROME_BATCH_RUNNER(string HtmPath)
        {
            return "@ECHO OFF\n" +
                   "TASKKILL /F /IM Chrome.exe\n" +
                   @"START ""Chrome"" ""C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"" ""file:///" + HtmPath + @""" --new-window" + "\n" +
                   ":LOOP\n" +
                   @"tasklist | find /i ""CHROME"" >nul 2>&1" + "\n" +
                   "IF ERRORLEVEL 1 (\n" +
                   "GOTO CONTINUE\n" +
                   ") ELSE  (\n" +
                   "ECHO CHROME is still running\n" +
                   "Timeout /T 300 /Nobreak\n" +
                   "GOTO CONTINUE\n" +
                   ")\n" +
                   ":CONTINUE";
        }
    }
}
