using Microsoft.AspNetCore.Mvc;
using WebApplicationMustToHave.Repository;
using WebApplicationMustToHave.Services;

namespace WebApplicationMustToHave.Controllers
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    public class BaseController : Controller
    {
        protected readonly ILoggerManager _logger;
        protected readonly DbManager _dm;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="dm">Менеджер работы с базой</param>
        /// <param name="logger">логгер</param>
        public BaseController(DbManager dm, ILoggerManager logger)
        {
            if (logger != null)
            {
                _logger = logger;
            }
            if (dm != null)
            {
                _dm = dm;
            }
        }
    }
}
