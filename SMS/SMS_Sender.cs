using CProject.child_Module;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CProject.SMS
{
    internal class SMS_Sender
    {
       
        int z = 0;  
        string M_contact = null;

        public void Sms_send()
        {

            List<string> ContactNo = new List<string>();

            //Notification send for 2 Vaccination

            if (z == 0)
            {
                z++;
                DateTime dt = DateTime.Now;

                
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Contact from Vaccine1 v inner join Parent p on v.Mother_Addhar_no=p.Mother_Addhar_no where v.TVaccination_date=@Vdate", con);
                cmd.Parameters.Add("@vdate", SqlDbType.Date).Value = dt;
                SqlDataReader rdr = cmd.ExecuteReader();

                
                while (rdr.Read())
                {
                    ContactNo.Add(rdr["Contact"].ToString());
                }

                foreach (string ct in ContactNo)
                {
                    M_contact = ct;
                    try
                    {
                        var accountSid = $"{Environment.GetEnvironmentVariable("MY_VARIABLE")}";
                        
                        var authToken = "3ea06b0aef8c5bc27b7d25c4bfb0ca4d";
                        TwilioClient.Init(accountSid, authToken);

                        var messageOptions = new CreateMessageOptions(
                          new PhoneNumber($"+91{ct}"));
                        messageOptions.From = new PhoneNumber("+19383004933");
                        messageOptions.Body = "Your Child vaccination  2 Dose  is Today..please take Vaccination from neares Vaccination Center  ";

                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                }
                ContactNo.Clear();

            }

            //Notification send for 3 Vaccination

            if (z ==1 )
            {
                z++;

                DateTime dt = DateTime.Now;
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Contact from Vaccine2 v inner join Parent p on v.Mother_Addhar_no=p.Mother_Addhar_no where v.TVaccination_date=@Vdate", con);
                cmd.Parameters.Add("@vdate", SqlDbType.Date).Value = dt;
                SqlDataReader rdr = cmd.ExecuteReader();

                
                while (rdr.Read())
                {
                    ContactNo.Add(rdr["Contact"].ToString());
                }
                foreach (string ct in ContactNo)
                {
                    M_contact = ct;
                    try
                    {
                        
                        var accountSid = $"{Global.SID}";
                        var authToken = "3ea06b0aef8c5bc27b7d25c4bfb0ca4d";
                        TwilioClient.Init(accountSid, authToken);

                        var messageOptions = new CreateMessageOptions(
                          new PhoneNumber($"+91{ct}"));
                        messageOptions.From = new PhoneNumber("+19383004933");
                        messageOptions.Body = "Your Child vaccination  3 Dose  is Today..please take Vaccination from neares Vaccination Center";

                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                }
                ContactNo.Clear();
            }

            //Notification send for 4 Vaccination

            if (z == 2)
            {
                z++;

                DateTime dt = DateTime.Now;
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Contact from Vaccine3 v inner join Parent p on v.Mother_Addhar_no=p.Mother_Addhar_no where v.TVaccination_date=@Vdate", con);
                cmd.Parameters.Add("@vdate", SqlDbType.Date).Value = dt;
                SqlDataReader rdr = cmd.ExecuteReader();

               
                while (rdr.Read())
                {
                    ContactNo.Add(rdr["Contact"].ToString());
                }
                foreach (string ct in ContactNo)
                {
                    M_contact = ct;
                    try
                    {
                        var accountSid = $"{Global.SID}";
                        var authToken = "3ea06b0aef8c5bc27b7d25c4bfb0ca4d";
                        TwilioClient.Init(accountSid, authToken);

                        var messageOptions = new CreateMessageOptions(
                          new PhoneNumber($"+91{ct}"));
                        messageOptions.From = new PhoneNumber("+19383004933");
                        messageOptions.Body = "Your Child vaccination  4 Dose  is Today..please take Vaccination from neares Vaccination Center";

                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                }
                ContactNo.Clear();
            }

            //Notification send for 5 Vaccination

            if (z == 3)
            {
                z++;

                DateTime dt = DateTime.Now;
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Contact from Vaccine4 v inner join Parent p on v.Mother_Addhar_no=p.Mother_Addhar_no where v.TVaccination_date=@Vdate", con);
                cmd.Parameters.Add("@vdate", SqlDbType.Date).Value = dt;
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    ContactNo.Add(rdr["Contact"].ToString());
                }
                foreach (string ct in ContactNo)
                {
                    M_contact = ct;
                    try
                    {
                        var accountSid = $"{Global.SID}";
                        var authToken = "3ea06b0aef8c5bc27b7d25c4bfb0ca4d";
                        TwilioClient.Init(accountSid, authToken);

                        var messageOptions = new CreateMessageOptions(
                          new PhoneNumber($"+91{ct}"));
                        messageOptions.From = new PhoneNumber("+19383004933");
                        messageOptions.Body = "Your Child vaccination  5 Dose  is Today..please take Vaccination from neares Vaccination Center";

                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                }
                ContactNo.Clear();
            }

            //Notification send for 6 Vaccination

            if (z == 4)
            {
                z++;

                DateTime dt = DateTime.Now;
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Contact from Vaccine5 v inner join Parent p on v.Mother_Addhar_no=p.Mother_Addhar_no where v.TVaccination_date=@Vdate", con);
                cmd.Parameters.Add("@vdate", SqlDbType.Date).Value = dt;
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    ContactNo.Add(rdr["Contact"].ToString());
                }
                foreach (string ct in ContactNo)
                {
                    M_contact = ct;
                    try
                    {
                        var accountSid = $"{Global.SID}";
                        var authToken = "3ea06b0aef8c5bc27b7d25c4bfb0ca4d";
                        TwilioClient.Init(accountSid, authToken);

                        var messageOptions = new CreateMessageOptions(
                          new PhoneNumber($"+91{ct}"));
                        messageOptions.From = new PhoneNumber("+19383004933");
                        messageOptions.Body = "Your Child vaccination  6 Dose  is Today..please take Vaccination from neares Vaccination Center";

                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                }
                ContactNo.Clear();
            }

            //Notification send for 7 Vaccination

            if (z == 5)
            {
                z++;

                DateTime dt = DateTime.Now;
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Contact from Vaccine6 v inner join Parent p on v.Mother_Addhar_no=p.Mother_Addhar_no where v.TVaccination_date=@Vdate", con);
                cmd.Parameters.Add("@vdate", SqlDbType.Date).Value = dt;
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    ContactNo.Add(rdr["Contact"].ToString());
                }
                foreach (string ct in ContactNo)
                {
                    M_contact = ct;
                    try
                    {
                        var accountSid = $"{Global.SID}";
                        var authToken = "3ea06b0aef8c5bc27b7d25c4bfb0ca4d";
                        TwilioClient.Init(accountSid, authToken);

                        var messageOptions = new CreateMessageOptions(
                          new PhoneNumber($"+91{ct}"));
                        messageOptions.From = new PhoneNumber("+19383004933");
                        messageOptions.Body = "Your Child vaccination  7 Dose  is Today..please take Vaccination from neares Vaccination Center";

                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                }
                ContactNo.Clear();
            }
             
            //Notification send for 8 Vaccination 

            if (z == 6)
            {
                z++;
                DateTime dt = DateTime.Now;
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Contact from Vaccine7 v inner join Parent p on v.Mother_Addhar_no=p.Mother_Addhar_no where v.TVaccination_date=@Vdate", con);
                cmd.Parameters.Add("@vdate", SqlDbType.Date).Value = dt;
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    ContactNo.Add(rdr["Contact"].ToString());
                }
                foreach (string ct in ContactNo)
                {
                    M_contact = ct;
                    try
                    {
                        var accountSid = $"{Global.SID}";
                        var authToken = "3ea06b0aef8c5bc27b7d25c4bfb0ca4d";
                        TwilioClient.Init(accountSid, authToken);

                        var messageOptions = new CreateMessageOptions(
                          new PhoneNumber($"+91{ct}"));
                        messageOptions.From = new PhoneNumber("+19383004933");
                        messageOptions.Body = "Your Child vaccination  8 Dose  is Today..please take Vaccination from neares Vaccination Center";

                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                }
                ContactNo.Clear();
            }

            //Notification send for 9 Vaccination

            if (z == 7)
            {
                z++;
                DateTime dt = DateTime.Now;
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Contact from Vaccine8 v inner join Parent p on v.Mother_Addhar_no=p.Mother_Addhar_no where v.TVaccination_date=@Vdate", con);
                cmd.Parameters.Add("@vdate", SqlDbType.Date).Value = dt;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ContactNo.Add(rdr["Contact"].ToString());
                }
                foreach (string ct in ContactNo)
                {
                    M_contact = ct;
                    try
                    {
                        var accountSid = $"{Global.SID}";
                        var authToken = "3ea06b0aef8c5bc27b7d25c4bfb0ca4d";
                        TwilioClient.Init(accountSid, authToken);

                        var messageOptions = new CreateMessageOptions(
                          new PhoneNumber($"+91{ct}"));
                        messageOptions.From = new PhoneNumber("+19383004933");
                        messageOptions.Body = "Your Child vaccination  9 Dose  is Today..please take Vaccination from neares Vaccination Center";

                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                }
                ContactNo.Clear();
            }


            Console.ReadKey();
        }


    }
}
