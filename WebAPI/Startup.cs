
using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrate.EntityFramework.Context;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }




        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddControllersWithViews(); // Razor UI dəstəyi üçün
            services.AddRazorPages();
            services.AddSession(); // Session dəstəyi üçün (əgər istifadə edəcəksənsə)

            services.AddDbContext<ContractContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Dependency Injection
            services.AddScoped<IContractService, ContractManager>();
            services.AddScoped<IContractDal, EfContractDal>();
            services.AddScoped<IAmountTypeService, AmountTypeManager>();
            services.AddScoped<IAmountTypeDal, EfAmountTypeDal>();
            services.AddScoped<ICategoryTypeService, CategoryTypeManager>();
            services.AddScoped<ICategoryTypeDal, EfCategoryTypeDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IContractStatusService, ContractStatusManager>();
            services.AddScoped<IContractStatusDal, EfContractStatusDal>();

            services.AddScoped<IPaymentMethodService, PaymentMethodManager>();
            services.AddScoped<IPaymentMethodDal, EfPaymentMethodDal>();


            services.AddScoped<IGuaranteeService, GuaranteeManager>();
            services.AddScoped<IGuaranteeDal, EfGuaranteeDal>();

            services.AddScoped<IOrganizationService, OrganizationManager>();
            services.AddScoped<IOrganizationDal, EfOrganizationDal>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IAuthService, AuthManager>(); // JWT token servisi

            // AutoMapper servisini əlavə et (profil avtomatik tapılır)
            //services.AddAutoMapper(typeof(ContractProfile));

            // JWT Authentication ayarları
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles(); // wwwroot fayllar üçün
            app.UseRouting();

            app.UseAuthentication(); // <-- Əlavə edildi
            app.UseAuthorization();

            app.UseSession(); // Session aktivləşdirilir

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");

                endpoints.MapRazorPages(); // Razor View-lər üçün lazım
            });
        }
    }
}

