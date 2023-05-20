using students_Api.Helpers;

namespace students_Api.Extenstions { 
    public static class HttpExtenstions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemPerPage,
            int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemPerPage, totalItems, totalPages);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            // CORS
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
