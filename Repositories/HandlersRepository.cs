using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel;
using UnitApi9K.Data;
using UnitApi9K.DTOs;
using UnitApi9K.Models;

namespace UnitApi9K.Repositories
{
    public class HandlersRepository : IHandlersRepository
    {
        private readonly UnitManagementDbContext _unitManagementDbContext;
        public HandlersRepository(UnitManagementDbContext unitManagementDbContext)
        {
            _unitManagementDbContext = unitManagementDbContext;
        }
        public bool Remove(int id)
        {
            var toDelete = _unitManagementDbContext.Handlers.Where(a => a.Id == id).FirstOrDefault();
            if (toDelete == null)
            {
                return false;
            }
            else
            {
                _unitManagementDbContext.Handlers.Remove(toDelete);
                _unitManagementDbContext.SaveChangesAsync();
                return true;
            }
            
        }
    }
}
