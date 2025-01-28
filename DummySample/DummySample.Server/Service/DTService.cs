using Azure;
using System.Data;
using DummySample.Server.Data;
using DummySample.Server.Interface;
using DummySample.Server.Model;
using DummySample.Server.TestModel;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DummySample.Server.Service
{
    public class DTService : IDT
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public DTService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<StatusModel<string>> DeleteByDT(ParameterModel.DeleteParamModel model)
        {
           StatusModel<string> status = new StatusModel<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Database")))
                {
                    using (SqlCommand con = new SqlCommand("DeleteData", conn))
                    {
                        con.CommandType = CommandType.StoredProcedure;
                        con.Parameters.Add(new SqlParameter("@demoid", model.DemoID));
                        using (SqlDataAdapter da = new SqlDataAdapter(con))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt != null)
                            {
                                status.Data = JsonConvert.SerializeObject(dt);
                                status.IsComplete = true;
                                status.Message = "Delete Successfully";
                            }
                            else
                            {
                                status.Data = null;
                                status.IsComplete = false;
                                status.Message = "Failed";

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                status.IsComplete = false;
                status.Message = ex.Message;
            }
            return status;
        }

        public async Task<StatusModel<string>> InsertDataByDT(ParameterModel.InsertDataParamsmodel model)
        {
            StatusModel<string> status = new StatusModel<string>();

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("Database")))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertData", sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@name", model.Name));
                        cmd.Parameters.Add(new SqlParameter("@description", model.Description));
                        cmd.Parameters.Add(new SqlParameter("@type", model.Type));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt != null)
                            {
                                status.Data = JsonConvert.SerializeObject(dt);
                                status.IsComplete = true;
                                status.Message = "Insert Successfully";
                            }
                            else
                            {
                                status.Data = null;
                                status.IsComplete = false;
                                status.Message = "Failed";

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status.IsComplete = false;
                status.Message = ex.Message;
            }
            return status;
        }

        public async Task<StatusModel<string>> UpdateByDT(ParameterModel.UpdateParamModel model)
        {
            StatusModel<string> status = new StatusModel<string>();
            try
            {
                using(SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("Database")))
                {
                    using(SqlCommand com = new SqlCommand("UpdateData",sqlcon))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@demoid",model.DemoID));
                        com.Parameters.Add(new SqlParameter("@name", model.Name));
                        com.Parameters.Add(new SqlParameter("@description",model.Description));
                        com.Parameters.Add(new SqlParameter("@type",model.Type));
                        using (SqlDataAdapter da = new SqlDataAdapter(com))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt != null)
                            {
                                status.Data = JsonConvert.SerializeObject(dt);
                                status.IsComplete = true;
                                status.Message = "Update Successfully";
                            }
                            else
                            {
                                status.Data = null;
                                status.IsComplete = false;
                                status.Message = "Failed";

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                status.IsComplete = false ;
                status.Message = ex.Message;
            }
            return status;
        }
    }
}
