using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broodjesservice
{
    public class Broodje
    {
        public string Name { get; set; }

		private string _type;

		public string Type
		{
			get { return _type; }
			set
            {
                if (Array.Exists(_allowedTypes, type => type.Equals(value, StringComparison.OrdinalIgnoreCase)))
                {
                    _type = value;
                }
                else
                {
                    throw new ArgumentException($"Ongeldige type {value}. De types zijn 'warm', 'koud', 'veggie' of 'speciaal'.");
                }
            }
		}

        public decimal Price { get; set; }

        private static readonly string[] _allowedTypes = { "warm", "koud", "veggie", "speciaal" };

        public static string[] AllowedTypes //string hierboven is private, enkel bruikbaar in de klasse. Deze public string[] is leesbaar in program-klasse (om de types niet zelf opnieuw te moeten typen in overzicht in program-klasse)
        {
            get { return _allowedTypes; }
        }

        public Broodje(string name, string type, decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

    }
}
