using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using Grabacr07.KanColleViewer.Models;
using Grabacr07.KanColleViewer.Models.Settings;
using Grabacr07.KanColleViewer.Properties;
using Grabacr07.KanColleWrapper;
using MetroTrilithon.Mvvm;
using Grabacr07.KanColleWrapper.Models;

namespace Grabacr07.KanColleViewer.ViewModels.Catalogs
{
	public class FleetPlannerWindowViewModel : WindowViewModel
	{
		private readonly Subject<Unit> updateSource = new Subject<Unit>();
		private readonly Homeport homeport = KanColleClient.Current.Homeport;

		public FleetPlannerWindowSettings Settings { get; }

		#region Ships 変更通知プロパティ

		private IEnumerable<ShipHierarchyViewModel> _shipGroups;

		public IEnumerable<ShipHierarchyViewModel> ShipGroups
		{
			get { return this._shipGroups; }
			set
			{
				if (this._shipGroups != value)
				{
					this._shipGroups = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region IsReloading 変更通知プロパティ

		private bool _IsReloading;

		public bool IsReloading
		{
			get { return this._IsReloading; }
			set
			{
				if (this._IsReloading != value)
				{
					this._IsReloading = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		public FleetPlannerWindowViewModel()
		{
			this.Title = Resources.ShipCatalog_WindowTitle;
			this.Settings = new FleetPlannerWindowSettings();

			this.updateSource
				.Do(_ => this.IsReloading = true)
				.SelectMany(u => UpdateAsync(u))
				.Do(_ => this.IsReloading = false)
				.Subscribe()
				.AddTo(this);

			this.homeport.Organization
				.Subscribe(nameof(Organization.Ships), this.Update)
				.AddTo(this);
		}

		public void Update()
		{
			this.updateSource.OnNext(Unit.Default);
		}

		private IObservable<Unit> UpdateAsync(Unit u)
		{
			return Observable.Start(() =>
			{
                var list = this.homeport.Organization.Ships
                    .Select(kvp => kvp.Value);

                this.ShipGroups = list
                    .Select((x, i) => new ShipViewModel(i + 1, x, null))
                    .GroupBy(s => s.Ship.Info.ShipType)
                    .Select(g => new ShipHierarchyViewModel(g.Key, g));
			});
		}
	}

    public class ShipHierarchyViewModel
    {
        public ShipHierarchyViewModel(ShipType shipType, IEnumerable<ShipViewModel> ships)
        {
            ShipType = shipType;
            Ships = ships;
        }

        public ShipType ShipType { get; }
        public IEnumerable<ShipViewModel> Ships { get; }
    }
}
