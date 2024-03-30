using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Repository.Data
{
    public class PersonaRepository : InterfacePersona
    {
        private IDbConnection conexionDB;
        public PersonaRepository(string _connectionString)
        {
            conexionDB = new DbConnection(_connectionString).dbConnection();
        }
        public bool add(PersonaModel persona)
        {
            try
            {
                if(conexionDB.Execute("insert into Persona(nombre, apellido, cedula) values (@nombre, @apellido, @cedula)", persona) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersonaModel get(string cedula)
        {
            try
            {
                return conexionDB.Query<PersonaModel>("Select * from Persona where cedula = @cedula", new { cedula }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PersonaModel> list()
        {
            try
            {
                return conexionDB.Query<PersonaModel>("Select * from Persona");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool remove(string cedula)
        {
            try
            {
                if (conexionDB.Execute("Delete from Persona where cedula = @cedula", new { cedula }) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(PersonaModel persona)
        {
            try
            {
                if (conexionDB.Execute("Update Persona set nombre = @nombre, apellido = @apellido where cedula = @cedula", persona) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
