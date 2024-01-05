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

    public bool InsertArticles(int id, string nm,string author){

        return DBManager.InsertArticles(id,nm,author);
    }
    public bool UpdateArticle(int id, string nm,string author){

        return DBManager.UpdateArticle(id,nm,author);
    }
    public bool DeleteArticle(int id){

        return DBManager.DeleteArticle(id);
    }

}
