using DummySample.Server.Common;
using DummySample.Server.Data;
using DummySample.Server.Interface;
using DummySample.Server.Model;
using Microsoft.EntityFrameworkCore;
using static DummySample.Server.TestModel.ParameterModel;

namespace DummySample.Server.Service
{
    public class DemoService : IDemo

    {
        private readonly ApplicationDbContext _context;
        public DemoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StatusModel<Demo>> DeleteData(DeleteModel model)
        {
            StatusModel<Demo> statusModel = new StatusModel<Demo>();
            try
            {
                var Data = await _context.DummyTable.SingleOrDefaultAsync(m => m.DemoID == model.ID);
                if (Data != null)
                {
                    statusModel.IsComplete = true;
                    statusModel.Data = Data;
                    statusModel.Status = 200;
                    statusModel.Message = "Data Deleted Successfully";
                    _context.Remove(Data);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    statusModel.IsComplete = false;
                    statusModel.Message = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                statusModel.IsComplete = false;
                statusModel.Message = ex.Message;
            }
            return statusModel;
        }

        public async Task<StatusModel<List<Demo>>> GetData()
        {
            StatusModel<List<Demo>> model = new StatusModel<List<Demo>>();
            try
            {
                List<Demo> list = await _context.DummyTable.ToListAsync();

                if (list.Count > 0)
                {
                    model.IsComplete = true;
                    model.Data = list;
                    model.Status = 200;
                    model.Message = "Approved";
                }
                else
                {
                    model.IsComplete = false;
                    model.Data = null;
                    model.Message = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                model.IsComplete = false;
                model.Message = ex.Message;
            }
            return model;


        }

        public async Task<StatusModel<Demo>> GetDataById(GetBYIDModel model)
        {
            StatusModel<Demo> models = new StatusModel<Demo>();
            try
            {
                var Data = await _context.DummyTable.SingleOrDefaultAsync(m => m.DemoID == model.ID);
                if (Data != null)
                {
                    models.IsComplete = true;
                    models.Data = Data;
                    models.Status = 200;
                    models.Message = "Approved";
                }
                else
                {
                    models.IsComplete = false;
                    models.Message = "No Record Found";
                    models.Status = 404;

                }
            }
            catch (Exception ex)
            {
                models.IsComplete = false;
                models.Message = ex.Message;
            }
            return models;
        }

        public async Task<StatusModel<Demo>> PostData(Demo demo)
        {
            StatusModel<Demo> model = new StatusModel<Demo>();
            try
            {
             
                var data = new Demo
                {
                   
                    Name = demo.Name,
                    Description = demo.Description,
                    Type = demo.Type,
                    CreatedBy = 7,
                };
                _context.Add(data);
                await _context.SaveChangesAsync();

                model.Status = 200;
                model.Message = "Saved successfully";
                model.Data = data;
                model.IsComplete = true;
            }
            catch (Exception ex)
            {
                model.IsComplete = false;
                model.Message = ex.Message;
            }
            return model;
        }

        public async Task<StatusModel<Demo>> UpdateData(UpadteModel model)
        {
            StatusModel<Demo> statusModel = new StatusModel<Demo>();
            try
            {
               
                var Data = await _context.DummyTable.SingleOrDefaultAsync(m => m.DemoID == model.ID);

                if (Data == null)
                {
                    statusModel.IsComplete = false;
                    statusModel.Message = "No Data Found";
                    return statusModel;
                }

                Data.Name = model.Name;
                Data.Description = model.Description;
                Data.Type = model.Type;
                Data.UpdatedBy = 7; 
                _context.Update(Data);
                await _context.SaveChangesAsync();

                statusModel.IsComplete = true;
                statusModel.Data = Data;
                statusModel.Status = 200;
                statusModel.Message = "Data Updated Successfully";
            }
            catch (Exception ex)
            {
                statusModel.IsComplete = false;
                statusModel.Message = ex.Message;
            }
            return statusModel;
        }
    }

    }
