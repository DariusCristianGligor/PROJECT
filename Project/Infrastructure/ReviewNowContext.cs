using CountryData.Standard;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure
{
    public  class ReviewNowContext:DbContext
    {   
        private readonly string _connString;
        public ReviewNowContext(string connString):base()
        {
            _connString = connString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Domain.Country> Countries { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfig());
           // modelBuilder.ApplyConfigurationsFromAssembly(typeof(CountryConfig).Assembly);
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new PlaceConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            var helper = new CountryHelper();
            var data = helper.GetCountryData();

            var countriesData = data.Select(c => c.CountryName).ToList();
            var countriesDatashortName = data.Select(c => c.CountryShortCode).ToList();
            int i = 0;
            foreach (var country in countriesData)
            {
                var id = System.Guid.NewGuid();
                modelBuilder.Entity<Domain.Country>().HasData(
            new Domain.Country()
            {
                Id = id,
                Name = country,
                ShortName = countriesDatashortName[i]
            }
            );
                var regions = helper.GetRegionByCountryCode(countriesDatashortName[i]);
                foreach (var region in regions)
                {
                    modelBuilder.Entity<Domain.City>().HasData(
                        new City()
                        {
                            Id = System.Guid.NewGuid(),
                            Name = region.Name,
                            CountryId = id
                        }
                        );
                }
                i++;
            }
        }


    }
}
