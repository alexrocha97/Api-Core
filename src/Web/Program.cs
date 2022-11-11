using Application;
using Infra;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddApplication()
    .AddInfra();
    builder.Services.AddControllers();
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
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
