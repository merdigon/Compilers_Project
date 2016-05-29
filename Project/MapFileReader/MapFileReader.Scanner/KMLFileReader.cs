using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Scanner
{
    public class KMLFileReader
    {
        private int Position { get; set; }
        private string Path { get; set; }
        private string ReadedFile { get; set; }

        public KMLFileReader()
        {
        }

        public void ReadFile(string path)
        {
            this.Path = path;
            using (StreamReader strReader = new StreamReader(Path))
            {
                ReadedFile = strReader.ReadToEnd();
                Position = 0;
            }
        }

        public void ReadString(string mapText)
        {
            ReadedFile = mapText;
            Position = 0;
        }

        public int Read()
        {
            if (Position >= ReadedFile.Length)
            {
                return -1;
            }
            else
            {
                return (int)ReadedFile[Position++];
            }
        }

        public void MovePointer(int numberOfSteps)
        {
            if (Position + numberOfSteps < 0)
                Position = 0;
            else if (Position + numberOfSteps > ReadedFile.Length)
                Position = ReadedFile.Length;
            else
                Position += numberOfSteps;
        }
    }
}
