using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoLibrary.Models;

namespace ToDoLibrary.DataAccess
{
    public class ToDoData
    {
        private readonly ISqlDataAccess _sql;

        public ToDoData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public Task <List<ToDoModel>> GetAllAssigned(int assignedTo)
        {
            return _sql.LoadData<ToDoModel, dynamic>(
                "dbp.spToDos_GetAllAssigned",
                new { AssignedTo = assignedTo },
                "Default");
        }

        public async Task<ToDoModel?> GetOneAssigned(int assignedTo, int toDoId)
        {
            var results = await _sql.LoadData<ToDoModel, dynamic>(
                "dbo.spToDos_GetOneAssigned",
                new { AssignedTo = assignedTo, ToDoId = toDoId },
                "Default");
            return results.FirstOrDefault();
        }


    }
}
