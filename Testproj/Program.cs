using System;
using System.Collections.Generic;
using System.Linq;

namespace Testproj
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("45 34 24 108 76 58 64 130 80 // 130 24 34 80 108 45 64 58 76");
            Console.WriteLine("Answer:");
            Console.WriteLine(Order("45 34 24 108 76 58 64 130 80"));

            Console.WriteLine("2022 70 123    3344 13 // 13 123 2022 70 3344");
            Console.WriteLine("Answer:");
            Console.WriteLine(Order("    2022 70 123    3344 13 "));

            Console.WriteLine(Order(""));
            Console.ReadKey();
        }

        static string Order(string input)
        {
            if (input == null || input == "")
            {
                return "line is empty";
            }
            string done_input_str = null;
            string[] arrnumb = input.Split(" ");
            Dictionary<int, int> numbers_numSum = new Dictionary<int, int>();
            foreach (string numb in arrnumb)
            {
                if (numb != "")
                {
                    numbers_numSum.Add(Int32.Parse(numb), Sum(Int32.Parse(numb)));
                }
            }

            List<int> keys_f = new List<int>();

            SameWeight(numbers_numSum, keys_f);

            var sortedDict = from numb in numbers_numSum orderby numb.Value ascending select numb;

            foreach(var numb in sortedDict)
            {
                done_input_str = done_input_str + numb.Key + " ";
            }

            return done_input_str;
        }

        static int Sum(int numb)
        {
            int sum = 0;
            while (numb != 0)
            {
                sum = sum + numb % 10;
                numb = numb / 10;
            }
            return sum;
        }

        static void SameWeight(Dictionary<int,int>numbers_numSum, List<int> keys_f)
        {
            foreach (var numb in numbers_numSum)
            {
                int count = 0;

                {
                    foreach (var numb_2 in numbers_numSum)
                    {

                        if (numb.Value == numb_2.Value)
                        {
                            count++;
                        }
                        if (count == 2 && keys_f.Contains(numb.Value) == false)
                        {
                            keys_f.Add(numb_2.Value);
                            count = 0;

                        }

                    }
                }
                
            }
            
            while (keys_f.Count != 0)
            {
                bool break_num = false;
                foreach (var numbch in numbers_numSum)
                {
                
                        foreach (var numbch_2 in numbers_numSum)
                        {


                            if (numbch.Value == numbch_2.Value && keys_f.Contains(numbch.Value) == true)
                            {
                                if (numbch.Key != numbch_2.Key)
                                {
                                    if (Convert.ToInt32(numbch.Key.ToString().First()) > Convert.ToInt32(numbch_2.Key.ToString().First()))
                                    {
                                        int first_K = numbch.Key;
                                        int first_V = numbch.Value;
                                        int second_K = numbch_2.Key;
                                        int second_V = numbch_2.Value;
                                        numbers_numSum.Remove(first_K);
                                        numbers_numSum.Remove(second_K);
                                        numbers_numSum.Add(first_K, second_V);
                                        numbers_numSum.Add(second_K, first_V);
                                        keys_f.Remove(numbch.Value);
                                        break_num = true;
                                        break;

                                    }

                                }

                                

                            }

                        }
                    if (break_num == true)
                    {
                        break;
                    }
                    
                }
            }
        }

    }
}
