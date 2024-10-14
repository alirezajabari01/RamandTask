using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Persistence.EF.Context;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection service)
    {
        return service.AddTransient<IDbConnection>((sp) =>
            new SqlConnection("Data Source=DESKTOP-G79AH4U;Initial Catalog=Ramand;Persist Security Info=True;User ID=sa;Password=Kiau@123%J;TrustServerCertificate=True;"));
    }
}