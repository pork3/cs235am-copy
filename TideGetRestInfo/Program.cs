using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TideGetRestInfo
{
    class MainClass
    {
        static void Main(string[] args)
        {


        }
    }


    public class TideRest
    {
        // URL 
        string tideURL = "http://opendap.co-ops.nos.noaa.gov/axis/webservices/highlowtidepred/index.jsp";
        string requestParams = "stationId=8454000&beginDate=20160523&endDate=20160623&datum=MLLW&unit=0&timeZone=0&format=text&Submit=Submit";
        //
        const string DATE_AND_TIME_TEMPLATE = "yyy-MM-ddTh:mm:ss";
        string begin = beginDateTime.ToString(DATE_AND_TIME_TEMPLATE);
        string end = beginDateTime.AddDays(7).ToString(DATE_AND_TIME_TEMPLATE);

        //string tideRequest = string.Format ("");

        var request = HttpWebRequest.Create(tideRequest);
        var response = (HttpWebResponse)request.GetResponse();

        var reader = new StreamReader(resopnse.GetResponseStream());
        string content = reader.ReadToEnd();
        //return parsed xml; 
    
    }
}
