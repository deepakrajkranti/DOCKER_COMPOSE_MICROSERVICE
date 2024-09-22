using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Learning.Service
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Product()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await _httpClient.GetAsync("https://localhost:63499/api/Product?id=1"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return new OkObjectResult(content);
                    }
                    return new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                return new StatusCodeResult(500);
            }
        }
    }
    
}
