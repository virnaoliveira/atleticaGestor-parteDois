using atleticaGestor_parteDois.Models;

namespace atleticaGestor_parteDois.Services
{
    public interface IAMService
    {
        Associacaomembrotime Create(Associacaomembrotime associacaomembrotime);
        Associacaomembrotime Update(Associacaomembrotime associacaomembrotime);
        List<Associacaomembrotime> FindAll();
        void Delete(long matricula);
    }
}
