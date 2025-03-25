using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IProviderServiceRepository : IRepositoryBase<ProviderService>
    {
        // Дополнительные методы для работы с услугами поставщиков
    }
}
