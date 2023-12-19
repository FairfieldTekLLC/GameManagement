using Microsoft.EntityFrameworkCore;

namespace GameManager.Models
{
    public partial class GameManagementContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=fftsql02;Initial Catalog=GameManagement;Integrated Security=True;TrustServerCertificate=true;");
    }
}
