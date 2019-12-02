using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ExampleButton.ViewModel
{
    public class MainViewModel : Base.ViewModelBase
    {
        #region Fields
        public ICollectionView Items { get; private set; }
        private ObservableCollection<UserViewModel> _userViewCollection = null;
        readonly string ImageDefault = $"/Image/user.png";

        #endregion Fields

        public MainViewModel()
        {
            UserViewCollection = LoadedProgram();
        }


        // Генерируем коллекцию
        ObservableCollection<UserViewModel> LoadedProgram()
        {
            AddUser = new Base.RelayCommand(new Action<object>(AddUserObject));
            DelUser = new Base.RelayCommand(new Action<object>(DelUserObject));

            ObservableCollection<UserViewModel>  temp = new ObservableCollection<UserViewModel>
            {
                new UserViewModel{FirstName = "First1", LastName = "Last1", Image = ImageDefault },
                new UserViewModel{FirstName = "Василий", LastName = "Васюков", Image = ImageDefault },
                new UserViewModel{FirstName = "Максим", LastName = "Максюков", Image = ImageDefault },
                new UserViewModel{FirstName = "Петр", LastName = "Петрюков", Image = ImageDefault },
            };

            Items = CollectionViewSource.GetDefaultView(temp);

            return temp;
        }

        public ObservableCollection<UserViewModel> UserViewCollection
        {
            get
            {
                return _userViewCollection;
            }
            set
            {
                if (_userViewCollection != value)
                {
                    _userViewCollection = value;
                    RaisePropertyChanged(() => UserViewCollection);
                }
            }
        }

        private ICommand m_addUser;
        private ICommand m_delUser;

        public ICommand AddUser
        {
            get { return m_addUser; }
            set { m_addUser = value; }
        }

        public ICommand DelUser
        {
            get { return m_delUser; }
            set { m_delUser = value; }
        }

        public void AddUserObject(object obj)
        {
            UserViewCollection.Add(new UserViewModel { Image = ImageDefault, FirstName = "", LastName = "" });
        }

        public void DelUserObject(object obj)
        {
            UserViewCollection.Remove(UserViewCollection[UserViewCollection.Count - 1]);
        }
    }
}
