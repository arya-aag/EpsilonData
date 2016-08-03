using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConnectionTest
{
    public class Connection
    {
        public string URL;

        public Connection(string url)
        {
            this.URL = url;
        }

        public int NumberOfTickers()
        {
            int numTicker=0;

            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(List<string>));
            WebClient getWC = new WebClient();
            Stream getStream = getWC.OpenRead(this.URL);
            List<string> allTickers = (List<string>)DCJS.ReadObject(getStream);

            //string fileName = @"context/allTickers.txt";
            //StreamReader reader = new StreamReader(fileName);
            //allTickers = (List<string>)DCJS.ReadObject(reader.BaseStream);

            foreach (string ticker in allTickers)
                lstTickers.Items.Add(ticker);

            return numTicker;
        }
    }
}
