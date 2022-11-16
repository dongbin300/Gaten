using Microsoft.EntityFrameworkCore;

namespace Gaten.Service.FindMissingNumberMainService.Models
{
    [PrimaryKey(nameof(Name))]
    public class ServerInfo
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
