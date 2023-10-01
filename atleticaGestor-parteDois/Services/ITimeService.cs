using atleticaGestor_parteDois.Models;

namespace atleticaGestor_parteDois.Services
{
    public interface ITimeService
    {
        Time Create(Time time);
        Time Update(Time time);
        List<Time> FindAll();
        Task<Time> CadastrarEsporte(Time time);
        void Delete(long id);
    }
}
