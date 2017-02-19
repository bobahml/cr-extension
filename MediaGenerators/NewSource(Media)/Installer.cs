using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Mindscan.Media.ProcessingApps.Bundle4.Sources;

namespace $rootnamespace$.$foldername$
{
	public class $classnameprefix$Installer : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(

				$windsorcomponents$

					);
		}
	}
}