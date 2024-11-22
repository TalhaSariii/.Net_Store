using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;

        public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                return result; // Hatalar Controller tarafından işlenecek
            }

            if (userDto.Roles.Any())
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                {
                    return roleResult; // Rollerle ilgili hataları döndür
                }
            }

            return result; // Başarılı sonucu döndür
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<IdentityUser> GetOneUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new Exception($"User with username '{userName}' not found.");
            }
            return user;
        }

        public async Task<UserDtoForUpdate> GetOneUserForUpdate(string userName)
        {
            var user = await GetOneUser(userName);
            if (user == null)
            {
                throw new Exception($"User with username '{userName}' not found.");
            }

            var userDto = _mapper.Map<UserDtoForUpdate>(user);
            userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name));
            userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));

            return userDto;
        }

        public async Task Update(UserDtoForUpdate userDto)
        {
            var user = await GetOneUser(userDto.UserName);
            if (user == null)
            {
                throw new Exception($"User with username '{userDto.UserName}' not found.");
            }

            user.PhoneNumber = userDto.PhoneNumber;
            user.Email = userDto.Email;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new Exception("Failed to update the user.");
            }

            if (userDto.Roles.Any())
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeRolesResult.Succeeded)
                {
                    throw new Exception("Failed to remove user roles.");
                }

                var addRolesResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!addRolesResult.Succeeded)
                {
                    throw new Exception("Failed to add new roles to the user.");
                }
            }
        }
    }
}
