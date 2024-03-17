using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.DbInitializer
{
    // Class responsible for initializing the database
    public class DbInitializer : IDbInitializer
    {
        // Fields to manage users, roles, and database context
        private readonly UserManager<IdentityUser> _userManager; // Manages user accounts
        private readonly RoleManager<IdentityRole> _roleManager; // Manages roles
        private readonly ApplicationDbContext _db; // Database context

        // Constructor to initialize the class with required services
        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, 
            ApplicationDbContext db 
            )
        {
            _userManager = userManager; 
            _roleManager = roleManager;
            _db = db; 
        }

        public void Initialize()
        {
            //migrations if they are not applied.
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
            //create roles if they are not created

            if (!_roleManager.RoleExistsAsync(StaticDetails.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_User_Indi)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_User_Comp)).GetAwaiter().GetResult();

                //if roles are not created, then we will create admin user as well.

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@username",
                    Email = "admin@example.com",
                    Name = "Mark Max",
                    PhoneNumber = "5247610641",
                    StreetAddress = "10 demo St",
                    State = "NY",
                    PostalCode = "61423",
                    City = "New York"
                }, "Admin@123").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@example.com");

                _userManager.AddToRoleAsync(user, StaticDetails.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
