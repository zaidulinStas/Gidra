﻿using System;
using System.Collections.Generic;

namespace GidraSIM.NewDataBase
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetList(); 
        T Get(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
    }
}
