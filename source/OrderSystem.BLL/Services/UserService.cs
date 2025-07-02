namespace OrderSystem.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Username = u.Username,
            Email = u.Email,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Description = u.Description,
            ProfileImage = u.ProfileImage,
            Role = u.Role.ToString()
        });
    }


    public async Task<UserDto?> GetUserByIdAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Description = user.Description,
            ProfileImage = user.ProfileImage,
            Role = user.Role.ToString()
        };
    }

    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Description = user.Description,
            ProfileImage = user.ProfileImage,
            Role = user.Role.ToString()
        };
    }

    public async Task AddUserAsync(UserDto userDto)
    {
        var user = new User
        {
            Username = userDto.Username,
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Description = userDto.Description,
            ProfileImage = userDto.ProfileImage,
            Role = Enum.Parse<UserRole>(userDto.Role)
        };
        await _userRepository.AddAsync(user);
    }

    public async Task UpdateUserAsync(UserDto userDto)
    {
        var user = await _userRepository.GetByIdAsync(userDto.Id);
        if (user != null)
        {
            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Description = userDto.Description;
            user.ProfileImage = userDto.ProfileImage;
            user.Role = Enum.Parse<UserRole>(userDto.Role);
            await _userRepository.UpdateAsync(user);
        }
    }

    public async Task DeleteUserAsync(long id)
    {
        await _userRepository.DeleteAsync(id);
    }
}