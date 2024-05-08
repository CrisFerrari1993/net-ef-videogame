using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("videogames")]
    [Index(nameof(VideogameID), IsUnique = true)]
    public class Videogame
    {
        [Key] public long VideogameID { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        [Column("released_date")]
        public DateTime ReleaseDate { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        // Relationship
        public long SoftwareHouseID { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Review> reviews { get; set; }

        public override string ToString()
        {
            return $"Id: {VideogameID}\nNome: {Name}\nRecensione: {Overview}\nData di rilascio: {ReleaseDate}\nSoftware House id: {SoftwareHouseID}";
        }
    }

    public class SoftwareHouse
    {
        [Key] public long SoftwareHouseID { get; set; }
        public string Name { get; set; }
        [Column("tax_id")]
        public string TaxId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        //Relationship
        public List<Videogame> VideogamesList { get; set; }
    }

    public class Tournament
    { 
        [Key] public long TournamentID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Year { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        // Relationship
        public long VideogameID { get; set; }
        public Videogame Videogame { get; set; }
        public List<Player> PartecipantsPlayers { get; set; }

    }

    public class Review
    {
        [Key] public long ReviewId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        //Relationship
        public long VideogameID { get; set; }
        public Videogame Videogame { get; set; }
        public long PlayerID {  get; set; }
        public Player Player { get; set; }

    }

    public class Player
    {
        [Key] public long PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string City { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        //Relationship
        public List<Tournament> TournamentList { get; set;}
    }
}
