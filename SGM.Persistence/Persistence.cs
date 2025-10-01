using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGM.Persistence.Context;
using SGM.Persistence.Base;
using SGM.Persistence.Repositories.Medical;
using SGM.Persistence.Repositories.Security;
using SGM.Persistence.Ado.Common;
using SGM.Persistence.Ado.Medical;
using SGM.Persistence.Ado.Security;
using SGM.Domain.Interfaces.Repository;
using SGM.Persistence.Interfaces.Medical;
using SGM.Persistence.Interfaces.Security;


namespace SGM.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration cfg)
        {
            services.AddDbContext<SGMDbContext>(options => options.UseSqlServer(cfg.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICitaRepository, CitaRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<StoredProcedureExecutor>();
            services.AddScoped<UsuarioAdoRepository>();
            services.AddScoped<MedicoAdoRepository>();
            services.AddScoped<PacienteAdoRepository>();
            services.AddScoped<CitaAdoRepository>();

            return services;
        }
    }
}