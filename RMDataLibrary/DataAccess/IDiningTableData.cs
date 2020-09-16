using RMDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataLibrary.DataAccess
{
    public interface IDiningTableData
    {
        Task DeleteTable(int id);
        Task<List<DiningTableModel>> GetAllTables();
        Task<List<int>> GetAllTableNumbers();
        Task<DiningTableModel> GetTableById(int id);
        Task<DiningTableModel> GetTableByTableNumber(int tableNumber);
        Task InsertTable(DiningTableModel table);
        Task UpdateTable(DiningTableModel table);
    }
}