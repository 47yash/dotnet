namespace BLL;
using BOL;
using DAL;
public class ArticleManager
{
    public List<Article> GetAllArticles(){
        List<Article> all=new List<Article>();
        all=DBManager.GetArticles();
        return all;
    }
}
