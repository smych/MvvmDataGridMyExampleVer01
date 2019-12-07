using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using ExampleButton.Model;
using ExampleButton.View;
using ExampleButton.ViewModel.Base;

namespace ExampleButton.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        public ICollectionView usersCollectionView { get; private set; }
        //private BindingList<User> _usersCollection;
        private BindingList<GroupUser> _rootGroupList = null;
        readonly string ImageDefault = $"/Image/user.png";
        #endregion Fields

        public MainViewModel()
        {
            _rootGroupList = new BindingList<GroupUser>();
            _rootGroupList = LoadProgram();
            RootGropsList.ListChanged += GroupList_ListChanged;
            //PeopleCollection.ListChanged += PeopleCollection_ListChanged;
        }

        BindingList<GroupUser> LoadProgram()
        {
            //users

            BindingList<User> users1 = new BindingList<User>
            {
                new User { FirstName = "boss1", LastName ="LastBoss1", Image = ImageDefault},
                new User { FirstName = "boss2", LastName ="LastBoss2", Image = ImageDefault},
                new User { FirstName = "boss3", LastName ="LastBoss3", Image = ImageDefault}
            };

            users1.ListChanged += Users_ListChanged;

            BindingList<User> users2 = new BindingList<User>
            {
                new User { FirstName = "Производство1", LastName ="LastПроизводство1", Image = ImageDefault},
                new User { FirstName = "Производство2", LastName ="LastПроизводство2", Image = ImageDefault},
                new User { FirstName = "Производство3", LastName ="LastПроизводство3", Image = ImageDefault}
            };

            users2.ListChanged += Users_ListChanged;

            BindingList<User> users3 = new BindingList<User>
            {
                new User { FirstName = "Вышивка1", LastName ="LastВышивка1", Image = ImageDefault},
                new User { FirstName = "Вышивка2", LastName ="LastВышивка2", Image = ImageDefault},
                new User { FirstName = "Вышивка3", LastName ="LastВышивка3", Image = ImageDefault},
            };

            users3.ListChanged += Users_ListChanged;

            BindingList<User> users4 = new BindingList<User>
            {
                new User { FirstName = "Продажник1", LastName ="LastПродажник1", Image = ImageDefault},
                new User { FirstName = "Продажник2", LastName ="LastПродажник2", Image = ImageDefault},
                new User { FirstName = "Продажник3", LastName ="LastПродажник3", Image = ImageDefault}
            };

            users4.ListChanged += Users_ListChanged;

            BindingList<User> users5 = new BindingList<User>
            {
                new User { FirstName = "support1", LastName ="Lastsupport1", Image = ImageDefault},
                new User { FirstName = "support2", LastName ="Lastsupport2", Image = ImageDefault}
            };

            users5.ListChanged += Users_ListChanged;

            BindingList<User> users6 = new BindingList<User>
            {
                new User { FirstName = "buh1", LastName ="Lastbuh1", Image = ImageDefault},
                new User { FirstName = "buh2", LastName ="Lastbuh2", Image = ImageDefault}
            };

            users6.ListChanged += Users_ListChanged;
            //

            GroupUser Group1 = new GroupUser
            { NameGroup = "Босс", ChildrenUsers = users1 };

            GroupUser Group2 = new GroupUser
            { NameGroup = "Производство", ChildrenUsers = users2 };

            GroupUser Group3 = new GroupUser
            { NameGroup = "Вышивка", ChildrenUsers = users3 };

            GroupUser Group4 = new GroupUser
            { NameGroup = "Sales", ChildrenUsers = users4 };

            GroupUser Group5 = new GroupUser
            { NameGroup = "Buh", ChildrenUsers = users6 };

            GroupUser Group6 = new GroupUser
            { NameGroup = "It", ChildrenUsers = users5 };

            // Списки
            BindingList<GroupUser> gp0 = new BindingList<GroupUser>();
            BindingList<GroupUser> gp1 = new BindingList<GroupUser>();
            BindingList<GroupUser> gproot = new BindingList<GroupUser>();

            //Боссы
            gp0.Add(Group6);
            gp0.Add(Group5);
            gp0.Add(Group4);

            Group1.ChildrenGroups = gp0;

            //Производство
            gp1.Add(Group3);

            Group2.ChildrenGroups = gp1;

            //Root
            gproot.Add(Group1);
            gproot.Add(Group2);

            return gproot;
        }

        private void Users_ListChanged(object sender, ListChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public BindingList<GroupUser> RootGropsList 
        {
            get { return _rootGroupList; } 
        }

        //Метод обработки события
        private void GroupList_ListChanged(object sender, ListChangedEventArgs e)
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

        // Свойство возвращает выбранную позицыю из списка Groups

        private GroupUser _selectedGroup;
        public GroupUser SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                RaisePropertyChanged(() => SelectedGroup);
            }
        }

        #region Command

        //// команда добавления нового объекта
        //private RelayCommand _adduser;
        //public RelayCommand AddUser
        //{
        //    get
        //    {
        //        return _adduser ??
        //          (_adduser = new RelayCommand(obj =>
        //          {
        //              UserViewModel temp = new UserViewModel() { FirstName = "Blank", LastName = "Blank", Image = ImageDefault };
        //              PeopleCollection.Add(temp);
        //              SelectedUser = temp;

        //              //Model.Phone phone = new Model.Phone();
        //              //Phones.Insert(0, phone);
        //              //SelectedPhone = phone;
        //          }));
        //    }
        //}

        //// команда добавления нового объекта
        //private RelayCommand _deliteUser;
        //public RelayCommand DeliteUser
        //{
        //    get
        //    {
        //        return _deliteUser ??
        //          (_deliteUser = new RelayCommand(obj =>
        //          {
        //              UserViewModel temp = obj as UserViewModel;
        //              if (temp != null)
        //              {
        //                  PeopleCollection.Remove(temp);
        //              }

        //          },
        //            (obj) => PeopleCollection.Count > 0));    

        //    }
        //}

        //// Отображение DataGrid
        //private RelayCommand _dgView;
        //public RelayCommand DGView
        //{
        //    get
        //    {
        //        return _dgView ??
        //          (_dgView = new RelayCommand(obj =>
        //          {

        //          }));
        //    }
        //}

        //// Отображение DataGrid
        //private RelayCommand _lbView;
        //public RelayCommand LBView
        //{
        //    get
        //    {
        //        return _adduser ??
        //          (_adduser = new RelayCommand(obj =>
        //          {

        //          }));
        //    }
        //}
        #endregion

    }
}
