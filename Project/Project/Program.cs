using CountryData.Standard;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Domain;
namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Transaction();
            EagerLoading();
            NPlusOneProblem();
            LeftJoinFunction();
            InnerJoin();
            GetAllPlacesOrderedByRating();
            WriteDiferentTypesOfqueries();
                //tranzaction begin
                //using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                //{
                //    try 
                //    {
                //        var query = dbContext.Countries.Where(x=>x.ShortName.Contains("T"));
                //        foreach (var shortName in query)
                //        {
                //            shortName.ShortName = null;
                //        }
                //        dbContext.SaveChanges();
                //        dbContextTransaction.Commit();
                //    }

            //    catch (Exception)
            //    {
            //        dbContextTransaction.Rollback();
            //    }

            //}
            //tranzactionend

            static void Transaction()
            {
                var connString = @"Server=LAPTOP-R308IB89\SQLEXPRESS;Database=ReviewWithSeed1;Trusted_Connection=True;";
                using (var dbContext = new ReviewNowContext(connString))
                {

                    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            var query = dbContext.Countries.Where(x => x.ShortName.Contains("T"));
                            foreach (var shortName in query)
                            {
                                shortName.ShortName = null;
                            }
                            dbContext.SaveChanges();
                            dbContextTransaction.Commit();
                        }

                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }

                }
            }
            static void EagerLoading()
            {

                var connString = @"Server=LAPTOP-R308IB89\SQLEXPRESS;Database=ReviewWithSeed1;Trusted_Connection=True;";
                using (var dbContext = new ReviewNowContext(connString))
                {
                    CountryRepository countryRepository = new CountryRepository(dbContext);
                    List<Domain.Country> countries = countryRepository.GetAllCountriesWithCities();
                    foreach (var country in countries)
                    {
                        Console.WriteLine($"Country:{country.Name} with cities:");
                        foreach (var city in country.Cities)
                        {
                            Console.WriteLine(city.Name);
                        }
                    }
                }
            }
            static void NPlusOneProblem()
            {
                var connString = @"Server=LAPTOP-R308IB89\SQLEXPRESS;Database=ReviewWithSeed1;Trusted_Connection=True;";
                using (var dbContext = new ReviewNowContext(connString))
                {   
                    foreach (Domain.Country country in dbContext.Countries)
                    {
                        Console.WriteLine($"Country:{country.Name} with cities:");
                        //foreach (var city in country.Cities)
                        //{
                        //    Console.WriteLine(city.Name);
                        //}
                    }

                }

            }
            static void LeftJoinFunction()
            {
                Console.WriteLine("LeftJoin::--------------------------------------");
                var connString = @"Server=LAPTOP-R308IB89\SQLEXPRESS;Database=ReviewWithSeed1;Trusted_Connection=True;";
                using (var dbContext = new ReviewNowContext(connString)) {
                    IQueryable<City> outer = dbContext.Cities;
                    IQueryable<Domain.Country> inner = dbContext.Countries;

                    var nameCitiesAndNameCountri =
                        from city in outer
                        join country in inner
                        on city.CountryId equals country.Id into cityAndCountry
                        from country in cityAndCountry.DefaultIfEmpty()
                        select new { City = city.Name, Country = country.Name, ShortName = country.ShortName,NumberOfRegion=country.Cities.Count };
                    foreach (var a in nameCitiesAndNameCountri)
                    {
                        Console.WriteLine($"{a.ShortName}::{a.Country}::{a.City}::{a.NumberOfRegion}");
                    }
                }
            }
            static void InnerJoin()
            {
                var connString = @"Server=LAPTOP-R308IB89\SQLEXPRESS;Database=ReviewWithSeed1;Trusted_Connection=True;";
                using (var dbContext = new ReviewNowContext(connString))
                {
                    IQueryable<City> outer = dbContext.Cities;
                    IQueryable<Domain.Country> inner = dbContext.Countries;

                    var nameCitiesAndNameCountri =
                        from city in outer
                        join country in inner
                        on city.Id equals country.Id
                        select new { City = city.Name, Country = country.Name, ShortName = country.ShortName };
                    foreach (var a in nameCitiesAndNameCountri)
                    {
                        Console.WriteLine($"{a.ShortName}::{a.Country}::{a.City}");
                    }

                }

            }
            static ICollection<Place> GetAllPlacesOrderedByRating()
            {
                var connString = @"Server=LAPTOP-R308IB89\SQLEXPRESS;Database=ReviewWithSeed1;Trusted_Connection=True;";
                using (var dbContext = new ReviewNowContext(connString))
                {
                    PlaceRepository placeRepository = new PlaceRepository(dbContext);
                    return placeRepository.GetAllOrderedByRating();
                    
                }
            }
            static void WriteDiferentTypesOfqueries()
            {
                var connString = @"Server=LAPTOP-R308IB89\SQLEXPRESS;Database=ReviewWithSeed1;Trusted_Connection=True;";
                using (var dbContext = new ReviewNowContext(connString))
                {
           
                    var reviewss1 = dbContext.Reviews
                        .AsEnumerable()
                        .GroupBy(x => x.PlaceId);
                    foreach (var a in reviewss1)
                    {
                        Console.WriteLine(a.Key);
                    }
                    var reviewss2 = dbContext.Reviews
                        .AsEnumerable()
                        .Where(x => x.Stars > 3)
                        .GroupBy(x => new { x.PlaceId, x.Stars, x.CostOfPlace })
                        .OrderBy(g => g.Average(x=>x.Stars));

                    foreach (var a in reviewss2)
                    {
                        Console.WriteLine($"{a}");
                        foreach (var x in a)
                        {
                            Console.WriteLine($"{x.CostOfPlace}::{x.Stars}");
                        }
                    }
                    var reviewss3 = dbContext.Reviews
                        .AsEnumerable()
                        .Where(x => x.Stars > 3)
                        .GroupBy(x => new { x.PlaceId, x.Stars, x.CostOfPlace })
                        .OrderByDescending(g => g.Count());
                    foreach (var a in reviewss3)
                    {
                        Console.WriteLine($"{a}");
                        foreach (var x in a)
                        {
                            Console.WriteLine($"{x.CostOfPlace}::{x.Stars}::");
                        }
                    }
                    var reviewss4 = dbContext.Reviews
                        .AsEnumerable()
                        .GroupBy(x => x.PlaceId)
                        .Select(x => new
                        {
                            NameId = x.Key,
                            Average = x.Average(y => y.Stars),
                            ReviewCount = x.Count()
                        }
                        );
                    foreach (var a in reviewss4)
                    {
                        Console.WriteLine($"{a.NameId}::{a.Average}::{a.ReviewCount}");
                    }
                    Console.WriteLine("-----------------------------------------");
                    foreach (var a in reviewss4)
                    {
                        Console.WriteLine($"{a.NameId}::{a.Average}::{a.ReviewCount}");
                    }
                    Console.WriteLine("-----------------------------------------");
                    var reviewss5 = dbContext.Places.Where(x => x.Reviews.All(y => y.Stars >= 4));
                    foreach (var a in reviewss5)
                    {
                        Console.WriteLine($"{a.Name}");
                    }
                    Console.WriteLine("-----------------------------------------");
                    var reviewss6 = dbContext.Places.Where(x => x.Reviews.Any(y => y.Stars >= 4.2));
                    foreach (var a in reviewss6)
                    {
                        Console.WriteLine($"{a.Name}");
                    }
                    var reviewss7 = dbContext.Places.AsEnumerable().Where(x => x.Reviews.ToList().Exists(y => y.Stars >= 4.2));
                    foreach (var a in reviewss7)
                    {
                        Console.WriteLine($"{a.Name}");
                    }
                }

            }
            //dbContext.Database.EnsureCreated();
            //CategoryRepository categoryRepository = new CategoryRepository(dbContext);
            //Category category1 = new Category
            //{
            //    Name = "Fun",
            //    Id = new Guid(),
            //    Description = "You could come here if you want to party"
            //};
            //categoryRepository.AddCategory(category1);
            //List < Category >categories= new List<Category>();
            //categories.Add(category1);

            //Category category2 = new Category
            //{
            //    Name = "Amusementt",
            //    Id = new Guid(),
            //    Description = "You could come here if you want to joke"
            //};
            //categoryRepository.AddCategory(category2);
            //Category category3 = new Category
            //{
            //    Name = "asdasdasd",
            //    Id = new Guid(),
            //    Description = "You could come here if you want to asdasdas"
            //};
            //categoryRepository.AddCategory(category3);
            //Domain.Country country = new Domain.Country
            //{
            //    Id = new Guid(),
            //    Name = "Romania",

            //};
            //CountryRepository countryRepository = new CountryRepository(dbContext);
            //countryRepository.AddCountry(country);
            //categories.Add(category2);
            //City city1 = new City
            //{
            //    Name = "Alba",
            //    Id = new Guid(),
            //};
            //City city2 = new City
            //{
            //    Name = "Sibiu",
            //    Id = new Guid(),
            //};
            //City city3 = new City
            //{
            //    Name = "Timisoara",
            //    Id = new Guid(),
            //};
            //City city4 = new City
            //{
            //    Name = "Bucuresti",
            //    Id = new Guid(),
            //};
            //ICollection<City> cities = new List<City>();
            //cities.Add(city1);
            //cities.Add(city2);
            //cities.Add(city3);
            //cities.Add(city4);
            //city1.Country = country;
            //city2.Country = country;
            //city3.Country = country;
            //city4.Country = country;
            //CityRepository cityRepository = new CityRepository(dbContext);
            //cityRepository.AddCity(city1);
            //cityRepository.AddCity(city2);
            //cityRepository.AddCity(city3);
            //cityRepository.AddCity(city4);
            //Place martinuzzi = new Place
            //{
            //    Id = new Guid(),
            //    Name = "Martinuzzi",
            //    CityId = city1.Id,
            //    Rating = 0,
            //    AvgStars = 0,
            //    Categories = categories,
            //    Address = "str.Alba,nr22",
            //    NumberOfReview = 0,
            //    City = city1,
            //};
            //city1.Places = new List<Place>();
            //city1.Places.Add(martinuzzi);
            //PlaceRepository placeRepository = new PlaceRepository(dbContext);
            //placeRepository.AddPlace(martinuzzi);
            //Review review = new Review
            //{
            //    Id = new Guid(),
            //    Stars = 4,
            //    Place = martinuzzi,
            //    PlaceId = martinuzzi.Id,
            //    CostOfPlace = Price.Affordable
            //};
            //martinuzzi.Reviews = new List<Review>();

            //Review review1 = new Review
            //{
            //    Id = new Guid(),
            //    Stars = 5,
            //    Place = martinuzzi,
            //    PlaceId = martinuzzi.Id,
            //    CostOfPlace = Price.Affordable
            //};

            //ReviewRepository reviewRepository = new ReviewRepository(dbContext);
            //reviewRepository.Add(review);
            //reviewRepository.Add(review1);
            ////////////////////////////////////////////////
            //List<Review> revv = new List<Review>();
            //revv.Add(review);
            //martinuzzi.Reviews = revv;
            //CityRepository cityRepository = new CityRepository(dbContext);
            //cityRepository.AddCity(city1);
            //cityRepository.AddCity(city2);
            //cityRepository.AddCity(city3);
            //cityRepository.AddCity(city4);
            //PlaceRepository placeRepository = new PlaceRepository(dbContext);
            //placeRepository.AddPlace(martinuzzi);
            //ReviewRepository reviewRepository = new ReviewRepository(dbContext);
            //reviewRepository.Add(review);
            //categoryRepository.AddCategory(category2);

            //Console.WriteLine("Doneeee");
            //ICollection<Guid> categoriesId = new List<Guid>();
            //categoriesId.Add(category3.Id);
            ////categoriesId.Add(category1.Id);
            //ICollection<Place> result= placeRepository.GetAllByCityIdAndCategoryId(city1.Id,categoriesId);
            //foreach(Place a in result)
            //{
            //    Console.WriteLine(a);
            //}



            //Guid asd = new Guid();
            //PlaceRepository place= new PlaceRepository();
            ////List<Place> places = place.GetAllByCityId(asd);
            ////foreach(Place i in places)
            ////{
            ////    Console.WriteLine(i);
            ////}
            //City c = new City("asdasdasdasdasd");
            //Place pl = new Place("aaaaaaaaaaa","bbbbbbbbbbb",c);
            //Review rew=new Review(3, Price.Affordable, pl);
            //ReviewRepository rep = new ReviewRepository();
            //rep.Add(rew);
            //List<Review> reviews = new List<Review>();
            //reviews= rep.GetReviews(pl);
            //foreach (Review r in reviews)
            //{
            //    Console.WriteLine(r);
            //}
            //City city = new City("Alba");
            //Place place = new Place("Catelul Martinuzzi", "Str.Primaverii,nr.26", city);
            //Review rev = new Review(4, Price.Affordable, place);
            //Review rev1 = rev;
            //Console.WriteLine(rev == rev1);
            //Console.WriteLine("asdasd");
            //string aa = getAllCountries();
            //Console.WriteLine(aa);
            //getAllRegionByCountry(aa);

            //DataBaseSingleton a = new DataBaseSingleton();
            //a.Add();
            //a.Add();
            //DataBaseSingleton b = new DataBaseSingleton();
            //Console.WriteLine(a.Added() == b.Added());

            ////proxyFct();

            ////Decade
            ////var simple = new CategoryDecoratorConcret("Restaurant","you can eat");
            ////CategoryEat decoartor1 = new CategoryEat(simple);
            ////CategoryRelax decorator2 = new CategoryRelax(decoartor1);
            ////var simple2 = new CategoryDecoratorConcret("Restaurant2", "you can eat");
            ////CategoryRelax decoratorsimple2 = new CategoryRelax(simple2);
            ////CategoryEat decoartor2simple2 = new CategoryEat(decoratorsimple2);
            ////client(decoartor2simple2);
            ////client(decorator2);
            ////endDecade
            //ServiceLocator.RegisterAll();
            //var userSerice = ServiceLocator.Resolve<WriteWithOracle>();
            //var userSerice2 = ServiceLocator.Resolve<WriteWithSqlServer>();
            //User user = new User("Marianaaaaaaaaaaaaaaaaaaaaaaaa", "marian@yahoo.com", "asdasd", "LPX52qqqaz", userSerice);
            //User user2 = new User("Marian", "marian@yahoo.com", "asdasd", "LPX52qqqaz", userSerice2);
            ////ServiceLocator.RegisterAll();
            //user.WriteInDataBaze();
            //user2.WriteInDataBaze();
            //////testaplicatie
            ////Console.WriteLine("What do you want to do? \n Select:\n1-to create a new user\n2-to create a country\n3-to create a city \n4-to create a place \n5- to create a category\n6-to create a review");

            ////int choice = int.Parse(Console.ReadLine());

            ////if (choice == 1)
            ////{
            ////    var user = createUser();
            ////    Console.WriteLine(user);
            ////}
            ////else if (choice == 2)
            ////{
            ////    var country = createCounty();
            ////    Console.WriteLine(country);
            ////}
            ////else if (choice == 3)
            ////{
            ////    var city = createCity();
            ////    Console.WriteLine(city);
            ////}
            ////else if (choice == 4)
            ////{
            ////    var place = createPlace();
            ////    Console.WriteLine(place);

            ////}
            ////else if (choice == 5)
            ////{
            ////    var category = createCategory();
            ////    Console.WriteLine(category);
            ////}
            ////else if (choice == 6)
            ////{
            ////    var review = CreateReview();
            ////    Console.WriteLine(review);
            ////}
            ///////endoftest

            ////List < string >countryList= GetCountryList();

            ////foreach (var a in countryList)
            ////{
            ////    Console.WriteLine(a);
            ////}
            ////Console.WriteLine(countryList.Count);



        }
        public static ICollection<Category> GetAllCategories(ReviewNowContext dbContext)
        {
            var categoryRepository = new CategoryRepository(dbContext);
            return categoryRepository.GetAll();
        }
        public static void AddPlace(ReviewNowContext dbContext,Place place)
        {
            var placeRepository = new PlaceRepository(dbContext);
            placeRepository.AddPlace(place);
        }
        public static void AddPlace(ReviewNowContext dbContext, Place place, Review review)
        {
            var placeRepository = new PlaceRepository(dbContext);
            placeRepository.AddPlace(place);
            var reviewRepostory = new ReviewRepository(dbContext);
            reviewRepostory.Add(review);
        }
        public static ICollection<Place> GetAllPlacesByCityId(ReviewNowContext dbContext,Guid city)
        { 
            var placeRepository = new PlaceRepository(dbContext);
            return placeRepository.GetAllByCityId(city);
        }
        public static ICollection<Place> GetAllPlacesByCityIdAndCategoryId(ReviewNowContext dbContext, Guid city, ICollection<Guid> categories)
        {
            var placeRepository = new PlaceRepository(dbContext);
            return placeRepository.GetAllByCityIdAndCategoryId(city,categories);
        }
        public static ICollection<Place> GetAllPlacesByCategory(ReviewNowContext dbContext,ICollection<Guid> categories)
        {
            var placeRepository = new PlaceRepository(dbContext);
            return placeRepository.GetAllByCategoryId(categories);
        }
        public static ICollection<Place> GetAllPlacesByCategoryIdAndCountryId(ReviewNowContext dbContext, ICollection<Guid> categories,Guid CountryId)
        {
            var placeRepository = new PlaceRepository(dbContext);
            return placeRepository.GetAllByCategoryIdAndCountryId(categories,CountryId);
        }
        //public static List<string> GetCountryList()
        //{
        //    List<string> cultureList = new List<string>();
        //    CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        //    foreach (CultureInfo culture in cultures)
        //    {
        //        RegionInfo region = new RegionInfo(culture.LCID);

        //        if (!(cultureList.Contains(region.EnglishName)))
        //        {
        //            cultureList.Add(region.EnglishName);
        //        }
        //    }
        //    cultureList.Sort();
        //    return cultureList;
        //}
        //public static User createUser()
        //{

        //    Console.WriteLine("Enter your name:");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Enter your mail:");
        //    string mail = Console.ReadLine();
        //    Console.WriteLine("Enter your address:");
        //    string address = Console.ReadLine();
        //    Console.WriteLine("Enter your password:");
        //    string password = Console.ReadLine();
        //    User user = new User(name, mail, address, password, new WriteWithOracle());
        //    return user;
        //}
        //public static Country createCounty()
        //{
        //    Console.WriteLine("Enter the country name:");
        //    string name = Console.ReadLine();
        //    Country country = new Country(name);
        //    return country;
        //}
        //public static City createCity()
        //{
        //    Console.WriteLine("Enter the city name:");
        //    string name = Console.ReadLine();
        //    City city = new City(name);
        //    return city;
        //}
        //public static Place createPlace()
        //{
        //    Console.WriteLine("Enter the place name:");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Enter the place address:");
        //    string address = Console.ReadLine();
        //    City city = createCity();
        //    Place place = new Place(name, address, city.IdCity);
        //    return place;
        //}
        //public static Category createCategory()
        //{
        //    Console.WriteLine("Enter the category name:");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Enter the description of category:");
        //    string description = Console.ReadLine();
        //    Category category = new Category(name, description);
        //    return category;
        //}
        //public static Review CreateReview()
        //{
        //    Place place = createPlace();
        //    Category category = createCategory();
        //    Console.WriteLine("Enter the note of place:");
        //    float note = float.Parse(Console.ReadLine());
        //    Console.WriteLine("Select how expensive the place is:\n1) Cheap \n2)Medium \n3) Expensive");
        //    int expensive = int.Parse(Console.ReadLine());
        //    Review review;
        //    if (expensive == 1)
        //    {
        //        review = new Review(note, Price.Cheap, place, category);
        //    }
        //    else if (expensive == 2)
        //    {
        //        review = new Review(note, Price.Affordable, place, category);
        //    }
        //    else
        //    {
        //        review = new Review(note, Price.Expensive, place, category);
        //    }
        //    return review;
        //}

        //public static void proxyFct()
        //{
        //    Console.WriteLine("Enter your name:");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Enter your mail:");
        //    string mail = Console.ReadLine();
        //    Console.WriteLine("Enter your address:");
        //    string address = Console.ReadLine();
        //    Console.WriteLine("Enter your password:");
        //    string password = Console.ReadLine();
        //    IUser user = new Userr(name, mail, address, password);
        //    IUser userProxy = new ProxyU(user);
        //    userProxy.changeThePassword("madaaaaaaaaa");

        //}
        //public static void client(CategoryComponent component)
        //{
        //    Console.WriteLine("RESULT: " + component.addToDescription());
        //}
        //public static string getAllCountries()
        //{
        //    var helper = new CountryHelper();
        //    var data = helper.GetCountryData();

        //    var countriesData = data.Select(c => c.CountryName).ToList();
        //    var countriesShort = data.Select(c => c.CountryShortCode).ToList();
        //    int i = 1;
        //    foreach (var country in countriesData)
        //    {
        //        Console.Write($"{i}.");
        //        Console.WriteLine(country);
        //        i++;
        //    }
        //    i = 1;
        //    foreach (var countryshort in countriesShort)
        //    {
        //        Console.Write($"{i}.");
        //        Console.WriteLine(countryshort);
        //        i++;
        //    }
        //    Console.WriteLine("Select the country number:");
        //    int a = int.Parse(Console.ReadLine());
        //    return countriesShort[--a];
        //}

        //public static void getAllRegionByCountry(string country)
        //{
        //    var helper = new CountryHelper();
        //    var regions = helper.GetRegionByCountryCode(country);
        //    foreach (var region in regions)
        //    {
        //        Console.WriteLine(region.Name);
        //    }
        //}
    }
}

