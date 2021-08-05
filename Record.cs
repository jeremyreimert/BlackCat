/*****************************************************************************************
 * Application: VINYLCAT
 * Class:       Record
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

using System;

namespace BlackCat
{
    class Record
    { 
        public String Artist;
        public String Album;
        public String Tracks;
        public String Content;

        /*******************************************************************************
        * Record()
        * Default Constructor
        * *******************************************************************************/
        public Record()
        {

        }

        /*******************************************************************************
        * Record(string, string)
        * Constructor
        * *******************************************************************************/
        public Record(String artist, string album)
        {
            try
            {
                Artist = artist;
                Album = album;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        /*******************************************************************************
        * Record(string, string, string)
        * Constructor
        * *******************************************************************************/
        public Record(String artist, string album, string tracks)
        {
            try
            {
                Artist = artist;
                Album = album;
                Tracks = tracks;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        /*******************************************************************************
        * Record(string, string, string, string)
        * Constructor
        * *******************************************************************************/
        public Record(String artist, string album, string tracks, string content)
        {
            try
            {
                Artist = artist;
                Album = album;
                Tracks = tracks;
                Content = content;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

    }
}
