using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DefectMapApplication.Services.API.DefectEndpointService
{
    public class DefectEndpoint : IDefectEndpoint
    {
        readonly HttpClient httpClient;
        public DefectEndpoint(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Create(Defect defect)
        {
            var response = await httpClient.PostAsJsonAsync("v1/defect", defect);

            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync(Path.Combine("v1/defect/", id.ToString()));

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Defect>> Find(string name)
        {
            var response = await httpClient
                .GetFromJsonAsync<List<Defect>>(Path.Combine("v1/defect?name=", name));

            return response;
        }

        public async Task<Defect> Get(int id)
        {
            var response = await httpClient
                .GetFromJsonAsync<Defect>(Path.Combine("v1/defect/", id.ToString()));

            return response;
        }

        public async Task<IEnumerable<Defect>> GetAll()
        {
            var response = await httpClient
                .GetFromJsonAsync<List<Defect>>(Path.Combine("v1/defect/"));

            return response;
        }

        public async Task Update(Defect defect)
        {
            var response = await httpClient
                .PutAsJsonAsync(Path.Combine("v1/defect/"), defect);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ServerFile>> UploadDefectPhoto(params FileResult[] files)
        {
            using var content = new MultipartFormDataContent();
            
            foreach (var file in files)
            {
                var streamContent = new StreamContent(await file.OpenReadAsync());

                streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                content.Add(streamContent, "photos", Guid.NewGuid().ToString());
            }

            var result = await httpClient.PostAsJsonAsync("v1/defect/UploadPhotos", content);

            var serverFiles = await result.Content.ReadFromJsonAsync<List<ServerFile>>();

            return serverFiles;
        }
    }
}
