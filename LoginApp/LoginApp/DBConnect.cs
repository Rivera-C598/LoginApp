using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp
{
 
    internal class DBConnect
    {
        private readonly SQLiteAsyncConnection database;

        public DBConnect(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user) 
        {
            if (user.Id != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }    
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return database.DeleteAsync(user);
        }
    }
}
