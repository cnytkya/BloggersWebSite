using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDb;Database=BloggersWebSiteDb;Trusted_Connection=True;TrustServerCertificate=True");
		}

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogReyting> BlogReytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
				.HasOne(x=>x.HomeTeam)
				.WithMany(y=>y.HomeMathches)
				.HasForeignKey(z=>z.HomeTeamId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Match>()
				.HasOne(x=>x.GuestTeam)
				.WithMany(y=>y.AwayMatches)
				.HasForeignKey(z=>z.GuestTeamId)
				.OnDelete(DeleteBehavior.ClientSetNull); //ilişkili nesne silindiğinde, bağımsız olan nesnenin ilgili alanının null olmasına izin verir. Bu, ilişkili nesne silindikten sonra, bağımsız nesnenin hala referansını taşıyabileceği anlamına gelir, ancak artık bu referans geçersizdir ve ilişkilendirilmiş bir nesneyi göstermez.

			modelBuilder.Entity<Message2>()
				.HasOne(x => x.SenderUser)
				.WithMany(y => y.WriterSender)
				.HasForeignKey(z=>z.SenderId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Message2>()
				.HasOne(x => x.ReceiverUser)
				.WithMany(y => y.WriterReceiver)
				.HasForeignKey(z => z.ReceiverId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			base.OnModelCreating(modelBuilder);

            //HomeMathches-->WriterSender
            //AwayMatches-->WriterReceiver

            //HomeTeam-->SenderUser
            //GuestTeam-->ReceiverUser
        }       
	}
}
