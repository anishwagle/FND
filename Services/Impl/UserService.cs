
using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.DTO;
using FND.Models;

namespace FND.Services.Impl
{

    public class UserService : IUserService
    {
        private readonly IJwtUtils _jwtUtils;
        // private readonly IMapper _mapper;
        private readonly IUserDao _context;
        public UserService(
            IUserDao userDao,
            IJwtUtils jwtUtils, IJwtUtils jwtUtils2)
        {
            _context = userDao;
            _jwtUtils = jwtUtils;
            _jwtUtils = jwtUtils2;
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model)
        {
            var user = await _context.GetByUsernameAsync(model.Username);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new Exception("Username or password is incorrect");

            // authentication successful
            var response = new AuthenticateResponse
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username

            };
            response.JwtToken = _jwtUtils.GenerateToken(user);
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return (IEnumerable<User>)_context.GetUsers();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async Task<User> RegisterAsync(RegisterRequest model)
        {
            // validate
            if (await _context.GetByUsernameAsync(model.Username) != null)
                throw new Exception("Username '" + model.Username + "' is already taken");

            // map model to new user object
            var user = new User
            {
                Username = model.Username,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                ReferedBy = model.ReferedBy

            };

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            // save user
            User response = await _context.AddAsync(user);

            return response;
        }

        // public void Update(int id, UpdateRequest model)
        // {
        //     var user = getUser(id);

        //     // validate
        //     if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
        //         throw new AppException("Username '" + model.Username + "' is already taken");

        //     // hash password if it was entered
        //     if (!string.IsNullOrEmpty(model.Password))
        //         user.PasswordHash = BCryptNet.HashPassword(model.Password);

        //     // copy model to user and save
        //     _mapper.Map(model, user);
        //     _context.Users.Update(user);
        //     _context.SaveChanges();
        // }

        public void Delete(string id)
        {
            _context.Delete(id);
        }
    }
}