using Db_FirstPet.Models;

namespace Db_FirstPet.Repository
{
    public interface IPetService
    {
        List<Pet> GetAllPets();
        Pet GetPetById(int id);
        int AddNewPet(Pet pet);
        string UpdatePet(Pet pet);
        string DeletePet(int id);
    }
}
