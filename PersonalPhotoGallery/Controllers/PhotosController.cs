using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalPhotoGallery.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IKeyGenerator _keyGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoMetaData _photoMetaData;
        private readonly IFileStorage _fileStorage;

        public PhotosController(IKeyGenerator keyGenerator, IHttpContextAccessor httpContextAccessor,
            IPhotoMetaData photoMetaData, IFileStorage fileStorage)
        {
            _keyGenerator = keyGenerator;
            _httpContextAccessor = httpContextAccessor;
            _photoMetaData = photoMetaData;
            _fileStorage = fileStorage;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(PhotoUploadViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = _httpContextAccessor.HttpContext.Session.GetString("User");
                var uniqueKey = _keyGenerator.GetKey(userName);
                var fileName = model.File.FileName;

                await _photoMetaData.SavePhotoMetaData(userName, model.Description, fileName);
                await _fileStorage.StoreFile(model.File, uniqueKey);
            }

            return View();
        }
    }
}