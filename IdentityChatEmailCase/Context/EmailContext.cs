using IdentityChatEmailCase.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityChatEmailCase.Context
{
    public class EmailContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Initial Catalog=EmailChatCaseDb; Integrated Security=true; Trust Server Certificate=true");
        }

        public DbSet<Message> Messages { get; set; }
        
    }
}
