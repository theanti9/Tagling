using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagling.ID3v24
{
    public class Frame
    {
        private Byte[] bFrameId;
        private int iSize;
        private Byte[] bFlags;
        private String sData;

        public string FrameId { 
            get {
                return (new UTF8Encoding()).GetString(bFrameId);
            }
        }

        public int Length
        {
            get
            {
                return iSize;
            }
        }

        public string Data
        {
            get
            {
                return sData;
            }
        }

        // Create new Frame from existing bytes starting at an offset
        public Frame(Byte[] bytes, int offset)
        {
            List<Byte> byteList = bytes.ToList<Byte>();
            bFrameId = byteList.GetRange(0+offset, 4).ToArray<Byte>();
            
            iSize = BitConverter.ToInt32(bytes, 4+offset);
            bFlags = byteList.GetRange(8+offset, 2).ToArray<Byte>();
            sData = (new UTF8Encoding()).GetString(byteList.GetRange(10+offset,iSize).ToArray<Byte>());
        }
        // Create new Frame from existing bytes with no offset
        public Frame(Byte[] bytes) : this(bytes,0)
        {
            // Called original constructor with 0 offset
        }

        // Create frame from scratch
        public Frame(FrameMeta.FrameIDs id, FrameFlags flags, String data)
        {
            bFrameId = (new UTF8Encoding()).GetBytes(id.ToString());
            bFlags = flags.GetBytes();
            sData = data;
            iSize = data.Length;
        }

        public void SetData(String data)
        {
            sData = data;
            iSize = data.Length;
        }

        public void SetFlags(FrameFlags flags)
        {
            bFlags = flags.GetBytes();
        }

        public Byte[] GetBytes()
        {
            Byte[] output = new Byte[10 + iSize];
            bFrameId.CopyTo(output, 0);
            System.BitConverter.GetBytes(iSize).CopyTo(output, 4);
            bFlags.CopyTo(output, 8);
            (new UTF8Encoding()).GetBytes(sData).CopyTo(output, 10);
            
            return output;
        }
        

    }
}
