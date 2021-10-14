using DalPiaz.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalPiaz.contexto
{
    public class DPSyncContext : DbContext
    {
        public DbSet<MessageFile> messageFiles { get; set; }
        public DbSet<Log> logs { get; set; }

        public DPSyncContext() : base("name=dpsync")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("public");


            modelBuilder.Entity<MessageFile>().HasKey(k => new { k.Id, k.Esn });
            modelBuilder.Entity<MessageFile>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<MessageFile>().Property(p => p.InputXml).HasColumnName("input_xml");
            modelBuilder.Entity<MessageFile>().Property(p => p.Esn).HasColumnName("esn");
            modelBuilder.Entity<MessageFile>().Property(p => p.Unixtime).HasColumnName("unixtime");
            modelBuilder.Entity<MessageFile>().Property(p => p.Payload).HasColumnName("payload");
            modelBuilder.Entity<MessageFile>().Property(p => p.OutputXml).HasColumnName("output_xml");
            modelBuilder.Entity<MessageFile>().Property(p => p.OutputCsv).HasColumnName("output_csv");
            modelBuilder.Entity<MessageFile>().Property(p => p.Mobile).HasColumnName("mobile");
            modelBuilder.Entity<MessageFile>().Property(p => p.DataConvertida).HasColumnName("data_convertida");
            modelBuilder.Entity<MessageFile>().Property(p => p.Lat).HasColumnName("lat");
            modelBuilder.Entity<MessageFile>().Property(p => p.Lon).HasColumnName("lon");
            modelBuilder.Entity<MessageFile>().Property(p => p.Obs).HasColumnName("obs");
            modelBuilder.Entity<MessageFile>().ToTable("tb_dpsync");


            modelBuilder.Entity<Log>().HasKey(k => new { k.dataCriacao,  });
            modelBuilder.Entity<Log>().Property(p => p.dataCriacao).HasColumnName("data_criacao");
            modelBuilder.Entity<Log>().Property(p => p.aviso).HasColumnName("aviso");
            modelBuilder.Entity<Log>().Property(p => p.arquivo).HasColumnName("arquivo");
            modelBuilder.Entity<Log>().ToTable("tb_log");



        }
    }
}
