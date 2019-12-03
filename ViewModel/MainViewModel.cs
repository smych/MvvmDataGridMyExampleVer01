using ExampleButton.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ExampleButton.ViewModel
{
    public class MainViewModel : Base.ViewModelBase
    {
        #region Fields
        public ICollectionView ItemsCollectionView { get; private set; }
        //?
        private ObservableCollection<UserViewModel> _userViewCollection = null;
        readonly string ImageDefault = $"/Image/user.png";
        public BindingList<UserViewModel> PeopleCollection { get; set; }


        #region Test
        /// <summary>
        /// Test
        /// </summary>
        // private SelectItemDataGridViewModel selectItem;
        // Доступ к контролам
        public static readonly MainWindow _main = ((MainWindow)System.Windows.Application.Current.MainWindow);

        //
        #endregion


        #endregion Fields

        public MainViewModel()
        {
            AddUser = new Base.RelayCommand(new Action<object>(AddUserObject));
            DelUser = new Base.RelayCommand(new Action<object>(DelUserObject));

            //UserViewCollection = LoadedProgram();
            PeopleCollection = LoadPeopleList();
            PeopleCollection.ListChanged += PeopleCollection_ListChanged;
        }

        private void PeopleCollection_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    MessageBox.Show(string.Format($"{sender}"));
                }
                catch (Exception obj)
                {
                    MessageBox.Show(obj.Message);
                    return;
                }
            }
        }

        BindingList<UserViewModel> LoadPeopleList()
        {
            BindingList<UserViewModel> temp = new BindingList<UserViewModel>
            {
                new UserViewModel{FirstName = "First1", LastName = "Last1", Image = ImageDefault },
                new UserViewModel{FirstName = "Василий", LastName = "Васюков", Image = ImageDefault },
                new UserViewModel{FirstName = "Максим", LastName = "Максюков", Image = ImageDefault },
                new UserViewModel{FirstName = "Петр", LastName = "Петрюков", Image = ImageDefault }
            };

            //
            ItemsCollectionView = CollectionViewSource.GetDefaultView(temp);

            return temp;
        }

        // Генерируем коллекцию
        ObservableCollection<UserViewModel> LoadedProgram()
        {
            ObservableCollection<UserViewModel>  temp = new ObservableCollection<UserViewModel>
            {
                new UserViewModel{FirstName = "First1", LastName = "Last1", Image = ImageDefault },
                new UserViewModel{FirstName = "Василий", LastName = "Васюков", Image = ImageDefault },
                new UserViewModel{FirstName = "Максим", LastName = "Максюков", Image = ImageDefault },
                new UserViewModel{FirstName = "Петр", LastName = "Петрюков", Image = ImageDefault }
            };

            //ItemsCollectionView = CollectionViewSource.GetDefaultView(temp);
            
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
            if(obj!=null)
            UserViewCollection.Add(new UserViewModel { Image = ImageDefault, FirstName = "", LastName = "" });
        }

        public void DelUserObject(object obj)
        {
            if (obj != null)
                UserViewCollection.Remove(UserViewCollection[UserViewCollection.Count - 1]);
        }


    }
}
