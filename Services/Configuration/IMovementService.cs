using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IMovementService
    {
        public Task<IEnumerable<MovementVM>> GetMovements();
        public Task<string> UpdateMovement(MovementVM movement);
        public Task<string> SaveMovement(MovementVM movement);
    }
}
