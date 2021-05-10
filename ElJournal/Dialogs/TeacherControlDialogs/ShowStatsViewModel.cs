using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Dialogs.TeacherControlDialogs
{
    class ShowStatsViewModel: BaseViewModel
    {
        #region Поля

        private Student _selectedStudent;

        #endregion

        #region Свойства

        public List<Student> StudentsList
        {
            get => new StudentModel().GetStudentsByGroup(CurrentInfo.CurrentSelectedGroup.GroupID);
        }

        public List<Mark> MarksList
        {
            get
            {
                if (_selectedStudent != null)
                {
                    var markmodel = new MarkModel();
                    return markmodel.GetMarksByStudentAndSemester(_selectedStudent.StudentID, CurrentInfo.CurrentSelectedSemester.SemesterID);
                }
                else return null;
            }
        }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
                OnPropertyChanged(nameof(IsStudentSelected));
                OnPropertyChanged(nameof(Average));
                OnPropertyChanged(nameof(SemesterMark));
                OnPropertyChanged(nameof(Skips));
                OnPropertyChanged(nameof(MarksList));
            }
        }

        public double Average
        {
            get
            {
                if (_selectedStudent != null)
                {
                    double sum = 0;
                    int count = 0;
                    foreach(var item in MarksList)
                    {
                        double mark;
                        if (double.TryParse(item.Value, out mark))
                        {
                            sum += mark;
                            count++;
                        }
                    }
                    if (count == 0)
                        return 0;
                    else return Math.Round(sum / count,2);
                }
                else return 0;
            }
        }

        public decimal SemesterMark
        {
            get => Math.Round((decimal)Average);
        }

        public int Skips
        {
            get
            {
                if (_selectedStudent != null)
                {
                    int count = 0;
                    foreach (Mark item in MarksList)
                    {
                        if (item.Value.Contains("Нб"))
                        {
                            count++;
                        }
                    }
                    return count;
                }
                else return 0;
            }
        }

        public bool IsStudentSelected => _selectedStudent != null;

        #endregion
    }
}
