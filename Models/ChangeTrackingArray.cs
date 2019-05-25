using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MMRando.Models
{
    public class ChangeTrackingArray<T>
    {
        private readonly T[] _data;
        private readonly List<Tuple<int, T[]>> _changes = new List<Tuple<int, T[]>>();

        public ChangeTrackingArray(T[] data)
        {
            _data = data;
        }

        public T this[int index]
        {
            get => _data[index];
            set
            {
                _changes.Add(new Tuple<int, T[]>(index, new T[] { value }));
                _data[index] = value;
            }
        }

        public void Write(int index, T[] data)
        {
            _changes.Add(new Tuple<int, T[]>(index, data));
            for (var i = 0; i < data.Length; i++)
            {
                _data[index + i] = data[i];
            }
        }

        public int Length => _data.Length;

        public ReadOnlyCollection<T> ReadonlyData => Array.AsReadOnly(_data);

        public ReadOnlyCollection<Tuple<int, T[]>> Changes => _changes.AsReadOnly();
    }
}
