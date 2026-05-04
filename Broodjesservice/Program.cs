using System.ComponentModel;

namespace Broodjesservice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List < Broodje > broodjes = new List<Broodje>();
            Dictionary<string, decimal> amountPerType = new Dictionary<string, decimal>();

            Console.WriteLine("----BROODJESBESTELLING----");
            Console.Write($"Geldige types: ");
            foreach (string type in Broodje.AllowedTypes) 
            {
                Console.Write($"'{type}' ");
            }

            Console.WriteLine();
            Console.ReadLine();

            string inputName;
            do
            {
                Console.WriteLine("Geef de naam van het broodje (of 'stop' om te eindigen):");                  
                inputName = Console.ReadLine();
                if (inputName == "stop")
                {
                    break;
                }
                Console.WriteLine("Geef het type: ");
                string inputType = Console.ReadLine();
                Console.WriteLine("Geef de prijs: ");
                decimal.TryParse(Console.ReadLine(), out decimal price);

                //nakijken of er al een broodje in de lijst staat van het nieuw ingevoerde type. (stond eerst ná try-catch maar daarin wordt broodje toegevoegd, dus uiteraard is bool dan altijd true).
                // bool isExistingType = broodjes.Exists(b => b.Type == inputType); 

                if (!broodjes.Exists(b => b.Type.Equals(inputType)))
                { 
                    try
                    {
                        broodjes.Add(new Broodje(inputName, inputType, price)); // niet eerst nieuw broodje maken en daarna toevoegen maar in één weg (dan moet ik geen zinloze variabele-naam voor het nieuwe broodje verzinnen)
                        amountPerType.Add(inputType, 0.0m);
                        amountPerType[inputType] += price;

                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else
                {
                    amountPerType[inputType] += price;
                }

                    
                    Console.ReadLine();

            } while (inputName != "stop") ;

            Console.WriteLine();
            Console.WriteLine("Omzet per type: ");
            foreach (var kv in amountPerType)
            {
                Console.WriteLine($"{kv.Key}: {kv.Value:c}");
            }


        }
    }
}
