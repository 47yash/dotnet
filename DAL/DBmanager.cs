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


    



  
}
    
