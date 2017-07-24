using Common.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Common.Database
{
    public class ApplicationDbInitializer
    {
        public async virtual Task InitializeDatabaseAsync<T, T2>(IServiceProvider serviceProvider)
            where T : ApplicationDbContext<T2>
            where T2 : ApplicationUser
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<T>();

                await db.Database.MigrateAsync();
                //await createLogTable<T, T2>(db);
            }
        }

        //private async Task createLogTable<T, T2>(T db)
        //  where T : ApplicationDbContext<T2>
        //  where T2 : ApplicationUser
        //{
        //    var sql = @"IF  NOT EXISTS (SELECT * FROM sys.objects
        //WHERE object_id = OBJECT_ID(N'[Logs]') AND type in (N'U'))

        //BEGIN

        //CREATE TABLE [Logs](
        //	[Id] [int] IDENTITY(1,1) NOT NULL,
        //    [Code] [nvarchar](max) NULL,
        //    [Message] [nvarchar](max) NULL,
        //	[MessageTemplate] [nvarchar](max) NULL,
        //	[Level] [nvarchar](128) NULL,
        //	[TimeStamp] [datetime] NOT NULL,
        //    [CreatedBy] [nvarchar](max) NULL,
        //	[Exception] [nvarchar](max) NULL,
        //	[Properties] [xml] NULL,
        // CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED
        //(
        //	[Id] ASC
        //)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
        //) ON [PRIMARY]

        //END";
        //    await db.Database.ExecuteSqlCommandAsync(sql);
        //}
    }
}