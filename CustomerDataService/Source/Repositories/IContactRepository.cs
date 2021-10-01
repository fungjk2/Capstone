﻿using System.Threading.Tasks;

namespace CustomerDataService.Repositories;

public interface IContactRepository
{
    public Task<ContactEntity> GetContactAsync(string phoneNumber);
}