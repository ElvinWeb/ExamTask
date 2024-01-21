using Boocic.Business.CustomExceptions.Common;
using Boocic.Business.CustomExceptions.ServiceImage;
using Boocic.Business.Helpers;
using Boocic.Core.Entites;
using Boocic.Core.Repositories;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Business.Services.Implementations
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IWebHostEnvironment _env;

        public ServicesService(IServiceRepository serviceRepository, IWebHostEnvironment env)
        {
            _serviceRepository = serviceRepository;
            _env = env;
        }

        public async Task CreateAsync(Service service)
        {
            if (service.Image != null)
            {
                if (service.Image.ContentType != "image/png" && service.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentTypeOrSizeException("Image", "Image content type is wrong!");
                }
                if (service.Image.ContentType != "image/png" && service.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentTypeOrSizeException("Image", "Image size must be less than 2 mb!");
                }
            }
            else
            {
                throw new ImageRequiredException("Image", "Image must be choosed!");
            }

            service.ImgUrl = await Helper.GetFileName(_env.WebRootPath, "uploads/Services-Images", service.Image);
            service.CreatedDate = DateTime.UtcNow.AddHours(4);
            service.UpdatedDate = DateTime.UtcNow.AddHours(4);


            await _serviceRepository.CreateAsync(service);
            await _serviceRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null || id <= 0) throw new InvalidIdOrBlowThanZeroException();

            Service wantedService = await _serviceRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);

            if (wantedService == null) throw new InvalidEntityException();

            string filePath = Path.Combine(_env.WebRootPath, "uploads/Services-Images", wantedService.ImgUrl);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _serviceRepository.Delete(wantedService);
            await _serviceRepository.SaveAsync();
        }

        public Task<List<Service>> GetAllServiceAsync()
        {
            return _serviceRepository.GetAllAsync(x => !x.IsDeleted);
        }

        public async Task<Service> GetServiceAsync(int id)
        {
            if (id == null || id <= 0) throw new InvalidIdOrBlowThanZeroException();

            return await _serviceRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task SoftDelete(int id)
        {
            if (id == null || id <= 0) throw new InvalidIdOrBlowThanZeroException();

            Service wantedService = await _serviceRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);

            if (wantedService == null) throw new InvalidEntityException();

            wantedService.IsDeleted = !wantedService.IsDeleted;

            await _serviceRepository.SaveAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            Service wantedService = await _serviceRepository.GetByIdAsync(x => x.Id == service.Id && !x.IsDeleted);
            if (wantedService == null) throw new InvalidEntityException();

            if (service.Image != null)
            {
                if (service.Image.ContentType != "image/png" && service.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentTypeOrSizeException("Image", "Image content type is wrong!");
                }
                if (service.Image.ContentType != "image/png" && service.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentTypeOrSizeException("Image", "Image size must be less than 2 mb!");
                }

                string oldFilePath = Path.Combine(_env.WebRootPath, "uploads/Services-Images", wantedService.ImgUrl);

                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }

                wantedService.ImgUrl = await Helper.GetFileName(_env.WebRootPath, "uploads/Services-Images", service.Image);
            }

            wantedService.Category = service.Category;
            wantedService.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _serviceRepository.SaveAsync();
        }
    }
}
