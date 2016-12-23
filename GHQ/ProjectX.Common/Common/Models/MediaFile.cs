using GalaSoft.MvvmLight.Command;
using System;
using Xamarin.Forms;

namespace Models
{
    public class MediaFile
    {
        public Byte[] data { get; set; }
        public string Extension { get; set; }
        public Size Size { get; set; }
        public EventHandler<EventArgs> OnDeleted { get; set; }


        public bool isSelected { get; set; }

        private RelayCommand _DeleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                _DeleteCommand = _DeleteCommand ?? new RelayCommand(DoDeleteCommand);
                return _DeleteCommand;
            }
        }


        private void DoDeleteCommand()
        {
            isSelected = true;
        }

    }

}
