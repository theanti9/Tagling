using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagling.ID3v24
{
    public class FrameCollection : IEnumerable<Frame>
    {
        #region Private Variables

        private List<Frame> frames;
        private int iSize;

        #endregion

        #region Public Variables

        public int Size { get { return iSize; } }

        #endregion

        #region Constructors

        public FrameCollection()
        {
            frames = new List<Frame>();
        }

        public FrameCollection(List<Frame> f)
        {
            if (f == null)
            {
                frames = f;
            }
            else
            {
                frames = new List<Frame>();
            }
        }

        public FrameCollection(Frame[] f)
        {
            frames = f.ToList<Frame>();
        }
        #endregion

        #region Adding Frames

        public void AddFrame(Frame f) {
            frames.Add(f);
            iSize += 10 + f.Length;
        }

        public void AddFrames(IEnumerable<Frame> f)
        {
            frames.AddRange(f);
            iSize += CalculateSize(f);
        }


        #endregion

        #region Remove Frames

        #region Single Frame
        public void RemoveFrame(int index)
        {
            iSize -= frames.ElementAt(index).Length + 10;
            frames.RemoveAt(index);
        }

        public void RemoveFrame(Frame f)
        {
            iSize -= f.Length + 10;
            frames.Remove(f);
        }
        #endregion

        #region Multiple Frames
        public void RemoveFrames(int index, int count)
        {
            iSize -= CalculateSize(frames.GetRange(index, count));
            frames.RemoveRange(index, count);
        }

        public void RemoveAll()
        {
            iSize = 0;
            frames.Clear();
        }
        #endregion


        #endregion

        #region Getting Enumerators

        public FrameEnumerator GetEnumerator()
        {
            return new FrameEnumerator(this);
        }

        public IEnumerator<Frame> IEnumerator<Frame>.GetEnumerator()
        {
            return (IEnumerator<Frame>)new FrameEnumerator(this);
        }

        #endregion

        #region Enumerator

        public class FrameEnumerator : IEnumerator<Frame>
        {
            private int position = -1;
            private FrameCollection f;

            public FrameEnumerator(FrameCollection fc)
            {
                this.f = fc;
            }

            public bool MoveNext()
            {
                if (position < f.frames.Count - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }

            public Frame Current
            {
                get
                {
                    return f.frames.ElementAt(position);
                }
            }

            object IEnumerator<Frame>.Current
            {
                get
                {
                    return f.frames.ElementAt(position);
                }
            }
        }
        #endregion

        #region Size Calculation

        public int CalculateSize(IEnumerable<Frame> framelist)
        {
            // Start with size of all the 10 byte headers
            int size = frames.Count * 10;
            foreach (Frame f in framelist)
            {
                size += f.Length;
            }

            return size;
        }

        

        #endregion

        #region Serializer

        Byte[] Serialize()
        {
            Byte[] output = new Byte[iSize];
            // output position offset
            int offset = 0;

            foreach (Frame f in frames) {
                // Get the frames bytes and copy them to the output array
                // using the accumulating offset
                Byte[] tmp = f.GetBytes();
                tmp.CopyTo(output, offset);
                // Move offset up the length of what we just added
                offset += tmp.Length;
            }

            return output;
        }

        #endregion
    }
}
