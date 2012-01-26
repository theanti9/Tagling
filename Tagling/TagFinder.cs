using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tagling.ID3v24;
namespace Tagling
{
    public class TagFinder
    {
        public static Tag[] FindAllTags(String path)
        {
            List<Tag> taglist = new List<Tag>();
            FileStream stream = File.OpenRead(path);
            Char[] id3 = new Char[] { 'I', 'D', '3' };
            Byte[] searchbuff = new Byte[1];
            int read;
            int offset = 0;
            int pos = -1;
            int found = 0;
            bool done = false;
            bool end = false;
            if (stream.CanRead) {
                while (!end)
                {
                    while (!done)
                    {
                        read = stream.Read(searchbuff, offset, 1);
                        if (read == 0)
                        {
                            end = true;
                            break;
                        }
                        if (searchbuff[0] == BitConverter.GetBytes(id3[found])[0])
                        {
                            found++;
                            if (found == 1)
                            {
                                pos = offset;
                            }
                            else if (found == 3)
                            {
                                done = true;
                                break;
                            }
                        }
                        offset++;
                    }
                    if (pos > -1 && done)
                    {
                        Byte[] headerBytes = new Byte[10];
                        stream.Read(headerBytes, offset, 10);
                        TagHeader th = new TagHeader(headerBytes);
                        Byte[] tagBytes = new Byte[th.Size];
                        stream.Read(tagBytes, 0, th.Size);
                        Tag t = new Tag(tagBytes, 0);
                        taglist.Add(t);
                    }
                    else
                    {
                        continue;
                    }
                    if (end)
                    {
                        break;
                    }
                }
                return taglist.ToArray<Tag>();
            } else {
                throw new IOException("Could not read stream");
            }
        }

    }
}
