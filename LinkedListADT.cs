using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LinkedLists
{
    public interface LinkedListADT
    {
        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>True if it is empty.</returns>
        bool IsEmpty();

        ///<summary>Clears the list.</summary>
        void Clear();

        /// <summary>
        /// Adds to the end of the list.
        /// </summary>
        /// <param name="data">Data to append.</param>
        void Append(Object data);

        /// <summary>
        /// Prepends (adds to beginning) data to the list.
        /// </summary>
        /// <param name="data">Data to store inside element.</param>
        void Prepend(Object data);

        /// <summary>
        /// Adds a new element at a specific position.
        /// </summary>
        /// <param name="data">Data that element is to contain.</param>
        /// <param name="index">Index to add new element at.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or past the size of the list.</exception>
        void Insert(Object data, int index);

        /// <summary>
        /// Replaces the data at index.
        /// </summary>
        /// <param name="data">Data to replace.</param>
        /// <param name="index">Index of element to replace.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        void Replace(Object data, int index)
        {
            
        }
        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        /// <returns>Size of list (0 meaning empty).</returns>
        int Size();

        /// <summary>
        /// Removes element at index from list, reducing the size.
        /// </summary>
        /// <param name="index">Index of element to remove.</param>
        /// <exception cref="IndexOutOfBoundsException">Thrown if index is negative or past the size - 1.</exception>
        void Delete(int index);

        /// <summary>
        /// Gets the data at the specified index.
        /// </summary>
        /// <param name="index">Index of element to get.</param>
        /// <returns> Data in element or null if it was not found.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of the list.</exception>
        Object Retrieve(int index);

        /// <summary>
        /// Gets the first index of element containing data.
        /// </summary>
        /// <param name="data">Data object to find the first index of.</param>
        /// <returns>First of index of element with matching data or -1 if not found.</returns>
        int IndexOf(Object data);

        /// <summary>
        /// Go through elements and check if we have one with data.
        /// </summary>
        /// <param name="data">Data object to search for.</param>
        /// <returns>True if element exists with value.</returns>
        bool Contains(Object data);
    }
}
