//using CloudinaryDotNet;
//using CloudinaryDotNet.Actions;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Options;
//using TimeZone.Business.ExtensionServices.Interfaces;
//using TimeZone.Core.Entities;

//namespace TimeZone.Business.ExtensionServices.Implements;

//public class PhotoService : IPhotoService
//{
//    private readonly Cloudinary _cloudinary;
//    public PhotoService(IOptions<CloudinarySettings> config)
//    {
//        var  acc = new Account
//        (
//                config.Value.CloudName,
//                config.Value.ApiKey,
//                config.Value.ApiSecret
//        );
//        _cloudinary = new Cloudinary(acc);
//    }

//    public async Task<ImageUploadResult> AddPhotoAsnyc(IFormFile file)
//    {
//        if (file == null || file.Length == 0)
//            throw new ArgumentNullException("Invalid file");

//        using var stream = file.OpenReadStream();
//        var uploadParams = new ImageUploadParams
//        {
//            File = new FileDescription(file.FileName, stream),
//            Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
//        };

//        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

//        return uploadResult;

//    }

//    public async Task<DeletionResult> DeletePhotoAsnyc(string publicId)
//    {
//        var deleteParams = new DeletionParams(publicId);
//        var result= await _cloudinary.DestroyAsync(deleteParams);
//        return result;
//    }
//}
