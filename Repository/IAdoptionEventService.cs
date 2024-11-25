using Db_FirstPet.Models;

namespace Db_FirstPet.Repository
{
    public interface IAdoptionEventService
    {
        List<AdoptionEvent> GetAllEvents();
        AdoptionEvent GetAdoptionEventById(int id);
        int AddNewEvent(AdoptionEvent adoptionEvent);

        string UpdateAdoptionEvent(AdoptionEvent adoptionEvent);
        string DeleteAdoptionEvent(int id);

    }
}
