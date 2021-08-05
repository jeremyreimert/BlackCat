/*****************************************************************************************
 * Application: VINYLCAT
 * Class:       RecordInfo
 * Developer:   ninedimensions
 * Last Update: March 15, 2021
 * Description: Catalog for vinyl record collection
 *              Cover art retrieved through LastFm and MusicBrainz APIs
 *
 * LastFM credentials:
 *  API Key:        718eb9ee6bd589e09bb940d77e8ea0d8
 *  Shared Secret:  7514ead22ec833370327f1dc06b1f2d5
 *  Registered to:  ninedimensions
 * **************************************************************************************/

using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlackCat
{
    static class RecordInfo
    {
        /*******************************************************************************
        * GetTrackList(Record)
        * Accepts a record object 
        * Creates Http GET request using the record 
        * Retrieves the track list         
        * Returns the track list as a TResult<string>
        * *******************************************************************************/
        public static async Task<string> GetTrackList(Record rec)
        {
            try
            {
                StringBuilder query = new StringBuilder("http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key=718eb9ee6bd589e09bb940d77e8ea0d8&artist=");
                query.Append(rec.Artist.Replace(" ", "+"));
                query.Append("&album=");
                query.Append(rec.Album.Replace(" ", "+"));
                query.Append("&format=json");

                HttpClient client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.GetAsync(query.ToString());

                string result = response.Content.ReadAsStringAsync().Result;

                var userObj = JObject.Parse(Convert.ToString(result));

                string list = "";

                if (userObj.ContainsKey("album"))
                {

                    foreach (var track in userObj["album"]["tracks"]["track"].Values("name"))
                    {
                        list += track.ToString() + "\n";
                    }
                }

                if (list.Equals(""))
                {
                    list = "Empty List";
                }

                return list;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return "Error Getting Track LIst";
            }
        }

        /*******************************************************************************
        * GetSummary(Record)
        * Accepts a record object 
        * Creates Http GET request using the record 
        * Retrieves the album summary        
        * Returns the summary as a TResult<string>
        * *******************************************************************************/
        public static async Task<string> GetSummary(Record rec)
        {
            try
            {
                StringBuilder query = new StringBuilder("http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key=718eb9ee6bd589e09bb940d77e8ea0d8&artist=");
                query.Append(rec.Artist.Replace(" ", "+"));
                query.Append("&album=");
                query.Append(rec.Album.Replace(" ", "+"));
                query.Append("&format=json");

                HttpClient client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.GetAsync(query.ToString());

                string result = response.Content.ReadAsStringAsync().Result;

                var userObj = JObject.Parse(Convert.ToString(result));

                Console.WriteLine(userObj.ToString());

                string list = "";

                if (userObj.ContainsKey("album"))
                {
                    list = userObj["album"]["wiki"]["content"].ToString();  
                }

                if (list.Equals(""))
                {
                    list = "Content Unavailable";
                }

                return list;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return "Error Getting Content";
            }
        }
    }
}

