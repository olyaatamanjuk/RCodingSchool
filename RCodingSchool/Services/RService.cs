using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace RCodingSchool.Services
{
    public class RService
    {
		public HerstIndex AnalizeDataByRange(string filePath,string N = "3", string K = "20")
        {
            var proc = new Process();
            string processLocation = @"C:\Program Files\R\R-3.4.2\bin\x64\Rscript.exe";
            string scriptLocation = @"D:\PROJECT\RCodingSchool\RCodingSchool\V1.R";

            proc.StartInfo = new ProcessStartInfo(processLocation, scriptLocation);
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.StandardInput.WriteLine($"{N} {K} {filePath}");
            proc.StandardInput.Flush();
            proc.WaitForExit(20000);

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
		public double[] H_MFDFA { get; set; }
		public double[] H_GPH { get; set; }
		public string FilePath { get; set; }
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

				string[] mas = text.Split(new char[] { '\n' });


				string[] h_mdfa = mas[0].Split(new char[] { ' ' });
				H_MFDFA = new double[h_mdfa.Length];
				for (int i = 0; i < h_mdfa.Length; i++)
				{
					H_MFDFA[i] = double.Parse(h_mdfa[i], CultureInfo.InvariantCulture);
				}

				string[] h_gph = mas[1].Split(new char[] { ' ' });
				H_GPH = new double[h_gph.Length];
				for (int i = 0; i < h_gph.Length; i++)
				{
					H_GPH[i] = double.Parse(h_gph[i], CultureInfo.InvariantCulture);
				}

				string[] h = mas[2].Split(new char[] { ' ' });
				H = new double[h.Length];
				for (int i = 0; i < h.Length; i++)
				{
					H[i] = double.Parse(h[i], CultureInfo.InvariantCulture);
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
