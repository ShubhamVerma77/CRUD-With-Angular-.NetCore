using DummySample.Server.Model;
using DummySample.Server.TestModel;
using Microsoft.EntityFrameworkCore;

namespace DummySample.Server.Interface
{
    public interface ISP
    {
       public Task<StatusModel<List<GetAllDataModel>>> GetAllAsync();

    }
}
