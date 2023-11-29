namespace SE1726_NET_SWP391_Group5.Helpers
{
    public class PagingModel
    {
        public int currentPage { get; set; }
        public int countPages { get; set; }
        public Func<int?, string> generateUrl { get; set; }
    }
}
