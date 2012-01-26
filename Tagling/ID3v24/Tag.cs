using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagling.ID3v24
{
    public class Tag
    {
        public TagHeader Header { get; }

        private Byte[] tagBytes;


        public Tag(Byte[] bytes, int offset)
        {
            List<Byte> byteList = bytes.ToList<Byte>();
            TagHeader header = new TagHeader(byteList.GetRange(offset, 10).ToArray<Byte>());
            tagBytes = byteList.GetRange(offset + 10, header.Size).ToArray<Byte>();

            int i = 0;
            FrameCollection collection = new FrameCollection();

            while (i < tagBytes.Length)
            {
                Frame f = new Frame(tagBytes, i);
                i += f.Length;

                collection.AddFrame(f);
            }
        }
    }
}
