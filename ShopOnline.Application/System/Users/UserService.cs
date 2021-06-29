using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.Data.Entities;
using ShopOnline.ViewModels.Common;
using ShopOnline.ViewModels.System.Users;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> singInManager,
            RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = singInManager;
            _roleManager = roleManager;
            _config = config;
        }
        
      
        public async Task<ApiResult<string>> AuthenCate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;

            var result = await _signInManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.firstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>( new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserViewModel>("User không tồn tại");
            }
            var userVm = new UserViewModel()
            {
                Email = user.Email,
                phoneNumber = user.PhoneNumber,
                firstName = user.firstName,
                Dob = user.Dob,
                Id = user.Id,
                lastName = user.lastName,
                UserName = user.UserName
                

            };
            return new ApiSuccessResult<UserViewModel>(userVm);
        }

      

        public async Task<ApiResult<PagedResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.UserName.Contains(request.KeyWord) || x.Email.Contains(request.KeyWord));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    Email = x.Email,
                    UserName = x.UserName,
                    phoneNumber = x.PhoneNumber

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<UserViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {

            if (await _userManager.FindByNameAsync(request.UserName) != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Email đã tồn tại");
            }
            var user11 = new AppUser()
            {
                firstName = request.firstName,
                lastName = request.lastName,
                Dob =request.Dob,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName
            };
            var result = await _userManager.CreateAsync(user11, request.PassWord);
            if(result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng kí không thành công");
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.firstName = request.FirstName;
            user.lastName = request.LastName;
            user.Dob = request.Dob;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        
    }
}
