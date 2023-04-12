//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		    1260-DubinJustin-Lab5
//	File Name:		Library.cs
//	Description:	Implement Library as an array of Book objects
//	Course:			CSCI 1260-001 - Intro to Computer Sci II
//	Author:			Don Bailes, bailes@etsu.edu, Department of Computing, East Tennessee State University
//	Created:		    Thursday, January 09, 2020
//  Modified:      6/23/22 by Erin Cook, cookel@etsu.edu convert from Java to C#
//	Copyright:		Don Bailes, 2020
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/// <summary>
/// Implement Library as an array of Book objects
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork03_student
{
    internal class Library
    {
        public List<Book> Books { get; set; }
        public bool HasChange { get; set; }

        /// <summary>
        /// Default constructor: Initializes a new instance 
        /// 	of the Book class using default values
        /// </summary>
        public Library()
        {
            this.Books = new List<Book>();
        }

        /// <summary>
        /// Return the number of Books in books collection
        /// </summary>
        /// <returns>return the number of Books in books</returns>
        public int GetNumBooks()
        {
            return Books.Count;
        }

        /// <summary>
        /// If n is valid, return nth Book in the library;
        ///     else throw exception
        /// </summary>
        /// <param name="n">the position of the book to be returned</param>
        /// <returns>the selected book</returns>
        /// <exception cref="Exception"></exception>
        public Book GetBook(int n)
        {
            if (n >= 0 && n < GetNumBooks())
                return Books[n];
            else
                throw new Exception($"There is no book number {n}" +
                    $" in the library.");
        }
        /// <summary>
        /// Add a book to the library if it is not already
        ///     present; throw excetion if it is already
        /// </summary>
        /// <param name="b">Book to Add</param>
        /// <exception cref="Exception"></exception>
        public void AddBook(Book b)
        {
            if (Books.Contains(b))
                throw new Exception($"Book {b.Title} is already in" +
                    $" the library");
            else
            {
                Books.Add(b);
                HasChange = true;
            }
        }

        /// <summary>
        /// Reset HasChange property to false
        /// </summary>
        public void ResetChangeFlag()
        {
            HasChange = false;
        }

        /// <summary>
        /// Delete the selected book from the library
        /// </summary>
        /// <param name="index">position of Book to be deleted</param>
        /// <exception cref="Exception"></exception>
        public void Delete(int index)
        {
            if ((index >= 0) && (index < GetNumBooks()))
            {
                Books.RemoveAt(index);
                HasChange = true;
            }
            else
            {
                throw new Exception($"The index {index} is " +
                    $"invalid in the Library's Delete method.");
            }
        }

        /// <summary>
        /// Format the books in the library for display
        /// </summary>
        /// <returns>the formatted string</returns>
        override
        public string ToString()
        {
            string str = "";
            for (int n = 0; n < GetNumBooks(); n++)
            {
                str += $"Book {n + 1}.\n{Books[n]}\n";
            }
            return str;
        }
    }
}