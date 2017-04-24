using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrainingVisit.Models
{
    public class TraininDbo
    {
        string cs = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public List<Training> ListAll()
        {
            List<Training> lst = new List<Training>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectAllTraining", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Training
                    {
                        idTraining = Convert.ToInt32(rdr["id"]),
                        NameTraining = rdr["TrainingName"].ToString(),
                        DescrTraining = rdr["TrainingDescription"].ToString()
                    });
                }
                return lst;
            }
        }

        //Method for Updating record
        public int Update(Training training)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateTrainig", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", training.idTraining);
                com.Parameters.AddWithValue("@Name", training.NameTraining);
                com.Parameters.AddWithValue("@Description", training.DescrTraining);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting record
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteTraining", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Adding 
        public int Add(Training training)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateTrainig", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", training.idTraining);
                com.Parameters.AddWithValue("@Name", training.NameTraining);
                com.Parameters.AddWithValue("@Description", training.DescrTraining);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        public List<User> ListUserById(int id)
        {
            List<User> lst = new List<User>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetByGoTrain", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new User
                    {
                        idUser = Convert.ToInt32(rdr["id"]),
                        NameTrainig = rdr["TrainingName"].ToString(),
                        NameUser = rdr["UserName"].ToString(),
                        Surname = rdr["UserSurname"].ToString(),
                        UserBirthdate = Convert.ToDateTime(rdr["UserBirthdate"].ToString())
                    });
                }
                return lst;
            }
        }

        public List<User> GetLatestTrainings(int id)
        {
            List<User> lst = new List<User>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetLatestTrainings", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new User
                    {
                        NameTrainig = rdr["TrainingName"].ToString(),
                        NameUser = rdr["UserName"].ToString()
                    });
                }
                return lst;
            }
        }
    }
}
// StoredProcedure 
/*
    -- ================================================
    -- Template generated from Template Explorer using:
    -- Create Procedure (New Menu).SQL
    --
    -- Use the Specify Values for Template Parameters 
    -- command (Ctrl-Shift-M) to fill in the parameter 
    -- values below.
    --
    -- This block of comments will not be included in
    -- the definition of the procedure.
    -- ================================================
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    -- =============================================
    -- Author:		<Author,,Name>
    -- Create date: <Create Date,,>
    -- Description:	<Description,,>
    -- =============================================

    Create Procedure SelectAllTraining
    as 
    Begin 
    Select * from Training; 
    End

    Create Procedure   InsertUpdateTrainig
    ( 
    @id integer, 
    @Name nvarchar(100), 
    @Description nvarchar(500),
    @Action varchar(10) 
    ) 
    As 
    Begin 
    if @Action='Insert' 
    Begin 
     Insert into Training(TrainingName,TrainingDescription) values(@Name,@Description); 
    End 
    if @Action='Update' 
    Begin 
     Update Training set TrainingName=@Name,TrainingDescription=@Description where id=@id; 
    End   
    End
    Create Procedure DeleteTraining 
    ( 
     @id integer 
    ) 
    as  
    Begin 
     Delete Training where id=@id; 
    End 

    Create Procedure GetByGoTrain
    @id integer
    as 
    Begin 
    SELECT
          u.id
          ,[UserName]
          ,[UserSurname]
          ,[UserBirthdate]
      FROM [dbo].[TrainingVisit] as trv left join Training tr on tr.id = trv.[IdTrainig] 
      left join [User] u on u.id = trv.IdUser Where trv.[IdTrainig] =@id
      end

    Create Procedure GetLatestTrainings
    @id integer
    as Begin 

    SELECT 
       u.id, [UserName]
          ,[UserSurname]
          ,[UserBirthdate], tr.TrainingName
	        FROM [dbo].[TrainingVisit] as trv left join Training tr on tr.id = trv.[IdTrainig] 
      left join [User] u on u.id = trv.IdUser Where trv.IdUser =@id
    END
    */
