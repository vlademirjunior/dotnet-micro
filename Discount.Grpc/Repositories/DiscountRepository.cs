using System;
using System.Threading.Tasks;
using Dapper;
using Discount.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            NpgsqlConnection connection = GetConnectionPostgreSQL();

            var query = "SELECT * FROM Coupon WHERE ProductName = @ProductName";

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(
                query, new { ProductName = productName }
            );

            return coupon ?? new Coupon { ProductName = "No Discoutn", Amount = 0, Description = "Do Discount Desc" };
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            NpgsqlConnection connection = GetConnectionPostgreSQL();

            var query = "INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)";

            var affected = await connection.ExecuteAsync(
                query, new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount }
            );

            return !(affected == 0);
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            NpgsqlConnection connection = GetConnectionPostgreSQL();

            var query = "UPDATE Coupon SET ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE Id = @Id";
            
            var affected = await connection.ExecuteAsync(
                query, new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id }
            );

            return !(affected == 0);
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            NpgsqlConnection connection = GetConnectionPostgreSQL();
            
            var query = "DELETE FROM Coupon WHERE ProductName = @ProductName";

            var affected = await connection.ExecuteAsync(
                query, new { ProductName = productName }
            );

            return !(affected == 0);
        }

        private NpgsqlConnection GetConnectionPostgreSQL()
        {
            return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }
    }
}