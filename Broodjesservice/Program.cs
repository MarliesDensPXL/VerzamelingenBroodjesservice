using System.ComponentModel;

namespace Broodjesservice
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine("Geef de naam van het broodje (of 'stop' om te eindigen):" +
                    "");
                inputName = Console.ReadLine();
                if (inputName == "stop")
                {
                    break;
                }
                Console.WriteLine("Geef het type: ");
                string inputType = Console.ReadLine();
                Console.WriteLine("Geef de prijs: ");
                decimal.TryParse(Console.ReadLine(), out decimal price);

                try
                {
                    broodjes.Add(new Broodje(inputName, inputType, price)); // niet eerst nieuw broodje maken en daarna toevoegen maar in één weg (dan moet ik geen zinloze variabele-naam voor het nieuwe broodje verzinnen)
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                bool isExistingType = broodjes.Exists(b => b.Type == inputType); //nakijken of er al een broodje in de lijst staat van het nieuw ingevoerde type.
                if (!isExistingType) //als type nog niet voorkomt in de lijst, nieuw item in dictionary aanmaken.
                {
                    amountPerType.Add(inputType, 0.0m); 
                }
                else
                {
                    amountPerType[inputType] += price;
                }


                    Console.ReadLine();

            } while (inputName != "stop") ;

        }
    }
}
