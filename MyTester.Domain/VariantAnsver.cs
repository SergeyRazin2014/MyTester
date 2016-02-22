using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class VariantAnsver
    {
        public int Id { get; set; }
        
        public string Text { get; set; }
        
        public bool IsRight { get; set; }

        public int QueryId { get; set; }

        public virtual Query Query { get; set; }
    }
}
