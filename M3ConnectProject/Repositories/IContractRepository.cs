using System.Collections.Generic;
using M3ConnectProject.Models;

namespace M3ConnectProject.Repositories
{
    public interface IContractRepository
    {
        IEnumerable<Contract> GetAll();
        Contract GetById(int id);
        void Add(Contract contract);
        void Update(Contract contract);
        void Delete(int id);
    }
}
