using System;
using System.Diagnostics;
using System.Globalization;

namespace RCodingSchool.Services
{
    public class RService
    {
		public HerstIndex AnalizeDataByRange(string filePath,string N = "3", string K = "20")
        {
            var proc = new Process();
            string processLocation =  @"C:\Program Files\R\R-3.4.2\bin\Rscript.exe";
            string scriptLocation = @"D:\PROJECT\RCodingSchool\RCodingSchool\V1.R";

			proc.StartInfo = new ProcessStartInfo(processLocation, scriptLocation + " 5 20");
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.StandardInput.WriteLine($"{N} {K} {filePath}");
            proc.StandardInput.Flush();
            proc.WaitForExit(10000);

            var result = proc.StandardOutput.ReadToEnd();
            var error = proc.StandardError.ReadToEnd();
			HerstIndex herstIndex = new HerstIndex();
			herstIndex.CreateObjectFromString(result, N, K);
			return herstIndex ;
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


				text = text.Substring(indexOfChar + 10).Replace("[1] ", "").Trim();

				string[] mas = text.Split(new char[] { ' ' });
				H = new double[mas.Length];
				for (int i = 0; i < mas.Length; i++)
				{
					H[i] = double.Parse(mas[i], CultureInfo.InvariantCulture);
				}

			}
			catch (Exception e)
			{
				//TODO : What we must to do here?
			}
		}
	}
}

// @"C:\Program Files\R\R-3.4.2\bin\x64\Rscript.exe", @"D:\temp-projects\RCodingSchool\RCodingSchool\V1.R"
