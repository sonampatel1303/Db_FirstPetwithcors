using Db_FirstPet.Models;

namespace Db_FirstPet.Repository
{
    public class ParticipantService : IParticipantService
    {
        private PetPalsContext _context;

        public ParticipantService(PetPalsContext context)
        {
            _context = context;
        }
        public int AddNewParticipant(Participant participant)
        {
            try
            {
                if (participant != null)
                {
                    _context.Participants.Add(participant);
                    _context.SaveChanges();
                    return participant.ParticipanntId;

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

        public string DeleteParticipant(int id)
        {
            if (id != null)
            {
                var participant = _context.Participants.FirstOrDefault(x => x.ParticipanntId == id);
                if (participant!= null)
                {
                    _context.Participants.Remove(participant);
                    _context.SaveChanges();
                    return "the given Partcipant id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public List<Participant> GetAllpartcipants()
        {
            var participant = _context.Participants.ToList();
            if (participant.Count > 0)
            {
                return participant;
            }
            else
                return null;
        }

        public Participant GetParticipantById(int id)
        {
            if (id != 0 || id != null)
            {
                var participant = _context.Participants.FirstOrDefault(x => x.ParticipanntId == id);
                if (participant != null)
                    return participant;
                else
                    return null;
            }
            return null;
        }

        public string UpdateParticipant(Participant participant)
        {
            var existingParticipant = _context.Participants.FirstOrDefault(x => x.ParticipanntId == participant.ParticipanntId);
            if (existingParticipant != null) { 
            existingParticipant.ParticipanntId = participant.ParticipanntId;
                existingParticipant.ParticipantType = participant.ParticipantType;
                existingParticipant.ParticipantName = participant.ParticipantName;
                existingParticipant.EventId = participant.EventId;
                _context.Entry(existingParticipant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
