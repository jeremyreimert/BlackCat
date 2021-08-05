/*****************************************************************************************
 * Application: VINYLCAT
 * Class:       DataBaseCommands
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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace BlackCat
{
    class DataBaseCommand
    {

        



        // Find path to database
        readonly static string path = PathToFile("\\Albums.mdf");

        // Create the connection string

        //readonly static string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +
        //    " AttachDbFilename=" + path + ";Integrated Security=SSPI;Initial Catalog=Albums";

        readonly static string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +
            " AttachDbFilename=" + path + ";Integrated Security=SSPI";

        /*******************************************************************************
         * PathToFile(string)
         * Combines the path of the current directory with the file's local path
         * accepts: the local path of the file
         * returns: the full path to a the file 
         *******************************************************************************/
        public static string PathToFile(string localPath)
        {
            try
            {
                string currentDir = Environment.CurrentDirectory;
                DirectoryInfo directory = new DirectoryInfo(
                    Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));

                return directory.ToString();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        /*******************************************************************************
         * Insert(Record)
         * Adds a record to the database
         * accepts: a Record object
         * returns: the number of rows affected 
         *******************************************************************************/
        public int Insert(Record rec)
        {
            int result = 0;

            try
            {
                // create connection object passing connection string
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    // create command object with SQL query and link to connection object
                    using (SqlCommand com = new SqlCommand("EXEC InsertAlbum @Artist, @Album, @Tracks, @Content", connect))
                    {
                        // create your parameters
                        com.Parameters.Add("@Artist", System.Data.SqlDbType.VarChar);
                        com.Parameters.Add("@Album", System.Data.SqlDbType.VarChar);
                        com.Parameters.Add("@Tracks", System.Data.SqlDbType.VarChar);
                        com.Parameters.Add("@Content", System.Data.SqlDbType.VarChar);

                        // set values to parameters from date selectors
                        com.Parameters["@Artist"].Value = rec.Artist;
                        com.Parameters["@Album"].Value = rec.Album;
                        com.Parameters["@Tracks"].Value = rec.Tracks;
                        com.Parameters["@Content"].Value = rec.Content;

                        // open sql connection
                        connect.Open();

                        // execute the query and return number of rows affected, should be one
                        result = com.ExecuteNonQuery();
                    }

                    // close connection when done
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        /*******************************************************************************
        * Delete(Record)
        * Deletes a record from the database
        * accepts: a Record object
        * returns: the number of rows affected 
        *******************************************************************************/
        public int Delete(Record rec)
        {
            int result = 0;

            try
            {
                // create connection object passing connection string
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    // create command object with SQL query and link to connection object
                    using (SqlCommand com = new SqlCommand("EXEC DeleteAlbum @Artist, @Album;", connect))
                    {

                        // create your parameters
                        com.Parameters.Add("@Artist", System.Data.SqlDbType.VarChar);
                        com.Parameters.Add("@Album", System.Data.SqlDbType.VarChar);

                        // set values to parameters from date selectors
                        com.Parameters["@Artist"].Value = rec.Artist;
                        com.Parameters["@Album"].Value = rec.Album;

                        // open sql connection
                        connect.Open();

                        // execute the query and return number of rows affected, should be one
                        result = com.ExecuteNonQuery();
                    }

                    // close connection when done
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        /*******************************************************************************
        * Select(string, string)
        * Retrieves records from the database using the album and artist name
        * accepts: artist and album names as strings
        * returns: the selected album as a record object  
        *******************************************************************************/
        public Record Select(string artist, string album)
        {
            DataTable dataRecords = new DataTable();
            Record rec = null;

            try
            {
                // create connection object passing connection string
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    // create command object with SQL query and link to connection object
                    using (SqlCommand com = new SqlCommand("EXEC SelectAlbum @Artist, @Album;", connect))
                    {
                        // create your parameters
                        com.Parameters.Add("@Artist", System.Data.SqlDbType.VarChar);
                        com.Parameters.Add("@Album", System.Data.SqlDbType.VarChar);

                        // set values to parameters from date selectors
                        com.Parameters["@Artist"].Value = artist;
                        com.Parameters["@Album"].Value = album;

                        using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(com))
                        {
                            sqlDataAdap.Fill(dataRecords);

                            // open sql connection
                            connect.Open();

                            // execute the query and return number of rows affected, should be one
                            int RowsAffected = com.ExecuteNonQuery();

                            if (dataRecords.Rows.Count > 0)
                            {
                                Object[] rowArray = dataRecords.Rows[0].ItemArray;

                                rec = new Record(rowArray[0].ToString(), rowArray[1].ToString(), rowArray[2].ToString(), rowArray[3].ToString());
                            }

                        }
                    }

                    connect.Close();
                }

                return rec;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /*******************************************************************************
        * SelectAll()
        * Retrieves all records from the database 
        * accepts nothing
        * returns: a datatable containing all records 
        *******************************************************************************/
        public DataTable SelectAll()
        {
            DataTable dataRecords = new DataTable();

            try
            {
                // create connection object passing connection string
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    // create command object with SQL query and link to connection object
                    using (SqlCommand com = new SqlCommand("SELECT * FROM Records ORDER BY Artist, Album;", connect))
                    {
                        using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(com))
                        {
                            sqlDataAdap.Fill(dataRecords);

                            // open sql connection
                            connect.Open();

                            // execute the query and return number of rows affected, should be one
                            int RowsAffected = com.ExecuteNonQuery();
                        }
                    }

                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }

            // return the table
            return dataRecords;
        }

        /*******************************************************************************
        * GetNext(Record)
        * accepts: the current album as a record object
        * returns: the next album as a record object  
        *******************************************************************************/
        public Record GetNext(Record rec)
        {
            DataTable dataRecords = new DataTable();

            try
            {
                // create connection object passing connection string
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    // create command object with SQL query and link to connection object
                    using (SqlCommand com = new SqlCommand("EXEC GetNext @Artist, @Album;", connect))
                    {

                        // create your parameters
                        com.Parameters.Add("@Artist", System.Data.SqlDbType.VarChar);
                        com.Parameters.Add("@Album", System.Data.SqlDbType.VarChar);

                        // set values to parameters from date selectors
                        com.Parameters["@Artist"].Value = rec.Artist;
                        com.Parameters["@Album"].Value = rec.Album;

                        using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(com))
                        {
                            sqlDataAdap.Fill(dataRecords);

                            // open sql connection
                            connect.Open();

                            // execute the query and return number of rows affected, should be one
                            int RowsAffected = com.ExecuteNonQuery();

                            rec = null;

                            if (dataRecords.Rows.Count > 0)
                            {
                                object[] rowArray = dataRecords.Rows[0].ItemArray;
                                rec = new Record(rowArray[0].ToString(), rowArray[1].ToString(), rowArray[2].ToString(), rowArray[3].ToString());
                            }
                        }
                    }

                    connect.Close();
                }

                return rec;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return null;
            }
        }

        /*******************************************************************************
        * GetPrevious(Record)
        * accepts: the current album as a record object
        * returns: the previous album as a record object  
        *******************************************************************************/
        public Record GetPrevious(Record rec)
        {
            DataTable dataRecords = new DataTable();

            try
            {
                // create connection object passing connection string
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    // create command object with SQL query and link to connection object
                    using (SqlCommand com = new SqlCommand("EXEC GetPrevious @Artist, @Album;", connect))
                    {

                        // create your parameters
                        com.Parameters.Add("@Artist", System.Data.SqlDbType.VarChar);
                        com.Parameters.Add("@Album", System.Data.SqlDbType.VarChar);

                        // set values to parameters from date selectors
                        com.Parameters["@Artist"].Value = rec.Artist;
                        com.Parameters["@Album"].Value = rec.Album;

                        using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(com))
                        {
                            sqlDataAdap.Fill(dataRecords);

                            // open sql connection
                            connect.Open();

                            // execute the query and return number of rows affected, should be one
                            int RowsAffected = com.ExecuteNonQuery();

                            rec = null;

                            if (dataRecords.Rows.Count > 0)
                            {
                                object[] rowArray = dataRecords.Rows[0].ItemArray;
                                rec = new Record(rowArray[0].ToString(), rowArray[1].ToString(), rowArray[2].ToString(), rowArray[3].ToString());
                            }
                        }
                    }

                    connect.Close();
                }

                return rec;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /*******************************************************************************
        * SelectFirts()
        * accepts: nothing 
        * returns: the first album in the database as a record object  
        *******************************************************************************/
        public Record SelectFirst()
        {
            DataTable dataRecords = new DataTable();
            Record rec = null;

            try
            {
                // create connection object passing connection string
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    // create command object with SQL query and link to connection object
                    using (SqlCommand com = new SqlCommand("SELECT TOP 1 Artist, Album, Tracks, Content FROM Records ORDER BY Artist, Album;", connect))
                    {
                        using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(com))
                        {
                            sqlDataAdap.Fill(dataRecords);

                            // open sql connection
                            connect.Open();

                            // execute the query and return number of rows affected, should be one
                            int RowsAffected = com.ExecuteNonQuery();

                            if (dataRecords.Rows.Count > 0)
                            {
                                object[] rowArray = dataRecords.Rows[0].ItemArray;
                                rec = new Record(rowArray[0].ToString(), rowArray[1].ToString(), rowArray[2].ToString(), rowArray[3].ToString());
                            }
                        }
                    }

                    connect.Close();
                }

                return rec;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /*******************************************************************************
       * SelectLast()
       * accepts: nothing 
       * returns: the last album in the database as a record object  
       *******************************************************************************/
        public Record SelectLast()
        {
            DataTable dataRecords = new DataTable();
            Record rec = null;

            try
            {
                // create connection object passing connection string
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    // create command object with SQL query and link to connection object
                    using (SqlCommand com = new SqlCommand("SELECT TOP 1 Artist, Album, Tracks, Content FROM Records ORDER BY Artist DESC, Album DESC;", connect))
                    {
                        using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(com))
                        {
                            sqlDataAdap.Fill(dataRecords);

                            // open sql connection
                            connect.Open();

                            // execute the query and return number of rows affected, should be one
                            int RowsAffected = com.ExecuteNonQuery();

                            if (dataRecords.Rows.Count > 0)
                            {
                                object[] rowArray = dataRecords.Rows[0].ItemArray;
                                rec = new Record(rowArray[0].ToString(), rowArray[1].ToString(), rowArray[2].ToString(), rowArray[3].ToString());
                            }
                        }
                    }

                    connect.Close();
                }

                return rec;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
