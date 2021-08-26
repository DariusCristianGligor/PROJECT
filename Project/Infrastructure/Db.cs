using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace infrastructure
{
    class Db
    {
        public List<City> Cities { get; }
        public List<Country> Countries { get; }
        public List<Category> Categories { get; }
        public List<Place> Claces { get; }
        public List<Review> Reviews { get; }
        public Db()
        { }
            //list<city> cities3;

            //country romania = new country("romania");
            //cities3 = new list<city>
            //{
            //new city("alba iulia",romania)
            //new city("sibiu",romania),
            //new city("timisoara",romania),
            //new city("cluj-napoca",romania),
            //new city("bucuresti",romania)
            //};
            //romania.cities = cities3;
            //list<city> cities1;
            //country germania = new country("germania");
            //cities1 = new list<city>
            //{
            //new city("berlin",germania),
            //new city("hamburg",germania),
            //new city("munchen",germania),
            //new city("nunberg",germania),
            //new city("stuttgart",germania)
            //};
            //germania.cities = cities1;
            //list<city> cities2;
            //country suedia = new country("suedia");
            //cities2 = new list<city>
            //{
            //new city("lund",suedia),
            //new city("halmstad",suedia),
            //new city("uppsala",suedia),
            //new city("stockholm",suedia),
            //new city("gotemborg",suedia)
            //};
            //suedia.cities = cities2;
            //countries = new list<country> {
            //romania,
            //germania,
            //suedia
            //};
            //cities = new list<city>();
            //cities.addrange(cities1);
            //cities.addrange(cities2);
            //cities.addrange(cities3);
            //list<category> categories2 = new list<category>
            //{
            //    new category("relax", "you should come here, if you are stressed"),
            //    new category("amusement", "you should come here, if you want to have fun") };
            //list<category> categories1 = new list<category>
            //{
            //    new category("sports", "you should come here, if you want to be a sportive"), };

            //places = new list<place> {
            //    new place("catelul martinuzzi","str.primaverii,nr.26",cities[0],categories2),
            //    new place("conacul salonti","str.albalac",cities[1],categories2),
            //    new place("restaurant tim raue","str.neagra,nr.11",cities[2],categories2),
            //    new place("barul polo","str.frumaosei,nr21",cities[3],categories2),
            //    new place("paragraf","str.alba iulia,nr21",cities[4],categories2),
            //    new place("gympower","str.konigstrasse,nr21",cities1[4],categories1),
            //    new place("gumrel","str.bernauer,nr212",cities1[0],categories1),
            //    new place("pension","str laubusstraße,nr.25",cities1[2],categories2),
            //    new place("dracula","str.nurembers,nr.11",cities1[1],categories2),
            //    new place("mavericks","str.bezirk,nr.102",cities1[3],categories2),
            //    new place("rauhrackel","strstora algatan nr.5,",cities2[0],categories2),
            //    new place("mozartstuben","str.kaiser franz josef-straße nr25",cities2[1],categories2),
            //};
            //categories = new list<category>();
            //categories.addrange(categories1);
            //categories.addrange(categories2);
            //reviews = new list<review> {
            //new review(5,price.affordable,places[0]),
            //new review(3,price.expensive,places[1]),
            //new review(4,price.cheap,places[2]),
            //new review(3,price.expensive,places[3]),
            //new review(2,price.expensive,places[4]),
            //new review(3,price.expensive,places[4]),
            //new review(4,price.expensive,places[0]),
            //new review(1,price.cheap,places[5]),
            //new review(2,price.affordable,places[5]),
            //new review(4,price.expensive,places[6]),
            //new review(3,price.affordable,places[6]),
            //new review(2,price.cheap,places[7]),
            //new review(1,price.affordable,places[7]),
            //new review(5,price.expensive,places[8]),
            //new review(5,price.expensive,places[8]),
            //new review(4,price.expensive,places[9]),
            //new review(5,price.affordable,places[9]),
            //new review(5,price.affordable,places[9]),
            //new review(2,price.affordable,places[11]),
            //new review(1,price.cheap,places[11]),
    }
}