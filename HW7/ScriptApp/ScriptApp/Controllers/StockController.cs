using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using ScriptApp.Models;

namespace ScriptApp.Controllers
{
    public class StockController : Controller
    {
        

        [HttpGet]
        public JsonResult Browse(string Name)
        {
            using (LogInfoContext db = new LogInfoContext())
           {
            CallerInfo callerInfo = new CallerInfo
            {
                TimeStamp = DateTime.Now,
                CallerIp = HttpContext.Request.UserHostAddress,
                CallerAgent = HttpContext.Request.UserAgent,
                CallerRequestString = HttpContext.Request.Url.OriginalString,
            };
            if (ModelState.IsValid)
            {
                    Debug.WriteLine(callerInfo.TimeStamp);
                    Debug.WriteLine(callerInfo.CallerIp);
                    Debug.WriteLine(callerInfo.CallerAgent);
                    Debug.WriteLine(callerInfo.CallerRequestString);
                    try
                {
                    db.CallerInfoes.Add(callerInfo);
                    db.SaveChanges();
                }
                    catch (DbEntityValidationException e)
                    {
                      throw new Exception(e.Message);
                    }

                }
                
            }
            //Debug.Write("stock name: "+Name);
            //string csvPath = "C:\\Users\\mazhe\\Documents\\cs460\\HW7\\ScriptApp\\ScriptApp\\App_Data\\chart.csv";
            //using (var c = new WebClient())//download the file we need from specified url below with a stock symbol passed from my index page which is user input by jQuery $().val()
            //{
            //    c.DownloadFile("http://chart.finance.yahoo.com/table.csv?s=" + Name + "&a=9&b=13&c=2016&d=10&e=13&f=2016&g=d&ignore=.csv", csvPath);//it is REST based API, and quite easy to download and parse the data once data has been downloaded.
            //}

            //webClient object will be released after reaching the end of this block
            string data;
            using (var c = new WebClient())//download the file/data we need from specified url below
            {
                 data = c.DownloadString("http://chart.finance.yahoo.com/table.csv?s=" + Name + "&a=9&b=13&c=2016&d=10&e=13&f=2016&g=d&ignore=.csv");//it is REST based API, and quite easy to download and parse the data once data has been downloaded.
            }

            //var AllText = System.IO.File.ReadAllText(csvPath);//read this file with an absolute directory into a string(convert data to string)
            // Debug.WriteLine("original source text: "+AllText);
             Debug.WriteLine("original source text: "+data);
            var source = data.Replace("\r", "").Split('\n');// replace the return character with empty character and splict the string into array by new line character
           // Debug.WriteLine("initial array size: "+source.Length);
            List<string[]> list = new List<string[]>();//create a list hold string array
            List<dynamic> InfoList = new List<dynamic>();
            foreach (var s in source)
            {
                Debug.WriteLine("each String of initial array: "+s);
                if (!String.IsNullOrWhiteSpace(s))//only add non null item to the list
                {
                    list.Add(s.Split(','));//split each string by , to array
                }
                
            }
            //Debug.Write(list.Count);
             list.RemoveAt(0);
            // Debug.Write(list.Count);
            // Debug.WriteLine(list[1].Length);
            
            foreach (var listItem in list)
            {
                //object initializer to create object with the data in the array and add all object to the InfoList

                //StockInfo si = new StockInfo
                //{
                //    Date = listItem[0],// Debug.Write(listItem[0]);
                //    Open = Convert.ToDecimal(listItem[1]), // Debug.Write(listItem[1]);
                //    High = Convert.ToDecimal(listItem[2]), //Debug.Write(listItem[2]);
                //    Low = Convert.ToDecimal(listItem[3]), // Debug.Write(listItem[3]);
                //    Close = Convert.ToDecimal(listItem[4]), //Debug.Write(listItem[4]);
                //    Volume = Convert.ToInt64(listItem[5]), //Debug.Write(listItem[5]);
                //    AdjClose = Convert.ToDecimal(listItem[6]) //Debug.Write(listItem[6]);
                //};

                var si = new
                {
                    Date = listItem[0],
                    Open = Convert.ToDecimal(listItem[1]),
                    High = Convert.ToDecimal(listItem[2]),
                    Low = Convert.ToDecimal(listItem[3]),
                    Close = Convert.ToDecimal(listItem[4]),
                    Volume = Convert.ToInt64(listItem[5]),
                    AdjClose = Convert.ToDecimal(listItem[6])
                };
                InfoList.Add(si);
            }


            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            // var Jasonstring = serializer.Serialize(InfoList);
            // Debug.WriteLine(InfoList.Count);
            return Json(InfoList, JsonRequestBehavior.AllowGet);//response the InfoList in json format/jsonResult

        }
    }
}