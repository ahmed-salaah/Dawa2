using System;
using GalaSoft.MvvmLight.Command;
using Models;
using Xamarin.Forms;

namespace GHQ.Logic.ViewModels.ContactUs
{
    public class ContactUsViewModel : BaseViewModel
    {
        public ContactUsViewModel()
        {

        }

        #region Private Members



        #endregion

        #region Properties



        private string _PhoneNo = "800555";
        public string PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                Set(() => PhoneNo, ref _PhoneNo, value);
            }
        }

        private string _Link = "www.uaensr.ae";
        public string Link
        {
            get
            {
                return _Link;
            }
            set
            {
                Set(() => Link, ref _Link, value);
            }
        }

        private string _FacebookLink = "https://www.facebook.com/UAE-National-Service-1436945753222903/";
        public string FacebookLink
        {
            get
            {
                return _FacebookLink;
            }
            set
            {
                Set(() => FacebookLink, ref _FacebookLink, value);
            }
        }

        private string _InstagramLink = "https://www.instagram.com/UAENSR/";
        public string InstagramLink
        {
            get
            {
                return _InstagramLink;
            }
            set
            {
                Set(() => InstagramLink, ref _InstagramLink, value);
            }
        }

        private string _TwitterLink = "https://twitter.com/UAENSR";
        public string TwitterLink
        {
            get
            {
                return _TwitterLink;
            }
            set
            {
                Set(() => TwitterLink, ref _TwitterLink, value);
            }
        }

        private string _GooglePlusLink = "https://www.youtube.com/channel/UCBvq8jYRaI6ZpvQX2aFSl2A/feed";
        public string GooglePlusLink
        {
            get
            {
                return _GooglePlusLink;
            }
            set
            {
                Set(() => GooglePlusLink, ref _GooglePlusLink, value);
            }
        }

        #endregion

        #region Private Methods

        #endregion

        #region Commands
        private RelayCommand _LinkSelectedCommand;
        public RelayCommand LinkSelectedCommand
        {
            get
            {
                if (_LinkSelectedCommand == null)
                {
                    _LinkSelectedCommand = new RelayCommand(Openlink);
                }
                return _LinkSelectedCommand;
            }
        }

        private void Openlink()
        {
            Device.OpenUri(new Uri("http://" + Link));
        }

        private RelayCommand _FacebookLinkSelectedCommand;
        public RelayCommand FacebookLinkSelectedCommand
        {
            get
            {
                if (_FacebookLinkSelectedCommand == null)
                {
                    _FacebookLinkSelectedCommand = new RelayCommand(OpenFacebooklink);
                }

                return _FacebookLinkSelectedCommand;
            }
        }
        private void OpenFacebooklink()
        {
            Device.OpenUri(new Uri(FacebookLink));
        }


        private RelayCommand _TwitterLinkSelectedCommand;
        public RelayCommand TwitterLinkSelectedCommand
        {
            get
            {
                if (_TwitterLinkSelectedCommand == null)
                {
                    _TwitterLinkSelectedCommand = new RelayCommand(OpenTwitterlink);
                }

                return _TwitterLinkSelectedCommand;
            }
        }
        private void OpenTwitterlink()
        {
            Device.OpenUri(new Uri(TwitterLink));
        }

        private RelayCommand _GooglePlusLinkSelectedCommand;
        public RelayCommand GooglePlusLinkSelectedCommand
        {
            get
            {
                if (_GooglePlusLinkSelectedCommand == null)
                {
                    _GooglePlusLinkSelectedCommand = new RelayCommand(OpenGooglePluslink);
                }

                return _GooglePlusLinkSelectedCommand;
            }
        }
        private void OpenGooglePluslink()
        {
            Device.OpenUri(new Uri(GooglePlusLink));
        }

        private RelayCommand _InstagramLinkSelectedCommand;
        public RelayCommand InstagramLinkSelectedCommand
        {
            get
            {
                if (_InstagramLinkSelectedCommand == null)
                {
                    _InstagramLinkSelectedCommand = new RelayCommand(OpenInstagramPluslink);
                }

                return _InstagramLinkSelectedCommand;
            }
        }
        private void OpenInstagramPluslink()
        {
            Device.OpenUri(new Uri(InstagramLink));
        }


        private RelayCommand _CallPhoneSelectedCommand;
        public RelayCommand CallPhoneSelectedCommand
        {
            get
            {
                if (_CallPhoneSelectedCommand == null)
                {
                    _CallPhoneSelectedCommand = new RelayCommand(Call);
                }

                return _CallPhoneSelectedCommand;
            }
        }
        private void Call()
        {
            Device.OpenUri(new Uri("tel://" + PhoneNo));
        }
        #endregion
    }
}
