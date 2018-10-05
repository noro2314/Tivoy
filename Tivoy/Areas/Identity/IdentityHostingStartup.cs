using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tivoy.Data;
using Tivoy.Models;

[assembly: HostingStartup(typeof(Tivoy.Areas.Identity.IdentityHostingStartup))]
namespace Tivoy.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {            
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}