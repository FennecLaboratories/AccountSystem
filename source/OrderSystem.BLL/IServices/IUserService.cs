using OrderSystem.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystem.BLL.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto?> GetUserByIdAsync(long id);
    Task<UserDto?> GetUserByEmailAsync(string email);
    Task AddUserAsync(UserDto userDto);
    Task UpdateUserAsync(UserDto userDto);
    Task DeleteUserAsync(long id);
}
