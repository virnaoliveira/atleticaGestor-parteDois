using atleticaGestor_parteDois.Data;
using atleticaGestor_parteDois.Models;

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
            if (!Exists(time.idtime)) return new Time();
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

        private bool Exists(long idtime)
        {
            return _context.Time.Any(p => p.idtime.Equals(idtime));
        }

        public List<Time> FindAll()
        {
            return _context.Time.ToList();
        }

        public Time FindById(long id)
        {
            return _context.Time.SingleOrDefault(p => p.idtime.Equals(id));
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
    }
}
