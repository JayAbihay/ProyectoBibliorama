using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        Task GuardarAsync();
    }
}
