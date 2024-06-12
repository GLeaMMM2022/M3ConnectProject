using System.Collections.Generic;
using System.Linq;
using M3ConnectProject.Models;

namespace M3ConnectProject.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly List<Contract> _contracts = new List<Contract>();

        public ContractRepository()
        {
            // Пример начальных данных
            _contracts.Add(new Contract
            {
                Id = 1,
                FullName = "Иванов Иван Иванович",
                IpAddress = "192.168.0.1",
                ServiceType = ServiceType.Internet,
                ContractDate = new System.DateTime(2024, 5, 30),
                IsActive = true
            });
            _contracts.Add(new Contract
            {
                Id = 2,
                FullName = "Петров Петр Петрович",
                IpAddress = "192.168.0.2",
                ServiceType = ServiceType.VideoSurveillance,
                ContractDate = new System.DateTime(2024, 5, 30),
                IsActive = false
            });
        }

        public IEnumerable<Contract> GetAll() => _contracts;

        public Contract GetById(int id) => _contracts.FirstOrDefault(c => c.Id == id);

        public void Add(Contract contract)
        {
            contract.Id = _contracts.Any() ? _contracts.Max(c => c.Id) + 1 : 1;
            _contracts.Add(contract);
        }

        public void Update(Contract contract)
        {
            var index = _contracts.FindIndex(c => c.Id == contract.Id);
            if (index >= 0) _contracts[index] = contract;
        }

        public void Delete(int id) => _contracts.RemoveAll(c => c.Id == id);
    }
}
