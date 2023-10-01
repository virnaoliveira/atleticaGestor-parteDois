using atleticaGestor_parteDois.Data;
using atleticaGestor_parteDois.Models;
using Microsoft.EntityFrameworkCore;

namespace atleticaGestor_parteDois.Services.Implementation
{
    public class TimeServiceImplementation : ITimeService
    {
        private Context _context;
        public TimeServiceImplementation(Context context)
        {
            _context = context;
        }
        public Time Create(Time time)
        {
            try
            {
                time.idatletica = 1;
                _context.Add(time);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return time;
        }

        public Time Update(Time time)
        {
            var result = _context.Time.SingleOrDefault(p => p.idtime.Equals(time.idtime));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(time);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return time;

        }

        public List<Time> FindAll()
        {
            return _context.Time.ToList();
        }

        public void Delete(long id)
        {
            var result = _context.Time.SingleOrDefault(p => p.idtime.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Time.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<Time> CadastrarEsporte(Time time)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var result = await _context.Time.AnyAsync(p => p.esporte.Equals(time.esporte));
                    if (result)
                    {
                        transaction.Rollback();
                        return null;
                    }
                    else
                    {
                        time.idatletica = 1;
                        _context.Add(time);
                        await _context.SaveChangesAsync();

                        transaction.Commit();
                        return time;
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
