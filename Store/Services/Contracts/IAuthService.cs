using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles {get;}

        IEnumerable<IdentityUser>GetAllUsers();
        Task<IdentityUser> GetOneUser(string UserName);

        Task<UserDtoForUpdate>GetOneUserForUpdate(string userName);
        Task<IdentityResult>CreateUser(UserDtoForCreation userDto);


        Task Update(UserDtoForUpdate userDto);
    }
} 