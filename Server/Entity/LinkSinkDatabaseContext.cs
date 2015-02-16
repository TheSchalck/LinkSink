﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public class LinkSinkDatabaseContext : DbContext, ILinkSinkDatabaseContext
    {
        //public virtual IDbSet<Message> Messages { get { return Set<Message>(); } }
        //public virtual IDbSet<MessageSource> MessageSources { get { return Set<MessageSource>(); } }
        //public virtual IDbSet<ReceiverBase> Receivers { get { return Set<ReceiverBase>(); } }
        //public virtual IDbSet<MessageRead> MessageReads { get { return Set<MessageRead>(); } }


        public LinkSinkDatabaseContext()
            : this("kuMessageStoreDbConnection")
        { }
        public LinkSinkDatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public TEntity Single<TEntity>(Func<TEntity, bool> predicate) where TEntity : class
        {
            return base.Set<TEntity>().Single(predicate);
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {

            return base.Set<TEntity>().Add(entity);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fase 2 messages....
            //modelBuilder.Entity<Message>().HasKey(x => x.Id).ToTable("Message");

            //modelBuilder.Entity<Message>()
            //    .HasRequired(x => x.MessageSource)
            //    .WithMany()
            //    .HasForeignKey(x => x.MessageSourceId);

            //modelBuilder.Entity<MessageSource>()
            //    .HasKey(x => x.Id)
            //    .ToTable("MessageSource");

            //modelBuilder.Entity<ReceiverBase>()
            //    .HasKey(x => x.Id)
            //    .ToTable("Receiver");

            //modelBuilder.Entity<Message>()
            //    .HasMany<ReceiverBase>(x => x.Receivers)
            //    .WithRequired(x => x.Message)
            //    .HasForeignKey(x => x.MessageId);

            //modelBuilder.Entity<MessageRead>().HasKey(x => x.Id).ToTable("MessageRead");

            //modelBuilder.Entity<MessageRead>()
            //    .HasRequired(x => x.TheMessage)
            //    .WithMany()
            //    .HasForeignKey(x => x.MessageId);

            //modelBuilder.Entity<Message>()
            //    .HasMany<MessageRead>(x => x.MessageReads)
            //    .WithRequired(x => x.TheMessage)
            //    .HasForeignKey(x => x.MessageId);
        }
    }
}