using Microsoft.AspNetCore.Mvc;
using System;

namespace Louis_Philippe_Loeckx_PartyMVC.Models
{
    public class VisitorController : Controller
    {
        [HttpGet]
        public IActionResult Input()
        {
            TempData["Visitors"] = 0;
            TempData["FamilyMembers"] = 0;
            TempData["Oldest"] = 0;
            TempData["Youngest"] = 0;

            return View();
        }

        [HttpPost]
        public IActionResult Input(Visitor visitor)
        {
            TempData["Visitors"] = (Int32)TempData.Peek("Visitors") + 1;
            if (visitor.IsFamily)
            {
                TempData["FamilyMembers"] = (Int32)TempData.Peek("FamilyMembers") + 1;
            }
            if ((Int32)TempData.Peek("Youngest") == 0)
            {
                TempData["Youngest"] = visitor.Age;
                TempData["Oldest"] = visitor.Age;
            }
            else
            {
                if ((Int32)TempData.Peek("Youngest") >= visitor.Age)
                {
                    TempData["Youngest"] = visitor.Age;
                }
                if ((Int32)TempData.Peek("Oldest") <= visitor.Age)
                {
                    TempData["Oldest"] = visitor.Age;
                }
            }
            
            TempData.Keep();
            return View(visitor);
        }

        [HttpGet]
        public IActionResult Summary()
        {
            ViewBag.TotalVisitors = TempData["Visitors"];
            ViewBag.TotalFamilyMembers = TempData["FamilyMembers"];
            ViewBag.OldestVisitor = TempData["Oldest"];
            ViewBag.YoungestVisitor = TempData["Youngest"];
            return View();
        }
    }
}
