﻿using AutoMapper;
using Course.Data;
using Course.Data.Dtos;
using Course.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Course.Services
{
    public class UserServices
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;
        private FolhaContext _folhaContext;

        public UserServices(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService, FolhaContext folhaContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _folhaContext = folhaContext;
        }

        public async Task Register(CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
            // Tratar o resultado da criação do usuário, se necessário.
        }

        public async Task<string> Login(LoginUserDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Usuario não autenticado");
            }

            var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName== dto.UserName.ToUpper());

            var token = _tokenService.GenerateToken(user);

            return token;
        }

        public async Task<List<User>> FindAllAsync()
        {
            var result = await _folhaContext.Users.OrderBy(x => x.UserName).ToListAsync();
            return result;
        }

        public async Task<User> FindById(int id)
        {
            var result = await _folhaContext.Users.FindAsync(id);
            return result;
        }

        public async Task<User> Update(int id, User userupdates)
        {
            var user = await  _folhaContext.FindAsync<User>(id);
            if(user == null)
            {
                throw new ApplicationException("Usuario nao encontrado");
            }

            user.Email = userupdates.Email;
            user.UserName = userupdates.UserName;
            user.PhoneNumber = userupdates.PhoneNumber;
            user.PasswordHash = userupdates.PasswordHash;

            await _folhaContext.SaveChangesAsync();
            return user;

        }

        public async Task<User> Delete(int id)
        {
            var user = await _folhaContext.FindAsync<User>(id);
            if(user == null)
            {
                throw new ApplicationException("Usuário não encontrado");
            }
            _folhaContext.Remove(user);
            await _folhaContext.SaveChangesAsync();

            return user;
        }
    }
}
