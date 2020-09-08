using RMDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataLibrary.DataAccess
{
    public class PersonData : IPersonData
    {
        private readonly ISqlDataAccess _sql;

        public PersonData(ISqlDataAccess sql)
        {
            _sql = sql;
        }


        public async Task InsertPerson(PersonModel person)
        {
            await _sql.SaveData<PersonModel>("People_Insert", person);
        }


        public async Task<List<PersonModel>> GetAllPeople()
        {
            var results = await _sql.LoadData<PersonModel, dynamic>("People_GetAll", new { });

            return results;
        }


        public async Task<PersonModel> GetPersonById(int id)
        {
            var results = await _sql.LoadData<PersonModel, dynamic>("People_GetById", new { id });

            return results.FirstOrDefault();
        }


        public async Task UpdatePerson(PersonModel person)
        {
            await _sql.SaveData<PersonModel>("People_Update", person);
        }


        public async Task DeletePerson(int id)
        {
            await _sql.DeleteData<dynamic>("People_Delete", new { id });
        }
    }
}
