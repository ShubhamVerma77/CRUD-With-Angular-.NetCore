using System.Data;
using DummySample.Server.Data;
using DummySample.Server.Interface;
using DummySample.Server.Model;
using DummySample.Server.TestModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DummySample.Server.Service
{
    public class SPService : ISP
    {
        private readonly ApplicationDbContext _context;
        public SPService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StatusModel<List<GetAllDataModel>>> GetAllAsync()
        {
       StatusModel<List<GetAllDataModel>> statusModel = new StatusModel<List<GetAllDataModel>>();
            try
            {
                List<GetAllDataModel> list = await _context.Set<GetAllDataModel>().FromSql($"GetAllData").ToListAsync();
                if (list.Count > 0)
                {
                    statusModel.Message = "List Approved Successfully";
                    statusModel.IsComplete = true;
                    statusModel.Data = list;
                    statusModel.Status = 200;

                }
                else
                {
                    statusModel.IsComplete = false;
                    statusModel.Message = "List Approved Deny";
                }
            }
            catch (Exception ex)
            {
                statusModel.Message=ex.Message;
            }
            return statusModel;
        }

    }
}
