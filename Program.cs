using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAID_Validity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Validity of South African ID Number---");
            Console.Write("Enter your ID number: ");
            string sID = Console.ReadLine();

            bool isDigits = sID.All(char.IsDigit);
            try
            {
                if (isDigits)
                {
                    if (sID.Length == 13)
                    {

                        int iYear = int.Parse(sID.Substring(0, 2));
                        int iMonth = int.Parse(sID.Substring(2, 2));
                        if (iMonth <= 12 && iMonth >= 01)
                        {
                            int iDay = int.Parse(sID.Substring(4, 2));
                            if (iDay <= 31 && iDay >= 01)
                            {

                                DateTimeFormatInfo Month = new DateTimeFormatInfo();
                                string sMonth = Month.GetMonthName(iMonth);

                                if (DateTime.Now.Year - iYear < 2000)
                                    iYear += 1900;
                                else
                                    iYear += 2000;

                                DateTime DOB = new DateTime(iYear, iMonth, iDay);

                                string sDay = DOB.DayOfWeek.ToString();

                                int iGender = int.Parse(sID.Substring(6, 4));
                                string sGender = "";
                                if (iGender >= 0000 && iGender < 5000)
                                    sGender = "Female";
                                else
                                if (iGender >= 5000 && iGender <= 9999)
                                    sGender = "Male";
                                else
                                    sGender = "Invalid";

                                int iCitizenship = int.Parse(sID.Substring(10, 1));
                                if (iCitizenship == 0 || iCitizenship == 1)
                                {
                                    string sCitizenship = "";
                                    if (iCitizenship == 0)
                                        sCitizenship = "South African Citizen";
                                    else if (iCitizenship == 1)
                                        sCitizenship = "Permanent Citizen";

                                    Console.WriteLine();
                                    Console.WriteLine("Birthdate: " + sDay + " " + iDay.ToString("D2") + " " + sMonth + " " + iYear.ToString());
                                    Console.WriteLine("Gender: " + sGender);
                                    Console.WriteLine("Citizenship: " + sCitizenship);
                                }
                                else
                                    Console.WriteLine("Invalid Citizenship");
                            }
                            else
                                Console.WriteLine("Invalid Day Entered");
                        }
                        else
                            Console.WriteLine("Invalid month entered");
                    }
                    else
                        Console.WriteLine("ID Number is less than 13 digits");
                }
                else
                    Console.WriteLine("Not all characters are digits");
            }
            catch
            {
                Console.WriteLine("Invalid ID Number");
            }


            Console.Write("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
