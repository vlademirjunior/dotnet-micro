using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products!.ToListAsync();// aqui é na memória, em prod não é recomendado assim.
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _context.Products!.Where(c => c.Id == id).FirstOrDefaultAsync();
        if (product == null)
            return new Product();
        return product;
    }

    public async Task<Product> Create(Product product)
    {
        _context.Products!.Add(product);
        await _context.SaveChangesAsync();// o correto seria implementar o padrão UnitOfWork e o save changes vira commit do unit of work
        // a definição do repositório é que ele é uma coleção de objetos de uso na MEMÓRIA então como não salva NADA NA MEMÓRIA o correto seria o UOW.
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;// o ef vai entender que houve alteração nessa entidade product e salvar esse objeto
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Delete(int id)
    {
        var product = await GetById(id);
        _context.Products!.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }
}
