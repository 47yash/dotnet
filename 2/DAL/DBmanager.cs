using BOL;
using MySql.Data.MySqlClient;

namespace DAL;

public class DBmanager
{
    public static string conString=@"server=localhost;port=3306;user=root;password=Sher@360;database=practice";

    public static List<Student> GetStudent(){
        List<Student> slist=new List<Student>();
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            con.Open();
            MySqlCommand cmd=new MySqlCommand();
            cmd.Connection=con;
            string query="select * from student";
            cmd.CommandText=query;
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read()){
                int id=int.Parse(reader["Id"].ToString());
                String name=reader["name"].ToString();
                int roll=int.Parse(reader["roll"].ToString());
                Student s=new Student{
                    Id=id,
                    name=name,
                    roll=roll,
                };
                slist.Add(s);
            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
        return slist;


    }

    public static bool InsertStudent(int id,string nm,int roll) {
        bool status=false;
        Console.WriteLine(id+nm+roll);

        string query="insert into student values(@id,@nm,@roll) ";

        MySqlConnection con =new MySqlConnection();
        con.ConnectionString=conString;
        try{
            con.Open();
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@nm",nm);
            cmd.Parameters.AddWithValue("@roll",roll);
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

    public static bool UpdateStudent(int id,string nm,int roll){
        bool status =false;
        string query ="update student set name=@nm,roll=@roll where id=@id";
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            con.Open();
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@nm",nm);
            cmd.Parameters.AddWithValue("@roll",roll);
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

   public static bool DeleteStudent(int id){
    bool status=false;
    Console.WriteLine(id);
    string query="delete from student where id=@id";
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
