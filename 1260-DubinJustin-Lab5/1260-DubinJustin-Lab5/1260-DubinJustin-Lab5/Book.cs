//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		    1260-DubinJustin-Lab5
//	File Name:		Book.cs
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
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Default constructor: Initializes a new instance 
        /// 	of the Book class using default values
        /// </summary>
        public Book()
        {
            this.Title = "no title";
            this.Author = "no author";
            this.Price = 0.0;
        }

        /// <summary>
        /// Parameterized constructor: Initializes a new instance 
        /// 	of the Book class using values specified in the parameters
        /// </summary>
        /// <param name="title">Book title</param>
        /// <param name="author">Book author</param>
        /// <param name="price">Book price</param>
        public Book(string title, string author, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        /// <summary>
        /// Copy constructor: Initializes a new instance 
        /// 	of the Book class using a book object specified in the parameters
        /// </summary>
        /// <param name="b">An existing book object</param>
        public Book(Book b)
        {
            this.Title = b.Title;
            this.Author = b.Author;
            this.Price = b.Price;
        }

        /// <summary>
        /// Format the book information for possible display
        /// </summary>
        /// <returns>formatted string containing book information</returns>
        override
        public string ToString()
        {
            string str = $"Title: {Title}\n";
            str += $"Author: {Author}, ";
            str += $"Price: ${Price:#,###.#0}\n";
            return str;
        }// end ToString
    }
}
