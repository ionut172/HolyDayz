using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository;

namespace Vacante.DataAccess.DbInitializer
{
    public class DBInitializer : IDBInitilizer
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DBInitializer(UserManager<IdentityUser> user, RoleManager<IdentityRole> role, ApplicationDBContext db)
        {
            this._db = db;
            this._userManager = user;
            this._roleManager = role;
        }
        public void Initialize()
        {
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
            if (!_roleManager.RoleExistsAsync("Customer").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Employee")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Company")).GetAwaiter().GetResult();
            }
            _userManager.CreateAsync(new VacanteAPP.Models.ApplicationUser
            {
                UserName = "admin@vacanteAPP.com",
                Email = "admin@vacanteAPP.com",
                Name = "Plesescu Ionut",
                PhoneNumber = "0765843324",
                Adresa = "Giurgiului 164",
                CodPostal = "000000",
                Oras = "Bucuresti",

            }, "Plesescu1!").GetAwaiter().GetResult();
            VacanteAPP.Models.ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@vacanteAPP.com");
            _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }
    }
}

