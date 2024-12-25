using Entity.Abstract;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.EntityFramework.Context
{
    public class EfContext : DbContext
    {
        public DbSet<TwitterAccount> TwitterAccount { get; set; }
        public DbSet<TwitterAccountToFollow> TwitterAccountToFollow { get; set; }
        public DbSet<FollowedAccount> FollowedAccount { get; set; }
        public DbSet<Tweet> Tweet { get; set; }
        public DbSet<ProcessHistory> ProcessHistory { get; set; }
        public DbSet<SharedTweet> SharedTweet { get; set; }
        public DbSet<TweetSharedTime> TweetSharedTime { get; set; }
        public EfContext() : base("name = EfContect")
        {

        }
    }
}
