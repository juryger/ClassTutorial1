using System;
using System.Collections.Generic;

namespace Version_1_C
{
    [Serializable()]
    public class clsWorksList : List<clsWork>
    {
        private byte _sortOrder; // 0 = Name, 1 = Date

        public byte SortOrder
        {
            get
            {
                return _sortOrder;
            }

            set
            {
                _sortOrder = value;
            }
        }

        public void AddWork(WorkType pWorkType)
        {
            clsWork lcWork = clsWork.NewWork(pWorkType);
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }

        public void DeleteWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
                throw new ArgumentOutOfRangeException(nameof(prIndex));

            RemoveAt(prIndex);
        }

        public void EditWork(int prIndex)
        {
            if (prIndex < 0 && prIndex >= this.Count)
                throw new ArgumentOutOfRangeException(nameof(prIndex));

            clsWork lcWork = (clsWork)this[prIndex];
            lcWork.EditDetails();
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsWork lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

        public void SortByName()
        {
            Sort(clsNameComparer.Instance);
        }

        public void SortByDate()
        {
            Sort(clsDateComparer.Instance);
        }
    }
}
