using System;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Controllers
{
    public class MeasureUnitController : Controller
    {
        private readonly IAppDbContext _db;
        private readonly IDbCompositionManager _cm;

        public MeasureUnitController(IAppDbContext db, IDbCompositionManager cm)
        {

        }
    }
}
