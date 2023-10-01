using atleticaGestor_parteDois.Models;

namespace atleticaGestor_parteDois.Services
{
    public interface IAtletaService
    {
        Atleta Create(Atleta atleta);
        Atleta Update(Atleta atleta);
        List<Atleta> FindAll();
        void Delete(long id);
    }
}
