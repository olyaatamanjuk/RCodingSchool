using OfficeOpenXml;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace StudLine.Services
{
	public class RService
	{
		public HerstIndex AnalizeDataByRange(string N = "3", string K = "20")
		{
			var proc = new Process();
			string processLocation = @"C:\Program Files\R\R-3.4.3\bin\x64\Rscript.exe";
			string scriptLocation = @"D:\PROJECT\RCodingSchool\RCodingSchool\V1.R";

			proc.StartInfo = new ProcessStartInfo(processLocation, scriptLocation);
			proc.StartInfo.RedirectStandardOutput = true;
			proc.StartInfo.RedirectStandardInput = true;
			proc.StartInfo.RedirectStandardError = true;
			proc.StartInfo.UseShellExecute = false;
			proc.Start();
			proc.StandardInput.WriteLine($"{N} {K}");
			proc.StandardInput.Flush();
			proc.WaitForExit(10000);

			var result = proc.StandardOutput.ReadToEnd();
			var error = proc.StandardError.ReadToEnd();
			HerstIndex herstIndex = new HerstIndex();
			herstIndex.CreateObjectFromString(result, N, K);
			return herstIndex;
		}

		public bool IsCorrectInputValues(HttpPostedFileBase file, int N, int K)
		{
			string fileName = file.FileName;
			string fileContentType = file.ContentType;
			byte[] fileBytes = new byte[file.ContentLength];
			var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

			int T = 0;

			try {
				using (var package = new ExcelPackage(file.InputStream))
				{
					var currentSheet = package.Workbook.Worksheets;
					var workSheet = currentSheet.First();
					T = workSheet.Dimension.End.Row;
				}

				if (T > 500 && ((T/N)-K)>0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
	
	}

	public class HerstIndex
	{
		public double[] H { get; set; }

		public int N { get; set; }
		public int K { get; set; }

		public void CreateObjectFromString(string text, string N, string K)
		{
			try
			{
				this.N = Convert.ToInt32(N);
				this.K = Convert.ToInt32(K);
				int indexOfChar = text.IndexOf("RESULTS:");

				if(indexOfChar != -1)
				{
					text = text.Substring(indexOfChar + 10).Replace("[1] ", "").Trim();

					string[] mas = text.Split(new char[] { ' ' });
					H = new double[mas.Length];
					for (int i = 0; i < mas.Length; i++)
					{
						H[i] = double.Parse(mas[i], CultureInfo.InvariantCulture);
					}
				}

			}
			catch (Exception)
			{
				
			}
		}
	}
}

