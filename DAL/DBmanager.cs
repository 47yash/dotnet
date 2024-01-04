namespace DAL;
using BOL;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


public class DBManager{
    public static string conString=@"server=localhost;port=3306;user=root;password=Sher@360;database=practice";
    public static List<Article> GetArticles(){

    
    List<Article> art=new List<Article>();
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=conString;
    try{
        con.Open();         
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        string qry="select * from Article";
        cmd.CommandText=qry;
        MySqlDataReader reader=cmd.ExecuteReader();
        while(reader.Read()){
                    int id = int.Parse(reader["Id"].ToString());
                    string name = reader["name"].ToString();
                    string author = reader["author"].ToString();

                    Article a= new Article{
                        Id= id,
                        Name=name,
                        Author=author,
                    };
                    // Console.WriteLine(id+" "+name+" "+author);
                    art.Add(a);
        }
    }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
        return art;
    }
    
    public static bool InsertArticles(int id,string nm,string author) {
        bool status=false;

        string query="insert into article values(@id,@nm,@author) ";

        MySqlConnection con =new MySqlConnection();
        con.ConnectionString=conString;
        try{
            con.Open();
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@nm",nm);
            cmd.Parameters.AddWithValue("@author",author);
            cmd.ExecuteNonQuery();
            status=true;
        }
        catch (Exception e){
            throw e;
        }
        finally{
            con.Close();
        }
        return status;

    }

    public static bool UpdateArticle(int id,string nm,string author){
        bool status =false;
        string query ="update article set name=@nm,author=@author where id=@id";
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            con.Open();
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@nm",nm);
            cmd.Parameters.AddWithValue("@author",author);
            cmd.ExecuteNonQuery();
            status=true;


        }
        catch(Exception e){
            throw e;
        }
        finally{
            con.Close();
        }
        return status;

    }

   public static bool DeleteArticle(int id){
    bool status=false;
    string query="delete from article where id=@id";
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=conString;
    try
    {
        con.Open();
        MySqlCommand cmd=new MySqlCommand(query,con);
        cmd.Parameters.AddWithValue("@id",id);
        cmd.ExecuteNonQuery();
        status=true;


    }catch(Exception e){
        throw e;

    }finally{
        con.Close();
    }
    return status;

   }


    



  
}
    
