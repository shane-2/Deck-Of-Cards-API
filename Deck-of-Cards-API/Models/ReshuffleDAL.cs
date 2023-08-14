using Newtonsoft.Json;
using System.Net;

namespace Deck_of_Cards_API.Models
{
    public class ReshuffleDAL
    {

        public static ReshuffleModel GetReshuffle()//Adjust here
        {
            //setup
            //adjust
            string deckid = Deckid.deckid;
            string url = $"https://deckofcardsapi.com/api/deck/{deckid}/shuffle/"; //link to api

            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Converting to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            //Adjust
            //Convert to c#            //show potential fixes - find and install Newtonsoft.json
            ReshuffleModel result = JsonConvert.DeserializeObject<ReshuffleModel>(json);
            return result;

        }
    }
}
