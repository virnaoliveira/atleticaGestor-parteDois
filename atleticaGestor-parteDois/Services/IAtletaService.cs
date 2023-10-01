using atleticaGestor_parteDois.Models;

namespace atleticaGestor_parteDois.Services
{
    public interface IAtletaService
    {
        Atleta Create(Atleta atleta);
        Atleta Update(Atleta atleta);
        Atleta FindById(long id);
        List<Atleta> FindAll();
        void Delete(long id);
    }
}
