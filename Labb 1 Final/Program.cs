internal class Program
{
    static void Main(string[] args)
    {
        List<string> endNumber = new List<string>();                    // här gör vi en lista så att den kan kasta upp siffrorna som ska sparas hela tiden och sedan kalla på dom
        //Console.WriteLine("Enter your sequence, i dare you try and crash it, it wont work, it is fool proof");
        //string input = Console.ReadLine();
        string input = "29535123p48723487597645723645"; 
        string sequence = "";                                           // för att spara sekvensen
        int starti = 0;                                                 // för att spara första siffran i sekvenser. Jag tappade bort mina sparade index och hade svårt att hitta dom. så det blev extra variabler
        int endj = 0;                                                   // för att spara värdet på index j sen 
        int i = 0;
        int j = 0;
        for (i = 0; i < input.Length; i++) // början av loopen
        {
            sequence = "";                                              // nollställer varje ny sekvens 
            starti = i;                                                 // sparar varje ny sekvens 
            for (j = i; j < input.Length; j++)                          // vi använder j för det kommer efter i
            {
                if (char.IsDigit(input[j]))                             // kollar av så att det är siffor och inget annat
                {
                    sequence += input[j];                               // lägger den här i ifall det är en siffra 
                    if (sequence.Length > 1 && sequence[0] == sequence[sequence.Length - 1]) // kollar ifall det är minst 2 siffror och ifall första och sista sifrran e samma
                    {
                        endNumber.Add(sequence);                        // vi sparar dom sifforna i en lista som passar för att sen räkna ihop dom
                        endj = j;                                       // här sparar vi slutindex av sekvensen. 
                        colourthis(input, starti, endj, sequence, i, j); // vi anroppar så vi kan färga dom matcahnde sekvenserna                        
                        i = starti;                                     // här går den tillbaka till start positionen där vi va senast så vi inte missar någon siffra
                        break;                                          // för att avbryta sekvensen och sluta leta efter siffor i denna sekvens 
                    }
                }

                else
                {
                    sequence = "";
                    break;                                              // ifall det finns en bokstav i den så avbryter vi och gör om sekvesen till en tom string och börjar om
                }
            }

        }
        TheSum(endNumber);                                              // här kallar vi på TheSum för att skriva ut vad totala blir
    }
    public static void colourthis(string input, int endj, int starti, string sequence, int i, int j) // för att färga den
    {
        Console.Write($"{input.Substring(0, i)}");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(sequence);
        Console.ResetColor();
        Console.WriteLine($"{input.Substring(j + 1, input.Length - (j + 1))}");
    }

    public static void TheSum(List<string> endNumber)
    {
        long Sum = 0;

        for (int i = 0; i < endNumber.Count; i++)
        {
            Sum += long.Parse(endNumber[i]);                            // vi gör den till en long för det är massa siffror
        }
        Console.WriteLine($"\nThe total value of the coloured numbers are: {Sum}");
    }

}




