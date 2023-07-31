namespace DefectMapApplication.Services.API.DefectEndpointService
{
    public interface IDefectEndpoint
    {
        Task<IEnumerable<Defect>> GetAll();

        Task<Defect> Get(int id);

        Task<IEnumerable<Defect>> Find(string name);

        Task<IEnumerable<ServerFile>> UploadDefectPhoto(params LocalFile[] files);

        Task Create(Defect defect);

        Task Update(Defect defect);

        Task Delete(int id);
    }
}
