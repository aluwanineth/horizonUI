using HorizonPollyC.Models.UserManagement;

namespace HorizonPollyC.Services.UserManagement
{
    public interface IUserManagementService
    {
        public Task<IEnumerable<Features>> GetFeatures();
        public Task<IEnumerable<Roles>> GetRoles();
        public Task<IEnumerable<Features>> GetRoleFeatures(string RoleID);
        public Task<IEnumerable<Features>> GetUsersFeatures(string UserName);
        public Task<IEnumerable<UserRoles>> GetUserRoles(string UserName);
        public Task CreateUpdateFeature(Features model);
        public Task CreateUpdateRole(Roles model);
        public Task AddRoleFeature(RoleFeature model);
        public Task AddUserFeature(UserFeature model);

        public Task DeleteFeature(int ID);
        public Task DeleteRole(int ID);
        public Task DeleteUserFeature(int ID, string UserID);
        public Task DeleteRoleFeature(int ID, int RoleID);


    }
}
