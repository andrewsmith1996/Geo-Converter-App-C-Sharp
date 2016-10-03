using System;

class converterProgram{
    public static void Main(string[] args){

        //Get Menu Input
        Console.WriteLine("1 - Convert NGR to E&N");
        Console.WriteLine("2 - Convert E&N to NGR");

        //Reads in input
        int choice = Convert.ToInt32(Console.ReadLine());

        //Switch menu
        switch(choice){
          //Conversion from NGR to N&E
          case 1:

              Console.WriteLine("Enter NGR");

              //Retrieve NGR code
              string inputCode = Console.ReadLine().ToUpper();

              //Turns NGR code into an array
              char[] code = inputCode.ToCharArray();

              //Loads the positions.txt file into thep rogram
              string[] text = System.IO.File.ReadAllLines(@"positions.txt");

              //Length validation
              if(inputCode.Length <= 9){
                Console.WriteLine("Invalid Code");
              }

              //Variable definitions
              string codePart1 = Convert.ToString(code[0]) + Convert.ToString(code[1]), codePart2 = "", codePart3 = "";

              //If 10 characters long

              //Forms part 2 and part 3 of the code by taking the rest of the NGR code
              if(inputCode.Length == 10){
                 codePart2 = Convert.ToString(code[2]) + Convert.ToString(code[3]) + Convert.ToString(code[4]) + Convert.ToString(code[5]);
                 codePart3 = Convert.ToString(code[6]) + Convert.ToString(code[7]) + Convert.ToString(code[8]) + Convert.ToString(code[9]);
              } else{
                 codePart2 = Convert.ToString(code[2]) + Convert.ToString(code[3]) + Convert.ToString(code[4]) + Convert.ToString(code[5]) + Convert.ToString(code[6]);
                 codePart3 = Convert.ToString(code[7]) + Convert.ToString(code[8]) + Convert.ToString(code[8]) + Convert.ToString(code[9]) + Convert.ToString(code[10]);
              }

              //Find in the text file where the 2 letters of the code are
              int index = Array.IndexOf(text, codePart1);

              //If not in text file then it's invalid
              if (index == -1){
                Console.WriteLine("Invalid Code");
              }

              //Translates the 2 alphabet letters into their respective codes, i.e SE into 44
              string eastings = text[index + 1], northings = text[index + 1];

              //Adds the second part of the code
              string feastings = Convert.ToString(eastings[0]) + codePart2, fnorthings = Convert.ToString(northings[1]) + codePart3;

              //Make it 6 digits long
              if(feastings.Length < 6){
                while(feastings.Length < 6){
                  feastings += "0";
                }
              }

              //Make it 6 digits long
              if(fnorthings.Length < 6){
                while(fnorthings.Length < 6){
                  fnorthings += "0";
                }
              }

              //Outputs
              Console.WriteLine("Eastings: {0}", feastings);
              Console.WriteLine("Northigs: {0}", fnorthings);

          break;

          //Conversion from N&E to NGR
          case 2:
              //Retrieve input
              Console.WriteLine("Enter Northing");
              string northing = Console.ReadLine().ToUpper();

              Console.WriteLine("Enter Easting");
              string easting = Console.ReadLine().ToUpper();

              //Loads in text file
              text = System.IO.File.ReadAllLines(@"positions.txt");

              //Finds the alphabet code in the textfile
              index = Array.IndexOf(text, Convert.ToString(easting[0]) + Convert.ToString(northing[0]));

              codePart1 = text[index - 1];
              codePart2 = "";
              codePart3 = "";

              //Translates the digits for the NGR code
              if(northing.Length == 5 & easting.Length == 5){
                 codePart2 = Convert.ToString(northing[1]) + Convert.ToString(northing[2]) + Convert.ToString(northing[3]) + Convert.ToString(northing[4]);
                 codePart3 = Convert.ToString(easting[1]) + Convert.ToString(easting[2]) + Convert.ToString(easting[3]) + Convert.ToString(easting[4]);
              } else{
                 codePart2 = Convert.ToString(northing[1]) + Convert.ToString(northing[2]) + Convert.ToString(northing[3]) + Convert.ToString(northing[4]) + Convert.ToString(northing[5]);
                 codePart3 = Convert.ToString(easting[1]) + Convert.ToString(easting[2]) + Convert.ToString(easting[3]) + Convert.ToString(easting[4]) + Convert.ToString(easting[5]);
              }

              //Outputs
              Console.WriteLine("NGR: {0}", codePart1 + codePart2 + codePart3);
            break;

          //Error switch state
          default:
            Console.WriteLine("Error");
            break;
          }
      }
    }
