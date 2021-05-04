using ElJournal.Dialogs;
using ElJournal.Dialogs.AdminGroupsDialogs;
using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace ElJournal.ViewModels.AdminControlViewModels
{
    class GroupsViewModel: BaseViewModel
    {
        #region Поля

        private List<Group> _groupsList;
        private Group _selectedGroup;
        private string _filter;
        private DelegateCommand _addGroup;
        private DelegateCommand _deleteGroups;
        private DelegateCommand _editGroup;
        private DelegateCommand _addSubject;
        private DelegateCommand _openSubjectsDialog;

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
                OnPropertyChanged(nameof(FilteredList));
            }
        }

        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }

        public IEnumerable<Group> FilteredList
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_filter))
                {
                    var filteredlist = GroupsList.Where(g => g.Name.ToLower().Contains(_filter.ToLower()) || g.Name.ToLower() == _filter.ToLower());
                    return filteredlist;
                }
                else
                    return GroupsList;
            }
        }

        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                OnPropertyChanged(nameof(FilteredList));
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
                        OnPropertyChanged(nameof(FilteredList));
                    }
                });
            }
        }

        public DelegateCommand DeleteGroup
        {
            get
            {
                return _deleteGroups ??= new DelegateCommand((obj) =>
                {
                    if (_selectedGroup != null)
                    {
                        var confirmdialog = new ConfirmDeleteDialog();
                        if (confirmdialog.ShowDialog() == true)
                        {
                            var groupmodel = new GroupModel();
                            groupmodel.Remove(_selectedGroup);
                            GroupsList = groupmodel.GetList();
                        }
                    }
                    else
                    {
                        var err = new ErrorDialog(Validation.ItemIsNotSelectedError);
                        err.ShowDialog();
                    }
                });
            }
        }

        public DelegateCommand EditGroup
        {
            get
            {
                return _editGroup ??= new DelegateCommand((arg) =>
                {
                    if (_selectedGroup != null)
                    {
                        var eg = new EditGroupDialog();
                        if (eg.ShowDialog() == true)
                        {
                            var vm = (EditGroupDialogViewModel)eg.DataContext;
                            var newgroup = new Group(vm.NewName, int.Parse(vm.SelectedCourse));
                            var groupmodel = new GroupModel();
                            groupmodel.EditGroup(_selectedGroup.GroupID, newgroup);
                            GroupsList = groupmodel.GetList();
                        }
                    }
                    else
                    {
                        var err = new ErrorDialog(Validation.ItemIsNotSelectedError);
                        err.ShowDialog();
                    }
                });
            }
        }

        public DelegateCommand AddSubject
        {
            get
            {
                return _addSubject ??= new DelegateCommand((obj) =>
                {
                    if (_selectedGroup != null)
                    {
                        var addsubjectdialog = new AddSubjectDialog();
                        if (addsubjectdialog.ShowDialog() == true)
                        {
                            var asdvm = (AddSubjectDialogViewModel)addsubjectdialog.DataContext;
                            var grouptosubjectmodel = new GroupToSubjectModel();
                            if (!grouptosubjectmodel.ConnectionExists(_selectedGroup.GroupID, asdvm.SelectedSubject.SubjectID))
                            {
                                var grouptosubject = new GroupToSubject(_selectedGroup.GroupID, asdvm.SelectedSubject.SubjectID);
                                grouptosubjectmodel.Add(grouptosubject);
                            }
                            else
                            {
                                var err = new ErrorDialog(Validation.ConnectionExist);
                                err.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        var err = new ErrorDialog(Validation.ItemIsNotSelectedError);
                        err.ShowDialog();
                    }
                });
            }
        }

        public DelegateCommand OpenSubjectsDialog
        {
            get
            {
                return _openSubjectsDialog ??= new DelegateCommand((obj) =>
                {
                    new ShowSubjectsDialog().ShowDialog();
                });
            }
        }

        #endregion

    }
}
