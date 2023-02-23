using Dapper;
using EmployService.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployService.Data.Repositories
{
    public class SalaryHistoryRepository : ISalaryHistoryRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public SalaryHistoryRepository(MySQLConfiguration connectionString)          
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<SalaryHistory>> GetAllSalarys()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM hrmagement.salary_history;";
            return await db.QueryAsync<SalaryHistory>(sql, new { });
        }
        public async Task<IEnumerable<SalaryHistory>> GetHistoryId(int id)
        {
            var db=dbConnection();
            
            var sql = @"SELECT  salary_period, date_salary_initial, date_salary_end, employees.name, employees.last_name, 
	            roles.rol_description
                FROM salary_history
                inner join hrmagement.employees
                inner join hrmagement.roles
                where salary_history.fk_id_employee=employees.emp_id and roles.id_roles= employees.fk_rol  
                and employees.emp_id=@Id;";
            return await db.QueryAsync<SalaryHistory>(sql, new { Id = id });
            //return (SalaryHistory)await db.QueryAsync(sql, param: new { sp_Emp_id = id };
            //return await db.QueryFirstOrDefaultAsync<SalaryHistory>(sql, new { Id = id });

        }
    }
}
