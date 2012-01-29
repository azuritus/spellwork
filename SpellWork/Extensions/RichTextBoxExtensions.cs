﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpellWork
{
    public static class RichTextBoxExtensions
    {
        private const string DEFAULT_FAMILY = "Arial Unicode MS";
        private const float DEFAULT_SIZE = 9f;

        public static void AppendFormatLine(this TextBoxBase textbox, string format, params object[] args)
        {
            textbox.AppendText(String.Format(format, args) + Environment.NewLine);
        }

        public static void AppendFormat(this TextBoxBase textbox, string format, params object[] args)
        {
            textbox.AppendText(String.Format(format, args));
        }

        public static void AppendLine(this TextBoxBase textbox)
        {
            textbox.AppendText(Environment.NewLine);
        }

        public static void AppendLine(this TextBoxBase textbox, string text)
        {
            textbox.AppendText(text + Environment.NewLine);
        }

        public static void Append(this TextBoxBase textbox, object text)
        {
            textbox.AppendText(text.ToString());
        }

        public static void AppendFormatLineIfNotZero(this TextBoxBase builder, string format, uint arg)
        {
            if (arg != 0)
                builder.AppendFormatLine(format, arg);
        }

        public static void AppendFormatLineIfNotZero(this TextBoxBase builder, string format, float arg)
        {
            if (arg != 0.0f)
                builder.AppendFormatLine(format, arg);
        }

        public static void AppendFormatLineIfNotNullOrEmpty(this TextBoxBase builder, string format, string arg)
        {
            if (!string.IsNullOrEmpty(arg))
                builder.AppendFormatLine(format, arg);
        }

        public static void AppendFormatIfNotZero(this TextBoxBase builder, string format, uint arg)
        {
            if (arg != 0)
                builder.AppendFormat(format, arg);
        }

        public static void AppendFormatIfNotZero(this TextBoxBase builder, string format, float arg)
        {
            if (arg != 0.0f)
                builder.AppendFormat(format, arg);
        }

        public static void SetStyle(this RichTextBox textbox, Color color, FontStyle style)
        {
            textbox.SelectionColor = color;
            textbox.SelectionFont = new Font(DEFAULT_FAMILY, DEFAULT_SIZE, style);
        }

        public static void SetBold(this RichTextBox textbox)
        {
            textbox.SelectionFont = new Font(DEFAULT_FAMILY, DEFAULT_SIZE, FontStyle.Bold);
        }

        public static void SetDefaultStyle(this RichTextBox textbox)
        {
            textbox.SelectionFont = new Font(DEFAULT_FAMILY, DEFAULT_SIZE, FontStyle.Regular);
            textbox.SelectionColor = Color.Black;
        }

        public static void ColorizeCode(this RichTextBox rtb)
        {
            var keywords = new[] { "INSERT", "INTO", "DELETE", "FROM", "IN", "VALUES", "WHERE" };
            var text = rtb.Text;

            rtb.SelectAll();
            rtb.SelectionColor = rtb.ForeColor;

            foreach (var keyword in keywords)
            {
                var keywordPos = rtb.Find(keyword, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);

                while (keywordPos != -1)
                {
                    var commentPos = text.LastIndexOf("-- ", keywordPos, StringComparison.OrdinalIgnoreCase);
                    var newLinePos = text.LastIndexOf("\n", keywordPos, StringComparison.OrdinalIgnoreCase);

                    var quoteCount = 0;
                    var quotePos = text.IndexOf("\"", newLinePos + 1, keywordPos - newLinePos, StringComparison.OrdinalIgnoreCase);

                    for (; quotePos != -1; quoteCount++)
                        quotePos = text.IndexOf("\"", quotePos + 1, keywordPos - (quotePos + 1), StringComparison.OrdinalIgnoreCase);

                    if (newLinePos >= commentPos && quoteCount % 2 == 0)
                        rtb.SelectionColor = Color.Blue;
                    else if (newLinePos == commentPos)
                        rtb.SelectionColor = Color.Green;

                    keywordPos = rtb.Find(keyword, keywordPos + rtb.SelectionLength, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
                }
            }

            rtb.Select(0, 0);
        }
    }
}
