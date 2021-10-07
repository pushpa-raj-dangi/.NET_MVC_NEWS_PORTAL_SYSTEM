using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Services
{
    public interface IFileUploadService
    {
        public string Upload(IFormFile file);
    }
}
