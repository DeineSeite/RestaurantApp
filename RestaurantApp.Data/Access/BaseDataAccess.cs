using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RestaurantApp.Data.Models;
using SQLite.Net;
using Xamarin.Forms;

namespace RestaurantApp.Data.Access
{
    public abstract class BaseDataAccess : IDataAccess
    {
        protected static readonly object _collisionLock = new object();
        protected readonly SQLiteConnection _database;
        public abstract void CreateTables();

        protected BaseDataAccess()
        {
            _database =
                DependencyService.Get<IDatabaseConnection>().
                    DbConnection();
        }

        /// <summary>
        ///     Get all rows from Table type T
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <returns>Rows</returns>
        public IEnumerable<T> GetTable<T>() where T : BaseModel
        {
            lock (_collisionLock)
            {
                var result = _database.Table<T>();
                return result;
            }
        }

        /// <summary>
        ///     Get row with id
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="id">Row id</param>
        /// <returns>One row</returns>
        public T GetRow<T>(int id) where T : BaseModel
        {
            lock (_collisionLock)
            {
                var result = _database.Table<T>().FirstOrDefault(x => x.Id == id);
                return result;
            }
        }

        /// <summary>
        ///     Get all rows with where clause
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="where">Where clause</param>
        /// <returns>Rows</returns>
        public IEnumerable<T> GetRowsWhere<T>(Func<T, bool> where) where T : BaseModel
        {
            lock (_collisionLock)
            {
                var result = _database.Table<T>().Where(where);
                return result;
            }
        }

        /// <summary>
        /// Insert one row in table T
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="row">Model</param>
        /// <returns>Row id</returns>
        public int AddNewRow<T>(T row) where T : BaseModel
        {
            lock (_collisionLock)
            {
                _database.Insert(row);
                return row.Id;
            }
        }

        /// <summary>
        ///     Insert or update row which main type is BaseModel
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="row"></param>
        /// <returns>Row Id</returns>
        public int InsertOrUpdateRow<T>(T row) where T : BaseModel
        {
            lock (_collisionLock)
            {
                _database.InsertOrReplace(row);
                return row.Id;
            }
        }


        /// <summary>
        ///     Update which main type is BaseModel
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="row"></param>
        /// <returns>Row Id</returns>
        public int UpdateRow<T>(T row) where T : BaseModel
        {
            lock (_collisionLock)
            {
                _database.Update(row);
                return row.Id;
            }
        }

        /// <summary>
        ///     Delete row
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="unit"></param>
        /// <returns>Id</returns>
        public int DeleteRow<T>(T unit) where T : BaseModel
        {
            lock (_collisionLock)
            {
                _database.Delete<T>(unit.Id);
                return unit.Id;
            }
        }

        /// <summary>
        /// Delete all rows from table T
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        public void DeleteAllRows<T>() where T : BaseModel
        {
            lock (_collisionLock)
            {
                _database.DeleteAll<T>();
            }
        }

        public void CreateTable<T>() where T : BaseModel
        {
            lock (_collisionLock)
            {
                _database.CreateTable<T>();
            }
        }


    }
}