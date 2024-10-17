using Hims.Arquitecture.Models;
using Hims.Data.ClienteRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TM.Data.CitaRepository
{
    public interface ICitaRepository : IRepository<Cita>
    {
        bool AddCita(Cita cita);
        bool DeleteCita(int id);
        IEnumerable<Cita> GetAllCitas();
        Cita GetCitaById(int id);
        Cita UpdateCita(Cita cita);
        IEnumerable<Cita> FindCitas(Expression<Func<Cita, bool>> predicate);
    }

    public class CitaRepository : Repository<Cita>, ICitaRepository
    {
        public CitaRepository(HimsContext context) : base(context)
        {
        }

        public bool AddCita(Cita cita)
        {
            return Add(cita);
        }

        public bool DeleteCita(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita == null)
            {
                return false;
            }

            _context.Citas.Remove(cita);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Cita> GetAllCitas()
        {
            return GetAll();
        }

        public Cita GetCitaById(int id)
        {
            return GetById(id);
        }

        public Cita UpdateCita(Cita cita)
        {
            return Update(cita);
        }

        public IEnumerable<Cita> FindCitas(Expression<Func<Cita, bool>> predicate)
        {
            return Find(predicate);
        }
    }
}