using System;
using System.Xml.Linq;

namespace CovidTesting.UTILS
{
    public class TeamGenerator
    {
        private static readonly Random rnd = new ();
        private readonly string[] familyNames = { "Szucsánszki", "Schatzl", "Márton", "Kovacsics", "Háfra", "Klujber" };
        private readonly string[] firstNames = { "Zita", "Nadine", "Gréta", "Anikó", "Noémi", "Katrin" };
        private readonly string[] codes = { "ABC123", "DEF456", "GHI789", "JKL123", "MNO456", "PQR789" };
        private readonly string[] positions = { "RightWing", "LeftWing", "Pivot", "Centre", "Left Back", "Right Back" };

        public XDocument GetTeam(int numPlayers)
        {
            XDocument doc = new (new XElement("players"));

            for (int i = 0; i < numPlayers; i++)
            {
                XElement node = new ("player", new XAttribute("code", codes[rnd.Next(codes.Length)]),
                    new XElement("familyName", familyNames[rnd.Next(familyNames.Length)]),
                    new XElement("firstName", firstNames[rnd.Next(firstNames.Length)]),
                    new XElement("position", positions[rnd.Next(positions.Length)])
                );
                doc.Root.Add(node);
            }
            return doc;
        }
    }
}
