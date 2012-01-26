using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagling.ID3v24
{
    public class FrameFlags
    {
        private Byte[] bytes;

        public bool TagAlterPreservation = false;
        public bool FileAlterPreservation = false;
        public bool ReadOnly = false;
        public bool GroupIdentifier = false;
        public bool Compression = false;
        public bool Encryption = false;
        public bool Unsynchronisation = false;
        public bool DataLengthIndicator = false;

        public FrameFlags()
        {
            // For creating flags
        }

        public FrameFlags(Byte[] b) {
            int check = 0x00;

            // byte 0 Format:  %0abc0000

            // Check Tag Alter Preservation (a)
            check = b[0] & 0x40;
            if (check == 64)
            {
                TagAlterPreservation = true;
            }

            // Check File Alter Preservation (b)
            check = b[0] & 0x20;
            if (check == 32)
            {
                FileAlterPreservation = true;
            }

            // Check Read Only (c)
            check = b[0] & 0x10;
            if (check == 16)
            {
                ReadOnly = true;
            }

            // Byte 1 Format: %0h00kmnp

            // Check Group Identifier (h)
            check = b[1] & 0x40;
            if (check == 64)
            {
                GroupIdentifier = true;
            }

            // Check Compression (k)
            check = b[1] & 0x08;
            if (check == 8)
            {
                Compression = true;
            }

            // Check encryption (m)
            check = b[1] & 0x04;
            if (check == 4)
            {
                Encryption = true;
            }

            // Check Unsynchronisation (n)
            check = b[1] & 0x02;
            if (check == 2)
            {
                Unsynchronisation = true;
            }

            // Check Data Length Indicator (p)
            check = b[1] & 0x01;
            if (check == 1)
            {
                DataLengthIndicator = true;
            }
        }

        public Byte[] GetBytes()
        {
            Byte b0 = 0x00;
            Byte b1 = 0x00;

            if (TagAlterPreservation)
            {
                b0 |= 0x40;
            }

            if (FileAlterPreservation)
            {
                b0 |= 0x20;
            }

            if (ReadOnly)
            {
                b0 |= 0x10;
            }

            if (GroupIdentifier)
            {
                b1 |= 0x40;
            }

            if (Compression)
            {
                b1 |= 0x08;
            }

            if (Encryption)
            {
                b1 |= 0x04;
            }

            if (Unsynchronisation)
            {
                b1 |= 0x02;
            }

            if (DataLengthIndicator)
            {
                b1 |= 0x01;
            }
            return new Byte[] { b0, b1 };
        }
    }
}
