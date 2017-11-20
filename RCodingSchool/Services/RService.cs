using System;
using System.Diagnostics;
using System.IO;

namespace RCodingSchool.Services
{
    public class RService
    {
        public object AnalizeDataByRange(string N = "3", string K = "20")
        {
            var proc = new Process();
            string processLocation = @"C:\Program Files\R\R-3.4.2\bin\x64\Rscript.exe";
            string scriptLocation = @"D:/temp-projects/RCodingSchool/RCodingSchool/V1.R";

            proc.StartInfo = new ProcessStartInfo(processLocation, scriptLocation);
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.StandardInput.WriteLine($"{N} {K}");
            proc.StandardInput.Flush();
            proc.WaitForExit();

            var result = proc.StandardOutput.ReadToEnd();
            var error = proc.StandardError.ReadToEnd();

            return result;
        }
    }
}

// @"C:\Program Files\R\R-3.4.2\bin\x64\Rscript.exe", @"D:\temp-projects\RCodingSchool\RCodingSchool\V1.R"
