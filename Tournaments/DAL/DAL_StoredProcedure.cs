using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.DAL
{
    public class DAL_StoredProcedure
    {
        SqlConnection con = null;
        public int DeleteFromTournament(Int64 iTournament, List<Event> _events)
        {
            int result = 0;
            String _w = "";

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AppDbContext"].ToString());
            SqlCommand cmd = new SqlCommand("DeleteFromTournament", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {

                foreach (var _ent in _events)
                {
                    cmd.Parameters.AddWithValue("@TournamentID", iTournament);
                    cmd.Parameters.AddWithValue("@EventID", _ent.EventID);


                    if (_w == "")
                    {
                        con.Open();
                        _w = "PW";
                    }
                    result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }


                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                con.Close();
            }
        }


        public int DeleteFromEvent(Int64 iEvent)
        {
            int result = 0;
            String _w = "";

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AppDbContext"].ToString());
            SqlCommand cmd = new SqlCommand("DeleteFromEvent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {

                
                    cmd.Parameters.AddWithValue("@EventID", iEvent);
                    


                    if (_w == "")
                    {
                        con.Open();
                        _w = "PW";
                    }
                    result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                


                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}