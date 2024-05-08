namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool program = true;
            while (program)
            {
                string userChoice = "";
                Console.WriteLine("Benvenuto nel software di gestione Videogame, scegliere fra le seguenti opzioni");
                Console.WriteLine("1 - Inserisci un VideoGame");
                Console.WriteLine("2 - Ricerca di un VideoGame (id)");
                Console.WriteLine("3 - Ricerca di un VideoGame per nome");
                Console.WriteLine("4 - Eliminare un videogioco (id)");
                Console.WriteLine("5 - Inserire una nuova Software House");
                Console.WriteLine("6 - Stampa tutti i videogame di una Software House (id)");
                Console.WriteLine("7 - Esci");
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        {

                            bool datiCorretti = true;
                            while (datiCorretti)
                            {
                                string name = "Unknown";
                                string overview = "Unknown";
                                string dateToParse;
                                DateTime date = DateTime.Now;
                                int sHId = 0;
                                try
                                {
                                    Console.Write("Inserisci nome viodeogame: ");
                                    name = Console.ReadLine();
                                    if (string.IsNullOrEmpty(name))
                                    {
                                        throw new Exception("Il nome non può essere vuoto");
                                    }
                                }
                                catch (Exception e)
                                {
                                    datiCorretti = false;
                                    Console.WriteLine($"Errori trovati: {e.Message}\n {e.StackTrace}");
                                }                           
                                try
                                {
                                    Console.Write("Inserisci descrizione per il viodeogame: ");
                                    overview = Console.ReadLine();
                                    if (string.IsNullOrEmpty(overview))
                                    {
                                        throw new Exception("Non dico di scrivere 1000 caratteri, ma mettile due parole :)");
                                    }
                                }
                                catch (Exception e)
                                {
                                    datiCorretti = false;
                                    Console.WriteLine($"Errori trovati: {e.Message}\n {e.StackTrace}");
                                }
                                try
                                {
                                    Console.Write("Inserisci data del rilascio del viodeogame: ");
                                    dateToParse = Console.ReadLine();
                                
                                    if (DateTime.TryParseExact(dateToParse, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                                    {
                                        date = parsedDate;
                                    }
                                    else throw new Exception("Il nome non può essere vuoto");
                                }
                                catch (Exception e)
                                {
                                    datiCorretti = false;
                                    Console.WriteLine($"Errori trovati: {e.Message}\n {e.StackTrace}");
                                }
                                try
                                {
                                    Console.Write("Inserisci id Software house viodeogame(id): ");
                                    sHId = int.Parse(Console.ReadLine());
                                    if (sHId < 0)
                                    {
                                        throw new Exception("L indice non può essere 0 o negativo");
                                    }
                                }
                                catch (Exception e)
                                {
                                    datiCorretti = false;
                                    Console.WriteLine($"Errori trovati: {e.Message}\n {e.StackTrace}");
                                }
                                bool success = VideogameManagement.InserisciVideogioco(name, overview, date, sHId);
                                string res = success ? "Operazione Completata" : "Operazione Fallita";
                                Console.WriteLine(res);
                                break;
                            }
                            break;
                        }
                    case "2":
                        {
                            {
                                bool datiCorretti = true;
                                while (datiCorretti)
                                {
                                    Console.Write("Inserisci ID del videogioco (numero intero): ");
                                    int gameId;
                                    if (!int.TryParse(Console.ReadLine(), out gameId))
                                    {
                                        Console.WriteLine("Inserisci un ID valido.");
                                        continue; // Ripeti il ciclo finché l'input non è valido
                                    }

                                    Videogame gameFound = VideogameManagement.CercaVIdeogiocoPerId(gameId);
                                    if (gameFound == null)
                                    {
                                        Console.WriteLine($"Non ho trovato nulla con ID {gameId}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Trovato: {gameFound.ToString()}");
                                    }

                                    // Imposta datiCorretti su false solo se non è stato trovato un videogioco
                                    datiCorretti = gameFound == null;
                                }
                            }
                            break;
                        }
                    case "3":
                        {
                            bool datiCorretti = true;
                            while (datiCorretti)
                            {
                                Console.Write("Inserisci nome o parte di esso del videogioco: ");
                                string gameName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(gameName))
                                {
                                    Console.WriteLine("Devi inserire almeno un carattere");
                                    continue; // Ripeti il ciclo finché l'input non è valido
                                }

                                Videogame gameFound = VideogameManagement.CercaVIdeogiocoPerNome(gameName);
                                if (gameFound == null)
                                {
                                    Console.WriteLine($"Non ho trovato nulla con il carattere o parola: {gameName}");
                                }
                                else
                                {
                                    Console.WriteLine($"Trovato: {gameFound.ToString()}");
                                }

                                // Imposta datiCorretti su false solo se non è stato trovato un videogioco
                                datiCorretti = gameFound == null;
                            }

                            break;
                        }
                    case "4":
                        {
                            bool datiCorretti = true;
                            while (datiCorretti)
                            {
                                Console.Write("Inserisci ID del videogioco da eliminare (numero intero): ");
                                int gameId;
                                if (!int.TryParse(Console.ReadLine(), out gameId))
                                {
                                    Console.WriteLine("Inserisci un ID valido.");
                                    continue; // Ripeti il ciclo finché l'input non è valido
                                }

                                Videogame gameFound = VideogameManagement.CercaVIdeogiocoPerId(gameId);
                                if (gameFound == null)
                                {
                                    Console.WriteLine($"Non ho trovato nulla con ID {gameId}");
                                }
                                else
                                {
                                    VideogameManagement.CancellaVideoGame(gameId);
                                    Console.WriteLine($"Cancellato con successo");
                                }
                            }
                        }
                        break;
                    case "5":
                        {
                            bool datiCorretti = true;
                            while (datiCorretti)
                            {
                                string name = "Unknown";
                                string taxId = "Unknown";
                                string city = "Unknown";
                                string country = "Unknown";
                                try
                                {
                                    Console.Write("Inserisci nome Software House: ");
                                    name = Console.ReadLine();
                                    if (string.IsNullOrEmpty(name))
                                    {
                                        throw new Exception("Il nome non può essere vuoto");
                                    }
                                }
                                catch (Exception e)
                                {
                                    datiCorretti = false;
                                    Console.WriteLine($"Errori trovati: {e.Message}\n {e.StackTrace}");
                                }
                                try
                                {
                                    Console.Write("Inserisci l'IVA della Software House: ");
                                    taxId = Console.ReadLine();
                                    if (string.IsNullOrEmpty(taxId))
                                    {
                                        throw new Exception("Non dico di scrivere 1000 caratteri, ma mettile due parole :)");
                                    }
                                }
                                catch (Exception e)
                                {
                                    datiCorretti = false;
                                    Console.WriteLine($"Errori trovati: {e.Message}\n {e.StackTrace}");
                                }
                                try
                                {
                                    Console.Write("Inserisci la città della Software House: ");
                                    city = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(city))
                                    {
                                        throw new Exception("Il nome della città non può essere vuota");
                                    }
                                }
                                catch (Exception e)
                                {
                                    datiCorretti = false;
                                    Console.WriteLine($"Errori trovati: {e.Message}\n {e.StackTrace}");
                                }
                                try
                                {
                                    Console.Write("Inserisci la nazione della Software House: ");
                                    country = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(country))
                                    {
                                        throw new Exception("Il nome del paese non può essere vuota");
                                    }
                                }
                                catch (Exception e)
                                {
                                    datiCorretti = false;
                                    Console.WriteLine($"Errori trovati: {e.Message}\n {e.StackTrace}");
                                }
                                bool success = VideogameManagement.InserisciSoftwareHouse(name, taxId, city, country);
                                string res = success ? "Operazione completata" : "Operazione Falita";
                                Console.WriteLine(res);
                                break;
                            }
                            break;
                        }
                        break;
                    case "6":
                        break;
                    case "7":
                        program = false;
                        break;
                         
                }
            }
        }
    }
}
