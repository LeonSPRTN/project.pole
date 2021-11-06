namespace project.pole.Services
{
    public interface IEstimateService
    {
        public byte[] Generate(long objectWorkId);
    }
}