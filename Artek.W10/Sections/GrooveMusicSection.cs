using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using Windows.ApplicationModel.Appointments;
using System.Linq;
using Windows.Storage;

using Artek.Navigation;
using Artek.ViewModels;

namespace Artek.Sections
{
    public class GrooveMusicSection : Section<GrooveMusic1Schema>
    {
		private DynamicStorageDataProvider<GrooveMusic1Schema> _dataProvider;		

		public GrooveMusicSection()
		{
			_dataProvider = new DynamicStorageDataProvider<GrooveMusic1Schema>();
		}

		public override async Task<IEnumerable<GrooveMusic1Schema>> GetDataAsync(SchemaBase connectedItem = null)
        {
            var config = new DynamicStorageDataConfig
            {
                Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=8cfa212c-c04b-4c44-9cab-a33b3ce00da4&appId=1b361c43-6266-4453-9518-3892751b61e2"),
                AppId = "1b361c43-6266-4453-9518-3892751b61e2",
                StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string,
            };
            return await _dataProvider.LoadDataAsync(config, MaxRecords);
        }

        public override async Task<IEnumerable<GrooveMusic1Schema>> GetNextPageAsync()
        {
            return await _dataProvider.LoadMoreDataAsync();
        }

        public override bool HasMorePages
        {
            get
            {
                return _dataProvider.HasMoreItems;
            }
        }

        public override ListPageConfig<GrooveMusic1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<GrooveMusic1Schema>
                {
                    Title = "GrooveMusic",

                    Page = typeof(Pages.GrooveMusicListPage),

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                    },
                    DetailNavigation = (item) =>
                    {
						return NavInfo.FromPage<Pages.GrooveMusicDetailPage>(true);
                    }
                };
            }
        }

        public override DetailPageConfig<GrooveMusic1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, GrooveMusic1Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = "";
                    viewModel.ImageUrl = ItemViewModel.LoadSafeUrl("");
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<GrooveMusic1Schema>>
                {
                    ActionConfig<GrooveMusic1Schema>.Play("Play", (item) => item.Link.ToSafeString()),
                    ActionConfig<GrooveMusic1Schema>.Play("kek", (item) => item.Link.ToSafeString()),
                };

                return new DetailPageConfig<GrooveMusic1Schema>
                {
                    Title = "GrooveMusic",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }
    }
}
