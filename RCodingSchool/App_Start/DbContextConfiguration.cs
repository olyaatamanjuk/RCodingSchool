using System.Data.Entity;

namespace StudLine.App_Start
{
    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            SetDatabaseInitializer(new MyContextInitializer());
        }
    }
}