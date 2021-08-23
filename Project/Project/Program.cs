using CountryData.Standard;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string aa= getAllCountries();
            Console.WriteLine(aa);
            getAllRegionByCountry(aa);

            DataBaseSingleton a = new DataBaseSingleton();
            a.Add();
            a.Add();
            DataBaseSingleton b = new DataBaseSingleton();
            Console.WriteLine(a.Added()==b.Added());

            //proxyFct();

            //Decade
            //var simple = new CategoryDecoratorConcret("Restaurant","you can eat");
            //CategoryEat decoartor1 = new CategoryEat(simple);
            //CategoryRelax decorator2 = new CategoryRelax(decoartor1);
            //var simple2 = new CategoryDecoratorConcret("Restaurant2", "you can eat");
            //CategoryRelax decoratorsimple2 = new CategoryRelax(simple2);
            //CategoryEat decoartor2simple2 = new CategoryEat(decoratorsimple2);
            //client(decoartor2simple2);
            //client(decorator2);
            //endDecade
            ServiceLocator.RegisterAll();
            var userSerice = ServiceLocator.Resolve<WriteWithOracle>();
            var userSerice2 = ServiceLocator.Resolve<WriteWithSqlServer>();
            User user = new User("Marian", "marian@yahoo.com","asdasd" ,"LPX52qqqaz", userSerice);
            User user2 = new User("Marian", "marian@yahoo.com","asdasd" ,"LPX52qqqaz", userSerice2);
            //ServiceLocator.RegisterAll();
            user.WriteInDataBaze();
            user2.WriteInDataBaze();
            ////testaplicatie
            //Console.WriteLine("What do you want to do? \n Select:\n1-to create a new user\n2-to create a country\n3-to create a city \n4-to create a place \n5- to create a category\n6-to create a review");

            //int choice = int.Parse(Console.ReadLine());

            //if (choice == 1)
            //{
            //    var user = createUser();
            //    Console.WriteLine(user);
            //}
            //else if (choice == 2)
            //{
            //    var country = createCounty();
            //    Console.WriteLine(country);
            //}
            //else if (choice == 3)
            //{
            //    var city = createCity();
            //    Console.WriteLine(city);
            //}
            //else if (choice == 4)
            //{
            //    var place = createPlace();
            //    Console.WriteLine(place);

            //}
            //else if (choice == 5)
            //{
            //    var category = createCategory();
            //    Console.WriteLine(category);
            //}
            //else if (choice == 6)
            //{
            //    var review = CreateReview();
            //    Console.WriteLine(review);
            //}
            /////endoftest
            
            //List < string >countryList= GetCountryList();
           
            //foreach (var a in countryList)
            //{
            //    Console.WriteLine(a);
            //}
            //Console.WriteLine(countryList.Count);



        }

        public static List<string> GetCountryList()
        {
            List<string> cultureList = new List<string>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(cultureList.Contains(region.EnglishName)))
                {
                    cultureList.Add(region.EnglishName);
                }
            }
            cultureList.Sort();
            return cultureList;
        }
        public static User createUser()
        {

            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your mail:");
            string mail = Console.ReadLine();
            Console.WriteLine("Enter your address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            User user = new User(name,mail,address,password,new WriteWithOracle());
            return user;
        }
        public static Country createCounty()
        {
            Console.WriteLine("Enter the country name:");
            string name = Console.ReadLine();
            Country country = new Country(name);
            return country;
        }
        public static City createCity()
        {
            Console.WriteLine("Enter the city name:");
            string name = Console.ReadLine();
            City city = new City(name);
            return city;
        }
        public static Place createPlace()
        {
            Console.WriteLine("Enter the place name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the place address:");
            string address = Console.ReadLine();
            City city=createCity();
            Place place = new Place(name, address, city.IdCity);
            return place;
        }
        public static Category createCategory()
        {
            Console.WriteLine("Enter the category name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the description of category:");
            string description = Console.ReadLine();
            Category category = new Category(name, description);
            return category;
        }
        public static Review CreateReview()
        {
            Place place = createPlace();
            Category category = createCategory();
            Console.WriteLine("Enter the note of place:");
            float note = float.Parse(Console.ReadLine());
            Console.WriteLine("Select how expensive the place is:\n1) Cheap \n2)Medium \n3) Expensive");
            int expensive = int.Parse(Console.ReadLine());
            Review review;
            if (expensive == 1)
            {
                review = new Review(note, Price.Cheap, place, category);
            }
            else if (expensive == 2)
            {
                review = new Review(note, Price.Affordable, place, category);
            }
            else
            { 
            review=new Review(note, Price.Expensive, place, category);
            }
            return review;
        }

        public static void proxyFct()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your mail:");
            string mail = Console.ReadLine();
            Console.WriteLine("Enter your address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            IUser user = new Userr(name, mail, address, password);
            IUser userProxy = new ProxyU(user);
            userProxy.changeThePassword("madaaaaaaaaa");
        
        }
        public static void client(CategoryComponent component)
        {
            Console.WriteLine("RESULT: " + component.addToDescription());
        }
        public static string getAllCountries()
        {
            var helper = new CountryHelper();
            var data = helper.GetCountryData();
            
            var countriesData = data.Select(c => c.CountryName).ToList();
            var countriesShort = data.Select(c => c.CountryShortCode).ToList();
            int i = 1;
            foreach (var country in countriesData)
            {
                Console.Write($"{i}.");
                Console.WriteLine(country);
                i++;
            }
            i = 1;
            foreach (var countryshort in countriesShort)
            {
                Console.Write($"{i}.");
                Console.WriteLine(countryshort);
                i++;
            }
            Console.WriteLine("Select the country number:");
            int a= int.Parse(Console.ReadLine());
            return countriesShort[--a];
        }

        public static void getAllRegionByCountry(string country)
        {
            var helper = new CountryHelper();
            var regions = helper.GetRegionByCountryCode(country);
            foreach (var region in regions)
            {
                Console.WriteLine(region.Name);
            }
        }
    }
}

