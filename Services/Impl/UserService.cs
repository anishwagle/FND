
using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.DTO;
using FND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace FND.Services.Impl
{

    public class UserService :ControllerBase, IUserService
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

        public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest model)
        {
            var user = await _context.GetByEmailAsync(model.Email);
            var apiResponse= new ServiceResult<AuthenticateResponse>();

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash)){
                apiResponse.IsError=true;
                apiResponse.Message="Username or Password Incorrect";
                apiResponse.Result=null;
                return Ok(apiResponse);
            }

            // authentication successful
            var response = new AuthenticateResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email

            };
            response.JwtToken = _jwtUtils.GenerateToken(user);

            apiResponse.IsError=false;
            apiResponse.Message="Authentication Success";
            apiResponse.Result=response;
            return Ok(apiResponse);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.GetUsers();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async Task<IActionResult> RegisterAsync(RegisterRequest model)
        {
            var apiResponse= new ServiceResult<User>();
            // validate
            if (await _context.GetByEmailAsync(model.Email) != null){
                apiResponse.IsError=true;
                apiResponse.Message="Email '" + model.Email + "' is already Exist";
                apiResponse.Result=null;
                return Ok(apiResponse);
            }

            // map model to new user object
            var user = new User
            {
                Name = model.Name,
                Email = model.Email

            };

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            // save user
            User response = await _context.AddAsync(user);
            apiResponse.IsError=false;
            apiResponse.Message="Authentication Success";
            apiResponse.Result=response;
            return Ok(apiResponse);

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