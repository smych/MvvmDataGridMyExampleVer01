using ExampleButton.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleButton.Model
{
    public class GroupUser : ViewModelBase
    {
        #region fields
        private bool _isSelected;
        private bool _isExpanded;
        private BindingList<GroupUser> _groups;
        private BindingList<User> _users;
        private string _nameGroup;
        #endregion

        #region properties
        public BindingList<GroupUser> ChildrenGroups
        {
            get
            {
                return _groups;
            }

            set
            {
                if (_groups != value)
                {
                    _groups = value;
                    RaisePropertyChanged(() => ChildrenGroups);
                }
            }
        }

        public BindingList<User> ChildrenUsers
        {
            get
            {
                return _users;
            }

            set
            {
                if (_users != value)
                {
                    _users = value;
                    RaisePropertyChanged(() => ChildrenUsers);
                }
            }
        }

        public string NameGroup
        {
            get
            {
                return _nameGroup;
            }

            set
            {
                if (_nameGroup != value)
                {
                    _nameGroup = value;
                    RaisePropertyChanged(() => NameGroup);
                }
            }
        }

        /// <summary>
        /// Gets/sets a proprrty to determine whether this item is currently selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged(() => IsSelected);
                }
            }
        }

        /// <summary>
        /// Gets/sets a proprrty to determine whether this item is currently expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }

            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    RaisePropertyChanged(() => IsExpanded);
                }
            }
        }

        #endregion
    }
}
