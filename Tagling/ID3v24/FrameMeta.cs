using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagling.ID3v24
{
    public class FrameMeta
    {
        public enum FrameIDs {
            AudioEncryption = "AENC",
            AttachedPicture = "APIC",
            AudioSeekPointIndex = "ASPI",

            Comments = "COMM",
            CommercialFrame = "COMR",
            
            EncryptionMethodRegistration = "ENCR",
            Equalization2 = "EQU2",
            EventTimeCodes = "ETCO",

            LinkedInfo = "LINK",

            MusicCDIdentifier = "MCDI",
            MPEGLocationLookupTable = "MLLT",

            Ownership = "OWNE",

            Privacy = "PRIV",
            PlayCounter = "PCNT",
            Popularimeter = "POPM",
            PositionSync = "POSS",

            RecommendedBufferSize = "RBUF",
            RelativeVolumeAdjustment = "RVA2",
            Reverb = "RVRB",

            Seek = "SEEK",
            Signature = "SIGN",
            SynchronisedLyrics = "SYLT",
            SynchronisedTempoCodes = "SYTC",

            Album = "TALB",
            BPM = "TBPM",
            Composer = "TCOM",
            ContentType = "TCON",
            Copyright = "TCOP",
            EncodingTime = "TDEN",
            PlaylistDelay = "TDLY",
            OriginalReleaseTime = "TDOR",
            RecordingTime = "TDRC",
            ReleaseTime = "TDRL",
            TaggingTime = "TDTG",
            EncodedBy = "TENC",
            Lyricist = "TEXT",
            FileType = "TFLT",
            InvolvedPeopleList = "TIPL",
            ContentGroupDescription = "TIT1",
            Title = "TIT2",
            Subtitle = "TIT3",
            InitialKey = "TKEY",
            Languages = "TLAN",
            Length = "TLEN",
            MusicianCreditList = "TMCL",
            MediaType = "TMED",
            Mood = "TMOO",
            OriginalAlbum = "TOAL",
            OriginalFileName = "TOFN",
            OriginalLyricist = "TOLY",
            OriginalArtist = "TOPE",
            FileOwner = "TOWN",
            LeadPerformer = "TPE1",
            Band = "TPE2",
            Conductor = "TPE3",
            RemixedBy = "TPE4",
            PartOfSet = "TPOS",
            ProducedNotice = "TPRO",
            Publisher = "TPUB",
            TrackNumber = "TRCK",
            RadioStationName = "TRSN",
            RadioStationOwner = "TRSO",
            AlbumSortOrtder = "TSOA",
            PerformerSortOrder = "TSOP",
            TitleSortOrder = "TSOT",
            ISRC = "TSRC",
            SettingsUsedForEncoding = "TSSE",
            SetSubtitle = "TSST",
            UserDefinedText = "TXXX",

            UniqueFileIdentifier = "UFID",
            TermsOfUse = "USER",
            UnsynchronisedLyrics = "USLT",

            CommercialInformation = "WCOM",
            CopyrightInfo = "WCOP",
            FileWebpage = "WOAF",
            ArtistWebpage = "WOAR",
            SourceWebpage = "WOAS",
            RadioStationHomepage = "WORS",
            Payment = "WPAY",
            PublisherWebpage = "WPUB",
            UserDefinedURL = "WXXX"

        };



    }
}
