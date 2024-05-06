using NEWWEBAPP.Models;

namespace NEWWEBAPP.Helpers
{
    public static class ImageHelper
    {
        public static readonly string DefaultProfilePicture = "/images/DefaultProfilePicture.";

        public static async Task<ImageUpload> GetImageUploadAsync(IFormFile file)
        {
            using var ms = new MemoryStream();

            await file.CopyToAsync(ms);
            byte[] data = ms.ToArray();

            if(ms.Length > 5 * 1024 * 1024)
            {
                throw new IOException("Images must be 5MB or less");
            }

            ImageUpload upload = new ImageUpload()
            { 
                
                Id = Guid.NewGuid(),
                Data = data,
                Type = file.ContentType,
            };

            return upload;
        }

    }
}
