using System.ComponentModel;

namespace Broodjesservice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List < Broodje > broodjes = new List<Broodje>();

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
                    broodjes.Add(new Broodje(inputName, inputType, price));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                Console.ReadLine();

            } while (inputName != "stop") ;

        }
    }
}
