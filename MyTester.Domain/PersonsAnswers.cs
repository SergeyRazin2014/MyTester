using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTester.Domain
{
    public class PersonsAnswers
    {
        [Key, Column(Order = 0)]
        public int PersonId { get; set; }

        internal virtual Person Person { get; set; }

        [Key, Column(Order = 1)]
        public int QueryId { get; set; }
        
        public virtual Query Query { get; set; }

        [Key, Column(Order = 2)]
        public int VariantAnsverId { get; set; }

        public virtual VariantAnsver VariantAnsver { get; set; }
        
    }
}
