using Microsoft.EntityFrameworkCore;
using System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<IndividualClient> IndividualClients { get; set; }
    public DbSet<CompanyClient> CompanyClients { get; set; }
    public DbSet<Software> SoftwareLicenses { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<SoftwareContract> Contracts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IndividualClient>().HasData(
            new IndividualClient { Id = 1, Address = "Konwiktorska 1", Email = "polonia@gmail.com", PhoneNumber = "1234567890", FirstName = "Fra", LastName = "Jer", PESEL = "12345678901" },
            new IndividualClient { Id = 2, Address = "Barcelona 10", Email = "leo.messi@gmail.com", PhoneNumber = "0987654321", FirstName = "Leo", LastName = "Messi", PESEL = "10987654321" },
            new IndividualClient { Id = 3, Address = "Madrid 7", Email = "cristron@gmail.com", PhoneNumber = "1234509876", FirstName = "Cristiano", LastName = "Ronaldo", PESEL = "12345098765" },
            new IndividualClient { Id = 4, Address = "Goralska 3", Email = "goral@gmail.com", PhoneNumber = "0987612345", FirstName = "God", LastName = "Thiago", PESEL = "09876123450" }
        );

        modelBuilder.Entity<CompanyClient>().HasData(
            new CompanyClient { Id = 5, Address = "Lazienkowska 3", Email = "company1@gmail.com", PhoneNumber = "1111111111", CompanyName = "Legia Warszawa", KRS = "12345678953" },
            new CompanyClient { Id = 6, Address = "Marysin 4", Email = "company2@gmail.com", PhoneNumber = "2222222222", CompanyName = "FC Barcelona", KRS = "987654321" },
            new CompanyClient { Id = 7, Address = "Mantra 2", Email = "company3@gmail.com", PhoneNumber = "3333333333", CompanyName = "Nike", KRS = "123123123" },
            new CompanyClient { Id = 8, Address = "Slojewskiego 214", Email = "company4@gmail.com", PhoneNumber = "4444444444", CompanyName = "Levis", KRS = "321321321" }
        );

        modelBuilder.Entity<Software>().HasData(
            new Software { Id = 1, Name = "Software One", Price = 100m, Version = "1.1", Category = "Finance" },
            new Software { Id = 2, Name = "Software Two", Price = 200m, Version = "2.6", Category = "Education" },
            new Software { Id = 3, Name = "Software Three", Price = 300m, Version = "3.9", Category = "Healthcare" },
            new Software { Id = 4, Name = "Software Four", Price = 400m, Version = "4.0.5", Category = "Sport" }
        );

        modelBuilder.Entity<Discount>().HasData(
            new Discount { Id = 1, Name = "Black Friday", Percentage = 10m, StartDate = new DateTime(2023, 11, 24), EndDate = new DateTime(2023, 11, 24), ProductId = 1 },
            new Discount { Id = 2, Name = "Cyber Monday", Percentage = 15m, StartDate = new DateTime(2023, 11, 27), EndDate = new DateTime(2023, 11, 27), ProductId = 2 },
            new Discount { Id = 3, Name = "Christmas", Percentage = 20m, StartDate = new DateTime(2023, 12, 25), EndDate = new DateTime(2023, 12, 25), ProductId = 3 },
            new Discount { Id = 4, Name = "New Year Sale", Percentage = 25m, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 1), ProductId = 4 }
        );

        modelBuilder.Entity<SoftwareContract>().HasData(
            new SoftwareContract { Id = 1, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 12, 31), Price = 500m, IsPaid = true, SoftwareId = 1, ClientId = 1 },
            new SoftwareContract { Id = 2, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 10, 3), Price = 600m, IsPaid = true, SoftwareId = 2, ClientId = 2 },
            new SoftwareContract { Id = 3, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 7, 19), Price = 700m, IsPaid = false, SoftwareId = 3, ClientId = 3 },
            new SoftwareContract { Id = 4, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 3, 5), Price = 800m, IsPaid = true, SoftwareId = 4, ClientId = 4 }
        );

        modelBuilder.Entity<Payment>().HasData(
            new Payment { Id = 1, PaymentDate = new DateTime(2024, 1, 1), Amount = 500m, ContractId = 1 },
            new Payment { Id = 2, PaymentDate = new DateTime(2024, 1, 2), Amount = 600m, ContractId = 2 },
            //new Payment { Id = 3, PaymentDate = new DateTime(2024, 2, 25), Amount = 700m, ContractId = 3 },
            new Payment { Id = 4, PaymentDate = new DateTime(2024, 1, 9), Amount = 800m, ContractId = 4 }
        );
    }
}
