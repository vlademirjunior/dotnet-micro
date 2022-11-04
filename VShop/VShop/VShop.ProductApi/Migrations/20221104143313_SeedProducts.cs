using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('Caderno', 7.55, 'Caderno Lindo', 10, 'caderno.jpg', 2)");
            
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('Lápis', 1.55, 'Lápis Lindo Preto', 20, 'lapispreto.jpg', 2)");

            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('Estojo', 4.55, 'Estojo rosa lindo', 10, 'estojo.jpg', 1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE * FROM Products");
        }
    }
}
