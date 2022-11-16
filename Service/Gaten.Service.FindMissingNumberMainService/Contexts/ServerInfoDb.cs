using Gaten.Service.FindMissingNumberMainService.Models;

using Microsoft.EntityFrameworkCore;

namespace Gaten.Service.FindMissingNumberMainService.Contexts
{
    public class ServerInfoDb : DbContext
    {
        public ServerInfoDb(DbContextOptions<ServerInfoDb> options) : base(options) { }
        public DbSet<ServerInfo> Data => Set<ServerInfo>();

        public ServerInfoDb Initialize()
        {
            Data.Add(new ServerInfo
            {
                Name = "Gaten Server",
                Status = "OK"
            });

            return this;
        }
    }
}
