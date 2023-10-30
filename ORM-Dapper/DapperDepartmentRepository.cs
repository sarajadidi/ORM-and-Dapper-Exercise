using System;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace ORM_Dapper
{
	public class DapperDepartmentRepository : IDepartmentRepository
	{
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
		{
            _connection = connection;
		}

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments;");
        }

        
    }
}

