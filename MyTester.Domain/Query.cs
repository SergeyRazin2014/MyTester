using System.Collections.Generic;

namespace MyTester.Domain
{
    public class Query
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Point { get; set; }

        public virtual List<VariantAnsver> VariantsAnsver { get; set; }
    }
}
