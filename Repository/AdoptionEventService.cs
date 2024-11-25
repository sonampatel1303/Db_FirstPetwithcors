using Db_FirstPet.Models;

namespace Db_FirstPet.Repository
{
    public class AdoptionEventService : IAdoptionEventService
    {
        private PetPalsContext _context;

        public AdoptionEventService(PetPalsContext context)
        {
            _context = context;
        }
        public int AddNewEvent(AdoptionEvent adoptionEvent)
        {
            try
            {
                if (adoptionEvent != null)
                {
                    _context.AdoptionEvents.Add(adoptionEvent);
                    _context.SaveChanges();
                    return adoptionEvent.EventId;

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteAdoptionEvent(int id)
        {
            if (id != null)
            {
                var events = _context.AdoptionEvents.FirstOrDefault(x => x.EventId == id);
                if (events != null)
                {
                    _context.AdoptionEvents.Remove(events);
                    _context.SaveChanges();
                    return "the given event id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public AdoptionEvent GetAdoptionEventById(int id)
        {
            if (id != 0 || id != null)
            {
                var events = _context.AdoptionEvents.FirstOrDefault(x => x.EventId == id);
                if (events != null)
                    return events;
                else
                    return null;
            }
            return null;
        }

        public List<AdoptionEvent> GetAllEvents()
        {
            var events= _context.AdoptionEvents.ToList();
            if (events.Count > 0)
            {
                return events;
            }
            else
                return null;
        }

        public string UpdateAdoptionEvent(AdoptionEvent adoptionEvent)
        {
            var existingEvent = _context.AdoptionEvents.FirstOrDefault(x => x.EventId==adoptionEvent.EventId);
            if (existingEvent != null)
            {
                existingEvent.EventId = adoptionEvent.EventId;
                existingEvent.EventName = adoptionEvent.EventName;
                existingEvent.EventDate = adoptionEvent.EventDate;
                existingEvent.Location = adoptionEvent.Location;
                _context.Entry(existingEvent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return "Record Updated successfully";
            }
            else
            {

                return "something went wrong while update";
            }

        }
    }
}
