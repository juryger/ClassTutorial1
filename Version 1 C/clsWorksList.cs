using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsWorksList : List<clsWork>
    {
        private static clsNameComparer _nameComparer = new clsNameComparer();
        private static clsDateComparer _dateComparer = new clsDateComparer();
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

        public void AddWork()
        {
            clsWork lcWork = clsWork.NewWork();
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }

        public void DeleteWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.RemoveAt(prIndex);
                }
            }
        }

        public void EditWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsWork lcWork = (clsWork)this[prIndex];
                lcWork.EditDetails();
            }
            else
            {
                MessageBox.Show("Sorry no work selected #" + Convert.ToString(prIndex));
            }
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
            Sort(_nameComparer);
        }

        public void SortByDate()
        {
            Sort(_dateComparer);
        }
    }
}
