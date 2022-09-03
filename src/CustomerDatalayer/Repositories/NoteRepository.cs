using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Repositories
{
    public class NoteRepository : BaseRepository, IRepository<Notes>
    {
        public void Create(Notes entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                 "INSERT INTO [Notes] (CustomerId, Note) VALUES (@CustomerId, @Note) ", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };
                var noteParam = new SqlParameter("@Note", SqlDbType.NVarChar, 255)
                {
                    Value = entity.Note
                };
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(noteParam);
                command.ExecuteNonQuery();
            }


        }


        public Notes Read(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Notes] WHERE NoteId= @NoteId", connection);

                var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(noteIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Notes
                        {
                            CustomerId = (int)reader["CustomerId"],
                            Note = reader["Note"].ToString()
                        };
                    }
                    return null;
                }
            }
        }


        public void Update(Notes entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE [Notes] SET CustomerId = @CustomerId, Note = @Note WHERE NoteId = @NoteId", 
                    connection);

                var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int)
                {
                    Value = entity.NoteId
                };
                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };
                var noteParam = new SqlParameter("@Note", SqlDbType.NVarChar, 255)
                {
                    Value = entity.Note
                };
                command.Parameters.Add(noteIdParam);
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(noteParam);
                command.ExecuteNonQuery();
            }
        }


        public void Delete(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [Notes] WHERE NoteId = @NoteId", connection);

                var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(noteIdParam);
                command.ExecuteNonQuery();
            }
        }


        public int GetId()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT NoteId FROM Notes", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["NoteId"]);
                }
            }
            return 0;
        }


        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [Notes]", connection);
                command.ExecuteNonQuery();
            }
        }


        public List<Notes> GetAll()
        {
            using (var connection = GetConnection())
            {
                var notes = new List<Notes>();
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Notes]", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notes.Add(new Notes
                        {
                            NoteId = Convert.ToInt32(reader["NoteId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            Note = reader["Note"].ToString(),
                        });
                    }
                }
                return notes;
            }
        }
    }
}
