using ExampleButton.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleButton.Model
{
    public class User : ViewModelBase
    {
        #region fields

        private string _firstName;
        private string _lastName;
        private string _image;

        #endregion fields

        /// <summary>
        /// Class constructor
        /// </summary>
        public User()
        {

        }

        #region properties
        /// <summary>
        /// Gets the title of a document to display the information in the UI.
        /// </summary>
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged(() => FirstName);
                }
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged(() => LastName);
                }
            }
        }

        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                if (_image != value)
                {
                    _image = value;
                    RaisePropertyChanged(() => Image);
                }
            }
        }

        #endregion properties
    }
}
