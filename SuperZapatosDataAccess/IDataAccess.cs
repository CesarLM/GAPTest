using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosDataAccess
{
    public interface IDataAccess<DTO> where DTO : class
    {
        DTO GetById(Guid? id);

        List<DTO> Get();

        void Insert(DTO InsertDTO);

        void Update(DTO UpdateDTO);

        void Delete(Guid? id);
    }
}
