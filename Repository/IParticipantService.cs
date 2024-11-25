using Db_FirstPet.Models;

namespace Db_FirstPet.Repository
{
    public interface IParticipantService
    {
        List<Participant> GetAllpartcipants();
        Participant GetParticipantById(int id);

        int AddNewParticipant(Participant participant);
        string UpdateParticipant(Participant participant);
        string DeleteParticipant(int id);
    }
}
