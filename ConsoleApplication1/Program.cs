using System;
using System.IO;
using System.Linq;
using System.Net;


namespace RestService
{
    public class TideRest
    {
        public string get7DayLowAndHigh(string stationID, DateTime beginDateTime)
        {
            // Set up the URL for querying the service
            string serviceUrl = "http://opendap.co-ops.nos.noaa.gov/axis/webservices/highlowtidepred/index.jsp";


            const string DATE_TIME_TEMPLATE = "yyyyMMdd";
            string begin = beginDateTime.ToString(DATE_TIME_TEMPLATE);
            string end = beginDateTime.AddDays(7).ToString(DATE_TIME_TEMPLATE);

            string theRequest = string.Format("{0}?stationId={1}&beginDate={2}&endDate={3}&datum=MLLW&unit=0&timeZone=0&format=text&Submit=Submit", serviceUrl, stationID, begin, end);

            // Send a request to the service and get a response
            var request = HttpWebRequest.Create(theRequest);
            var response = (HttpWebResponse)request.GetResponse();

            // Read and parse the response
            var reader = new StreamReader(response.GetResponseStream());
            //string content = reader.ReadToEnd();
            // return XmlParser.ParseLowsXml(content);
            return reader.ToString();
        }
    }
}


//date format: 20160624

//?stationId=8454000&beginDate=20160524
//&endDate=20160624&datum=MLLW&unit=0&
//timeZone=0&format=html&Submit=Submit
//string theRequest = string.Format("{0}?stationId={1}&beginDate={2}&endDate={3}&datum=MLLW&unit=0&timeZone=0&format=text&Submit=Submit", URL, stationid, begin ,end);