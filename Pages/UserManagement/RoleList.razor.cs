using HorizonPollyC.Models.UserManagement;
using HorizonPollyC.Services.UserManagement;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.UserManagement
{
    partial class RoleList
    {
        RadzenDataGrid<Roles> rolegrid;
        public IEnumerable<Roles> roleList = new List<Roles>();
        Roles rolesToInsert;
        bool enable = true;
        public RoleList()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            roleList = await _userManagementService.GetRoles();

        }

        async Task EditRow(Roles roles)
        {
            await rolegrid.EditRow(roles);
        }

        async void OnUpdateRow(Roles roles)
        {
            if (roles == rolesToInsert)
            {
                rolesToInsert = null;
            }

            await _userManagementService.CreateUpdateRole(roles);
        }

        async Task SaveRow(Roles roles)
        {
            if (roles == rolesToInsert)
            {
                rolesToInsert = null;
            }

            await rolegrid.UpdateRow(roles);
        }

        void CancelEdit(Roles roles)
        {
            if (roles == rolesToInsert)
            {
                rolesToInsert = null;
            }

            rolegrid.CancelEditRow(roles);

        }

        async Task DeleteRow(Roles roles)
        {
            if (roles == rolesToInsert)
            {
                rolesToInsert = null;
            }

            if (roleList.Contains(roles))
            {
                roleList.ToList().Remove(roles);
                await rolegrid.Reload();
            }
            else
            {
                rolegrid.CancelEditRow(roles);
            }
        }

        async Task InsertRow()
        {
            enable = false;
            rolesToInsert = new Roles();
            await rolegrid.InsertRow(rolesToInsert);

        }

        async Task OnCreateRow(Roles roles)
        {
            await _userManagementService.CreateUpdateRole(roles);
        }
    }
}
