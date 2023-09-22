using FileConverter.BL;
using FileConverter.DA;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.IoC
{
    /// <summary>
    /// This Ninject module registers the bindings for classes from the BL and DA layer
    /// </summary>
    public class FileConverterModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DA.Factory>().To<DA.Factory>();
            Bind<IFileConversionRunner>().To<FileConversionRunner>();
         }
    }
}
