using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GraphQL.API.Helpers;
using GraphQL.API.Models;
using GraphQL.Core.Data;
using GraphQL.Data;
using GraphQL.Data.Repositories;
using GraphQL.Types;

namespace GraphQL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddHttpContextAccessor();
            services.AddSingleton<ContextServiceLocator>();
            services.AddDbContext<GraphQLDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:GrapQLDb"], option => option.UseRowNumberForPaging()));
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ISkaterStatisticRepository, SkaterStatisticRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();            
            services.AddSingleton<GraphQLQuery>();
            services.AddSingleton<GraphQLMutation>();
            services.AddSingleton<PlayerType>();
            services.AddSingleton<PagingType>();
            services.AddSingleton<PlayerInputType>();
            services.AddSingleton<SkaterStatisticType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphQLSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env/*, GraphQLDbContext db*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
            //db.EnsureSeedData();
        }
    }
}
