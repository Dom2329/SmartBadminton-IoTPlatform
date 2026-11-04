
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IoTPlatform.Infrastructure.Data
{
    public class IoTPlatformDbContextFactory : IDesignTimeDbContextFactory<IoTPlatformDbContext>
    {
        //----------------------------------------create database context-----------------------
        public IoTPlatformDbContext CreateDbContext(string[] args)
        {
            // sql server connection
            string connection = @"Server=(localdb)\MSSQLLocalDB;Database=IoTPlatformDb;Trusted_Connection=True;TrustServerCertificate=True;";

            // database options
            var options = new DbContextOptionsBuilder<IoTPlatformDbContext>();

            options.UseSqlServer(connection);

            // return database context
            return new IoTPlatformDbContext(options.Options);
        }
    }
}

