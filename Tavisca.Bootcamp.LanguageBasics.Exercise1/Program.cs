using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var C = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {C}");
        }

        public static int FindDigit(string equation)
        {   
            string C = equation.Split('=')[1];
            string A = equation.Split('*')[0];
            string B = equation.Split('*')[1].Split('=')[0];
            float compResult = -1;
            string givenResult = "";
            

            if(A.IndexOf('?') > -1){
                compResult = ((float)Int32.Parse(C))/Int32.Parse(B);
                givenResult = A;
            }
            else if(B.IndexOf('?') > -1){
                compResult = ((float)Int32.Parse(C))/Int32.Parse(A);   
                givenResult = B;
            }
            else if(C.IndexOf('?') > -1){
                compResult = Int32.Parse(A)*Int32.Parse(B);
                givenResult = C;
            }

           // computed result is not integer, no integer solution possible
            if(compResult != (int)compResult){
                return -1;
            }

            string temp = compResult.ToString();

            if(temp.Length != givenResult.Length){
                // length mismatch
                return -1;
            }
            else{

             int index=givenResult.IndexOf('?');
             return (int)temp[index]-48;
             
         }       

     }
 }
}
