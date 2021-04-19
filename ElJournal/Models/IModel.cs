using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Models
{
    interface IModel<TData>
    {
        void Add(TData item);
        void Remove(TData item);
        TData GetItemByID(int id);
    }
}
