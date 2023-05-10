namespace DesignPattern.CQRS.CQRSPattern.Queries
{
    public class GetProductUpdateQuery
    {
        public int Id { get; set; }

        public GetProductUpdateQuery(int id)
        {
            Id = id;
        }
    }
}
