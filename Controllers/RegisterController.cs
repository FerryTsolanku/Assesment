using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using Assesment.Models;
using System.Net.Mail;
using System.Data;

namespace Assesment.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["PersonalDetails"].ToString();
            con = new SqlConnection(constr);
        }
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult IndexList()
        //{
        //    return View();
        //}

        public ActionResult IndexList()
        {
            List<RegisterModel> reg = new List<RegisterModel>();
            reg = getPersonalDetails();

            return View(reg);
        }

        [HttpPost]
        public ActionResult Index(RegisterModel Reg)
        {   try
            {
                
                if (ModelState.IsValid)
                {

                    if (Reg.Password == Reg.ConfirmPassword)
                    {
                        //insert to databse
                        RegsiterAdd(Reg);
                        ViewData["Message"] = "Success";
                        //send mail 
                        MailMessage mail = new MailMessage();

                        mail.To.Add(Reg.Email);
                       
                        System.Text.StringBuilder Body = new System.Text.StringBuilder();
                        Body.Append("Name :   " + Reg.Name);
                        Body.Append("Email :   " + Reg.Email);
                        Body.Append("Click Link :   " + " http://localhost:56050/Register/IndexList");
                        Body.Append("Comments :   " + Reg.Comments);

                        mail.Body = Body.ToString();
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Send(mail);
                    }
                    else
                    {
                        ViewData["Message"] = "Password dont match with confirmed password";


                    }

                }
                return View();
            }
            catch(Exception ex)
            {
                return View(ex + "Error");
            }
        }

        public bool RegsiterAdd(RegisterModel Obj)
        {
            connection();
            SqlCommand com = new SqlCommand("sp_Register",con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", Obj.Name);
            com.Parameters.AddWithValue("@Surname", Obj.Surname);
            com.Parameters.AddWithValue("@Email", Obj.Email);
            com.Parameters.AddWithValue("@Password", Obj.Password);
            com.Parameters.AddWithValue("@ConfirmPassword", Obj.ConfirmPassword);
            com.Parameters.AddWithValue("@Countries", Obj.Countries);
            com.Parameters.AddWithValue("@Fav_Color", Obj.FavouriteColor);
            com.Parameters.AddWithValue("@Birthday", Obj.Birthday);
            com.Parameters.AddWithValue("@PhoneNo", Obj.PhoneNumber);
            com.Parameters.AddWithValue("@Comments", Obj.Comments);

            con.Open();

            int i = com.ExecuteNonQuery();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return true;
            }
            
        }

        public static List<RegisterModel> getPersonalDetails()
        {
       
            string sql = "sp_getRegister";

            List<RegisterModel> RegList = new List<RegisterModel>();
            try
            {
                string connectstring = ConfigurationManager.ConnectionStrings["PersonalDetails"].ConnectionString;//Connection string
                SqlDataReader sqlReader = default(SqlDataReader);
                SqlCommand sqlCom = default(SqlCommand);

                using (SqlConnection connection = new SqlConnection(connectstring))
                {
                    connection.Open();
                    sqlCom = new SqlCommand(sql, connection);
                    sqlCom.CommandType = CommandType.StoredProcedure;

                    sqlReader = sqlCom.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        RegisterModel RegModel = new RegisterModel();
                        RegModel.Name = sqlReader["Name"].ToString();
                        RegModel.Surname = sqlReader["Surname"].ToString();
                        RegModel.Email = sqlReader["Email"].ToString();
                        RegModel.Password = sqlReader["Password"].ToString();
                        RegModel.ConfirmPassword = sqlReader["ConfirmPassword"].ToString();
                        RegModel.FavouriteColor = sqlReader["Fav_Color"].ToString();
                        RegModel.Birthday = DateTime.Parse(sqlReader["Birthday"].ToString());
                        RegModel.PhoneNumber = sqlReader["PhoneNo"].ToString();
                        RegModel.Comments = sqlReader["Comments"].ToString();
                        RegList.Add(RegModel);
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
 
            }
            
                return RegList;

        }
    }
}