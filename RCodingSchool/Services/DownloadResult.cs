using System;
using System.Web.Mvc;

namespace RCodingSchool.Services
{
	public class DownloadResult : ActionResult
	{
		public DownloadResult()
		{
		}
		public DownloadResult(string virtualPath)
		{
			this.VirtualPath = virtualPath;
		}
		public string VirtualPath { get; set; }
		public string FileDownloadName { get; set; }
		public override void ExecuteResult(ControllerContext context)
		{
			if (!String.IsNullOrEmpty(FileDownloadName))
			{
				context.HttpContext.Response.AddHeader("content-disposition",
				  "attachment; filename=" + this.FileDownloadName);
			}
			context.HttpContext.Response.TransmitFile(VirtualPath);
		}
	}
}