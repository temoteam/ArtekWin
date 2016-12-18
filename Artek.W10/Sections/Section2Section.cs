using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.Uwp;
using Windows.ApplicationModel.Appointments;
using System.Linq;

using Artek.Navigation;
using Artek.ViewModels;

namespace Artek.Sections
{
    public class Section2Section : Section<Section2Schema>
    {
		private LocalStorageDataProvider<Section2Schema> _dataProvider;

		public Section2Section()
		{
			_dataProvider = new LocalStorageDataProvider<Section2Schema>();
		}

		public override async Task<IEnumerable<Section2Schema>> GetDataAsync(SchemaBase connectedItem = null)
        {
            var config = new LocalStorageDataConfig
            {
                FilePath = "/Assets/Data/Section2.json",
            };
            return await _dataProvider.LoadDataAsync(config, MaxRecords);
        }

        public override async Task<IEnumerable<Section2Schema>> GetNextPageAsync()
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

        public override bool NeedsNetwork
        {
            get
            {
                return false;
            }
        }

        public override ListPageConfig<Section2Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Section2Schema>
                {
                    Title = "Словарь",

                    Page = typeof(Pages.Section2ListPage),

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Subtitle.ToSafeString();
                    },
                    DetailNavigation = (item) =>
                    {
                        return null;
                    }
                };
            }
        }

        public override DetailPageConfig<Section2Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Section2Schema>>();

                var actions = new List<ActionConfig<Section2Schema>>
                {
                };

                return new DetailPageConfig<Section2Schema>
                {
                    Title = "Словарь",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }
    }
}
