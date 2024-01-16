using EmployeeCrudBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudBlazor.Data.Repositories
{
    public class SQLBonCommandeRepository
    {
        private AppDbContext _appDbContext;
        public SQLBonCommandeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Employee>> GetAllClients()
        {
            return await _appDbContext.Employees.ToListAsync();
        }
        public async Task<Article> GetArticleById(int id)
        {
            Article article = await _appDbContext.Articles.SingleOrDefaultAsync(x => x.Id == id);
            return article;
        }
        public async Task<List<Commande>> GetAllCommmande()
        {
            return await _appDbContext.Commandes.Include(c => c.Article)
                    .ToListAsync();
        }
        public async Task AddBonCommande(Commande commande)
        {
            await _appDbContext.Commandes.AddAsync(commande);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _appDbContext.Employees.FindAsync(id);
             
        }

        public async Task EditBonCommande(Commande commande)
        {
            _appDbContext.Commandes.Update(commande);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task DeleteBonCommande(Commande commande)
        {
            _appDbContext.Commandes.Remove(commande);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Commande> GetCommandeById(int id)
        {
            return await _appDbContext.Commandes
         .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Commande>> GetAllCommandeByArticleId(int id)
        {
            return await _appDbContext.Commandes.Where(c=>c.Id_Article==id).Include(c=>c.Employee).ToListAsync();
        }
        
    }
}
