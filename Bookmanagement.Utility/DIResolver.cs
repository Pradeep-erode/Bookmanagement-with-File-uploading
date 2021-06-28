using Bookmanagement.Core.IRepository;
using Bookmanagement.Core.IService;
using Bookmanagement.Resources.BookRepository;
using Bookmanagement.Services.Bookservice;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Utility
{
    public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //for accessing the http context by interface in view level
            #region Http context
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
            //for service accesssing
            #region Service

            services.AddScoped<IServiceBook, BookService>();
            #endregion
            //for database accessing 
            #region Repository

            services.AddScoped<IRepositoryBook, BookRepository>();

            #endregion


        }
    }
}
