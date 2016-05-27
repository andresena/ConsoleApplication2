using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class isbn
    {   //attributes
        private string isbnNum;
        //method   
        public string GetIsbn()
        {
            return this.isbnNum;
        }
        //constructor
        public isbn()
        {
            Console.Write("Enter Your ISBN Number: ");
            this.isbnNum = Console.ReadLine();

        }//end default constructor

        //method
        public string displayISBN()
        {

            return this.GetIsbn();

        }


        public static void Main(string[] args)                             //começa aqui. void main.
        {
            //create a new instance of the ISBN/book class

            isbn myFavoriteBook = new isbn();                             ////chama daqui !!!

            //contains the method for checking validity 
            bool isValid = CheckDigit.CheckIsbn(myFavoriteBook.GetIsbn());

            //print out the results of the validity.
            Console.WriteLine(string.Format("Your book {0} a valid ISBN",
                                       isValid ? "has" : "doesn't have"));

            Console.ReadLine();

        }
    }

    public static class CheckDigit
    {       // attributes
        public static string NormalizeIsbn(string isbn)
        {
            return isbn.Replace("-", "").Replace(" ", "");
        }
        public static bool CheckIsbn(string isbn) // formula to check ISBN's validity
        {
            if (isbn == null)
                return false;

            isbn = NormalizeIsbn(isbn);
            if (isbn.Length != 10)
                return false;

            int result;
            for (int i = 0; i < 9; i++)
                if (!int.TryParse(isbn[i].ToString(), out result))
                    return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (i + 1) * int.Parse(isbn[i].ToString());

            int remainder = sum % 11;
            if (remainder == 10)
                return isbn[9] == 'X';
            else
                return isbn[9] == (char)('0' + remainder);
        }
    }
}
