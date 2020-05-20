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

        // Remove item from array
        public override bool Remove(T item)
        {
            // check for given item in array
            int itemLocation = IndexOf(item);
            if (itemLocation == -1)
            {
                return false;
            }
            else
            {
                // shift all the elements above the removed one down and change count
                ShiftDown(itemLocation + 1);
                count--;
                return true;
            }
        }

        public override int IndexOf(T item)
        {
            int lowerBound = 0;
            int upperBound = count - 1;
            int location = -1;

            // second part of Boolean expression added from defect discussed in reading
            // loop until found value or exhausted array
            while ((location == -1) &&
                (lowerBound <= upperBound))
            {
                // find the middle
                int middleLocation = lowerBound + (upperBound - lowerBound) / 2;
                T middleValue = items[middleLocation];

                // check for match
                if (middleValue.CompareTo(item) == 0)
                {
                    location = middleLocation;
                }
                else
                {
                    // split data set to search appropriate side
                    if (middleValue.CompareTo(item) > 0)
                    {
                        upperBound = middleLocation - 1;
                    }
                    else
                    {
                        lowerBound = middleLocation + 1;
                    }

                    // if statement no longer necessary when second part of while loop Boolean expression included
                    // check to see if the array is exhausted
                    //if (lowerBound > upperBound)
                    //{
                    //    break;
                    //}
                }
            }
            return location;
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

