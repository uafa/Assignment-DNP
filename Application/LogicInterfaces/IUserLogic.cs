﻿using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto dto);
    Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
}