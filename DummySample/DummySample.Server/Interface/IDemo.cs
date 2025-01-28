using DummySample.Server.Model;
using DummySample.Server.TestModel;
using static DummySample.Server.TestModel.ParameterModel;

namespace DummySample.Server.Interface
{
    public interface IDemo
    {
        Task<StatusModel<Demo>> PostData(Demo demo);
        Task<StatusModel<List<Demo>>> GetData();
        Task<StatusModel<Demo>> GetDataById(GetBYIDModel model);

        Task<StatusModel<Demo>> DeleteData(DeleteModel model);

        Task<StatusModel<Demo>> UpdateData(UpadteModel model);

     
    }
}
