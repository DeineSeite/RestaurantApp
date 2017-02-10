using System;
using System.Collections.Generic;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Data.Access
{
    public interface IDataAccess
    {
        void CreateTable<T>() where T : BaseModel;
        IEnumerable<T> GetTable<T>() where T : BaseModel;
        int AddNewRow<T>(T row) where T : BaseModel;
        int InsertOrUpdateRow<T>(T unit) where T : BaseModel;
        int UpdateRow<T>(T unit) where T : BaseModel;
        T GetRow<T>(int id) where T : BaseModel;
        IEnumerable<T> GetRowsWhere<T>(Func<T, bool> where) where T : BaseModel;
        int DeleteRow<T>(T unit) where T : BaseModel;
        void DeleteAllRows<T>() where T : BaseModel;
        void CreateTables();
    }
}