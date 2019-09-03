using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.BLL;
using Blog.DAL;
using Blog.IBLL;
using Blog.IDAL;
using Blog.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

//加载Swagger空间
using Swashbuckle.AspNetCore.Swagger;


namespace Blog.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public IConfiguration Configuration { get; }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //数据库连接
   


            #region 依赖注入
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IUserRepository,UserRespository>();
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<BlogContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase"));
            });

            #region CORS             //开放所有请求
            services.AddCors(c =>
            {
                c.AddPolicy("AllRequests", policy =>
                {
                    policy
                    .AllowAnyOrigin()//允许任何源
                    .AllowAnyMethod()//允许任何方式
                    .AllowAnyHeader()//允许任何头
                    .AllowCredentials();//允许cookie
                });
            });

            #endregion

            #region  Swagger Configure
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Alan Blog API", Version = "v1" });

                var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Blog.WebAPI.xml");//这个就是刚刚配置的xml文件名

                var xmlModelPath = Path.Combine(basePath, "Blog.Model.xml");//这个就是Model层的xml文件名
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
                c.IncludeXmlComments(xmlModelPath);

                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                var security = new Dictionary<string, IEnumerable<string>> { { "Blog", new string[] { } }, };
                c.AddSecurityRequirement(security);
                //方案名称“BaseFramwork”可自定义，上下一致即可
                c.AddSecurityDefinition("Blog", new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });

            });

            #endregion

            #region Token
            //2.1【认证】
            services.AddAuthentication(x =>
            {
                //看这个单词熟悉么？没错，就是上边错误里的那个。
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                 .AddJwtBearer(o =>
                 {
                     o.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Audience:Secret"])),
                         ValidateIssuer = true,
                         ValidIssuer = Configuration["Audience:Issuer"],//发行人
                         ValidateAudience = true,
                         ValidAudience = Configuration["Audience:Audience"],//订阅人
                         ValidateLifetime = true,
                         //过期时间 60秒
                         //ClockSkew = TimeSpan.FromSeconds(60),
                         RequireExpirationTime = true,
                     };

                 });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //启用系统认证机制
            app.UseAuthentication();

            #region Swagger 启用中间件
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Alan Blog ApiHelp V1");
                //c.RoutePrefix = "";//路径配置，设置为空，表示直接访问该文件，
            });
            #endregion

            //开放所有请求
            app.UseCors("AllRequests");

            app.UseMvc();
        }
    }
}
