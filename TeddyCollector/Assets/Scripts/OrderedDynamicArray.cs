using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Array;


namespace OrderedArray
{
    public class OrderedDynamicArray<T> : DynamicArray<T> where T: IComparable
    {

        public OrderedDynamicArray() : base()
        {

        }


        public override void Add(T item)
        {
            //Check to see if we need to expand the array
            if(count == items.Length)
            {
                Expand();
            }

            //find location at which to add the item
            int addLocation = 0;


            while ((addLocation < count) &&
                (items[addLocation].CompareTo(item) < 0))
            {
                 addLocation++;   
            }

            //shift array, add new item and increment count
            ShiftUp(addLocation);
            items[addLocation] = item;
            count++;

        }

        public override bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public override int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        /// Shifts all the array elements from the given index to the end of the array up one space
        private void ShiftUp(int index)
        {
            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        /// Shifts all the array elements from the given index to the end of the array down one space
        private void ShiftDown(int index)
        {
            for (int i = index; i < count; i++)
            {
                items[i - 1] = items[i];
            }
        }

    }

}

