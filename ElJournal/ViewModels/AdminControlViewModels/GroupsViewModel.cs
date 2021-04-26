using ElJournal.Dialogs;
using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ElJournal.ViewModels.AdminControlViewModels
{
    class GroupsViewModel: BaseViewModel
    {
        #region Поля

        private List<Group> _groupsList;
        private DelegateCommand _addGroup;
        private DelegateCommand _deleteGroups;

        #endregion

        #region Конструктор

        public GroupsViewModel()
        {
            var gm = new GroupModel();
            _groupsList = gm.GetList();
        }

        #endregion

        #region Свойства

        public List<Group> GroupsList
        {
            get => _groupsList;
            set
            {
                _groupsList = value;
                OnPropertyChanged(nameof(GroupsList));
            }
        }

        #endregion

        #region Команды

        public DelegateCommand AddGroup
        {
            get
            {
                return _addGroup ??= new DelegateCommand((obj) =>
                {
                    var addgroupdialog = new AddGroupDialog();
                    if (addgroupdialog.ShowDialog() == true)
                    {
                        var vm = (AddGroupDialogViewModel)addgroupdialog.DataContext;
                        var newgroup = new Group(vm.Name, int.Parse(vm.Course));
                        var gm = new GroupModel();
                        gm.Add(newgroup);
                        GroupsList = gm.GetList();
                        OnPropertyChanged(nameof(GroupsList));
                    }
                });
            }
        }

        public DelegateCommand DeleteGroups
        {
            get
            {
                return _deleteGroups ??= new DelegateCommand((obj) =>
                {
                    var gm = new GroupModel();
                    foreach(var item in GroupsList)
                    {
                        if (item.IsSelected)
                        {
                            gm.Remove(item);
                        }   
                    }
                    GroupsList = gm.GetList();
                });
            }
        }

        #endregion

    }
}
