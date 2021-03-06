﻿using System.Web.Optimization;

namespace StudLine.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
									"~/Scripts/jquery-3.2.1.js"));

			bundles.Add(new ScriptBundle("~/bundles/markdown").Include(
									"~/Scripts/simplemde.min.js"));
			
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-2.8.3.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js"));

			bundles.Add(new ScriptBundle("~/bundles/signalrScripts").Include(
						"~/Scripts/jquery.signalR-2.2.2.js"));

			bundles.Add(new ScriptBundle("~/bundles/MessageScripts").Include(
			"~/Scripts/message.js"));

			bundles.Add(new StyleBundle("~/bundles/baseCSS").Include(
					 "~/Content/bootstrap.css",
					 "~/Content/Site.css"));

			bundles.Add(new StyleBundle("~/bundles/markdownCSS").Include(
				"~/Content/simplemde.min.css"
				));

			bundles.Add(new StyleBundle("~/bundles/admin").Include(
				"~/Content/admin.css"
				));

			bundles.Add(new StyleBundle("~/bundles/fonts").Include(
				"~/Content/font-awesome.min.css"
				));

			bundles.Add(new StyleBundle("~/bundles/about").Include(
				"~/Content/about.css"
				));

			bundles.Add(new StyleBundle("~/bundles/login").Include(
				"~/Content/login.css"
				));

			bundles.Add(new StyleBundle("~/bundles/range").Include(
				"~/Content/range.css"
				));
		}
	}
}