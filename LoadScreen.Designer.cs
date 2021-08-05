/*****************************************************************************************
 * Application: VINYLCAT
 * Class:       LoadScreen
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

namespace BlackCat
{
    partial class LoadScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadScreen));
            this.barLoad = new System.Windows.Forms.ProgressBar();
            this.LoadTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGroup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // barLoad
            // 
            this.barLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.barLoad.BackColor = System.Drawing.Color.Lime;
            this.barLoad.ForeColor = System.Drawing.Color.Lime;
            this.barLoad.Location = new System.Drawing.Point(348, 580);
            this.barLoad.Name = "barLoad";
            this.barLoad.Size = new System.Drawing.Size(800, 23);
            this.barLoad.Step = 1;
            this.barLoad.TabIndex = 21;
            // 
            // timer1
            // 
            this.LoadTimer.Tick += new System.EventHandler(this.LoadTimer_Tick);
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroup.AutoSize = true;
            this.lblGroup.Enabled = false;
            this.lblGroup.Font = new System.Drawing.Font("High Tower Text", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(1130, 682);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(344, 32);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "ninedimensions copyright 2021";
            // 
            // LoadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::BlackCat.Properties.Resources.vinylcat;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1500, 750);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.barLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoadScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " V I N Y L C A T";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar barLoad;
        private System.Windows.Forms.Timer LoadTimer;
        private System.Windows.Forms.Label lblGroup;
    }
}