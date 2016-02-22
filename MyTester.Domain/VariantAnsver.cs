using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain
{
    
    public class VariantAnsver
    {
        public int Id { get; set; }
        
        public string Text { get; set; }
        
        public bool IsRight { get; set; }

        public int QueryId { get; set; }

        public bool IsSelected { get; set; }

        
        internal virtual Query Query { get; set; }
    }
}
