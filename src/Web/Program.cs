using Application;
using Infra;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Web.Erros;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddApplication()
    .AddInfra(builder.Configuration);
    // builder.Services.AddControllers(options => options.Filters.Add<ErrosFilters>());
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, DetalhesDeErros>();
}


#region Swagger Desativado
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

#region Swagger Desativado
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
#endregion



#region Swagger Desativado
// app.UseAuthorization();
#endregion

{
    // app.UseMiddleware<ManipulacaoError>();
    app.UseExceptionHandler("/error");
    // app.Map("/error", (HttpContext httpContext) =>{
    //     Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //     return Results.Problem();
    // });
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
