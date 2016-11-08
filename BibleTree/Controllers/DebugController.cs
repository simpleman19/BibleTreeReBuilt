using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibleTree.Services;

namespace BibleTree.Controllers
{
    public class DebugController : Controller
    {
        // GET: Debug
        public ActionResult Index() {
	        return View();
        }

	    public string Reset() {
		    SQLService sql = new SQLService();
			string result = sql.Rebuild();
		    return result;
	    }

	    public string SqlScripts() {
			string debug = "";
			foreach (var key in ScriptService.Scripts.Keys) {
				debug += key + ": <br/>" + ScriptService.Scripts[key] + "<br/><br/>";
			}
			if (ScriptService.Scripts.Count == 0) {
				debug = "No Scripts Found!";
			}
			return debug;
		}
    }
}