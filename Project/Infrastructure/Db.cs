using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Infrastructure
{
    class Db
    {   public List<City> Cities { get; }
        public List<Country> Countries { get; }
        public List<Category> Categories { get; }
        public List<Place> Places { get; }
        public List<Review> Reviews { get; }
        public Db()
        {
            List<City> Cities3;

            Country romania = new Country("Romania");
            Cities3 = new List<City>
            {
            new City("Alba Iulia",romania),
            new City("Sibiu",romania),
            new City("Timisoara",romania),
            new City("Cluj-Napoca",romania),
            new City("Bucuresti",romania)
            };
            romania.Cities = Cities3;
            List<City> Cities1;
            Country germania = new Country("Germania");
            Cities1 = new List<City>
            {
            new City("Berlin",germania),
            new City("Hamburg",germania),
            new City("Munchen",germania),
            new City("Nunberg",germania),
            new City("Stuttgart",germania)
            };
            germania.Cities = Cities1;
            List<City> Cities2;
            Country suedia = new Country("Suedia");
            Cities2 = new List<City>
            {
            new City("Lund",suedia),
            new City("Halmstad",suedia),
            new City("Uppsala",suedia),
            new City("Stockholm",suedia),
            new City("Gotemborg",suedia)
            };
            suedia.Cities = Cities2;
            Countries = new List<Country> {
            romania,
            germania,
            suedia
            };
            Cities = new List<City>();
            Cities.AddRange(Cities1);
            Cities.AddRange(Cities2);
            Cities.AddRange(Cities3);
             List<Category>Categories2 = new List<Category>
            {
                new Category("Relax", "You should come here, if you are stressed"),
                new Category("Amusement", "You should come here, if you want to have fun") };
            List<Category>Categories1=new List<Category>
            {
                new Category("Sports", "You should come here, if you want to be a sportive"), };
            
            Places = new List<Place> {
                new Place("Catelul Martinuzzi","Str.Primaverii,nr.26",Cities[0],Categories2),
                new Place("Conacul Salonti","Str.Albalac",Cities[1],Categories2),
                new Place("Restaurant Tim Raue","Str.Neagra,nr.11",Cities[2],Categories2),
                new Place("Barul Polo","Str.Frumaosei,nr21",Cities[3],Categories2),
                new Place("Paragraf","Str.Alba Iulia,nr21",Cities[4],Categories2),
                new Place("GymPower","Str.Konigstrasse,nr21",Cities1[4],Categories1),
                new Place("GumRel","Str.Bernauer,nr212",Cities1[0],Categories1),
                new Place("Pension","Str Laubusstraße,nr.25",Cities1[2],Categories2),
                new Place("Dracula","Str.Nurembers,nr.11",Cities1[1],Categories2),
                new Place("Mavericks","Str.Bezirk,nr.102",Cities1[3],Categories2),
                new Place("Rauhrackel","StrStora Algatan nr.5,",Cities2[0],Categories2),
                new Place("Mozartstuben","Str.Kaiser Franz Josef-Straße nr25",Cities2[1],Categories2),
            };
            Categories = new List<Category>();
            Categories.AddRange(Categories1);
            Categories.AddRange(Categories2);
            Reviews = new List<Review> {
            new Review(5,Price.Affordable,Places[0]),
            new Review(3,Price.Expensive,Places[1]),
            new Review(4,Price.Cheap,Places[2]),
            new Review(3,Price.Expensive,Places[3]),
            new Review(2,Price.Expensive,Places[4]),
            new Review(3,Price.Expensive,Places[4]),
            new Review(4,Price.Expensive,Places[0]),
            new Review(1,Price.Cheap,Places[5]),
            new Review(2,Price.Affordable,Places[5]),
            new Review(4,Price.Expensive,Places[6]),
            new Review(3,Price.Affordable,Places[6]),
            new Review(2,Price.Cheap,Places[7]),
            new Review(1,Price.Affordable,Places[7]),
            new Review(5,Price.Expensive,Places[8]),
            new Review(5,Price.Expensive,Places[8]),
            new Review(4,Price.Expensive,Places[9]),
            new Review(5,Price.Affordable,Places[9]),
            new Review(5,Price.Affordable,Places[9]),
            new Review(2,Price.Affordable,Places[11]),
            new Review(1,Price.Cheap,Places[11]),
            };
        }
        }
}
