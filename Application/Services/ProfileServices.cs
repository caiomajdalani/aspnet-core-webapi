﻿using Framework.Services;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfileServices : BaseServices, IProfileServices
    {
        public Task<ServicesResult> SaveUserPhotoAsync(string userId, byte[] image)
        {
            //Handle Image
            return Task.FromResult(Ok());
        }
    }
}
