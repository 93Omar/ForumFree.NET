using ForumFree.NET;
using Microsoft.Extensions.Options;
using WebApi.Configurations;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddUserSecrets<Program>();

            IServiceCollection services = builder.Services;

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<ForumConfiguration>(builder.Configuration.GetSection(nameof(ForumConfiguration)));

            services.AddHttpClient<ForumFreeClient>((sp, client) =>
            {
                ForumConfiguration forumConfiguration = sp.GetRequiredService<IOptions<ForumConfiguration>>()?.Value ?? throw new ArgumentNullException(nameof(ForumConfiguration));
                client.BaseAddress = forumConfiguration.ForumUri;
            })
            .AddHttpMessageHandler((sp) =>
            {
                ForumConfiguration forumConfiguration = sp.GetRequiredService<IOptions<ForumConfiguration>>()?.Value ?? throw new ArgumentNullException(nameof(ForumConfiguration));
                return new FixedCookieHandler(forumConfiguration.Cookie);
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
