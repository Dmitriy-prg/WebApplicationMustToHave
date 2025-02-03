using System;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Repository;
using WebApplicationMustToHave.Services;

namespace WebApplicationMustToHave.Controllers
{
    public class MeasureUnitController : BaseController
    {
        /// <summary>
        /// Создает контроллер единиц измерения
        /// </summary>
        /// <param name="dm">Менеджер работы с базой</param>
        /// <param name="logger">логгер</param>
        public MeasureUnitController(DbManager dm, ILoggerManager logger) : base(dm, logger) { }

        /// <summary>
        /// Возвращает список всех представлений единиц измерения
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список представлений персон</returns>
        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> ItemsAsync(CancellationToken cancellationToken = default)
        {
            List<IViewable> measureUnits = await _dm.GetViewsAsync<MeasureUnit>(cancellationToken);
            _logger.LogInformation("MeasureUnitController Items().Count = " + measureUnits?.Count);
            return View(measureUnits);
        }
    }
}
