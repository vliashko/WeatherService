using System.Collections.Generic;

namespace gRPCExampleProject.Server.Dtos.Responses
{
    public class BaseResponseModel<T>
    {
        public PaginationResponseModel PageModel { get; set; }

        public IEnumerable<T> Objects { get; set; }
    }
}
