using System;
using System.Collections.Generic;
using ManagerDatabase.Models;

namespace ManagerDatabase.Services
{
    public class ManagerService
    {
        private GenericRepository<Manager> manegerRepo;

        public ManagerService(ApplicationContext context)
        {
            manegerRepo = new GenericRepository<Manager>(context);
        }

        public IEnumerable<Manager> GetAll()
        {
            var items = manegerRepo.Get();
            return items;
        }
    }
}
