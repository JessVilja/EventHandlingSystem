using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Data
{
    public class DbInitializer
    {
        private readonly EventiaDbContext _ctx;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public DbInitializer(EventiaDbContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _ctx = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        public async Task Initialize()
        {
            await _roleManager.CreateAsync(new IdentityRole("Customer"));
            await _roleManager.CreateAsync(new IdentityRole("Organizer"));
            await _roleManager.CreateAsync(new IdentityRole("Admin"));

            var admin1 = new User()
            {
                FirstName = "Sara",
                LastName = "Johansson",
                UserName = "sara@mail.com",
                Email = "sara@mail.com",

            };

            var admin2 = new User()
            {
                FirstName = "Johanna",
                LastName = "Svensson",
                UserName = "johanna@mail.com",
                Email = "johanna@mail.com",
         
            };
            await _userManager.CreateAsync(admin1, "Passw0rd!");
            await _userManager.CreateAsync(admin2, "Passw0rd#");
            await _userManager.AddToRoleAsync(admin1, "Admin");
            await _userManager.AddToRoleAsync(admin2, "Admin");

            /* var Organizer = new List<User>[]
             {
                 new User
                 {
                     FirstName = "Ryans Travelling Agency",
                     Email = "ryanstravelling@gmail.com",
                     Phone_number = "0730781129"
                 },
                 new User
                 {
                     Name = "Happy Places Travelling",
                     Email = "happyplacestravelling@gmail.com",
                     Phone_number = "0704373051"
                 },
                 new Organizer
                 {
                     Name = "The Theater Tour Company",
                     Email = "ttc@gmail.com",
                     Phone_number = "0723756493"
                 },
             }; 
            */
            var Events = new List<Event>
            {
                new Event
                {
                    Title = "Cabaret",
                    Description =
                        "In a time when the world is changing forever, there is one place where everyone can be free…",
                    Place = "Kit Kat Club", Address = "Northumberland Ave, London WC2N 5DE, United Kingdom",
                    Date = new DateTime(2022, 10, 22), Spots_available = 22,
                   
                },
                new Event
                {
                    Title = "Pretty Woman, The Musical",
                    Description = "The '80s romcom is now a Broadway musical that hits all the right notes",
                    Place = "Savoy Theatre", Address = "Savoy Ct, Strand, London WC2R 0ET, United Kingdom",
                    Date = new DateTime(2022, 09, 10), Spots_available = 165,
           
                },
                new Event
                {
                    Title = "The Book of Mormon",
                    Description =
                        "The Book of Mormon musical follows the journey of two Mormon missionaries who travel to Africa to preach their religion.",
                    Place = "Prince of Wales Theatre", Address = "Coventry St, London W1D 6AS, United Kingdom",
                    Date = new DateTime(2023, 1, 28), Spots_available = 89,
   
                },
                new Event
                {
                    Title = "Disney's The Lion King",
                    Description =
                        "Based on the hit 1994 Walt Disney animated film of the same name, The Lion King musical is set in the African Pridelands and tells the coming of age story of lion cub Simba",
                    Place = "Lyceum Theatre", Address = "21 Wellington St, London WC2E 7RQ, United Kingdom",
                    Date = new DateTime(2022, 6, 5), Spots_available = 245,

                },
            }; 
            /*
            var Attendee = new Attendee[]
            {
                new Attendee
                {
                    Name = "Debbie Reynolds",
                    Email = "debbier@gmail.com",
                    Phone_number = "0765434409",
                },
                new Attendee
                {
                    Name = "Sara Silver",
                    Email = "saras@gmail.com",
                    Phone_number = "0709876625",
             
                },
                new Attendee
                {
                    Name = "Meg Griffin",
                    Email = "meggriffin@gmail.com",
                    Phone_number = "0738973365",
                  
                },
                new Attendee
                {
                    Name = "Lisa Simpson",
                    Email = "lisasimpson@gmail.com",
                    Phone_number = "0727769221",
                  
                }, 

            }; */
            
           await _ctx.AddRangeAsync(Events);
           // await _context.AddRangeAsync(Attendee);
           //await _context.AddRangeAsync(Organizer);
            await _ctx.SaveChangesAsync(); 
        } 
        public async Task Recreate()
        {
            await _ctx.Database.EnsureDeletedAsync();
            await _ctx.Database.EnsureCreatedAsync();
        }

        public async Task RecreateAndSeed()
        {
            await Recreate();
            await Initialize();
        }

        public async Task CreateIfNotExist()
        {
            await _ctx.Database.EnsureCreatedAsync();
        }

        public async Task CreateAndSeedIfNotExist()
        {
            bool didCreateDatabase = await _ctx.Database.EnsureCreatedAsync();
            if (didCreateDatabase)
            {
                await Initialize();
            }
        }
    } 
}
