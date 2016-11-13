using System;
using System.Diagnostics;
using Microsoft.Owin;
using Owin;
using BibleTree.Services;

[assembly: OwinStartupAttribute(typeof(BibleTree.Startup))]
namespace BibleTree
{
	public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			ConfigureAuth(app);
        }
    }
}
