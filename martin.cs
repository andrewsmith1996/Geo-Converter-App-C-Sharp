using System;

class converterProgram{
    public static void Main(string[] args){

        string inputCode = Console.ReadLine();

        char[] code = inputCode.ToCharArray();

        string[] text = System.IO.File.ReadAllLines(@"positions.txt");

        if(inputCode.Length <= 9){
          Console.WriteLine("Invalid Code");
        }

        string codePart1 = Convert.ToString(code[0]) + Convert.ToString(code[1]);
        string codePart2 = Convert.ToString(code[2]) + Convert.ToString(code[3]) + Convert.ToString(code[4]) + Convert.ToString(code[5]);
        string codePart3 = Convert.ToString(code[6]) + Convert.ToString(code[7]) + Convert.ToString(code[8]) + Convert.ToString(code[9]);

        int index = Array.IndexOf(text, codePart1);

        if (index == -1){
          Console.WriteLine("Invalid Code");
        }

        string eastings = text[index + 1];
        string northings = text[index + 1];

        string feastings = Convert.ToString(eastings[0]) + codePart2;
        string fnorthings = Convert.ToString(northings[1]) + codePart3;


        if(feastings.Length < 6){
          while(feastings.Length < 6){
            feastings += "0";
          }
        }

        if(fnorthings.Length < 6){
          while(fnorthings.Length < 6){
            fnorthings += "0";
          }
        }

        Console.WriteLine("Eastings: {0}", feastings);
        Console.WriteLine("Northigs: {0}", fnorthings);

    }
}
