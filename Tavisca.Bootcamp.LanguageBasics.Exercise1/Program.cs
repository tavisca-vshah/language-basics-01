using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1 {
  class Program {
    static void Main (string[] args) {
      Test ("42*47=1?74", 9);
      Test ("4?*47=1974", 2);
      Test ("42*?7=1974", 4);
      Test ("42*?47=1974", -1);
      Test ("2*12?=247", -1);
      //  Console.ReadKey(true);
    }

    private static void Test (string args, int expected) {
      var C = FindDigit (args).Equals (expected) ? "PASS" : "FAIL";
      Console.WriteLine ($"{args} : {C}");
    }

    public static int FindDigit (string equation) {
      string resultTerm, firstTerm, secondTerm, givenResult, result;
      float compResult = -1;
      resultTerm = equation.Split ('=') [1];
      firstTerm = equation.Split ('*') [0];
      secondTerm = equation.Split ('*') [1].Split ('=') [0];
      givenResult = "";

      if (firstTerm.Contains ('?')) {
        compResult = ((float) Int32.Parse (resultTerm)) / Int32.Parse (secondTerm);
        givenResult = firstTerm;
      } else if (secondTerm.Contains ('?')) {
        compResult = ((float) Int32.Parse (resultTerm)) / Int32.Parse (firstTerm);
        givenResult = secondTerm;
      } else {
        compResult = Int32.Parse (firstTerm) * Int32.Parse (secondTerm);
        givenResult = resultTerm;
      }

      result = compResult.ToString ();
      // computed result is not integer, no integer solution possible
      if ((compResult != (int) compResult) ||
        (result.Length != givenResult.Length)) return -1;

      else {

        /* Find Out the index at which '?' occur in givenResult and using this index,
         find out the missing digit from compResult */
        //  The ASCII value '0' is 48.Subtract to get Absolute value
        int index = givenResult.IndexOf ('?');
        return (int) result[index] - 48;

      }

    }
  }
}