﻿using MedicineCard.DTO;
using MedicineCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MedicineCard.Services
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IEfRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }



        public UserDto Auth(AuthRequest authRequest)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserName == authRequest.UserName && x.Password == authRequest.Password);

            if (user == null)
            {
                // todo: need to add logger
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public void Delete(long id)
        {
            _userRepository.Delete(id);    
        }


        public async Task<long> Add(User entity)
        {
            var result = await _userRepository.Add(entity);
            return result;
        }

        public long Update(User entity)
        {
            var result = _userRepository.Update(entity);
            return result;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(long id)
        {
            return _userRepository.GetById(id);
        }      
    }
}