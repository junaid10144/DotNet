using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace IdentityManagerServerApi.Data
{
    //public class AppDbContext: IdentityDbContext
    //{
    //    public AppDbContext(DbContextOptions options): base(options)
    //    {

    //    }
    //}

    public class AppDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
    {

    }
}
