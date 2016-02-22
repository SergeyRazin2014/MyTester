using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTester.Domain;

namespace Domain
{
    public class PersonsAnswers
    {
        [Key, Column(Order = 0)]
        public int PerosnId { get; set; }

        public virtual Person Person { get; set; }

        [Key, Column(Order = 1)]
        public int QueryId { get; set; }
        
        public virtual Query Query { get; set; }

        [Key, Column(Order = 2)]
        public int VariantAnsverId { get; set; }

        public virtual VariantAnsver VariantAnsver { get; set; }
        
    }
}
