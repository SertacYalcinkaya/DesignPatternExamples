using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Handlers;
using DesignPattern.CQRS.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _queryHandler;
        private readonly CreateProductCommandHandler _commandHandler;
        private readonly GetProductByIdQueryHandler _queryByIdHandler;
        private readonly RemoveProductCommandHandler _removeHandler;
        private readonly GetProductUpdateQueryHandler _getProductUpdateQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public DefaultController(GetProductQueryHandler queryHandler, CreateProductCommandHandler commandHandler, GetProductByIdQueryHandler queryByIdHandler, RemoveProductCommandHandler removeHandler, GetProductUpdateQueryHandler getProductUpdateQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
            _queryByIdHandler = queryByIdHandler;
            _removeHandler = removeHandler;
            _getProductUpdateQueryHandler = getProductUpdateQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _queryHandler.Handle();

            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _commandHandler.Handle(command);

            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(int id)
        {
            var values = _queryByIdHandler.Handle(new GetProductByIdQuery(id));

            return View(values);
        }

        public IActionResult DeleteProduct(int id)
        {
            _removeHandler.Handle(new RemoveProductCommand(id));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _getProductUpdateQueryHandler.Handle(new GetProductUpdateQuery(id));

            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);

            return RedirectToAction("Index");
        }
    }
}
