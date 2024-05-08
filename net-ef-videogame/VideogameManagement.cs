using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public static class VideogameManagement
    {
        public static bool InserisciVideogioco(string name, string overview, DateTime relaseDate, long softwareHouseId)
        {
            using (VideogameManagerContext db = new VideogameManagerContext())
            {
                try
                {
                    Videogame newVideoGame = new()
                    {
                        Name = name,
                        Overview = overview,
                        ReleaseDate = relaseDate,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        SoftwareHouseID = softwareHouseId
                    };
                    db.Add(newVideoGame);
                    db.SaveChanges();
                    return true;
                }
                catch
                {

                }
                return false;
            }
        }
        public static Videogame CercaVIdeogiocoPerId(long id)
        {
            using (VideogameManagerContext db = new VideogameManagerContext())
                try
            {
                
                Videogame gameFound = db.Videogames.Find(id);

                if (gameFound != null)
                {
                    // Il videogioco è stato trovato
                    return gameFound;
                }
                else
                {
                    // Il videogioco non è stato trovato
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni qui
                Console.WriteLine("Si è verificato un errore: " + ex.Message);
                return null;
            }
        }

        public static Videogame CercaVIdeogiocoPerNome(string name)
        {
            using (VideogameManagerContext db = new VideogameManagerContext())
                try
                {

                    Videogame gameFound = db.Videogames.Where(x => x.Name.Contains(name)).FirstOrDefault();

                    if (gameFound != null)
                    {
                        // Il videogioco è stato trovato
                        return gameFound;
                    }
                    else
                    {
                        // Il videogioco non è stato trovato
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Gestisci eventuali eccezioni qui
                    Console.WriteLine("Si è verificato un errore: " + ex.Message);
                    return null;
                }
        }

        public static bool CancellaVideoGame(int id)
        {
            using (VideogameManagerContext db = new VideogameManagerContext())
                try
                {
                    Videogame game = CercaVIdeogiocoPerId(id);
                    db.Remove(game);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Si è verificato un errore: " + ex.Message);
                    return false;
                }
        }

        public static bool InserisciSoftwareHouse(string name, string taxId, string city, string country)
        {
            using (VideogameManagerContext db = new VideogameManagerContext())
            {
                try
                {
                    SoftwareHouse newSoftwareHouse = new()
                    {
                        Name = name,
                        TaxId = taxId,
                        City = city,
                        Country = country,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
 
                    };
                    db.Add(newSoftwareHouse);
                    db.SaveChanges();
                    return true;
                }
                catch
                {

                }
                return false;
            }
        }
        // stampa tutti i videogiochi prodotti da una software house (all’utente verrà chiesto l’id della software house della quale mostrare i videogame)
        public static List<Videogame> StampaVideogiochi(int id)
        {
            return new List<Videogame>();
        }
    }
}
