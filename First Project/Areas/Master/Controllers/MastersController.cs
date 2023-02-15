using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.Areas.Master.Models;
using First_Project.Data.Master;
using First_Project.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace First_Project.Areas.Master.Controllers
{
    [Area("Master")]
    public class MastersController : Controller
    {
        private readonly IMasterService masterService;

        public MastersController(IMasterService _master)
        {
            this.masterService = _master;
        }
        public async Task<IActionResult> Country()
        {
            MastersViewModel model = new MastersViewModel
            {
                countries = await masterService.GetCountry(),
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Country([FromForm] MastersViewModel model)
        {
            var data = new Country
            {
                Id = model.countriesId,
                countryName = model.countryName,
                countryNameBn = model.countryNameBn,
            };

            await masterService.SaveCountry(data);
            return RedirectToAction(nameof(Country));
        }

        public async Task<IActionResult> Division()
        {
            MastersViewModel model = new MastersViewModel
            {
                divisions = await masterService.GetDivision(),
                countries = await masterService.GetCountry(),
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Division([FromForm] MastersViewModel model)
        {
            var data = new Division
            {
                Id = model.divisionId,
                countryId = model.countryId,
                divisionName = model.divisionName,
                divisionNameBn = model.divisionNameBn,
            };

            await masterService.SaveDivision(data);
            return RedirectToAction(nameof(Division));
        }
    }
}