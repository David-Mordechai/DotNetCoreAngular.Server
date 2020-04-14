using System.Collections.Generic;
using DotNetCoreAngular.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreAngular.WebApi.Controllers
{
    [Route("api/basicTable")]
    [ApiController]
    [Authorize]
    public class BasicTableController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GetData());
        }

        private IEnumerable<BasicTableModel> GetData() => new List<BasicTableModel>
        {
            new BasicTableModel {Position = 1, Name = "Hydrogen", Weight = 1.0079, Symbol = "H"},
            new BasicTableModel {Position = 2, Name = "Helium", Weight = 4.0026, Symbol = "He"},
            new BasicTableModel {Position = 3, Name = "Lithium", Weight = 6.941, Symbol = "Li"},
            new BasicTableModel {Position = 4, Name = "Beryllium", Weight = 9.0122, Symbol = "Be"},
            new BasicTableModel {Position = 5, Name = "Boron", Weight = 10.811, Symbol = "B"},
            new BasicTableModel {Position = 6, Name = "Carbon", Weight = 12.0107, Symbol = "C"},
            new BasicTableModel {Position = 7, Name = "Nitrogen", Weight = 14.0067, Symbol = "N"},
            new BasicTableModel {Position = 8, Name = "Oxygen", Weight = 15.9994, Symbol = "O"},
            new BasicTableModel {Position = 9, Name = "Fluorine", Weight = 18.9984, Symbol = "F"},
            new BasicTableModel {Position = 10, Name = "Neon", Weight = 20.1797, Symbol = "Ne"},
        };
    }
}