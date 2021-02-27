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

using System.Collections.Generic;

using Xeno.Core.Configuration;

// ReSharper disable CollectionNeverUpdated.Global

namespace Xeno.CLI
{
    internal record XenoConfiguration : IRkConfigNotifiedWhenUpdated
    {
        public string Requires { get; init; } = "any";
        public List<string> AllowRazorAssemblies { get; init; } = new();
        public List<string> BeforeBuild { get; init; } = new();
        public List<string> ExtraBeforeBuild { get; init; } = new();

        public void OnUpdated()
        {
            // Append pre-build commands
            if (ExtraBeforeBuild.Count > 0)
            {
                BeforeBuild.AddRange(ExtraBeforeBuild);
                ExtraBeforeBuild.Clear();
            }
        }
    }
}