using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src
{
    public class Store<T>  where T : IHasId
    {
        private Dictionary<int, T> items = new Dictionary<int, T>();

        public void Add(T item) 
        {
           if (items.ContainsKey(item.Id))
            {
                throw new ArgumentException($"An item with Id {item.Id} already exists.");
            }
            items.Add(item.Id, item);
            
        
        }

        public IReadOnlyList<T> GetAll() => items.Values.ToList();

        public T? GetById(int id) => items.GetValueOrDefault(id);

        public void Remove(T item) => items.Remove(item.Id);
    }
}
