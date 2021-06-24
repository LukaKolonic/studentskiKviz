using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        static QuizContext _dbContext;
        SqlRepository<Quiz> _customers;
        SqlRepository<User> _orders;

        public UnitOfWork()
        {
            if(_dbContext == null)
            {
                _dbContext = new QuizContext();
            }
        }

        public IRepository<Quiz> Quizes
        {
            get
            {
                return _customers ??
                    (_customers = new SqlRepository<Quiz>(_dbContext));
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return _orders ??
                    (_orders = new SqlRepository<User>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}