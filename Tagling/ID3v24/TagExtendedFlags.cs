using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagling.ID3v24
{
    public class TagExtendedFlags
    {
        public bool Update;
        public bool CRCData;
        public TagRestrictions Restrictions;

        public class TagRestrictions
        {
            public TagSizeRestriction TagSizeRestrictions = 0x00;
            public TextEncodingRestriction TextEncodingRestrictions = 0x00;
            public FieldSizeRestriction FieldSizeRestrictions = 0x00;
            public ImageEncodingRestriction ImageEncodingRestrictions = 0x00;
            public ImageSizeRestriction ImageSizeRestrictions = 0x00;

            public enum TagSizeRestriction
            {
                NoMoreThan128FramesAnd1MBTag = 0x00,
                NoMoreThan64FramesAnd128kBTag = 0x01,
                NoMoreThan32FramesAnd40kBTag = 0x02,
                NoMoreThan32Framesand4kBTag = 0x03
            }

            public enum TextEncodingRestriction
            {
                None = 0x0,
                UTF_8 = 0x1
            }

            public enum FieldSizeRestriction
            {
                None = 0x00,
                MaxLength1024Chars = 0x01,
                MaxLength128Chars = 0x02,
                MaxLength30Chars = 0x03
            }

            public enum ImageEncodingRestriction
            {
                None = 0x0,
                PNGorJPEG = 0x1
            }

            public enum ImageSizeRestriction
            {
                None = 0x00,
                AllLessThan256x256px = 0x01,
                AllLessThan64x64px = 0x02,
                AllExactly64x64px = 0x03
            }

            public Byte GetByte()
            {
                Byte b = 0x00;
                b |= (byte)TagSizeRestrictions;
                b = (byte)((b << 1) | (byte)TextEncodingRestrictions);
                b = (byte)((b << 2) | (byte)FieldSizeRestrictions);
                b = (byte)((b << 1) | (byte)ImageEncodingRestrictions);
                b = (byte)((b << 2) | (byte)ImageSizeRestrictions);
                return b;
            }

        }

    }
}
