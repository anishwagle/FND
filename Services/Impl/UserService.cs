
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
        private readonly IMailService _mailService;
        // private readonly IMapper _mapper;
        private readonly IUserDao _context;
        public UserService(
            IUserDao userDao,
            IJwtUtils jwtUtils, IJwtUtils jwtUtils2,IMailService mailService)
        {
            _context = userDao;
            _jwtUtils = jwtUtils;
            _jwtUtils = jwtUtils2;
            _mailService = mailService;
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

        public async Task<IActionResult> GeneratePasswordResetToken(string email){

             var apiResponse= new ServiceResult<User>();

             var user = await _context.GetByEmailAsync(email);
           
             
              if(user==null){
                apiResponse.IsError=true;
                apiResponse.Message="No user found with given email address";
                apiResponse.Result=null;
                return Ok(apiResponse);
                }
               
                    Random random = new Random();
                    int otp = random.Next(100000, 1000000);
                    DateTime validTill= DateTime.UtcNow.AddMinutes(10);

                    var passwordResetToken= new UserPasswordResetToken();
                    passwordResetToken.Token=otp.ToString();
                    passwordResetToken.ValidTill=validTill;

                    user.PasswordResetToken= passwordResetToken;
                try
                {
                    await _context.UpdateAsync(user);
                }
                catch(Exception e)
                {
                    throw e;
                }

                try{
                    await _mailService.SendEmailAsync(
                    email,
                    "FND password reset",
                    $"OTP for your FND Austrilia application password reset is <b>{otp}</b> <br/> ");
                
                }catch(Exception e){
                    throw e;
                }
                
            
            apiResponse.IsError=false;
            apiResponse.Message="Password reset token has been sent to the user's email Id";
            return Ok(apiResponse);
        }

         public async Task<IActionResult> VerifyPasswordResetToken(string userEmail,string token){

            var apiResponse= new ServiceResult<User>();

             var user = await _context.GetByEmailAsync(userEmail);
            if(user.PasswordResetToken.Token==token){
                if(DateTime.UtcNow<user.PasswordResetToken.ValidTill){
                    apiResponse.IsError=false;
                    apiResponse.Message="Successfully verified password reset token";
                }
                else{
                    apiResponse.IsError=true;
                    apiResponse.Message="ERROR! Token Has Expired";
                }
            }
            else{
                apiResponse.IsError=true;
                apiResponse.Message="VERIFICATION FAILED. INCORRECT TOKEN";
            }
            
            return Ok(apiResponse);
        }

        public async Task<IActionResult> ResetPassword(PasswordResetRequest resetReq){

            var apiResponse= new ServiceResult<User>();

             var user = await _context.GetByEmailAsync(resetReq.EmailId);
            if(user.PasswordResetToken.Token==resetReq.Token && DateTime.UtcNow<user.PasswordResetToken.ValidTill){//
                user.PasswordHash = BCryptNet.HashPassword(resetReq.NewPassword);
                user.PasswordResetToken=null;
                try{
                   await _context.UpdateAsync(user);
                }
                catch(Exception e){
                    throw e;
                }
                apiResponse.IsError=false;
                apiResponse.Message="Password Reset Successful";
            }
            else{
                apiResponse.IsError=true;
                apiResponse.Message="RESET FAILED!! Invalid or Expired Token";
            }
            
            return Ok(apiResponse);
        }


        public void Delete(string id)
        {
            _context.Delete(id);
        }
    }
}