using System.Collections.Generic;

namespace Application.Common.Models
{
    public class GridResult<T>
    {
        public IList<T> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }

    }
}
