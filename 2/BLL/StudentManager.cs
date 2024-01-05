namespace BLL;
using BOL;
using DAL;
using System.Collections.Generic;
public class StudentManager
{
    public List<Student> GetStudent(){
        List<Student> slist=new List<Student>();
        slist=DBmanager.GetStudent();
        return slist;
        

    }

    public bool DeleteStudent(int id){
        Console.WriteLine(id);
      
       return DBmanager.DeleteStudent(id);

    }
    public bool InsertStudent(int id,string name,int roll){
        return DBmanager.InsertStudent(id,name,roll);
    }

    public bool UpdateStudent(int id,string name,int roll){
        return DBmanager.InsertStudent(id,name,roll);
    }

}
