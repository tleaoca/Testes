using Microsoft.OpenApi.Models;

namespace BackEnd_1.Infra
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Teste BackEnd 1",
                    Description = "https://github.com/viavarejo/backend-test/blob/master/README.md",
                    Contact = new OpenApiContact { Name = "Thiago Leão", Email = "tleaoca@gmail.com" },                    
                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste BackEnd 1");
            });
        }
    }
}
