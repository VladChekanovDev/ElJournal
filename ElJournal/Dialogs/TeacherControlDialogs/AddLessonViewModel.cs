using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.TeacherControlDialogs
{
    class AddLessonViewModel: BaseViewModel
    {
        #region Поля

        private string _topic;
        private string _lessonType;
        private DelegateCommand _addLesson;

        #endregion

        #region Свойства

        public string Topic
        {
            get => _topic;
            set
            {
                _topic = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public string LessonType
        {
            get => _lessonType;
            set
            {
                _lessonType = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public bool IsAddActive => !string.IsNullOrWhiteSpace(_topic) && !string.IsNullOrWhiteSpace(_lessonType);

        #endregion

        #region Команды

        public DelegateCommand AddLesson
        {
            get
            {
                return _addLesson ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.DialogResult = true;
                });
            }
        }

        #endregion
    }
}
