/*****************************************************************************************
 * Application: VINYLCAT
 * Class:       CoverArt
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
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackCat
{
    class CoverArt
    {
        private static readonly Image defaultImage = Properties.Resources.GOLD;

        /*******************************************************************************
        * ShowCoverArt(Record)
        * Accepts a Record object 
        * Uses record to retrieve image file     
        * Returns the Image object
        * *******************************************************************************/
        public static Image ShowCoverArt(Record rec)
        {
            try
            {
                if (rec == null || !File.Exists(rec.Artist + " - " + rec.Album + ".jpg"))
                {
                    return defaultImage;
                }
                else
                {
                    return Image.FromFile(rec.Artist + " - " + rec.Album + ".jpg");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
              
                return defaultImage;
            }
        }

       /*******************************************************************************
       * RemoveCoverFromCatalog(Record) 
       * Accepts a Record object and removes the cover art associated with it
       * Returns void
       *******************************************************************************/
        public static void RemoveCoverFromCatalog(Record rec)
        {
            try
            {
                String fileName = rec.Artist + " - " + rec.Album + ".jpg";

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
        * GetCoverArt(Record)
        * Accepts a Record object
        * Retrieves the cover art from server and saves to file        
        * Returns TResult<bool> true if cover art was found
        ********************************************************************************/
        public static async Task<bool> GetCoverArt(Record rec)
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

                if (userObj.ContainsKey("album"))
                {
                    var mbid = Convert.ToString(userObj["album"]["mbid"]);

                    if (mbid.Equals(""))
                    {
                        Properties.Resources.GOLD.Save(rec.Artist + " - " + rec.Album + ".jpg");
                        return false;
                    }
                    else
                    {
                        MetaBrainz.MusicBrainz.CoverArt.CoverArt cover = new MetaBrainz.MusicBrainz.CoverArt.CoverArt("VINYLCAT");
                        MetaBrainz.MusicBrainz.CoverArt.CoverArtImageSize size = MetaBrainz.MusicBrainz.CoverArt.CoverArtImageSize.Original;

                        Guid id = new Guid(mbid);

                        using (MetaBrainz.MusicBrainz.CoverArt.CoverArtImage art = cover.FetchFront(id, size))
                        {
                            art.Decode().Save(rec.Artist + " - " + rec.Album + ".jpg");
                            art.Dispose();
                        }

                        return true;
                    }
                }
                else
                {
                    Properties.Resources.GOLD.Save(rec.Artist + " - " + rec.Album + ".jpg");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Properties.Resources.GOLD.Save(rec.Artist + " - " + rec.Album + ".jpg");
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
