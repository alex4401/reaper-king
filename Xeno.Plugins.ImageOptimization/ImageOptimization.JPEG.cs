/*!
 * This file is a part of Xeno, and the project's repository may be found at https://github.com/alex4401/rk.
 *
 * The project is free software: you can redistribute it and/or modify it under the terms of the GNU General Public
 * License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with this program. If not, see
 * http://www.gnu.org/licenses/.
 */

using System.Diagnostics;

using Xeno.Core;

namespace Xeno.Plugins
{
    public partial class RkImageOptimizationModule
        : RkModule, IRkResourceProcessorModule
    {
        
        private bool _invokeJpegRecompress(string source, string target)
        {
            if (!Config.Jpeg.UseRecompress)
            {
                return false;
            }
            
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Config.Jpeg.RecompressBinaryPath,
                    Arguments = $"-s -a -q high -m {Config.Jpeg.RecompressAlgorithm} "
                                + $"-n {Config.Jpeg.MinQualityLevel} -l 10 \"{source}\" \"{target}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            
            process.Start();
            process.WaitForExit();
            return process.ExitCode == 0;
        }
    }
}