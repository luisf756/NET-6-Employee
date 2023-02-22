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
    public class EmployeeRepository : IEmployRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public EmployeeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM employees where emp_id= @Id ";

            var result= await db.ExecuteAsync(sql , new {ID = employee.Emp_Id });
           
            return result > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var db = dbConnection();
            var sql = @"select employees.emp_id, employees.name,employees.last_name, employees.email, employees.personal_address, 
            employees.phone, employees.workin_start_date, employees.picture, employees.fk_rol, roles.rol_description, employees.salary 
            from employees
            inner join hrmagement.roles
            where roles.id_roles = employees.fk_rol;";
            return await db.QueryAsync<Employee>(sql, new { });
        }

        public async Task<Employee> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @"select employees.emp_id,employees.name,employees.last_name, employees.email, employees.personal_address, employees.phone, employees.workin_start_date, employees.picture, employees.fk_rol, roles.rol_description, employees.salary 
                from employees
                inner join hrmagement.roles
                where roles.id_roles = employees.fk_rol and
                emp_id = @Id";
            return await db.QueryFirstOrDefaultAsync<Employee>(sql, new {Id=id });
        }

        public async Task<bool> InsertEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO employees(name, last_name, email, personal_address, phone, workin_start_date, picture, fk_rol, salary) 
                values(@Name, @Last_Name, @Email, @personal_Address, @Phone, @Workin_Start_Date , @Picture, @Fk_Rol, @Salary)";

            var result = await db.ExecuteAsync(sql, new 
            { employee.Name, employee.Last_Name, employee.Email, employee.Personal_Address, employee.Phone, employee.Workin_Start_Date,
                employee.Picture, employee.Fk_Rol, employee.Salary, employee.Emp_Id });

            return result > 0;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"UPDATE employees
                        SET name=@Name,
                            last_name=@Last_Name,
                            email=@Email,
                            personal_address=@Personal_Address,
                            phone=@Phone,
                            workin_start_date= @Workin_Start_Date,
                            picture=@Picture,
                            fk_rol=@Fk_Rol,
                            salary=@Salary
                            WHERE emp_id=@Emp_Id ";

            var result = await db.ExecuteAsync(sql, new
            { employee.Name, employee.Last_Name, employee.Email, employee.Personal_Address, employee.Phone, employee.Workin_Start_Date, employee.Picture, employee.Fk_Rol, employee.Salary, employee.Emp_Id, });

            return result > 0;
        }

        public async Task<Employee> RecalculateSalaryEmployee(int id)
        {
            var db = dbConnection();
            var sql = "sp_recalculate_salary";


            return (Employee)await db.QueryAsync(sql, param:new { sp_Emp_id = id },
                commandType: CommandType.StoredProcedure);


    //        return await db.QueryFirstOrDefaultAsync<Employee>(sql, param: new { sp_Emp_id = id },
    //commandType: CommandType.StoredProcedure);

            //var command = new MySqlCommand("sp_recalculate_salary", connection: dbConnection());
            ////command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@Emp_Id", employee.Emp_Id);
            //using var reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    // lee los resultados aquí
            //}

        }

        //Task<Employee> IEmployRepository.RecalculateSalaryEmployee(int id)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<IEnumerable<Employee>> Export_DataEmployees()
        //{
        //    var db = dbConnection();
        //    var sql = @"call spExport_dataEmployees() ";

        //    return await db.QueryAsync<Employee>(sql, new { });
        //}





    }
}
