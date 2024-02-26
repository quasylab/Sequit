using System;
using System.IO;

namespace Utils
{
    public class CsvFileReader : IFileReader
    {

        private readonly StreamReader _reader;
        
        /// <summary>
        /// Creates a new reader with the given file
        /// </summary>
        /// <param name="file">The file path, or the entire contents on WebGL</param>
        /// 
        /// <exception cref="ArgumentException">If the given path or file is empty</exception>
        public CsvFileReader(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new ArgumentException("File or path is empty or null");

            _reader = new StreamReader(file);
            
            if (!HasNext())
                throw new ArgumentException("File is empty");
        }

        ~CsvFileReader()
        {
            _reader.Close();
        }


        public string[] ReadLine()
        {
            return _reader.ReadLine()!.Split(',');
        }

        public bool HasNext()
        {
            return !_reader.EndOfStream;
        }
    }
}