using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductUpdateQueryHandler
    {
        private readonly Context _context;

        public GetProductUpdateQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductUpdateQueryResult Handle(GetProductUpdateQuery query)
        {
            var values = _context.Products.Find(query.Id);

            return new GetProductUpdateQueryResult
            {
                ProductId = values.ProductId,
                Name = values.Name,
                Description = values.Description,
                Stock = values.Stock,
                Price = values.Price
            };
        }
    }
}
