using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogReyting
    {
        public int BlogReytingId { get; set; }
        public int BlogId { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogReytingCount { get; set; }
    }
}
