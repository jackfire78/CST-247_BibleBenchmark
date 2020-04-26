using Activity3.Models;
using Activity3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Activity3.Services.Business.Data{
    /**
     * SecurityDAO class will take in any parameters passed in from the business serivce and make requests to the Database based on what action is needed
     * createVerse will take in a bibleVerse that a user filled out from a form and create a copy of that in the Database
     * searchVerse will return a verse matching the parameters specified by the user in the search form page
     * Variable connection string is used to connect to our database
     */
    public class SecurityDAO{

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Bible; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Create Verse will create take what the user filled out in the Add Verse Form and create a new object of verse in the database
        public bool createVerse(BibleVerse bibleVerse) {
            MyLogger.GetInstance().Info("Entering the SecurityDAO. createVerse() method");
            //start by assuming nothing was found
            bool success = false;            
            //queryString to create new verse in database
            String queryString = "INSERT INTO dbo.Verses (testamentSelection, bookSelection, chapterNumber, verseNumber, verseText) VALUES (@Testament, @Book, @ChapterNum, @VerseNum, @VerseText)";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) {

                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection)) {
                    sqlCommand.Parameters.Add("@Testament", SqlDbType.VarChar).Value = bibleVerse.TestamentSelection;
                    sqlCommand.Parameters.Add("@Book", SqlDbType.VarChar).Value = bibleVerse.BookSelection;
                    sqlCommand.Parameters.Add("@ChapterNum", SqlDbType.VarChar).Value = bibleVerse.ChapterNumber;
                    sqlCommand.Parameters.Add("@VerseNum", SqlDbType.VarChar).Value = bibleVerse.VerseNumber;
                    sqlCommand.Parameters.Add("@VerseText", SqlDbType.Text).Value = bibleVerse.VerseText;

                    try {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        MyLogger.GetInstance().Info("sql Querey successfully inserted a verse into the database");

                        sqlConnection.Close();
                        success = true;
                    } catch (Exception e) {
                        MyLogger.GetInstance().Info("Fail occured in the createVerse() method within the SecurityDAO");

                        Debug.WriteLine(e.Message);
                    }
                }
            }
            return success;
        }

        //find verse will return the verse a user searched for in the search for verse form
        public BibleVerse findVerse(BibleVerse bibleVerse) {
            MyLogger.GetInstance().Info("Entering the SecurityDAO. findVerse() method");

            BibleVerse returnedVerse = new BibleVerse();

            String queryString = "SELECT * FROM dbo.Verses WHERE testamentSelection=@Testament AND bookSelection=@Book AND chapterNumber=@ChapterNum AND verseNumber=@VerseNum";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) {

                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection)) {
                    sqlCommand.Parameters.Add("@Testament", SqlDbType.VarChar).Value = bibleVerse.TestamentSelection;
                    sqlCommand.Parameters.Add("@Book", SqlDbType.VarChar).Value = bibleVerse.BookSelection;
                    sqlCommand.Parameters.Add("@ChapterNum", SqlDbType.VarChar).Value = bibleVerse.ChapterNumber;
                    sqlCommand.Parameters.Add("@VerseNum", SqlDbType.VarChar).Value = bibleVerse.VerseNumber;

                    try {
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        MyLogger.GetInstance().Info("Connection to the Database was made");

                        while (sqlDataReader.Read()) {
                            returnedVerse.TestamentSelection = sqlDataReader.GetString(1);
                            returnedVerse.BookSelection = sqlDataReader.GetString(2);
                            returnedVerse.ChapterNumber = sqlDataReader.GetString(3);
                            returnedVerse.VerseNumber = sqlDataReader.GetString(4);
                            returnedVerse.VerseText = sqlDataReader.GetString(5);
                            Debug.WriteLine("Retrieved text:"+sqlDataReader.GetString(5));
                        }
                        sqlConnection.Close();
                    } catch (Exception e) {
                        MyLogger.GetInstance().Info("Fail occured in the findVerse() method within the SecurityDAO");

                        Debug.WriteLine(e.Message);
                    }
                }
            }
            return returnedVerse;
        }



    }
}