using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src
{
    public class Store<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item) => items.Add(item);

        public List<T> GetAll() => items;

        public T? GetById(int id) => items.Find(i => i.Id == id);

        public void Remove(T item) => items.Remove(item);
    }
}
