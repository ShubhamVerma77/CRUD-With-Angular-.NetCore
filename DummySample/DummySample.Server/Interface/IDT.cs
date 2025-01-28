using DummySample.Server.Model;
using static DummySample.Server.TestModel.ParameterModel;

namespace DummySample.Server.Interface
{
    public interface IDT
    {
        Task<StatusModel<string>> InsertDataByDT(InsertDataParamsmodel model);
        Task<StatusModel<string>> UpdateByDT(UpdateParamModel model);
        Task<StatusModel<string>>DeleteByDT(DeleteParamModel model);
    }
}
