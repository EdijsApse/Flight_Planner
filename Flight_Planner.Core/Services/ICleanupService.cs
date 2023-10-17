namespace Flight_Planner.Core.Services
{
    public interface ICleanupService : IDbService
    {
        void CleanDatabase();
    }
}
