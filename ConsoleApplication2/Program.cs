using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBNnumber
{
    public class ISBN
    {
        private string isbnNum;
        public string GetIsbn()
        {
            Console.WriteLine("isbnNum is:");
            Console.WriteLine(isbnNum);
            long num = 123456789;
            bool test = Int64.TryParse(isbnNum, out num);            

            while ((test == false) || (isbnNum.Length != 12))  //validate if isbnNum is a number and have 12 digits.
            {                
                Console.WriteLine("Type a number and with 12 digits:");
                isbnNum = Console.ReadLine();
                Console.WriteLine("Length is:");
                Console.WriteLine(isbnNum.Length);
                test = Int64.TryParse(isbnNum, out num);
            }
            return this.isbnNum;
        }

        public ISBN()
        {
            Console.Write("Type a number with 12 digits:");
            this.isbnNum = Console.ReadLine();            
        }   

        public static void Main(string[] args)
        {  
            ISBN trueisbn = new ISBN(); //constructor

            string final_isbn = CheckDigit.CheckIsbn(trueisbn.GetIsbn());            
            Console.WriteLine(final_isbn);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public class CheckDigit
    {
        public static string CheckIsbn(string isbn)
        {
            string ISBN = isbn.Substring(3);    //Remove the three first digits from the typed number.             

            char[] reverse = ISBN.ToCharArray();  // Reverse number to sum correctly.
            Array.Reverse(reverse);

            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += (i + 2) * int.Parse(reverse[i].ToString());
            }

            int extra_digit = 0;
            extra_digit = (11 - (sum % 11)) % 11;
            Console.WriteLine("Extra digit is:");
            Console.WriteLine(extra_digit);

            if (extra_digit != 10)
            {
                Console.WriteLine("The final ISBN number is:");
                return (ISBN + extra_digit);
            }
            else
            {
                Console.WriteLine("The final ISBN number is:");
                return (ISBN + "x");    //Avoiding add two extra digits in ISBN number.   
            }
        }
    }
}