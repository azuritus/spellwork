using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Windows.Forms;

namespace SpellWork
{
    public static class RichTextBoxExtensions
    {
        private const string DefaultFontFamily = "Arial Unicode MS";
        private const float DefaultFontSize = 9f;

        public static void AppendFormatLine(this TextBoxBase textbox, string format, params object[] args)
        {
            Contract.Requires(format != null);
            Contract.Requires(args != null);

            textbox.AppendText(String.Format(format, args) + Environment.NewLine);
        }

        public static void AppendFormat(this TextBoxBase textbox, string format, params object[] args)
        {
            Contract.Requires(format != null);
            Contract.Requires(args != null);

            textbox.AppendText(String.Format(format, args));
        }

        /// <summary>
        /// Appends new line to current text of a text box.
        /// </summary>
        /// <param name="textbox"></param>
        public static void AppendLine(this TextBoxBase textbox)
        {
            textbox.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Appends the text and new line to current text of a text box.
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="text">The text to append to the current contents of the text box.</param>
        public static void AppendLine(this TextBoxBase textbox, string text)
        {
            textbox.AppendText(text + Environment.NewLine);
        }

        /// <summary>
        /// Appends textual representation of object to current text of a text box.
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="text">The object which textual representation has to be appendended to the current contents of the text box.</param>
        public static void Append(this TextBoxBase textbox, object text)
        {
            textbox.AppendText(text.ToString());
        }

        public static void AppendFormatLineIfNotZero(this TextBoxBase textbox, string format, uint arg)
        {
            Contract.Requires(format != null);

            if (arg != 0)
                textbox.AppendFormatLine(format, arg);
        }

        public static void AppendFormatLineIfNotZero(this TextBoxBase textbox, string format, float arg)
        {
            Contract.Requires(format != null);

            if (arg != 0.0f)
                textbox.AppendFormatLine(format, arg);
        }

        public static void AppendFormatLineIfNotNullOrEmpty(this TextBoxBase textbox, string format, string arg)
        {
            Contract.Requires(format != null);

            if (!string.IsNullOrEmpty(arg))
                textbox.AppendFormatLine(format, arg);
        }

        public static void AppendFormatIfNotZero(this TextBoxBase textbox, string format, uint arg)
        {
            Contract.Requires(format != null);

            if (arg != 0)
                textbox.AppendFormat(format, arg);
        }

        public static void AppendFormatIfNotZero(this TextBoxBase textbox, string format, float arg)
        {
            Contract.Requires(format != null);

            if (arg != 0.0f)
                textbox.AppendFormat(format, arg);
        }

        public static void SetStyle(this RichTextBox textbox, Color color, FontStyle style)
        {
            textbox.SelectionColor = color;
            textbox.SelectionFont = new Font(DefaultFontFamily, DefaultFontSize, style);
        }

        public static void SetBold(this RichTextBox textbox)
        {
            textbox.SelectionFont = new Font(DefaultFontFamily, DefaultFontSize, FontStyle.Bold);
        }

        public static void SetDefaultStyle(this RichTextBox textbox)
        {
            textbox.SelectionFont = new Font(DefaultFontFamily, DefaultFontSize, FontStyle.Regular);
            textbox.SelectionColor = Color.Black;
        }

        /// <summary>
        /// Highligths keywords in a text box.
        /// </summary>
        /// <param name="textbox"></param>
        public static void ColorizeCode(this RichTextBox textbox)
        {
            var keywords = new[] { "INSERT", "INTO", "DELETE", "FROM", "IN", "VALUES", "WHERE" };
            var text = textbox.Text;

            textbox.SelectAll();
            textbox.SelectionColor = textbox.ForeColor;

            foreach (var keyword in keywords)
            {
                var keywordPos = textbox.Find(keyword, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);

                while (keywordPos != -1)
                {
                    var commentPos = text.LastIndexOf("-- ", keywordPos, StringComparison.OrdinalIgnoreCase);
                    var newLinePos = text.LastIndexOf("\n", keywordPos, StringComparison.OrdinalIgnoreCase);

                    var quoteCount = 0;
                    var quotePos = text.IndexOf("\"", newLinePos + 1, keywordPos - newLinePos, StringComparison.OrdinalIgnoreCase);

                    for (; quotePos != -1; quoteCount++)
                        quotePos = text.IndexOf("\"", quotePos + 1, keywordPos - (quotePos + 1), StringComparison.OrdinalIgnoreCase);

                    if (newLinePos >= commentPos && quoteCount % 2 == 0)
                        textbox.SelectionColor = Color.Blue;
                    else if (newLinePos == commentPos)
                        textbox.SelectionColor = Color.Green;

                    keywordPos = textbox.Find(keyword, keywordPos + textbox.SelectionLength, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
                }
            }

            textbox.Select(0, 0);
        }
    }
}
