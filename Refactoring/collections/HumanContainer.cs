using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Refactoring.entities;

namespace Refactoring.collections
{
    public class HumanContainer<T> : IEnumerable<T> where T : Human
    {
        #region Fields
        private readonly List<T> _container;
        #endregion
        #region Constructors
        public HumanContainer()
        {
            _container = new List<T>();
        }
        #endregion

        #region Properties
        public int Count => _container.Count;

        #endregion
        #region Indexers
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return _container[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                _container[index] = value;
            }
        }
        #endregion
        #region Methods
        public T GetByName(string name)
        {
            return
                _container.FirstOrDefault(
                    h => string.Compare(h.FirstName, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        public void Add(T human)
        {
            _container.Add(human);
        }
        public T Remove(T human)
        {
            var element = _container.FirstOrDefault(h => h == human);
            if (element != null)
            {
                _container.Remove(element);
                return element;
            }
            throw new NullReferenceException();
        }
        public void Sort()
        {
            _container.Sort();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _container.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }
        #endregion
    }
}

