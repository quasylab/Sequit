using System;
using System.Collections.Generic;

namespace Utils
{
    public class FileStepsController<T> : IStepsController<T> where T : Step
    {
        private readonly IFileReader _reader;
        private readonly LinkedList<T> _entries;

        private readonly Func<string[], T> _creator;

        private LinkedListNode<T> _currNode;

        public float DeltaTime { get; private set; }


       
        public FileStepsController(string path, Func<string[], T> creator) 
            : this(new CsvFileReader(path), creator) { }

        private FileStepsController(IFileReader reader, Func<string[], T> creator)
        {
            _reader = reader;
            _entries = new LinkedList<T>();

            _creator = creator;
            
            _entries.AddLast(_creator(_reader.ReadLine()));
        }


        public T GetNext()
        {
            if (!_reader.HasNext())
                return null;
            
            if (_entries.Last == _currNode)
                _entries.AddLast(_creator(_reader.ReadLine()));

            _currNode = _currNode?.Next ?? _entries.First;
            if (_currNode != _entries.First)
                DeltaTime = _currNode.Value.Time - _currNode.Previous!.Value.Time;
            return _currNode.Value;
        }

        public T GetPrev()
        {
            if (_currNode?.Previous == null)
                return null;
            
            DeltaTime = _currNode.Value.Time - _currNode.Previous.Value.Time;
            _currNode = _currNode.Previous;
            return _currNode!.Value;
        }
    }
}