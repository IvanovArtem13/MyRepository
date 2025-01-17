﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineCard.Models;
using Microsoft.EntityFrameworkCore;


namespace MedicineCard.Services
{
    public class EfRepository<T> : IEfRepository<T> where T : BaseEntity 
    {
        protected readonly DataContext _context;

        public EfRepository(DataContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            var collection = _context.Set<T>().ToList();
            return collection;
        }

        public T GetById(long id)
        {
            var entity = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            return entity;
        }


        public async Task<long> Add(T entity)
        {
            var result = await _context.AddAsync(entity);
            _context.SaveChanges();
            return result.Entity.Id;           
        }

        public long Update(T entity)
        {
            var result = _context.Update(entity);
            _context.SaveChanges();
            return result.Entity.Id;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
