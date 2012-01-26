using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagling.ID3v24
{
    public class TagFlags
    {
        public bool Unsynchronisation = false;
        public bool ExtendedHeader = false;
        public bool ExperimentalIndicator = false;
        public bool FooterPresent = false;

        public TagFlags(Byte[] b, int index)
        {
            int check;

            check = b[index] & 0x80;
            if (check == 128)
            {
                Unsynchronisation = true;
            }

            check = b[index] & 0x40;
            if (check == 64)
            {
                ExtendedHeader = true;
            }

            check = b[index] & 0x20;
            if (check == 32)
            {
                ExperimentalIndicator = true;
            }

            check = b[index] & 0x10;
            if (check == 16)
            {
                FooterPresent = true;
            }
        }

        public TagFlags(Byte b) : this(new Byte[] { b }, 0)
        {
            
        }

        public Byte GetByte()
        {
            Byte b = 0x00;
            if (Unsynchronisation)
            {
                b |= 0x80;
            }
            if (ExtendedHeader)
            {
                b |= 0x40;
            }
            if (ExperimentalIndicator)
            {
                b |= 0x20;
            }
            if (FooterPresent)
            {
                b |= 0x10;
            }
            return b;
        }

    }
}
