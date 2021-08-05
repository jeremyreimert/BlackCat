/*****************************************************************************************
 * Application: VINYLCAT
 * Class:       LoasScreen : Form
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
using System.Windows.Forms;

namespace BlackCat
{
    public partial class LoadScreen : Form
    {
        DataBaseCommand data = new DataBaseCommand();   
        MainScreen catalog = new MainScreen();

        /*******************************************************************************
         * LoadScreen()
         * Constructor 
         * Initializes the form components
         * Sets double buffering to elliminate image flickering
         * Sets interval and enables LoadTimer
         * *******************************************************************************/
        public LoadScreen()
        {
            try
            {
                InitializeComponent();

                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint,true);

                Visible = false;
                LoadTimer.Interval = 50;
                LoadTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        /*******************************************************************************
         * LoadTimer_Tick(object, EventArgs)
         * Increments value of barLoad from 0 to 100
         * Provides time for logo to be displayed before main form is shown
         * Message box is shown with instructions if database is empty 
         * Returns void
         *******************************************************************************/
        private void LoadTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (barLoad.Value <= 99)
                {
                    barLoad.Value += 1;
                }

                if (barLoad.Value == 100)
                {
                    LoadTimer.Enabled = false;

                    catalog.Show();

                    Hide();

                    if (data.SelectAll().Rows.Count == 0)
                    {
                        MessageBox.Show("Your Vinyl Catalog is Empty\n" +
                                        "Add Your First Album by Entering the Artist and Album Names\n" +
                                        "Then click the Add Button",
                                        "Getting Started");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
