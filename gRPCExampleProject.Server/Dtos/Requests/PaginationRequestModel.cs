using gRPCExampleProject.Server.Infrastructure;

namespace gRPCExampleProject.Server.Dtos.Requests
{
    public abstract class PaginationRequestModel
    {
        public int PageNumber { get; set; } = Constants.BASE_PAGE_NUMBER;

        public int PageSize { get; set; } = Constants.BASE_PAGE_SIZE;
    }
}
