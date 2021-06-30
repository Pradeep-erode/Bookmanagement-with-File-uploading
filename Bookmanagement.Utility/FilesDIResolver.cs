using Bookmanagement.Core.IRepository;
using Bookmanagement.Core.IService;
using Bookmanagement.Resources.FilesRepository;
using Bookmanagement.Services.Filesservice;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Utility
{
    public class FilesDIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            //for service accesssing
           

            services.AddScoped<IServiceFiles, FilesService>();
           
            //for database accessing 
           

            services.AddScoped<IRepositoryFiles, FilesRepository>();
        }
    }
}
