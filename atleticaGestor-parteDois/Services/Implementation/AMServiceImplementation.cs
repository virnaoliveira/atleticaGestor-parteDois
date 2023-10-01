using atleticaGestor_parteDois.Data;
using atleticaGestor_parteDois.Models;

namespace atleticaGestor_parteDois.Services.Implementation
{
    public class AMServiceImplementation : IAMService
    {
        private Context _context;
        public AMServiceImplementation(Context context)
        {
            _context = context;
        }
        public Associacaomembrotime Create(Associacaomembrotime am)
        {
            try
            {
                _context.Add(am);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return am;
        }

        public Associacaomembrotime Update(Associacaomembrotime am)
        {
            if (!Exists(am.membro_matricula)) return new Associacaomembrotime();
            var result = _context.Associacaomembrotime.SingleOrDefault(p => p.idtime.Equals(am.membro_matricula));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(am);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return am;
        }

        private bool Exists(long matricula)
        {
            return _context.Associacaomembrotime.Any(p => p.idtime.Equals(matricula));
        }

        public List<Associacaomembrotime> FindAll()
        {
            return _context.Associacaomembrotime.ToList();
        }

        public void Delete(long matricula)
        {
            var result = _context.Associacaomembrotime.SingleOrDefault(p => p.idtime.Equals(matricula));
            if (result != null)
            {
                try
                {
                    _context.Associacaomembrotime.Remove(result);
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
