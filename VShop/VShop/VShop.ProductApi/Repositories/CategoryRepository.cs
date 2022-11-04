using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories!.ToListAsync();// aqui é na memória, em prod não é recomendado assim.
    }

    public async Task<Category> GetById(int id)
    {
        var category = await _context.Categories!.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        if (category == null)
            return new Category();
        return category;
    }

    public async Task<IEnumerable<Category>> GetCategoriesProducts()
    {
        return await _context.Categories!.Include(e => e.Products).ToListAsync();
    }

    public async Task<Category> Create(Category category)
    {
        _context.Categories!.Add(category);
        await _context.SaveChangesAsync();// o correto seria implementar o padrão UnitOfWork e o save changes vira commit do unit of work
        // a definição do repositório é que ele é uma coleção de objetos de uso na MEMÓRIA então como não salva NADA NA MEMÓRIA o correto seria o UOW.
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;// o ef vai entender que houve alteração nessa entidade category e salvar esse objeto
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Delete(int id)
    {
        var category = await GetById(id);
        _context.Categories!.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
}
