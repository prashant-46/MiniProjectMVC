using Microsoft.Data.SqlClient;
namespace MiniProjectMVC.Models
{
    public class Student
    {
        public int Rollno { get; set; }

        public string Name { get; set; }

        public string Stream { get; set; }

        public static List<Student> GetAllStudents()
        {
            List<Student> lststd = new List<Student>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from Studentsdata ";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    lststd.Add(new Student { Rollno = dr.GetInt32(0), Name = dr.GetString(1), Stream = dr.GetString(2) });
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lststd;
        }

        public static Student GetSingleStudent(int Rollno)
        {
            Student obj = new Student();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from Studentsdata where rollno=@Rollno";
                cmdInsert.Parameters.AddWithValue("@Rollno", Rollno);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    obj.Rollno = dr.GetInt32(0);
                    obj.Name = dr.GetString(1);
                    obj.Stream = dr.GetString(2);
                }
                else
                {
                    obj = null;
                    Console.WriteLine("Not present");
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }

        public static void InsertStudent(Student obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "insert into Studentsdata values(@Rollno,@Name,@Stream)";



                cmdInsert.Parameters.AddWithValue("@Rollno", obj.Rollno);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Stream", obj.Stream);
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateStudent(Student obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "update Studentsdata set name=@Name,stream=@Stream where rno=@Rollno";

                cmdInsert.Parameters.AddWithValue("@Rollno", obj.Rollno);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Stream", obj.Stream);

                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void DeleteStudent(int Rollno)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "delete from Studentsdata where rno =@Rollno";

                cmdInsert.Parameters.AddWithValue("@Rollno", Rollno);
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
