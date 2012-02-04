using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SpellWork
{
    public static class Extensions
    {
        /// <summary>
        /// Reads the NULL-terminated string from the current stream.
        /// </summary>
        /// <param name="reader">Stream to read from.</param>
        /// <returns>Resulting string.</returns>
        public static string ReadCString(this BinaryReader reader)
        {
            byte num;
            var temp = new List<byte>();

            while ((num = reader.ReadByte()) != 0)
            {
                temp.Add(num);
            }

            return Encoding.UTF8.GetString(temp.ToArray());
        }

        /// <summary>
        /// Reads the struct from the current stream.
        /// </summary>
        /// <typeparam name="T">Struct type.</typeparam>
        /// <param name="reader">Stream to read from.</param>
        /// <returns>Resulting struct.</returns>
        public static T ReadStruct<T>(this BinaryReader reader) where T : struct
        {
            var rawData = reader.ReadBytes(Marshal.SizeOf(typeof(T)));

            var handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            var returnObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));

            handle.Free();

            return returnObject;
        }

        public static StringBuilder AppendFormatIfNotNull(this StringBuilder builder, string format, params object[] args)
        {
            Contract.Requires(format != null);
            //FIXME
            if (args[0].ToUInt32() != 0)
                return builder.AppendFormat(format, args);

            return builder;
        }

        // Append Format Line
        public static StringBuilder AppendFormatLine(this StringBuilder builder, string format, params object[] args)
        {
            Contract.Requires(format != null);

            return builder.AppendFormat(format, args).AppendLine();
        }

        public static StringBuilder AppendFormatLineIfNotZero(this StringBuilder builder, string format, int arg)
        {
            Contract.Requires(format != null);

            if (arg != 0)
                return builder.AppendFormat(format, arg).AppendLine();

            return builder;
        }

        public static StringBuilder AppendFormatLineIfNotZero(this StringBuilder builder, string format, uint arg)
        {
            Contract.Requires(format != null);

            if (arg != 0)
                return builder.AppendFormat(format, arg).AppendLine();

            return builder;
        }

        public static uint ToUInt32(this object val)
        {
            if (val == null)
                return 0;

            uint num;
            uint.TryParse(val.ToString(), out num);
            return num;
        }

        public static int ToInt32(this object val)
        {
            if (val == null)
                return 0;

            int num;
            int.TryParse(val.ToString(), out num);
            return num;
        }

        public static float ToFloat(this object val)
        {
            if (val == null)
                return 0.0f;

            float num;
            float.TryParse(val.ToString().Replace(',', '.'), out num);
            return num;
        }

        public static ulong ToUlong(this object val)
        {
            if (val == null)
                return 0U;

            ulong num;
            ulong.TryParse(val.ToString(), out num);
            return num;
        }

        public static String NormalizeString(this string text, string remove)
        {
            if (!string.IsNullOrEmpty(remove))
                text = text.Replace(remove, string.Empty);

            var str = string.Empty;
            foreach (var s in text.Split('_'))
            {
                str += char.ToUpper(s[0], CultureInfo.CurrentCulture) + s.Substring(1).ToLower(CultureInfo.CurrentCulture);
                str += " ";
            }

            return str.Remove(str.Length - 1);
        }

        public static void SetCheckedItemFromFlag(this CheckedListBox name, uint value)
        {
            for (var i = 0; i < name.Items.Count; ++i)
            {
                name.SetItemChecked(i, ((value / (1U << (i - 1))) % 2) != 0);
            }
        }

        public static uint GetFlagsValue(this CheckedListBox name)
        {
            uint val = 0;
            for (var i = 0; i < name.CheckedIndices.Count; i++)
            {
                val += 1U << (name.CheckedIndices[i] - 1);
            }

            return val;
        }

        public static void SetFlags<T>(this CheckedListBox clb)
        {
            clb.Items.Clear();

            foreach (var elem in Enum.GetValues(typeof(T)))
            {
                clb.Items.Add(elem.ToString().NormalizeString(string.Empty));
            }
        }

        public static void SetFlags<T>(this CheckedListBox clb, string remove)
        {
            clb.Items.Clear();

            foreach (var elem in Enum.GetValues(typeof(T)))
            {
                clb.Items.Add(elem.ToString().NormalizeString(remove));
            }
        }

        public static void SetFlags(this CheckedListBox clb, Type type, string remove)
        {
            clb.Items.Clear();

            foreach (var elem in Enum.GetValues(type))
            {
                clb.Items.Add(elem.ToString().NormalizeString(remove));
            }
        }

        public static void SetEnumValues<T>(this ComboBox cb, string noValue)
        {
            var dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");

            dt.Rows.Add(new object[] { -1, noValue });
            foreach (var en in Enum.GetValues(typeof(T)))
                dt.Rows.Add(en, string.Format("({0:X}) {1}", en, en));

            cb.DataSource = dt;
            cb.DisplayMember = "NAME";
            cb.ValueMember = "ID";
        }

        public static void SetEnumValuesDirect<T>(this ComboBox cb, bool setFirstValue)
        {
            cb.BeginUpdate();

            cb.Items.Clear();
            foreach (Enum value in Enum.GetValues(typeof(T)))
                cb.Items.Add(value.GetFullName());

            if (setFirstValue && cb.Items.Count > 0)
                cb.SelectedIndex = 0;

            cb.EndUpdate();
        }

        public static void SetStructFields<T>(this ComboBox cb)
        {
            cb.Items.Clear();

            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(MemberInfo));
            dt.Columns.Add("NAME", typeof(string));

            var members = typeof(T).GetMembers();
            var i = 0;
            foreach (var member in members)
            {
                if (member is FieldInfo || member is PropertyInfo)
                {
                    var dr = dt.NewRow();
                    dr["ID"] = member;
                    dr["NAME"] = string.Format("({0:000}) {1}", i, member.Name);
                    dt.Rows.Add(dr);
                    i++;
                }
            }

            cb.DataSource = dt;
            cb.DisplayMember = "NAME";
            cb.ValueMember = "ID";
        }

        /// <summary>
        /// Compares the text on the partial occurrence of a string and ignore case
        /// </summary>
        /// <param name="text">The original text, which will search entry</param>
        /// <param name="compareText">String which will be matched with the original text</param>
        /// <returns>Boolean(true or false)</returns>
        public static bool ContainsText(this string text, string compareText)
        {
            Contract.Requires(compareText != null);

            return text.IndexOf(compareText, StringComparison.CurrentCultureIgnoreCase) != -1;
        }

        /// <summary>
        /// Compares the text on the partial occurrence of a string and ignore case
        /// </summary>
        /// <param name="text">The original text, which will search entry</param>
        /// <param name="compareText">Array strings which will be matched with the original text</param>
        /// <returns>Boolean(true or false)</returns>
        public static bool ContainsText(this string text, string[] compareText)
        {
            Contract.Requires(compareText != null);

            return compareText.Any(str => text.IndexOf(str, StringComparison.CurrentCultureIgnoreCase) != -1);
        }

        public static bool HasAnyFlagOnSameIndex(this uint[] array, uint[] value)
        {
            Contract.Requires(value != null);

            return array.Length == value.Length && array.Where((t, i) => (t & value[i]) != 0).Any();
        }

        public static string GetFullName(this Enum _enum)
        {
            var field = _enum.GetType().GetField(_enum.ToString());
            if (field != null)
            {
                var attrs = (FullNameAttribute[])field.GetCustomAttributes(typeof(FullNameAttribute), false);

                if (attrs.Length > 0)
                    return attrs[0].FullName;
            }

            return _enum.ToString();
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class FullNameAttribute : Attribute
    {
        public string FullName { get; private set; }

        public FullNameAttribute(string fullName)
        {
            this.FullName = fullName;
        }
    }
}
