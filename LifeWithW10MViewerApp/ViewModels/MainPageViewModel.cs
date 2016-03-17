using LifeWithW10MViewerApp.Models;
using Prism.Windows.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using System.Reactive.Disposables;
using Windows.UI.Xaml.Controls;
using Windows.System;

namespace LifeWithW10MViewerApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private LifeWithW10MViewer Model { get; }
        public ReadOnlyReactiveProperty<Post[]> Posts { get; }

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public MainPageViewModel(LifeWithW10MViewer model)
        {
            this.Model = model;
            this.Posts = this.Model
               .ObserveProperty(x => x.Posts)
               .ToReadOnlyReactiveProperty()
               .AddTo(this.Disposable);
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            if (!suspending)
            {
                this.Disposable.Dispose();
            }
        }

        public async void ItemClick(object sender, ItemClickEventArgs e)
        {
            var target = e.ClickedItem as Post;
            await Launcher.LaunchUriAsync(target.Uri);
        }
    }
}
