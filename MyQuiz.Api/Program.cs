using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyQuiz.Api.Hab;
using MyQuiz.Api.Habs;
using MyQuiz.Appliction.Contracts.IRepositories.IQuiz;
using MyQuiz.Appliction.Contracts.IServices;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Appliction.Services.QuizServiceAsync;
using MyQuiz.Identity;
using MyQuiz.Infrastructure.AllContexts;
using MyQuiz.Infrastructure.Repositories.QuizRepositoryAsync;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<QuizDemoAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultCon")));
builder.Services.AddDbContextPool<QuizPrivilageContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PrivilageCon")));
builder.Services.AddIdentity<Priv_User, Priv_Role>().AddEntityFrameworkStores<QuizPrivilageContext>().AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





#region Repositories Registration

builder.Services.AddScoped<ISystemCodeRepositoryAsync, SystemCodeRepositoryAsync>();
builder.Services.AddScoped<IQuestionRepositoryAsync, QuestionRepositoryAsync>();
builder.Services.AddScoped<IQuestionChoiceRepositoryAsync, QuestionChoiceRepositoryAsync>();
builder.Services.AddScoped<IQuizRepositoryAsync, QuizRepositoryAsync>();
builder.Services.AddScoped<IQuizQuestionRepositoryAsync, QuizQuestionRepositoryAsync>();
builder.Services.AddScoped<IQuizStudentRepositoryAsync, QuizStudentRepositoryAsync>();
#endregion



#region AppServic
builder.Services.AddScoped<IQuizServiceAsync, QuizServiceAsync>();
builder.Services.AddScoped<IChoiceServiceAsync, QuestionChoiceServiceAsync>();
builder.Services.AddScoped<IQuestionServiceAsync , QuestionServiceAsync>();
builder.Services.AddScoped<IQuizQuestionServiceAsync,  QuizQuestionServiceAsync>();
builder.Services.AddScoped<IQuizStudentServiceAsync, QuizStudentServiceAsync>();
#endregion


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
               .SetIsOriginAllowed(_ => true));
}   );
builder.Services.AddSignalR();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

builder.Services.AddControllers();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAll");
app.MapHub<chatHub>("/OnlinUserss");
app.MapHub<userStatusHub>("/userStatusHub");

app.Run();
