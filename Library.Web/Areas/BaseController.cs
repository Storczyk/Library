using Library.Application.General;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas
{
    public class BaseController : Controller
    {
        public const string ShortMessageTempDataTag = "ShortMessage";
        protected ICommandBus commandBus;
        protected IQueryDispatcher queryDispatcher;

        public BaseController(ICommandBus commandBus, IQueryDispatcher queryDispatcher)
        {
            this.commandBus = commandBus;
            this.queryDispatcher = queryDispatcher;
        }

        protected void DisplayShortMessage(string message)
        {
            TempData[ShortMessageTempDataTag] = message;
        }

        protected void DisplayShortMessage(bool isSucces)
        {
            string message = isSucces ? "Succes!" : "Something went wrong!";
            DisplayShortMessage(message);
        }
    }
}
