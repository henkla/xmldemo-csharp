using System;
using XmlDemo.Common;

namespace XmlDemo.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var boksamlingAsObject = CreateBoksamlingObject();
            
            // först agerar vi Producer genom att skapa, serialisera och skicka/skriva Boksamling/xml
            using (var producer = new Producer<Boksamling>())
            {
                producer.Send(boksamlingAsObject);
                boksamlingAsObject = default; // bara för att demonstrera att objektet faktiskt nollställs
            }

            // sedan agerar vi Consumer genom att ta emot/läsa, deserializera och skriva ut Boksamlingen
            using (var consumer = new Consumer<Boksamling>())
            {
                boksamlingAsObject = consumer.Receive();
            }

            PrintCollectionToConsole(boksamlingAsObject);
        }



        private static Boksamling CreateBoksamlingObject()
        {
            return new Boksamling()
            {
                bok = new bokType[]
                {
                    new bokType
                    {
                        antalSidor = "1337",
                        författare = new forfattareType
                        {
                            namn = new forfattareTypeNamn
                            {
                                efternamn = "Larsson",
                                förnamn = "Henrik"
                            }
                        },
                        förlag = "NullFörlag AB",
                        omslag = "Paperback",
                        pris = 420,
                        titel = "En Inte Fullt Så Intressant Berättelse",
                        utgivningsår = "2019"
                    }
                }
            };
        }

        private static void PrintCollectionToConsole(Boksamling boksamling)
        {
            if (CollectionIsNullOrEmpty(boksamling))
            {
                Console.WriteLine("Boksamlingen innehåller inga element");
                return;
            }

            foreach (var bok in boksamling.bok)
            {
                Console.WriteLine(bok.titel + " - " + bok.pris + " kr");
            }
        }

        private static bool CollectionIsNullOrEmpty(Boksamling boksamling)
        {
            return boksamling == null ||
                   boksamling.bok == null ||
                   boksamling.bok.Length == 0;
        }
    }
}
