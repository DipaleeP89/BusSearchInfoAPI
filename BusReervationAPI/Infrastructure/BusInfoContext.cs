using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusReervationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BusReervationAPI.Infrastructure
{
    public class BusInfoContext : DbContext
    {
        public BusInfoContext(DbContextOptions<BusInfoContext> options) : base(options)
        {

        }

        public DbSet<BusInfo> BusInfo { get; set; }
        public DbSet<BookingInfo> BookingInfos { get; set; }
    }
}
