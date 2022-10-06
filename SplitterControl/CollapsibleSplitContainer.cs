// Collapsible Split Container
// (c) 2014 Ed Gadziemski, v. 1.0.0.2
// Last updated 9/18/2014
// Licensed under Code Project Open License
// forked from https://www.codeproject.com/Articles/820888/Collapsible-Split-Container
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SoftGee
{
    public enum ButtonStyle { None, Image };
    public enum ButtonPosition { TopLeft, Center, BottomRight };
    public enum CollapseDistance { MinSize, Collapsed };

    public class CollapsibleSplitContainer : SplitContainer, ISupportInitialize
    {
        #region Variables
        private bool panel1Minimized         = false;
        private bool panel2Minimized         = false;
        private int splitterDistanceOriginal = 0;

        // Left-oriented bitmap from which the other three directional bitmaps are derived
        private Bitmap splitterButtonBitmap = null, bitmapRight = null, bitmapUp = null, bitmapDown = null;

        // Property fields
        private ButtonStyle      splitterButtonStyle        = ButtonStyle.Image;
        private ButtonPosition   splitterButtonPosition     = ButtonPosition.TopLeft;
        private CollapseDistance splitterCollapseDistance   = CollapseDistance.MinSize;

        private Button splitterButton1;
        private Button splitterButton2;
        private readonly string TableFillLeft = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQBAMAAADt3eJSAAAACXBIWXMAAA7EAAAOxAGVKw4bAAAAKlBMVEX////w7/H29vZCQkLh5ewscKw7erEOXKF4ocalvtYAU5zD0uFKg7YdZqaTf92qAAAAAXRSTlMAQObYZgAAAFFJREFUeF5FjbsNwCAMRC1vgMQEbECSBSgoMgESXZosQZUuozFB5iHisP2qp/PnSOEAiPfJRhzdD+Rc4kuC5IbkqN99Qfr7yMiW7dweaoWVCgN1DhODhN6CWAAAAABJRU5ErkJggg==";
        #endregion

        public CollapsibleSplitContainer()
        {
            // Bug fix for SplitContainer problems with flickering and resizing
            ControlStyles cs = ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer;
            SetStyle(cs, true);
            object[] objArgs = new object[] { cs, true };
            MethodInfo objMethodInfo = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
            objMethodInfo.Invoke(Panel1, objArgs);
            objMethodInfo.Invoke(Panel2, objArgs);
            splitterButton1 = new Button();
            splitterButton2 = new Button();
            splitterButton1.Size = new Size(16, 16);
            splitterButton2.Size = new Size(16, 16);
            splitterButton1.Margin = new Padding(0);
            splitterButton2.Margin = new Padding(0);
            splitterButton1.BackgroundImageLayout = ImageLayout.Zoom;
            splitterButton2.BackgroundImageLayout = ImageLayout.Zoom;
            splitterButton1.BackColor = Color.Transparent;
            splitterButton2.BackColor = Color.Transparent;
            splitterButton1.FlatStyle = FlatStyle.Flat;
            splitterButton2.FlatStyle = FlatStyle.Flat;
            splitterButton1.FlatAppearance.BorderSize = 0;
            splitterButton2.FlatAppearance.BorderSize = 0;
            splitterButton1.Click += SplitterButton1_Click;
            splitterButton2.Click += SplitterButton2_Click;
            splitterButton1.BringToFront();
            splitterButton2.BringToFront();
            Panel1.Controls.Add(splitterButton1);
            Panel2.Controls.Add(splitterButton2);
        }

        #region Properties
        [Category("Collapsible"), Description("The bitmap used on the splitter pushbuttons")]
        [DefaultValue(null)]
        public Bitmap SplitterButtonBitmap
        {
            get => splitterButtonBitmap;
            set
            {
                if (splitterButtonBitmap == value) return;

                splitterButtonBitmap = value;

                if (splitterButtonBitmap == null) splitterButtonBitmap = Base64ToBitmap(TableFillLeft);

                splitterButtonBitmap.MakeTransparent();
                // Create the bitmaps for the remaining directions
                bitmapRight = (Bitmap)splitterButtonBitmap.Clone();
                bitmapRight.RotateFlip(RotateFlipType.RotateNoneFlipX);
                bitmapUp = (Bitmap)splitterButtonBitmap.Clone();
                bitmapUp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                bitmapDown = (Bitmap)splitterButtonBitmap.Clone();
                bitmapDown.RotateFlip(RotateFlipType.Rotate270FlipNone);

                Refresh();
                UpdateSplitterButtonsImage();
            }
        }

        [Category("Collapsible"), Description("Where the collapse buttons are located on the splitter")]
        [DefaultValue(ButtonPosition.TopLeft)]
        public ButtonPosition SplitterButtonPosition
        {
            get => splitterButtonPosition;
            set
            {
                if (splitterButtonPosition == value) return;
                splitterButtonPosition = value;
                Refresh();
                UpdateSplitterButtonsPosition();
            }
        }

        [Category("Collapsible"), Description("The technique used to generate the splitter buttons")]
        [DefaultValue(ButtonStyle.Image)]
        public ButtonStyle SplitterButtonStyle
        {
            get => splitterButtonStyle;
            set
            {
                if (splitterButtonStyle == value) return;
                splitterButtonStyle = value;
                if (splitterButtonStyle == ButtonStyle.None)
                {
                    splitterButton1.Hide();
                    splitterButton2.Hide();
                }
                else
                {
                    splitterButton1.Show();
                    splitterButton2.Show();
                }
                Refresh();
            }
        }

        [Category("Collapsible"), Description("How completely the affected panel collapses")]
        [DefaultValue(CollapseDistance.MinSize)]
        public CollapseDistance SplitterCollapseDistance
        {
            get => splitterCollapseDistance;
            set
            {
                if (splitterCollapseDistance == value) return;
                if (value == CollapseDistance.MinSize)
                {
                    if (Panel1Collapsed)
                    {
                        panel1Minimized = true;
                        SplitterDistance = Panel1MinSize;
                    }
                    else if (Panel2Collapsed)
                    {
                        panel2Minimized = true;

                        // Calculate the splitter position
                        int distance = -1 * (Panel2MinSize + SplitterWidth);
                        distance += Orientation == Orientation.Vertical ? Panel1.Width : Panel1.Height;

                        SplitterDistance = distance;
                    }

                    Panel1Collapsed = false;
                    Panel2Collapsed = false;
                }
                else if (value == CollapseDistance.Collapsed)
                {
                    if (panel1Minimized) Panel1Collapsed = true;
                    else if (panel2Minimized) Panel2Collapsed = true;

                    panel1Minimized = false;
                    panel2Minimized = false;
                }

                splitterCollapseDistance = value;
                Refresh();
                UpdateSplitterButtonsPosition();
            }
        }

        // Forces designer to refresh and reflect changes to the property
        public new bool IsSplitterFixed
        {
            get => base.IsSplitterFixed;
            set
            {
                if (base.IsSplitterFixed == value) return;
                base.IsSplitterFixed = value;
                Refresh();
            }
        }

        [Category("CatBehavior"), Description("SplitContainerOrientationDescr")]
        [DefaultValue(Orientation.Vertical)]
        [Localizable(true)]
        public new Orientation Orientation
        {
            get => base.Orientation;
            set
            {
                if (base.Orientation == value) return;

                base.Orientation = value;
                Refresh();
                UpdateSplitterButtonsPosition();
                UpdateSplitterButtonsImage();
            }
        }
        #endregion

        #region General Event Handlers
        private void SplitterButton1_Click(object sender, EventArgs e)
        {
            if (splitterButtonStyle == ButtonStyle.None) return;

            if (splitterCollapseDistance == CollapseDistance.Collapsed)
            {
                // Hide the panel associated with the clicked button
                if (Panel1Collapsed && !Panel2Collapsed) Panel2Collapsed = !Panel2Collapsed;
                else if (!Panel1Collapsed && Panel2Collapsed) Panel1Collapsed = !Panel1Collapsed;
                else Panel1Collapsed = true;
            }
            else if (splitterCollapseDistance == CollapseDistance.MinSize)
            {
                // If the panel for the clicked button is already minimized, do nothing
                // Otherwise, have the panel shrink to or return from the minimum size
                if (panel1Minimized) return;
                else if (panel2Minimized) // Panel 2
                {
                    SplitterDistance = splitterDistanceOriginal;
                    panel2Minimized = false;
                }
                else // Panel 1
                {
                    splitterDistanceOriginal = SplitterDistance;
                    SplitterDistance = Panel1MinSize;
                    panel1Minimized = true;
                }
            }
            Refresh();
        }

        private void SplitterButton2_Click(object sender, EventArgs e)
        {
            if (splitterButtonStyle == ButtonStyle.None) return;

            if (splitterCollapseDistance == CollapseDistance.Collapsed)
            {
                // Hide the panel associated with the clicked button
                if (!Panel1Collapsed && Panel2Collapsed) Panel1Collapsed = !Panel1Collapsed;
                else if(Panel1Collapsed && !Panel2Collapsed) Panel2Collapsed = !Panel2Collapsed;
                else Panel2Collapsed = true;
            }
            else if (splitterCollapseDistance == CollapseDistance.MinSize)
            {
                // If the panel for the clicked button is already minimized, do nothing
                // Otherwise, have the panel shrink to or return from the minimum size
                if (panel2Minimized) return;
                else if (panel1Minimized) // Panel 1
                {
                    SplitterDistance = splitterDistanceOriginal;
                    panel1Minimized = false;
                }
                else // Panel 2
                {
                    splitterDistanceOriginal = SplitterDistance;

                    // When the splitter is vertical, set the location of the splitter to
                    // the splitcontainer control width minus the minimum size of panel 2.
                    // For horizontal, set it to height minus panel 2 minimum size
                    if (Orientation == Orientation.Vertical) SplitterDistance = Width - Panel2MinSize;
                    else SplitterDistance = Height - Panel2MinSize;

                    panel2Minimized = true;
                }
            }
            Refresh();
        }

        /// <summary>
        /// Paint splitter and, if enabled, the buttons
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (IsSplitterFixed || splitterButtonStyle == ButtonStyle.None) return;

            UpdateSplitterButtonsPosition();
            UpdateSplitterButtonsImage();
        }
        #endregion

        #region Update Splitter Buttons
        /// <summary>
        /// Update the splitter buttons based on system capability
        /// </summary>
        private void UpdateSplitterButtonsPosition()
        {
            if (splitterButtonStyle == ButtonStyle.None) return;

            int position = GetButtonPosition();
            if (Orientation == Orientation.Vertical)
            {
                int width = splitterCollapseDistance == CollapseDistance.Collapsed ? 0 : Panel1Collapsed ? Panel2.ClientRectangle.Right - splitterButton2.Width : Panel1.ClientRectangle.Right - splitterButton1.Width;
                splitterButton1.Location = new Point(width, position);
                splitterButton2.Location = new Point(0, position);
            }
            else
            {
                int height = splitterCollapseDistance == CollapseDistance.Collapsed ? 0 : Panel1Collapsed ? Panel2.ClientRectangle.Bottom - splitterButton2.Height : Panel1.ClientRectangle.Bottom - splitterButton1.Height;
                splitterButton1.Location = new Point(position, height);
                splitterButton2.Location = new Point(position, 0);
            }
        }

        /// <summary>
        /// Render the splitter buttons based on system capability and button style
        /// </summary>
        private void UpdateSplitterButtonsImage()
        {
            if (splitterButtonStyle == ButtonStyle.None) return;

            splitterButton1.BackgroundImage = Orientation == Orientation.Vertical ? splitterButtonBitmap : bitmapUp;
            splitterButton2.BackgroundImage = Orientation == Orientation.Vertical ? bitmapRight : bitmapDown;
        }
        #endregion

        #region Miscellaneous Helpers
        /// <summary>
        /// Get the button position based on splitterButtonPosition
        /// </summary>
        private int GetButtonPosition()
        {
            int position;

            Rectangle rect = Panel1Collapsed ? Panel2.ClientRectangle : Panel1.ClientRectangle;

            if (Orientation == Orientation.Vertical)
            {
                position = rect.Top;
                if (splitterButtonPosition == ButtonPosition.Center) position = rect.Bottom / 2 - splitterButton1.Height / 2;
                else if (splitterButtonPosition == ButtonPosition.BottomRight) position = rect.Bottom - splitterButton1.Height;
            }
            else
            {
                position = rect.Left;
                if (splitterButtonPosition == ButtonPosition.Center) position = rect.Right / 2 - splitterButton1.Width / 2;
                else if (splitterButtonPosition == ButtonPosition.BottomRight) position = rect.Right - splitterButton1.Width;
            }
            return position;
        }

        /// <summary>
        /// Decoding/Converting Base64 strings to Bitmap images
        /// https://softwarebydefault.com/2013/03/01/base64-strings-bitmap/
        /// </summary>
        public Bitmap Base64ToBitmap(string base64)
        {
            Bitmap bitmap = null;
            byte[] byteBuffer = Convert.FromBase64String(base64);
            using (MemoryStream memoryStream = new MemoryStream(byteBuffer))
            {
                memoryStream.Position = 0;
                bitmap = new Bitmap(Image.FromStream(memoryStream));
                byteBuffer = null;
            }

            return bitmap;
        }
        #endregion
    }
}