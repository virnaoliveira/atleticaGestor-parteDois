using atleticaGestor_parteDois.Data;
using atleticaGestor_parteDois.Models;

namespace atleticaGestor_parteDois.Services.Implementation
{
    public class AtletaServiceImplementation : IAtletaService
    {

        private Context _context;
        public AtletaServiceImplementation(Context context)
        {
            _context = context;
        }
        public Atleta Create(Atleta atleta)
        {
            try
            {
                _context.Add(atleta);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return atleta;
        }

        public Atleta Update(Atleta atleta)
        {
            if (!Exists(atleta.membro_matricula)) return new Atleta();
            var result = _context.Atleta.SingleOrDefault(p => p.membro_matricula.Equals(atleta.membro_matricula));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(atleta);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return atleta;
        }

        private bool Exists(long matricula)
        {
            return _context.Atleta.Any(p => p.membro_matricula.Equals(matricula));
        }

        public List<Atleta> FindAll()
        {
            return _context.Atleta.ToList();
        }

        public void Delete(long id)
        {
            var result = _context.Atleta.SingleOrDefault(p => p.membro_matricula.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Atleta.Remove(result);
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