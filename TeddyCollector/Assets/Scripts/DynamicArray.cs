using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Array
{
    public abstract class DynamicArray<T>
    {
        const int ExpandMultiplyFactor = 2;
        public T[] items;
        public int count;

        protected DynamicArray()
        {
            items = new T[4];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public abstract void Add(T item);
        public abstract bool Remove(T item);

        public abstract int IndexOf(T item);

        public void Clear()
        {
            count = 0;
        }

        public override String ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                builder.Append(items[i]);
                if (i < count - 1)
                {
                    builder.Append(",");
                }
            }
            return builder.ToString();

        }

        public void Print()
        {
            foreach(T item in items)
            {
                Console.WriteLine(item);
            }
        }

        protected void Expand()
        {
            T[] newItems = new T[items.Length * ExpandMultiplyFactor];

            //copy elements from old array into new array
            for(int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }

            items = newItems;

        }


    }
}
