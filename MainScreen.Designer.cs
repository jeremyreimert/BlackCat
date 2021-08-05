/*****************************************************************************************
 * Application: VINYLCAT
 * Class:       MainScreen
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
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.lblAlbum = new System.Windows.Forms.Button();
            this.lblArtist = new System.Windows.Forms.Button();
            this.lblSelection = new System.Windows.Forms.Button();
            this.btnScrollRight = new System.Windows.Forms.Button();
            this.btnScrollLeft = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnInfo = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArtist
            // 
            this.txtArtist.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtArtist.BackColor = System.Drawing.Color.SeaShell;
            this.txtArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArtist.Location = new System.Drawing.Point(279, 36);
            this.txtArtist.Margin = new System.Windows.Forms.Padding(2);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(310, 31);
            this.txtArtist.TabIndex = 1;
            // 
            // txtAlbum
            // 
            this.txtAlbum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAlbum.BackColor = System.Drawing.Color.SeaShell;
            this.txtAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlbum.Location = new System.Drawing.Point(837, 36);
            this.txtAlbum.Margin = new System.Windows.Forms.Padding(2);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(310, 31);
            this.txtAlbum.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFind.BackColor = System.Drawing.Color.SlateGray;
            this.btnFind.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnFind.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnFind.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnFind.Location = new System.Drawing.Point(1215, 26);
            this.btnFind.Margin = new System.Windows.Forms.Padding(2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(300, 100);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "F I N D";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.BackColor = System.Drawing.Color.SlateGray;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnDelete.Location = new System.Drawing.Point(1215, 248);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(300, 100);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "D E L E T E";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.BackColor = System.Drawing.Color.SlateGray;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnAdd.Location = new System.Drawing.Point(1215, 137);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(300, 100);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "A D D";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // picCover
            // 
            this.picCover.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCover.BackColor = System.Drawing.Color.SlateGray;
            this.picCover.Location = new System.Drawing.Point(70, 91);
            this.picCover.Margin = new System.Windows.Forms.Padding(2);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(528, 480);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCover.TabIndex = 11;
            this.picCover.TabStop = false;
            this.picCover.Click += new System.EventHandler(this.picCover_Click);
            // 
            // lblAlbum
            // 
            this.lblAlbum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAlbum.BackColor = System.Drawing.Color.SlateGray;
            this.lblAlbum.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.lblAlbum.FlatAppearance.BorderSize = 0;
            this.lblAlbum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.lblAlbum.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbum.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblAlbum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlbum.Location = new System.Drawing.Point(628, 26);
            this.lblAlbum.Margin = new System.Windows.Forms.Padding(2);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(528, 50);
            this.lblAlbum.TabIndex = 0;
            this.lblAlbum.TabStop = false;
            this.lblAlbum.Text = "      A L B U M";
            this.lblAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlbum.UseVisualStyleBackColor = false;
            // 
            // lblArtist
            // 
            this.lblArtist.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblArtist.BackColor = System.Drawing.Color.SlateGray;
            this.lblArtist.CausesValidation = false;
            this.lblArtist.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblArtist.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.lblArtist.FlatAppearance.BorderSize = 0;
            this.lblArtist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.lblArtist.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblArtist.Location = new System.Drawing.Point(70, 26);
            this.lblArtist.Margin = new System.Windows.Forms.Padding(2);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(528, 50);
            this.lblArtist.TabIndex = 0;
            this.lblArtist.TabStop = false;
            this.lblArtist.Text = "      A R T I S T";
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArtist.UseVisualStyleBackColor = false;
            // 
            // lblSelection
            // 
            this.lblSelection.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSelection.BackColor = System.Drawing.Color.SlateGray;
            this.lblSelection.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.lblSelection.FlatAppearance.BorderSize = 0;
            this.lblSelection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.lblSelection.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelection.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblSelection.Location = new System.Drawing.Point(70, 581);
            this.lblSelection.Margin = new System.Windows.Forms.Padding(2);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(1086, 100);
            this.lblSelection.TabIndex = 9;
            this.lblSelection.Text = " A R T I S T  -  A L B U M";
            this.lblSelection.UseVisualStyleBackColor = false;
            this.lblSelection.Click += new System.EventHandler(this.lblSelection_Click);
            // 
            // btnScrollRight
            // 
            this.btnScrollRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnScrollRight.BackColor = System.Drawing.Color.SlateGray;
            this.btnScrollRight.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnScrollRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnScrollRight.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrollRight.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnScrollRight.Location = new System.Drawing.Point(1215, 470);
            this.btnScrollRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnScrollRight.Name = "btnScrollRight";
            this.btnScrollRight.Size = new System.Drawing.Size(300, 100);
            this.btnScrollRight.TabIndex = 7;
            this.btnScrollRight.Text = "> > >";
            this.btnScrollRight.UseVisualStyleBackColor = false;
            this.btnScrollRight.Click += new System.EventHandler(this.btnScrollRight_Click);
            // 
            // btnScrollLeft
            // 
            this.btnScrollLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnScrollLeft.BackColor = System.Drawing.Color.SlateGray;
            this.btnScrollLeft.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnScrollLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnScrollLeft.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrollLeft.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnScrollLeft.Location = new System.Drawing.Point(1215, 359);
            this.btnScrollLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btnScrollLeft.Name = "btnScrollLeft";
            this.btnScrollLeft.Size = new System.Drawing.Size(300, 100);
            this.btnScrollLeft.TabIndex = 6;
            this.btnScrollLeft.Text = "< < <";
            this.btnScrollLeft.UseVisualStyleBackColor = false;
            this.btnScrollLeft.Click += new System.EventHandler(this.btnScrollLeft_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExit.BackColor = System.Drawing.Color.SlateGray;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnExit.Location = new System.Drawing.Point(1215, 581);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(300, 100);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "E X I T";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnInfo.BackColor = System.Drawing.Color.SlateGray;
            this.btnInfo.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnInfo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnInfo.Location = new System.Drawing.Point(628, 91);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(528, 480);
            this.btnInfo.TabIndex = 10;
            this.btnInfo.Text = "  T R A C K  L I S T";
            this.btnInfo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.SlateGray;
            this.lblInfo.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblInfo.Location = new System.Drawing.Point(648, 137);
            this.lblInfo.MaximumSize = new System.Drawing.Size(475, 350);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(107, 22);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "TRACK LIST";
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.BackColor = System.Drawing.Color.SlateGray;
            this.lblSummary.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblSummary.Location = new System.Drawing.Point(785, 204);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(0, 23);
            this.lblSummary.TabIndex = 17;
            // 
            // MainScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::BlackCat.Properties.Resources.records2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.ControlBox = false;
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtAlbum);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.btnScrollLeft);
            this.Controls.Add(this.btnScrollRight);
            this.Controls.Add(this.lblSelection);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnFind);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " V I N Y L C A T";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.Button lblAlbum;
        private System.Windows.Forms.Button lblArtist;
        private System.Windows.Forms.Button lblSelection;
        private System.Windows.Forms.Button btnScrollRight;
        private System.Windows.Forms.Button btnScrollLeft;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblSummary;
    }
}

