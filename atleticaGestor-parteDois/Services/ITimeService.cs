using atleticaGestor_parteDois.Models;

namespace atleticaGestor_parteDois.Services
{
    public interface ITimeService
    {
        Time Create(Time time);
        Time Update(Time time);
        Time FindById(long id);
        List<Time> FindAll();
        void Delete(long id);
    }
}
