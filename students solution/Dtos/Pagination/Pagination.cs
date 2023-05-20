namespace Dtos.Pagination
{
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int ItemPerPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public static implicit operator Pagination(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class PaginatedResult<T>
    {
        public T Result { get; set; }
        public Pagination Pagination { get; set; }
    }
}
