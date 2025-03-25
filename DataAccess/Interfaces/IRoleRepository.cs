using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        // Дополнительные методы для работы с ролями
    }
}
