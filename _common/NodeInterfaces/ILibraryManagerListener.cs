using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _common.NodeInterfaces
{
    public interface ILibraryManagerListener
    {
        void OnLibraryListRetreived(List<string> libraryList);
        void OnHasLibrary(string libraryName, bool hasLibrary);
        void OnLibraryInstalled(string libraryName);
        void OnLibraryManagerError(string msg);
    }
}
