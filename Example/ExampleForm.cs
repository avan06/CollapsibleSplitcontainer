// Demo application for CollapsibleSplitContainer
using System;
using System.Windows.Forms;
using SoftGee;

namespace Example
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();

            // Set button style menuitem check
            if (splitter.SplitterButtonStyle == ButtonStyle.None)
            {
                noneToolStripMenuItem.Checked = true;
                ToggleChecked(noneToolStripMenuItem);
            }
            else if (splitter.SplitterButtonStyle == ButtonStyle.Image)
            {
                imageToolStripMenuItem.Checked = true;
                ToggleChecked(imageToolStripMenuItem);
            }

            // Set button position menuitem check
            if (splitter.SplitterButtonPosition == ButtonPosition.TopLeft)
            {
                topLeftToolStripMenuItem.Checked = true;
                ToggleChecked(topLeftToolStripMenuItem);
            }
            else if (splitter.SplitterButtonPosition == ButtonPosition.Center)
            {
                centerToolStripMenuItem.Checked = true;
                ToggleChecked(centerToolStripMenuItem);
            }
            else if (splitter.SplitterButtonPosition == ButtonPosition.BottomRight)
            {
                bottomRightToolStripMenuItem.Checked = true;
                ToggleChecked(bottomRightToolStripMenuItem);
            }

            // Set collapse distance menuitem check
            if (splitter.SplitterCollapseDistance == CollapseDistance.Collapsed)
            {
                collapsedToolStripMenuItem.Checked = true;
                ToggleChecked(collapsedToolStripMenuItem);
            }
            else if (splitter.SplitterCollapseDistance == CollapseDistance.MinSize)
            {
                minSizeToolStripMenuItem.Checked = true;
                ToggleChecked(minSizeToolStripMenuItem);
            }
        }

        private void exit_Click(object sender, EventArgs e) => Application.Exit();

        private void buttonStyle_Click(object sender, EventArgs e)
        {
            string val = ((ToolStripMenuItem)sender).Text;
            ButtonStyle cd = (ButtonStyle)Enum.Parse(typeof(ButtonStyle), val);
            splitter.SplitterButtonStyle = cd;
            ToggleChecked(sender);
        }

        private void buttonPosition_Click(object sender, EventArgs e)
        {
            string val = ((ToolStripMenuItem)sender).Text;
            ButtonPosition cd = (ButtonPosition)Enum.Parse(typeof(ButtonPosition), val);
            splitter.SplitterButtonPosition = cd;
            ToggleChecked(sender);
        }

        private void collapseDistance_Click(object sender, EventArgs e)
        {
            string val = ((ToolStripMenuItem)sender).Text;
            CollapseDistance cd = (CollapseDistance)Enum.Parse(typeof(CollapseDistance), val);
            splitter.SplitterCollapseDistance = cd;
            ToggleChecked(sender);
        }

        private void orientation_Click(object sender, EventArgs e) => splitter.Orientation = splitter.Orientation == Orientation.Vertical ? Orientation.Horizontal : Orientation.Vertical;

        private void ToggleChecked(object sender)
        {
            if (sender == null) throw new ArgumentNullException("sender");
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem subitem in item.Owner.Items)
            {
                if (subitem != item) subitem.Checked = false;
                else item.Checked = true;
            }
        }
    }
}
