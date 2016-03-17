using LifeWithW10MViewerApp.Models;
using Microsoft.Practices.Unity;
using Prism.Unity.Windows;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace LifeWithW10MViewerApp
{
    sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterType<LifeWithW10MViewer>(new ContainerControlledLifetimeManager());
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var ignore = this.Container.Resolve<LifeWithW10MViewer>().InitializeAsync();
            return base.OnInitializeAsync(args);
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            this.NavigationService.Navigate("Main", null);
            return Task.CompletedTask;
        }
    }
}
