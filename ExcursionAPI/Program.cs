using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using DataAccess.Wrapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Domain.Wrapper;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Domain.Interfacess;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ��������� ������ �����������
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ExcursionBdContext>(options => options.UseSqlServer(connectionString));

        // ����������� ��������
        builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IComplaintService, ComplaintService>();
        builder.Services.AddScoped<INotificationService, NotificationService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IProviderServiceService, ProviderServiceService>();
        builder.Services.AddScoped<IReviewService, ReviewService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IStatisticService, StatisticService>();
        builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
        builder.Services.AddScoped<ITourLoadStatisticService, TourLoadStatisticService>();
        builder.Services.AddScoped<ITourService, TourService>();

        // ��������� Swagger
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "�������������-���� API",
                Description = "��������� �� ������ API",
                Contact = new OpenApiContact
                {
                    Name = "������ ��������",
                    Url = new Uri("https://gorbilet.com/msk/catalog/ekskursii-po-moskve/")
                },
                License = new OpenApiLicense
                {
                    Name = "������ ��������",
                    Url = new Uri("https://example.com/license")
                }
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        // ���������� ������������ � Swagger
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        // ��������� CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        // �����������
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();

        var app = builder.Build();

        // Middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}