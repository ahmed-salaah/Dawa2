using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Models.Data.Map;
using GHQ.Logic.Service.Map;
using Models;
using Xamarin.Forms.Maps;

namespace GHQ.Logic.ViewModels.Map
{
    public class MapViewModel : BaseViewModel
    {
        public MapViewModel(IMapService _mapService)
        {
            mapService = _mapService;
        }

        #region Private Members

        IMapService mapService;

        #endregion

        #region Properties

		 private List<MapData> _Locations;
		public List<MapData> Locations
		{
			get
			{
				return _Locations;
			}
			set
			{
				Set(() => Locations, ref _Locations, value);
			}
		}
  

		#endregion

		#region Private Methods

		#endregion

		#region Commands


		#region Intialize Command

		private RelayCommand _OnIntializeCommand;
        public RelayCommand OnIntializeCommand
        {
            get
            {
                if (_OnIntializeCommand == null)
                {
                    _OnIntializeCommand = new RelayCommand(Intialize);
                }
                return _OnIntializeCommand;
            }
        }
        private void Intialize()
        {
            try
            {
				OnLocationCommand.Execute(null);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

        #region Login Command

        private RelayCommand _OnLocationCommand;
        public RelayCommand OnLocationCommand
        {
            get
            {
                if (_OnLocationCommand == null)
                {
                    _OnLocationCommand = new RelayCommand(GetLocation);
                }
                return _OnLocationCommand;
            }
        }
        private void GetLocation()
        {
            try
            {
				Locations = mapService.GetLocation();
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }
        }


        #endregion

        #endregion
    }
}
