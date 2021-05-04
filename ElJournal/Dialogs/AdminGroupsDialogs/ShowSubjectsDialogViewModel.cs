using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Dialogs.AdminGroupsDialogs
{
    class ShowSubjectsDialogViewModel: BaseViewModel
    {
        #region Поля

        private List<Group> _groupsList;
        private Group _selectedGroup;

        #endregion

        #region Конструктор

        public ShowSubjectsDialogViewModel()
        {
            var groupmodel = new GroupModel();
            _groupsList = groupmodel.GetConnectionedList();
        }

        #endregion

        #region Свойства

        public List<Group> GroupsList
        {
            get => _groupsList;
            set
            {
                _groupsList = value;
                OnPropertyChanged();
            }
        }

        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(SubjectsList));
            }
        }

        public List<GroupToSubject> SubjectsList
        {
            get
            {
                if (_selectedGroup != null)
                {
                    return _selectedGroup.GroupToSubjects;
                }
                else return null;
            }
        }

        #endregion
    }
}
