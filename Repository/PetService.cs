using Db_FirstPet.Models;

namespace Db_FirstPet.Repository
{
    public class PetService : IPetService
    {
        private PetPalsContext _context;

        public PetService(PetPalsContext context) { 
        _context = context;
        }
        public int AddNewPet(Pet pet)
        {
            try
            {
                if (pet != null)
                {
                    _context.Pets.Add(pet);
                    _context.SaveChanges();
                    return pet.PetId;

                }
                else {
                    return 0;
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public string DeletePet(int id)
        {
            if (id != null)
            {
                var pet = _context.Pets.FirstOrDefault(x => x.PetId == id);
                if (pet != null)
                {
                    _context.Pets.Remove(pet);
                    _context.SaveChanges();
                    return "the given Pet id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public List<Pet> GetAllPets()
        {
            var pets = _context.Pets.ToList();
            if (pets.Count > 0)
            {
                return pets;
            }
            else
                return null;
        }

        public Pet GetPetById(int id)
        {
            if (id != 0 || id != null)
            {
                var pet = _context.Pets.FirstOrDefault(x => x.PetId == id);
                if (pet != null)
                    return pet;
                else
                    return null;
            }
            return null;
        }

        public string UpdatePet(Pet pet)
        {
            var existingPet = _context.Pets.FirstOrDefault(x => x.PetId == pet.PetId);
            if (existingPet != null)
            {
                existingPet.Name =pet.Name;
                existingPet.OwnerId = pet.OwnerId;
                existingPet.PetId = pet.PetId;
                existingPet.Age = pet.Age;
                existingPet.Breed = pet.Breed;
                existingPet.ShelterId = pet.ShelterId;
                existingPet.Type = pet.Type;
                existingPet.AvailableForAdoption = pet.AvailableForAdoption;
                _context.Entry(existingPet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
