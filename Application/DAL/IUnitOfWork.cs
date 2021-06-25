using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL
{
    public interface IUnitOfWork
    {
        IRepository<Quiz> Quizes { get; }
        IRepository<User> Users { get; }
        IRepository<Pitanje> Pitanja { get; }
        IRepository<Odgovor> Odgovori { get; }
        void Commit();
    }
}
