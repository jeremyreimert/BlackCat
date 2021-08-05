/*****************************************************************************************
 * Application: VINYLCAT
 * Class:       MainScreen : Form
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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BlackCat
{
    public partial class MainScreen : Form
    {
        readonly private DataBaseCommand data = new DataBaseCommand(); // create a DataBaseCommand object

        /*******************************************************************************
         * MainScreen()
         * Constructor 
         * Initializes the form components
         * Sets double buffering to elliminate image flickering
         * Calls LoadAlbum() to load as initial album
         * *******************************************************************************/
        public MainScreen()
        {
            try
            {
                InitializeComponent();

                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);

                lblSelection.Text = "";
                btnInfo.Text = "";
                lblInfo.Text = "";
                picCover.Image = Properties.Resources.GOLD;

                Record rec = data.SelectFirst();

                if (rec != null)
                {
                    LoadAlbum(rec);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
        * LoadAlbums(Record)
        * Accepts a record 
        * Assigns record data to form components
        * returns the record
        *******************************************************************************/
        private Record LoadAlbum(Record rec)
        {
            try
            {
                if (rec == null)
                {
                    lblSelection.Text = "";
                    btnInfo.Text = "";
                    lblInfo.Text = "";
                    picCover.Image = Properties.Resources.GOLD;
                }
                else
                {
                    lblSelection.Text = rec.Artist + " - " + rec.Album;
                    btnInfo.Text = " T R A C K  L I S T";
                    lblInfo.Font = new Font("Century Gothic", 14);
                    lblInfo.Text = rec.Tracks;

                    Image img = CoverArt.ShowCoverArt(rec);
                    picCover.Image = img.GetThumbnailImage(200, 200, null, new IntPtr());
                    img.Dispose();
                    

                    //using (Image img = CoverArt.ShowCoverArt(rec))
                    //{
                    //    picCover.Image = img.GetThumbnailImage(200, 200, null, new IntPtr());
                    //}
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
        * btnScrollRight_Click(object, EventArgs)
        * On btnScrollRight click - scrolls right through the catalog
        * Returns void
        *******************************************************************************/
        private void btnScrollRight_Click(object sender, EventArgs e)
        {
            try
            {
                Record current = null;

                string[] selection = lblSelection.Text.Split('-');

                if (selection.Length == 2)
                {
                    current = data.Select(selection[0].Trim(), selection[1].Trim());
                }

                if (current != null)
                {
                    if (data.SelectLast().Album == current.Album)
                    {
                        LoadAlbum(data.SelectFirst());
                    }
                    else
                    {
                        LoadAlbum(data.GetNext(current));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
        * btnScrollLeft_Click(object, EventArgs)
        * On btnScrollLeft click - scrolls left through the catalog
        * Returns void
        *******************************************************************************/
        private void btnScrollLeft_Click(object sender, EventArgs e)
        {
            try
            {
                Record current = null;

                string[] selection = lblSelection.Text.Split('-');

                if(selection.Length == 2)
                {
                    current = data.Select(selection[0].Trim(), selection[1].Trim());
                }

                if(current != null)
                {
                    if (data.SelectFirst().Album == current.Album)
                    {
                        LoadAlbum(data.SelectLast());
                    }
                    else
                    {
                        LoadAlbum(data.GetPrevious(current));
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
        * btnSearch_Click(object, EventArgs)
        * Selects a record from the database
        * Loads the album if the record exists.
        *******************************************************************************/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerifyInput())
                {
                    Record rec = GetInput();
                    rec = data.Select(rec.Artist, rec.Album);

                    if (rec == null)
                    {
                        MessageBox.Show("Album not found");
                    }
                    else
                    {
                        LoadAlbum(rec);
                    }
                }

                ClearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
        * btnAdd_Click(object, EventArgs)
        * Calls GetInput() to create a Record object from user input
        * Calls RecordExists() to check for the existence of the record in the database
        * Adds the record if it does not exist
        * Returns void
        *******************************************************************************/
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerifyInput())
                {
                    Record rec = GetInput();

                    if (data.Select(rec.Artist, rec.Album) == null)
                    {
                        if (MessageBox.Show("Confirm Addition", "Add New Album?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            rec.Tracks = await RecordInfo.GetTrackList(rec);
                            rec.Content = await RecordInfo.GetSummary(rec);

                            if (data.Insert(rec) == 0)
                            {
                                MessageBox.Show("Error Adding Album");
                            }
                            else
                            {
                                if (!await CoverArt.GetCoverArt(rec))
                                {
                                    if (MessageBox.Show("Add From File?", "Unable to Download Cover Art", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                    {
                                        if (openFile.ShowDialog() == DialogResult.OK)
                                        {
                                            Image.FromFile(openFile.FileName).Save(rec.Artist + " - " + rec.Album + ".jpg");
                                            MessageBox.Show("Album Successfully Added");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Using Default Image", "Cover Art Not Found");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Using Default Image", "Cover Art Not Found");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Album Successfully Added");
                                }

                                LoadAlbum(rec);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Addition Canceled");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Album already exists in catalog");
                    }
                }

                ClearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
        * btnDelete_Click(object, EventArg)
        * Deletes a record from the database
        * Calls GetInput() to create a Record object from user input
        * Calls RecordExists() to check for the existence of the record in the database
        * Adds the record if it does not exist
        * Returns void
        *******************************************************************************/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // IF YOU DELETED THE LAST RECORD??????????
            try
            {
                if (VerifyInput())
                {
                    Record rec = GetInput();

                    if (data.Select(rec.Artist, rec.Album) != null)
                    {
                        if (MessageBox.Show("Confirm Deletion", "Delete Selected Album?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (data.Delete(rec) == 0)
                            {
                                MessageBox.Show("Error Deleting Album");
                            }
                            else
                            {
                                picCover.Image.Dispose();
                                CoverArt.RemoveCoverFromCatalog(rec);
                                rec = data.SelectFirst();
                                
                                LoadAlbum(rec);      ////////////////////////

                                if (data.SelectAll().Rows.Count == 0)
                                {
                                    MessageBox.Show("Album Successfully Deleted\nDatabase is empty");
                                }
                                else
                                {
                                    MessageBox.Show("Album Successfully Deleted");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Deletion Canceled");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Record does not exist");
                    }
                }

                ClearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
        * GetInput()
        * Removes all non-alphanumeric characters from txtArtist.Text and txtAlbum.Text
        * Sets the data members of a Record object to these modified strings
        * Returns Record 
        *******************************************************************************/
        private Record GetInput()
        {
            Record record = new Record(); // create a Record object

            try
            {
                // apply user text to Record members
                record.Album = Regex.Replace(txtAlbum.Text, "[^a-zA-Z0-9]", " ");
                record.Artist = Regex.Replace(txtArtist.Text, "[^a-zA-Z0-9]", " ");
                //ClearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                record = null;
            }

            return record; // return the Record object
        }

        /*******************************************************************************
        * VerifyInput()
        * Verifies Checks that input exists in required fields 
        * Highlights txtArtist and/or txtAlbum if input is missing
        * Returns bool
        *******************************************************************************/
        private bool VerifyInput()
        {
            try
            {
                // If text boxes are empty show error message
                if (txtAlbum.Text.Equals("") || txtArtist.Text.Equals(""))
                {
                    if (txtAlbum.Text.Equals(""))
                    {
                        txtAlbum.BackColor = System.Drawing.Color.Red;
                        txtAlbum.Focus();
                    }

                    if (txtArtist.Text.Equals(""))
                    {
                        txtArtist.BackColor = System.Drawing.Color.Red;
                        txtArtist.Focus();
                    }

                    MessageBox.Show("Required Fields Are Empty");
                    return false;
                }
                else
                {
                    txtAlbum.BackColor = System.Drawing.Color.SeaShell;
                    txtArtist.BackColor = System.Drawing.Color.SeaShell;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /*******************************************************************************
        * ClearText()
        * Clears text from txtArtist and txtAlbum 
        * Places focus on txtArtist
        * Returns void
        *******************************************************************************/
        private void ClearText()
        {
            try
            {
                txtArtist.Clear();
                txtAlbum.Clear();
                txtArtist.Focus();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
         * ProcessCmdKey(ref Message, Keys)
         * Captures key strokes of left and right arrow keys.
         * left key stroke performs btnScrollLeft.PerformClick()
         * right key stroke performs btnScrollRight.PerformClick()
         * Returns bool 
         *******************************************************************************/
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                //capture left arrow key
                if (keyData == Keys.Left)
                {
                    btnScrollLeft.PerformClick();
                    return true;
                }
                //capture right arrow key
                if (keyData == Keys.Right)
                {
                    btnScrollRight.PerformClick();
                    return true;
                }

                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /*******************************************************************************
         * lblSelection_Click(object, EventArgs)
         * On click of lblSelection - lblSelection.Text is split, trimmed,
         * and copied to txtArtist.Text and txtAlbum.Text
         * Returns void 
         *******************************************************************************/
        private void lblSelection_Click(object sender, EventArgs e)
        {
            try
            {
                string[] selection = lblSelection.Text.Split('-');
                txtArtist.Text = selection[0].Trim();
                txtAlbum.Text = selection[1].Trim();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
         * btnExit_Click(object, EventArgs)
         * On click of btnExit the application is closed
         * Returns void 
         *******************************************************************************/
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*******************************************************************************
         * FlipInfo()
         * Flips information displayed in lblInfo between album tracks and summary
         * Returns void 
         *******************************************************************************/
        private void FlipInfo()
        {
            string[] selection = lblSelection.Text.Split('-');

            Record rec = data.Select(selection[0].Trim(), selection[1].Trim());

            if (btnInfo.Text.Equals(" S U M M A R Y"))
            {
                btnInfo.Text = " T R A C K  L I S T";
                lblInfo.Font = new Font("Century Gothic", 14);
                lblInfo.Text = rec.Tracks;
            }
            else
            {
                btnInfo.Text = " S U M M A R Y";
                lblInfo.Font = new Font("Century Gothic", 8);
                lblInfo.Text = rec.Content;
            }
        }

        /*******************************************************************************
         * btnInfo_Click(object, EventArgs)
         * On click of btnInfo calls FlipInfo() 
         * Returns void 
         *******************************************************************************/
        private void btnInfo_Click(object sender, EventArgs e)
        {
            FlipInfo();
        }

        /*******************************************************************************
         * picCover_Click(object, EventArgs)
         * On click of picCover calls FlipInfo() 
         * Returns void 
         *******************************************************************************/
        private async void picCover_Click(object sender, EventArgs e)
        {
            try
            {
                string[] selection = lblSelection.Text.Split('-');

                Record rec = new Record(selection[0].Trim(), selection[1].Trim());

                if (MessageBox.Show("Change Cover Art?", "Edit Album", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (!await CoverArt.GetCoverArt(rec))
                    {
                        if (MessageBox.Show("Add From File?", "Unable to Download Cover Art", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (openFile.ShowDialog() == DialogResult.OK)
                            {
                                Image.FromFile(openFile.FileName).Save(rec.Artist + " - " + rec.Album + ".jpg");
                                LoadAlbum(data.Select(rec.Artist, rec.Album));
                                MessageBox.Show("Album Successfully Added");
                            }
                            else
                            {
                                MessageBox.Show("Addition Canceled");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Addition Canceled");
                        }
                    }
                    else
                    {
                        LoadAlbum(rec);
                        MessageBox.Show("Album Successfully Added");
                    }
                }
                else
                {
                    MessageBox.Show("Addition Canceled");
                }

                ClearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
         * lblInfo_Click(object, EventArgs)
         * On click of lblInfo calls FlipInfo() 
         * Returns void 
         *******************************************************************************/
        private void lblInfo_Click(object sender, EventArgs e)
        {
            FlipInfo();
        }
    }
}