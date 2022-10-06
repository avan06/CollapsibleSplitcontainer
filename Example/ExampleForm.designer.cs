namespace Example
{
	partial class ExampleForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExampleForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pushButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.scrollBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.positionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.topLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bottomRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.distanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.collapsedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.minSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.focusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.orientationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitter = new SoftGee.CollapsibleSplitContainer();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
			this.splitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.styleToolStripMenuItem,
            this.positionToolStripMenuItem,
            this.distanceToolStripMenuItem,
            this.focusToolStripMenuItem,
            this.orientationToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(384, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadImageToolStripMenuItem
			// 
			this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
			this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.loadImageToolStripMenuItem.Text = "Load Button Image...";
			this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImage_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
			// 
			// styleToolStripMenuItem
			// 
			this.styleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.pushButtonToolStripMenuItem,
            this.scrollBarToolStripMenuItem});
			this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
			this.styleToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.styleToolStripMenuItem.Text = "Style";
			// 
			// noneToolStripMenuItem
			// 
			this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
			this.noneToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.noneToolStripMenuItem.Text = "None";
			this.noneToolStripMenuItem.Click += new System.EventHandler(this.buttonStyle_Click);
			// 
			// imageToolStripMenuItem
			// 
			this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
			this.imageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.imageToolStripMenuItem.Text = "Image";
			this.imageToolStripMenuItem.Click += new System.EventHandler(this.buttonStyle_Click);
			// 
			// pushButtonToolStripMenuItem
			// 
			this.pushButtonToolStripMenuItem.Name = "pushButtonToolStripMenuItem";
			this.pushButtonToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.pushButtonToolStripMenuItem.Text = "PushButton";
			this.pushButtonToolStripMenuItem.Click += new System.EventHandler(this.buttonStyle_Click);
			// 
			// scrollBarToolStripMenuItem
			// 
			this.scrollBarToolStripMenuItem.Name = "scrollBarToolStripMenuItem";
			this.scrollBarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.scrollBarToolStripMenuItem.Text = "ScrollBar";
			this.scrollBarToolStripMenuItem.Click += new System.EventHandler(this.buttonStyle_Click);
			// 
			// positionToolStripMenuItem
			// 
			this.positionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topLeftToolStripMenuItem,
            this.centerToolStripMenuItem,
            this.bottomRightToolStripMenuItem});
			this.positionToolStripMenuItem.Name = "positionToolStripMenuItem";
			this.positionToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
			this.positionToolStripMenuItem.Text = "Position";
			// 
			// topLeftToolStripMenuItem
			// 
			this.topLeftToolStripMenuItem.Name = "topLeftToolStripMenuItem";
			this.topLeftToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.topLeftToolStripMenuItem.Text = "TopLeft";
			this.topLeftToolStripMenuItem.Click += new System.EventHandler(this.buttonPosition_Click);
			// 
			// centerToolStripMenuItem
			// 
			this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
			this.centerToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.centerToolStripMenuItem.Text = "Center";
			this.centerToolStripMenuItem.Click += new System.EventHandler(this.buttonPosition_Click);
			// 
			// bottomRightToolStripMenuItem
			// 
			this.bottomRightToolStripMenuItem.Name = "bottomRightToolStripMenuItem";
			this.bottomRightToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.bottomRightToolStripMenuItem.Text = "BottomRight";
			this.bottomRightToolStripMenuItem.Click += new System.EventHandler(this.buttonPosition_Click);
			// 
			// distanceToolStripMenuItem
			// 
			this.distanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapsedToolStripMenuItem,
            this.minSizeToolStripMenuItem});
			this.distanceToolStripMenuItem.Name = "distanceToolStripMenuItem";
			this.distanceToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.distanceToolStripMenuItem.Text = "Distance";
			// 
			// collapsedToolStripMenuItem
			// 
			this.collapsedToolStripMenuItem.Name = "collapsedToolStripMenuItem";
			this.collapsedToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.collapsedToolStripMenuItem.Text = "Collapsed";
			this.collapsedToolStripMenuItem.Click += new System.EventHandler(this.collapseDistance_Click);
			// 
			// minSizeToolStripMenuItem
			// 
			this.minSizeToolStripMenuItem.Name = "minSizeToolStripMenuItem";
			this.minSizeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.minSizeToolStripMenuItem.Text = "MinSize";
			this.minSizeToolStripMenuItem.Click += new System.EventHandler(this.collapseDistance_Click);
			// 
			// focusToolStripMenuItem
			// 
			this.focusToolStripMenuItem.Name = "focusToolStripMenuItem";
			this.focusToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.focusToolStripMenuItem.Text = "Focus";
			this.focusToolStripMenuItem.Click += new System.EventHandler(this.focus_Click);
			// 
			// orientationToolStripMenuItem
			// 
			this.orientationToolStripMenuItem.Name = "orientationToolStripMenuItem";
			this.orientationToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.orientationToolStripMenuItem.Text = "Orientation";
			this.orientationToolStripMenuItem.Click += new System.EventHandler(this.orientation_Click);
			// 
			// splitter
			// 
			this.splitter.Cursor = System.Windows.Forms.Cursors.Default;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitter.Location = new System.Drawing.Point(0, 24);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(384, 237);
			this.splitter.SplitterButtonBitmap = ((System.Drawing.Bitmap)(resources.GetObject("splitter.SplitterButtonBitmap")));
			this.splitter.SplitterButtonStyle = SoftGee.ButtonStyle.PushButton;
			this.splitter.SplitterDistance = 128;
			this.splitter.SplitterWidth = 22;
			this.splitter.TabIndex = 2;
			// 
			// ExampleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 261);
			this.Controls.Add(this.splitter);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ExampleForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Collapsible Splitter Example";
			this.Load += new System.EventHandler(this.ExampleForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
			this.splitter.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pushButtonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scrollBarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem positionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem topLeftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bottomRightToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem distanceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem collapsedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem minSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem focusToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem orientationToolStripMenuItem;
		private SoftGee.CollapsibleSplitContainer splitter;
	}
}