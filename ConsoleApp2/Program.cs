namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Aanmaken van een lamp
            Lamp lamp1 = new Lamp();
            lamp1.Naam = "Fred";
            lamp1.StaatAan = true;
            Console.WriteLine(lamp1.Naam);

            // Aanmaken van een schakelaar
            Schakelaar schakelaar = new Schakelaar();
            schakelaar.Lampen.Add(lamp1);

            // Aanmaken van nog een lamp
            Lamp lamp2 = new Lamp();
            lamp2.Naam = "Bert";
            schakelaar.Lampen.Add(lamp2);

            // Alle lampen aanzetten
            schakelaar.ZetAan();

            // Voor iedere lamp de naam printen + of deze aan staat
            foreach (Lamp lamp in schakelaar.Lampen)
            {
                Console.WriteLine(lamp.Naam + " " + lamp.StaatAan.ToString());
            }

            // Alle lampen uitzetten
            schakelaar.ZetUit();

            // Voor iedere lamp de naam printen + of deze aan staat
            foreach (Lamp lamp in schakelaar.Lampen)
            {
                Console.WriteLine(lamp.Naam + " " + lamp.StaatAan.ToString());
            }

            // Nieuwe school aanmaken
            School school = new School() {  Name = "Zuyd" };

            // Docenten aanmaken
            Docent docent1 = new Docent();
            docent1.Name = "Rob";
            docent1.MedewerkerId = 1234;

            Docent docent2 = new Docent();
            docent2.Name = "Josianne";
            docent2.MedewerkerId = 4321;

            // Rob toevoegen aan medewerkers van de school
            school.Medewerkers.Add(docent1);

            // Ralf toevoegen als medewerker. Let hier op -> Ralf is geen docent maar medewerker. Dit kan omdat docent van medewerker overerft.
            Medewerker algemeen1 = new Medewerker() { Name = "Ralf", MedewerkerId = 12345 };
            school.Medewerkers.Add(algemeen1);
        }

        /// <summary>
        /// Een simpele lamp.
        /// </summary>
        class Lamp
        { 
            /// <summary>
            /// True als de lamp aan staat, anders false
            /// </summary>
            public bool StaatAan { get; set; }

            public string Merk { get; set; }

            public string Kleur { get; set; }

            public string Naam { get; set; }

            public string GeefNaam()
            {
                return Naam;
            }
        }

        class Schakelaar
        {
                      
            public List<Lamp> Lampen { get; set; } = new List<Lamp>();

            /// <summary>
            /// Zet alle lampen van de schakelaar aan
            /// </summary>
            public void ZetAan()
            {
                foreach (Lamp lamp in Lampen)
                {
                    lamp.StaatAan = true;
                }
            }

            /// <summary>
            /// Zet alle lampen van de schakelaar uit
            /// </summary>
            public void ZetUit()
            {
                foreach (Lamp lamp in Lampen)
                {
                    lamp.StaatAan = false;
                }
            }
        }

        class School
        {
            public string Name { get; set; }

            public List<Medewerker> Medewerkers { get; set; } = new List<Medewerker>();


        }

        class Medewerker
        {
            public string Name { get; set; }

            public int MedewerkerId { get; set; }
        }

        class Docent : Medewerker
        {

            public List<string> Vakken { get; set; }
        }

        class Congierge : Medewerker 
        {

            public List<string> Gebouwen { get; set; } = new List<string>();
        }
    }
}