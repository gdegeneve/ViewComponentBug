using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ViewComponentBug.Services
{
    public interface IScopeService
    {
        string GuidTest { get; }

        void FillGuid();
    }

    public static class ScopeServiceExtension
    {
        public static IServiceCollection AddScopeService(this IServiceCollection services)
        {
            services.AddScoped<IScopeService, ScopeService>();

            return services;
        }
    }

    public class ScopeService : IScopeService
    {
        private string _GuidTest = "";

        public string GuidTest
        {
            get
            {
                return _GuidTest;
            }
        }

        public void FillGuid()
        {
            _GuidTest = Guid.NewGuid().ToString();
        }
    }
}