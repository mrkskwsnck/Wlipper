using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Wlipper
{
    public partial class WlipperForm : Form
    {
        #region Fields

        private FileInfo readme;
        private FileInfo tmpDoc;
        private ToolStripMenuItem toolStripMenuItemEmpty;
        private uint historyLength;
        private uint entryLength;
        private uint tooltipLength;
        private bool formatted;
        private uint histories;
        Wlipper.Properties.Settings preferences;
        public bool insertingHistory;

        #endregion

        #region Properties

        private FileInfo ReadMe
        {
            get
            {
                return readme;
            }
            set
            {
                readme = value;
            }
        }

        private FileInfo TmpDoc
        {
            get
            {
                return tmpDoc;
            }
            set
            {
                tmpDoc = value;
            }
        }

        private ToolStripMenuItem ToolStripMenuItemEmpty
        {
            get
            {
                return toolStripMenuItemEmpty;
            }
            set
            {
                toolStripMenuItemEmpty = value;
            }
        }

        private uint HistoryLength
        {
            get
            {
                return historyLength;
            }
            set
            {
                historyLength = value;
            }
        }

        private uint EntryLength
        {
            get
            {
                return entryLength;
            }
            set
            {
                entryLength = value;
            }
        }

        private uint TooltipLength
        {
            get
            {
                return tooltipLength;
            }
            set
            {
                tooltipLength = value;
            }
        }

        private Wlipper.Properties.Settings Preferences
        {
            get
            {
                return preferences;
            }

            set
            {
                preferences = value;
            }
        }

        public bool Formatted
        {
            get
            {
                return formatted;

            }
            set
            {
                formatted = value;
            }
        }

        public uint Histories
        {
            get
            {
                return histories;

            }
            set
            {
                histories = value;
            }
        }

        public bool InsertingHistory
        {
            get
            {
                return insertingHistory;
            }
            set
            {
                insertingHistory = value;
            }
        }

        #endregion

        #region Constructors

        public WlipperForm()
        {
            InitializeComponent();
            InitializeView();
            InitializeDocument();
            LoadPreferences();
            RegisterWindowToChain();
        }

        #endregion

        #region Initialization methods

        private void InitializeView()
        {
            // Placeholder representing an empty list of clipboard elements
            ToolStripMenuItemEmpty = new ToolStripMenuItem(Localization.EMPTY);
            ToolStripMenuItemEmpty.Enabled = false;
            contextMenuStrip.Items.Insert(2, ToolStripMenuItemEmpty);
            //

            // Set the standard button
            buttonOk.Focus();
            AcceptButton = buttonOk;
            CancelButton = buttonCancel;
            //
        }

        private void InitializeDocument()
        {
            Preferences = new Wlipper.Properties.Settings();
        }

        #endregion

        #region Event callback methods

        private void WlipperForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                LoadPreferences();
                ToggleWindow();
            }
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            while (contextMenuStrip.Items.IndexOf(toolStripSeparator2) != 2)
            {
                contextMenuStrip.Items.RemoveAt(2);
            }
            contextMenuStrip.Items.Insert(2, ToolStripMenuItemEmpty);
        }

        private void ClipboardMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            Clipboarding.SetClipboardTextContent(Formatted, (object[])toolStripMenuItem.Tag);
            contextMenuStrip.Items.Remove(toolStripMenuItem);
        }

        private void toolStripMenuItemPreferences_Click(object sender, EventArgs e)
        {
            if (Visible == false)
                ToggleWindow();
        }

        /// <summary>
        /// Retrieve documentation file from assembly resource for opening.
        /// </summary>
        private void toolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            try
            {
                if (TmpDoc == null)
                {
                    // Vollen Ressourcenpfad zusammenstellen
                    string resourcePath = string.Concat(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, string.Concat(SpecialCharacters.DOT, Naming.README));
                    // Die Ressource per Stream auslesen
                    Stream resourceStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);

                    // Create temporary documentation file
                    FileInfo tmpPath = new FileInfo(Path.GetTempFileName());
                    StreamReader resourceFile = new StreamReader(resourceStream, Encoding.UTF8, true);
                    StreamWriter tmpFile = new StreamWriter(tmpPath.FullName, false, Encoding.UTF8);

                    // Write resource to file
                    tmpFile.Write(resourceFile.ReadToEnd());
                    tmpFile.Close();
                    resourceFile.Close();
                    resourceStream.Close();

                    // Rename temporary file for opening 
                    tmpPath.MoveTo(string.Concat(tmpPath.FullName, Naming.HTML_ENDING));

                    // For deleting temporary file(s) later
                    TmpDoc = tmpPath;
                }

                // Open documentation file
                Process.Start(TmpDoc.FullName);
            }
            catch
            {
                MessageBox.Show(this, Localization.NOREADME, Localization.FAILURE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            DeleteTmpDoc();
            Dispose();
            Application.Exit();
        }

        private void numericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SavePreferences();
            RearrangeList();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LoadPreferences();
            ToggleWindow();
        }

        /// <summary>
        /// For testing purpose re-registering the application to the clipboard chain for listening on changes.
        /// </summary>
        void ReregisterToolStripMenuItemClick(object sender, EventArgs e)
        {
            UnregisterWindowFromChain();
            RegisterWindowToChain();
        }

        #endregion

        #region Other methods

        /// <summary>
        /// For processing the clipboard after the appropriate event occurred.
        /// </summary>
        private void MakeItSo()
        {
            // Processing new clipboard's text content
            object[] objectFormats = Clipboarding.GetClipboardTextContent();
            string unformatted = objectFormats[0] as string;

            if (unformatted != null)
            {
                // Set a new clipboard object without formatting information
                // But only if the event notification happens twice
                if (!Formatted)
                {
                    InsertingHistory = true;
                    Clipboarding.SetClipboardTextContent(Formatted, objectFormats);
                }
                else
                    InsertingHistory = true;

                if (InsertingHistory)
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(PrepareTextForToolStripMenuItem(unformatted), null, ClipboardMenuItem_Click);
                    toolStripMenuItem.Tag = objectFormats;
                    toolStripMenuItem.ToolTipText = PrepareTextForToolTipText(unformatted);
                    contextMenuStrip.Items.Insert(2, toolStripMenuItem);
                }

                // Delete the ToolStripMenuItem representing an empty list
                contextMenuStrip.Items.Remove(ToolStripMenuItemEmpty);

                // Cut history
                CuttingHistory();
            }

            // No special exception handling needed

            // Disallow insertion to history
            InsertingHistory = false;
        }

        /// <summary>
        /// Cuts the amount of history entries if needed.
        /// </summary>
        private void CuttingHistory()
        {
            int historyOffset = contextMenuStrip.Items.IndexOf(toolStripSeparator3);
            int historyEndHard = (int)HistoryLength + historyOffset;
            int historyEndSoft = contextMenuStrip.Items.IndexOf(toolStripSeparator2) - historyOffset;

            if (historyEndSoft > historyEndHard)
            {
                do
                {
                    contextMenuStrip.Items.RemoveAt(historyEndSoft);
                    historyEndSoft = contextMenuStrip.Items.IndexOf(toolStripSeparator2) - historyOffset;
                }
                while (historyEndSoft > historyEndHard);
            }
        }

        /// <summary>
        /// Removes all newlines and cuts from both sides to length given via preferences.
        /// </summary>
        private string PrepareTextForToolStripMenuItem(string text)
        {
            // Removing newlines
            string[] newlines = new string[3];
            newlines[0] = "\r\n";
            newlines[1] = "\r";
            newlines[2] = "\n";
            string replacement = SpecialCharacters.WHITESPACE;
            foreach (string newline in newlines)
            {
                text = text.Replace(newline, replacement);
            }

            // Evaluate special characters
            string[] specialCharacters = new string[1];
            specialCharacters[0] = SpecialCharacters.AMPERSAND;
            foreach (string character in specialCharacters)
            {
                text = text.Replace(character, string.Concat(character, character));
            }

            // Splitting or not
            if (EntryLength == 1)
            {
                text = string.Concat(text.Substring(0, (int)EntryLength), Naming.ETC);
            }
            else if (text.Length > EntryLength)
            {
                uint rightLength = EntryLength / 2;
                uint leftLength = EntryLength - rightLength;

                string left = text.Substring(0, (int)leftLength);
                string right = text.Substring(text.Length - (int)rightLength, text.Length - (text.Length - (int)rightLength));

                text = string.Concat(left, Naming.ETC);
                text = string.Concat(text, right);
            }

            return text;
        }

        /// <summary>
        /// Cuts to length given via preferences.
        /// </summary>
        private string PrepareTextForToolTipText(string text)
        {
            if (text.Length < TooltipLength)
            {
                return text;
            }
            else
            {
                return string.Concat(text.Substring(0, (int)TooltipLength), Naming.ETC);
            }
        }

        /// <summary>
        /// Toggles the visibility of the Form.
        /// </summary>
        private void ToggleWindow()
        {
            // Toggle window
            // Using the ShowInTaskbar property there is a problem with the chained form
            // The ShowInTaskbar property will be set implicitly
            if (Visible)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        /// <summary>
        /// Delete the temporary documentation file(s) on program exit.
        /// </summary>
        private void DeleteTmpDoc()
        {
            try
            {
                TmpDoc.Delete();
            }
            catch
            {
                // Temporary file can't be deleted because of still being used by another process
            }
        }

        private void LoadPreferences()
        {
            HistoryLength = Preferences.HistoryLength;
            EntryLength = Preferences.EntryLength;
            TooltipLength = Preferences.TooltipLength;
            Formatted = Preferences.Formatted;

            numericUpDownHistory.Value = HistoryLength;
            numericUpDownEntry.Value = EntryLength;
            numericUpDownTooltip.Value = TooltipLength;
            checkBoxFormatted.Checked = Formatted;
        }

        private void SavePreferences()
        {
            HistoryLength = (uint)numericUpDownHistory.Value;
            EntryLength = (uint)numericUpDownEntry.Value;
            TooltipLength = (uint)numericUpDownTooltip.Value;
            Formatted = checkBoxFormatted.Checked;

            Preferences.HistoryLength = HistoryLength;
            Preferences.EntryLength = EntryLength;
            Preferences.TooltipLength = TooltipLength;
            Preferences.Formatted = Formatted;

            try
            {
                Preferences.Save();
            }
            catch
            {
                MessageBox.Show(this, Localization.NOSAVE, Localization.FAILURE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ToggleWindow();
        }

        /// <summary>
        /// Rearrange list of captured clipboard entries
        /// </summary>
        private void RearrangeList()
        {
            // If history is cleared do nothing, otherwise some exceptions will occur
            if (GetHistories() == 0)
                return;

            CuttingHistory();

            int listStart = contextMenuStrip.Items.IndexOf(toolStripSeparator3) + 1;
            int listEnd = contextMenuStrip.Items.IndexOf(toolStripSeparator2) - 1;
            for (int i = listStart; i <= listEnd; i++)
            {
                ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)contextMenuStrip.Items[i];
                toolStripMenuItem.Text = PrepareTextForToolStripMenuItem(((object[])toolStripMenuItem.Tag)[0] as string);
                toolStripMenuItem.ToolTipText = PrepareTextForToolTipText(((object[])toolStripMenuItem.Tag)[0] as string);
            }
        }

        /// <summary>
        /// Returns the number of history items.
        /// </summary>
        /// <returns>The number of history items.</returns>
        public uint GetHistories()
        {
            // This is an approximation due to the relative positions of the context menu arrangement only!
            int toolStripSeparatorPosition2 = contextMenuStrip.Items.IndexOf(toolStripSeparator2);
            int toolStripSeparatorPosition3 = contextMenuStrip.Items.IndexOf(toolStripSeparator3);
            int difference = toolStripSeparatorPosition2 - toolStripSeparatorPosition3;
            difference--;
            if (1 == difference && contextMenuStrip.Items[2].Equals(ToolStripMenuItemEmpty))
                Histories = 0;
            else
                Histories = (uint)difference;
            return Histories;
        }

        #endregion
    }
}
