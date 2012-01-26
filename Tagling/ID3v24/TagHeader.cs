using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagling.ID3v24
{
    public class TagHeader
    {
        private String identifier = "ID3";
        private Byte[] version;
        private Byte flags;
        private int size;

        public int MajorVersion { get { return version[0]; } }
        public int Revision { get { return version[1]; } }
        public TagFlags Flags { get { return new TagFlags(flags); } }
        public int Size { get { return size; } }

        public TagHeader(Byte[] bytes, int offset)
        {
            List<Byte> list = bytes.ToList<Byte>();
            version = list.GetRange(3+offset, 2).ToArray<Byte>();
            if (version[0] != 2 || version[1] != 4)
            {
                throw new Exception("Incorrect Tag Version");
            }
            flags = list.ElementAt(5+offset);
            size = BitConverter.ToInt32(bytes, 6 + offset);
        }

        public TagHeader(Byte[] bytes) : this(bytes, 0)
        {

        }

        public TagHeader(TagFlags f, int tagSize)
        {
            flags = f.GetByte();
            size = tagSize;
            version = new Byte[] { 0x02, 0x04 };
        }

    }
}
