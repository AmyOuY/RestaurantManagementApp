using RMDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataLibrary.DataAccess
{
    public interface IDiningTableData
    {
        Task DeleteTable(int id);
        Task<List<DiningTableModel>> GetAllTables();
        Task<DiningTableModel> GetTableById(int id);
        Task InsertTable(DiningTableModel table);
        Task UpdateTable(DiningTableModel table);
    }
}