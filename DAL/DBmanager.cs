namespace DAL;
using MySql.Data.MySqlClient;
using BOL;

public DBManager
{
    public static string conString=@"server=localhost;port=3306;user=root;password=Sher@360;database=practice";
    public static list<Article> GetArticles(){

    
    list<Article> art=new list<Article>;
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=conString;
    try{
        con.open();
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        string qry="select * from Articles";
        cmd.CommandText=qry;
        MySqlDataReader reader=cmd.ExecuteReader();
        while(reader.Read()){
              int Id = int.Parse(reader["Id"].ToString());
                    string name = reader["name"].ToString();
                    string author = reader["author"].ToString();

                    Article a= new Article{
                        Id= Id,
                        name=name,
                        author=author,
                    };
                    art.add(a);
        }
        catch(Exception e){
            Console.WriteLine(ee.Message);
        }
        finally{
            con.close();
        }
        return art;
    }

    }
}
