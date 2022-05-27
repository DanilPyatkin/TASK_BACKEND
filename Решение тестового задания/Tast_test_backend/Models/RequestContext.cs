using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTestApp.Models
{
    public class RequestContext : DbContext
    {
        public DbSet<RequestData> Requests { get; set; }
        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {
            //Создание базы при первом обращении к ней
            Database.EnsureCreated();
        }
        
        //Для Update-Migration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestData>().OwnsOne(r => r.UserData);

            base.OnModelCreating(modelBuilder);
        }

        //асинхронное добавление новых данных и сохранение в БД
        public async Task AddAsyncFake(RequestData request)
        {
            await Task.Run(() => Requests.Add(request)).ContinueWith((r) => SaveChanges());
        }

        ///асинхронная выборка по Guid
        public async Task<RequestData> GetAsyncFake(string requestGuid)
        {
            return await Task.Run(() => Requests.Where(r => r.QueryId == requestGuid).FirstOrDefault());
        }
    }
}
