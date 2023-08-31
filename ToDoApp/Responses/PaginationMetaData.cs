namespace ToDoApp.Responses
{
    public class PaginationMetaData
    {
        public int pageSize { get; set; }

        public int pageCount { get; set; }

        public int currentPage { get; set; }

        public int totalCount { get; set; }

        public PaginationMetaData(int ps, int cp, int tc)
        {
            this.totalCount = tc;
            this.pageSize = ps; 
            this.currentPage = cp;
            this.pageCount = (int)Math.Ceiling((double)tc/(double)ps);
        }

    }
}
