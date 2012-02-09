using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SpellWork
{
    static class DbcReader
    {
        public static IDictionary<uint, T> ReadDbc<T>(IDictionary<uint, string> strDict) where T : struct
        {
            var dict = new Dictionary<uint, T>();
            var fileName = Path.Combine(Dbc.DbcPath, typeof(T).Name + ".dbc").Replace("Entry", String.Empty);

            Stream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                using (var reader = new BinaryReader(fileStream, Encoding.UTF8))
                {
                    fileStream = null;

                    if (!File.Exists(fileName))
                        throw new FileNotFoundException("One of DBC files not found.", fileName);

                    // read dbc header
                    var header = reader.ReadStruct<DbcHeader>();
                    var size = Marshal.SizeOf(typeof(T));

                    if (!header.IsDbc)
                        throw new IOException(fileName + " is not DBC file!");

                    if (header.RecordSize != size)
                        throw new IOException(string.Format("Size of row in DBC file ({0}) != size of DBC struct ({1}) in DBC: {2}", header.RecordSize, size, fileName));

                    // read dbc data
                    for (var record = 0; record < header.RecordsCount; ++record)
                    {
                        var key = reader.ReadUInt32();
                        reader.BaseStream.Position -= 4;

                        var entry = reader.ReadStruct<T>();

                        dict.Add(key, entry);
                    }

                    // read dbc strings
                    if (strDict != null)
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            var offset = (uint)(reader.BaseStream.Position - header.StartStringPosition);
                            var str = reader.ReadCString();
                            strDict.Add(offset, str);
                        }
                    }
                }
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Dispose();
            }
            return dict;
        }
    }
}
