using System.Data.Entity;

namespace RCodingSchool.App_Start
{
    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            SetDatabaseInitializer(new MyContextInitializer());
        }
    }
}