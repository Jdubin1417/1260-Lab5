//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		    1260-DubinJustin-Lab5
//	File Name:		LibraryDriver.cs
//	Description:	Implement Library as an array of Book objects
//	Course:			CSCI 1260-001 - Intro to Computer Sci II
//	Author:			Don Bailes, bailes@etsu.edu, Department of Computing, East Tennessee State University
//	Created:		    Thursday, January 09, 2020
//  Modified:     31 Oct 22 by Justin Dubin, dubinj@etsu.edu added File Save Functions
//	Copyright:		Don Bailes, 2020
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Classwork03_student;
using System;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Implement Library as an array of Book objects
/// </summary>
public class LibraryDriver
{
    private static Library lib = new Library();
    private static string fileName;                 // Save filename for later use


    /// <summary>
    /// Main method - fill library from input file; add books;
    ///     save library
    /// </summary>
    public static void Main(string[] args)
    {
        Console.WriteLine("     Welcome to the Library Manager\n" +
            "---------------------------------------\n\tby Erin L Cook");
        InputFile();
        DisplayLibrary();
        AddBooks();             //AddBooks has SaveFile method called inside of it

        Console.WriteLine("\nThank you for using the Library Manager.");
    }

    /// <summary>
    /// Save the file back to its original position
    /// </summary>
    static void SaveFile()
    {
        StreamWriter writer = null;
        Console.Write("Please enter a file path: ");
        string fileName = Console.ReadLine();
        try
        {
            writer = new StreamWriter(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)); //Open new writer
            for (int i = 0; i < lib.GetNumBooks(); i++)
            {
                writer.WriteLine(lib.Books[i].Title + "," + lib.Books[i].Author + "," + lib.Books[i].Price.ToString()); //Write all library obejcts to text file
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not access file. Failed to write data to the file.");
        }
        finally
        {
            if (writer != null)
                writer.Close();             //Finally Statement closes writer to ensure file is saved
        }
    }

    /// <summary>
    /// Allow the user to try to add any number of books to the library; this
    ///     will result in an exception if one tries to add a book beyond the 
    ///     library size
    /// </summary>
    static void AddBooks()
    {
        int booksAdded = 0;
        // code for adding books to library goes here - including any exception handlinng
        Console.Write("Would you like to add one or more books?(Y/N) : ");
        String YorN = Console.ReadLine();
        while (YorN == "Y")
        {
            Console.Write("Enter a Book Title: ");
            string Title = Console.ReadLine();
            Console.Write("Enter a Book Author: ");
            string Author = Console.ReadLine();
            Console.Write("Enter Book Price: ");
            try
            {
                double Price = Convert.ToDouble(Console.ReadLine());
                Book UserBook = new Book(Title, Author, Price);
                lib.AddBook(UserBook);      //Adds book object to library list
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            booksAdded++;       //Counts amount of books added to library
            Console.Write("Would you like to add one or more books?(Y/N) : ");
            YorN = Console.ReadLine();
        }
        if (booksAdded > 0)
        {
            Console.WriteLine($"{booksAdded} books added");
            DisplayLibrary();
            SaveFile();
        }
    }

    /// <summary>
    /// Get the filename from the user and try to open it; read
    ///     contents and build library; handle any exceptions 
    ///     that occur.
    /// </summary>
    static void InputFile()
    {
        StreamReader reader = null;
        try
        {
            Console.Write("Please enter a file path: ");
            fileName = Console.ReadLine();
            reader = new StreamReader(fileName);
            while (reader.Peek() != -1) //Peek returns -1 if there is no more text left to process
            {
                string line = reader.ReadLine(); //reads one line
                string[] fields = line.Split(",");  //Delimiter is a comma
                Book b = new Book(fields[0], fields[1], double.Parse(fields[2]));
                lib.AddBook(b);     //Adds text already in file to the Book Object
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (reader != null)
                reader.Close();     //Closes reader once complete to ensure data is not lost
        }
    }

    /// <summary>
    /// Display the current library contents
    /// </summary>
    static void DisplayLibrary()
    {
        Console.WriteLine($"You should have {lib.GetNumBooks()}" +
            $" books in the library list.");
        Console.WriteLine($"\n\n\nLibrary Contents\n------------------\n" +
            $"{lib}\n");
    }
}

