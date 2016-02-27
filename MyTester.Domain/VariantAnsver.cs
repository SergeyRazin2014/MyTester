namespace MyTester.Domain
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
