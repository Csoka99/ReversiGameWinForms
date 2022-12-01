namespace ReversiGame.View
{
    partial class ReversiWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.twentyStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.thirtyStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.blackPointLabel = new System.Windows.Forms.Label();
            this.whitePointLabel = new System.Windows.Forms.Label();
            this.blackTime = new System.Windows.Forms.Label();
            this.whiteTime = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.newGameToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(641, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.onSaveMenuItemClicked);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.onLoadGameMenuItemClicked);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.onPauseMenuItemClicked);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.onExitMenuItemClicked);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tenStripMenu,
            this.twentyStripMenu,
            this.thirtyStripMenu});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // tenStripMenu
            // 
            this.tenStripMenu.Name = "tenStripMenu";
            this.tenStripMenu.Size = new System.Drawing.Size(162, 34);
            this.tenStripMenu.Text = "10x10";
            // 
            // twentyStripMenu
            // 
            this.twentyStripMenu.Name = "twentyStripMenu";
            this.twentyStripMenu.Size = new System.Drawing.Size(162, 34);
            this.twentyStripMenu.Text = "20x20";
            // 
            // thirtyStripMenu
            // 
            this.thirtyStripMenu.Name = "thirtyStripMenu";
            this.thirtyStripMenu.Size = new System.Drawing.Size(162, 34);
            this.thirtyStripMenu.Text = "30x30";
            // 
            // buttonTableLayout
            // 
            this.buttonTableLayout.ColumnCount = 2;
            this.buttonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayout.Location = new System.Drawing.Point(12, 128);
            this.buttonTableLayout.Name = "buttonTableLayout";
            this.buttonTableLayout.RowCount = 2;
            this.buttonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayout.Size = new System.Drawing.Size(617, 617);
            this.buttonTableLayout.TabIndex = 1;
            // 
            // blackPointLabel
            // 
            this.blackPointLabel.AutoSize = true;
            this.blackPointLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.blackPointLabel.Location = new System.Drawing.Point(12, 44);
            this.blackPointLabel.Name = "blackPointLabel";
            this.blackPointLabel.Size = new System.Drawing.Size(135, 38);
            this.blackPointLabel.TabIndex = 2;
            this.blackPointLabel.Text = "Black : 2 ";
            // 
            // whitePointLabel
            // 
            this.whitePointLabel.AutoSize = true;
            this.whitePointLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.whitePointLabel.Location = new System.Drawing.Point(493, 44);
            this.whitePointLabel.Name = "whitePointLabel";
            this.whitePointLabel.Size = new System.Drawing.Size(136, 38);
            this.whitePointLabel.TabIndex = 3;
            this.whitePointLabel.Text = "White : 2";
            // 
            // blackTime
            // 
            this.blackTime.AutoSize = true;
            this.blackTime.Location = new System.Drawing.Point(12, 91);
            this.blackTime.Name = "blackTime";
            this.blackTime.Size = new System.Drawing.Size(145, 25);
            this.blackTime.TabIndex = 4;
            this.blackTime.Text = "Black time: 00:00";
            // 
            // whiteTime
            // 
            this.whiteTime.AutoSize = true;
            this.whiteTime.Location = new System.Drawing.Point(475, 91);
            this.whiteTime.Name = "whiteTime";
            this.whiteTime.Size = new System.Drawing.Size(154, 25);
            this.whiteTime.TabIndex = 5;
            this.whiteTime.Text = "White Time: 00:00";
            // 
            // ReversiWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 757);
            this.Controls.Add(this.whiteTime);
            this.Controls.Add(this.blackTime);
            this.Controls.Add(this.whitePointLabel);
            this.Controls.Add(this.blackPointLabel);
            this.Controls.Add(this.buttonTableLayout);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "ReversiWindow";
            this.Text = "Reversi";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem tenStripMenu;
        private ToolStripMenuItem twentyStripMenu;
        private ToolStripMenuItem thirtyStripMenu;
        private ToolStripMenuItem pauseToolStripMenuItem;
        private TableLayoutPanel buttonTableLayout;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label blackPointLabel;
        private Label whitePointLabel;
        private Label blackTime;
        private Label whiteTime;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}