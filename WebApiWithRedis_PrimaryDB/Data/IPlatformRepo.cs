using WebApiWithRedis_PrimaryDB.Models;

namespace WebApiWithRedis_PrimaryDB.Data 
{
    public interface IPlatformRepo
    {
        void CreatePlatform(Platform plat);
        Platform? GetPlatformById(string id);
        IEnumerable<Platform?>? GetAllPlatforms();
    }
}