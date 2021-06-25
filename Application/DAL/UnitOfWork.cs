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
        SqlRepository<Quiz> _quizes;
        SqlRepository<User> _users;
        SqlRepository<Pitanje> _pitanja;
        SqlRepository<Odgovor> _odgovori;
       

        public UnitOfWork()
        {
            if(_dbContext == null)
            {
                _dbContext = new QuizContext();
            }
        }

        public IRepository<Quiz> Quizes
        {
            get => _quizes ?? (_quizes = new SqlRepository<Quiz>(_dbContext));
        }

        public IRepository<User> Users
        {
            get => _users ?? (_users = new SqlRepository<User>(_dbContext));
        }

        public IRepository<Pitanje> Pitanja
        {
            get => _pitanja ?? (_pitanja = new SqlRepository<Pitanje>(_dbContext));
        }

        public IRepository<Odgovor> Odgovori
        {
            get => _odgovori ?? (_odgovori = new SqlRepository<Odgovor>(_dbContext));
        }

        public void Commit() => _dbContext.SaveChanges();
    }
}