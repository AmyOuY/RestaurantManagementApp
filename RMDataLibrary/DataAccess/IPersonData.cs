using RMDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataLibrary.DataAccess
{
    public interface IPersonData
    {
        Task DeletePerson(int id);
        Task<List<PersonModel>> GetAllPeople();
        Task<PersonModel> GetPersonById(int id);
        Task InsertPerson(PersonModel person);
        Task UpdatePerson(PersonModel person);
    }
}