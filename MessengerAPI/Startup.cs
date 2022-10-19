using learn.core.domain;
using learn.core.Repoisitory;
using learn.core.Service;
using learn.infra.domain;
using learn.infra.Repoisitory;
using learn.infra.Service;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using Messenger.infra.Repoisitory;
using Messenger.infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MessengerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDBContext, DbContext>();

            services.AddScoped<IServicesRepository, ServicesRepository>();
            services.AddScoped<IServicesService, ServicesService>();

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IReportUserRepoisitory, ReportUserRepoisitory>();
            services.AddScoped<IReportUserService, ReportUserService>();

            services.AddScoped<IGroupMemberRepoisitory, GroupMemberRepoisitory>();
            services.AddScoped<IGroupMemberService, GroupMemberService>();

            services.AddScoped<IFrindRepository, FrindRepository>();
            services.AddScoped<IFrindService, FrindService>();

            services.AddScoped<IMessageGroupRepoisitory, MessageGroupRepoisitory>();
            services.AddScoped<IMessageGroupservice, MessageGroupservice>();

            services.AddScoped<IMessageRepoisitory, MessageRepoisitory>();
            services.AddScoped<IMessageservice, Messageservice>();
            
            services.AddScoped<IDtoRepository, DtoRepository>();
            services.AddScoped<IDtoService, DtoService>();

            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<ITestimonialService, TestimonialService>();

            services.AddScoped<IHomeRepoisitory, HomeRepoisitory>();
            services.AddScoped<IHomeService, HomeService>();

            services.AddScoped<IFooterRepoisitory, FooterRepository>();
            services.AddScoped<IFooterService, FooterService>();

            services.AddScoped<IAboutUsRepoisitory, AboutUsRepoisitory>();
            services.AddScoped<IAboutUsService, AboutUsService>();

            services.AddScoped<IContactUsRepoisitory, ContactUsRepoisitory>();
            services.AddScoped<IContactUsService, ContactUsService>();

            //add cors for connect angular
            //services.AddCors(corsOptions =>
            //{
            //    corsOptions.AddPolicy("policy",
            //    builder =>
            //    {
            //        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //    });
            //});

            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

           ).AddJwtBearer(y =>
           {
               y.RequireHttpsMetadata = false;
               y.SaveToken = true;
               y.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                   ValidateIssuer = false,
                   ValidateAudience = false,

               };


           });

            services.AddSignalR();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //add cors for connect angular
            //app.UseCors("policy");
            app.UseCors(p =>
            {
                p.WithOrigins("http://localhost:4200")
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });

            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<Chat>("/chat");
            });
        }
    }
}
