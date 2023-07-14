using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Persistence
{
   //OBJETO QUE IRÁ ARMAZENAR O ESTADO DO NOSSO BANCO DE DADOS//
    public class DevEventsDbContext : DbContext
    {
        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        { 
        
        }
        
        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> DevEventsSpeaker { get; set; }
        
    }
}
