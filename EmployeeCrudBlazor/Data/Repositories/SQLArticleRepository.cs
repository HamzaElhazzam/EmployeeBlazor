using EmployeeCrudBlazor.Context;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Kanban.Internal;

namespace EmployeeCrudBlazor.Data.Repositories
{
    public class SQLArticleRepository
    {
        private AppDbContext Context;
        public SQLArticleRepository(AppDbContext context)
        {
            Context = context;
        }
        //Get All Articles List
        public async Task<List<Article>> GetAllArticles()
        {
            return await Context.Articles.ToListAsync();
        }

        //Add Article
        public async Task<bool> AddArticle(Article article)
        {
            await Context.Articles.AddAsync(article);
            await Context.SaveChangesAsync();
            return true;

        }
        //Get Article By Id
        public async Task<Article> GetArticleById(int id)
        {

            Article article = await Context.Articles.SingleOrDefaultAsync(x => x.Id == id);
            return article;
        }
        //Update Article Data
        public async Task<bool> UpdateArticleDetails(Article article)
        {
            Context.Articles.Update(article);
            await Context.SaveChangesAsync();
            return true;
        }
        //Delete Article Data
        public async Task<bool> DeleteArticle(Article article)
        {
            Context.Articles.Remove(article);
            await Context.SaveChangesAsync();
            return true;
        }
        //Get articles by marque
        public async Task<List<Article>> GetAllArticlesByMarque(string article)
        {
            return await Context.Articles.Where(x=>x.Marque == article).ToListAsync();
        }
        //Get articles ordered by client
        public async Task<List<Article>> GetArticleCommander()
        {
            var sql = "SELECT DISTINCT Articles.* FROM Articles, Commandes WHERE Articles.Id = Commandes.Id_Article";
            return Context.Articles.FromSqlRaw(sql).ToList();
        }
    }
}
