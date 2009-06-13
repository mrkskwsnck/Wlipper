using System.Windows.Forms;

namespace Wlipper
{
    /// <summary>
    /// Provides access to the clipboard's content.
    /// </summary>
    class Clipboarding
    {
        /// <summary>
        /// Writes given text to the clipboard.
        /// </summary>
        public static void SetClipboardTextContent(bool formatted, object[] data)
        {
            IDataObject dataObject = new DataObject();
            dataObject.SetData(DataFormats.UnicodeText, data[0]);
            if (formatted)
            {
                dataObject.SetData(DataFormats.Rtf, data[1]);
                dataObject.SetData(DataFormats.Html, data[2]);
            }
            Clipboard.SetDataObject(dataObject);
        }

        /// <summary>
        /// Reads and returns text from the clipboard.
        /// If data in clipboard is not of unicode text format an empty string will be returned.
        /// </summary>
        public static object[] GetClipboardTextContent()
        {
            // 0 => UnicodeText, 1 => RTF, 2 => HTML
            object[] objectFormats = new object[3];

            IDataObject dataObject = Clipboard.GetDataObject();
            if (dataObject.GetDataPresent(DataFormats.UnicodeText))
            {
                objectFormats[0] = dataObject.GetData(DataFormats.UnicodeText);

                if (dataObject.GetDataPresent(DataFormats.Rtf))
                    objectFormats[1] = dataObject.GetData(DataFormats.Rtf);

                if (dataObject.GetDataPresent(DataFormats.Html))
                    objectFormats[2] = dataObject.GetData(DataFormats.Html);
            }

            return objectFormats;
        }
    }
}
