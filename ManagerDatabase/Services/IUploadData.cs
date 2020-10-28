using System;
using System.Collections.Generic;

namespace ManagerDatabase.Services
{
    public interface IUploadData<TEntity>
    {
        List<TEntity> GetAll();
    }
}
