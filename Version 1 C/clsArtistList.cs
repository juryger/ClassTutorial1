using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Version_1_C.Delegates;

namespace Version_1_C
{
    [Serializable()]
    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string _fileName = "gallery.bin";
        private MainFormUpdateDelegate _mainFormUpdate;
        private string _galleryName;

        public string GalleryName
        {
            get
            {
                return _galleryName;
            }

            set
            {
                _galleryName = value;
            }
        }

        public clsArtistList()
        {

        }

        public clsArtistList(MainFormUpdateDelegate pMainFormUpdate)
        {
            if (pMainFormUpdate == null)
                throw new ArgumentNullException(nameof(pMainFormUpdate));

            _mainFormUpdate = pMainFormUpdate;
        }

        public void EditArtist(string prKey)
        {
            var lcArtist = this[prKey];
            if (lcArtist != null)
            {
                lcArtist.EditDetails();
            }
        }

        public void NewArtist()
        {
            new clsArtist(
                new IsDuplicateArtistDelegate(IsDuplicateArtist),
                new FinishArtistEditingDelegate(OnArtistEditingDone));
        }

        private bool IsDuplicateArtist(string pArtistName)
        {
            return ContainsKey(pArtistName);
        }

        private void OnArtistEditingDone(clsArtist pArtist, bool isInsert)
        {
            try
            {
                if (pArtist.Name != "")
                {
                    if (isInsert)
                        Add(pArtist.Name, pArtist);

                    _mainFormUpdate();
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Artist list duplicate key!");
            }
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }

        public static clsArtistList Retrieve(MainFormUpdateDelegate pMainFormUpdate)
        {
            if (pMainFormUpdate == null)
                throw new ArgumentNullException(nameof(pMainFormUpdate));

            var lcFileStream = new FileStream(_fileName, FileMode.Open);
            var lcFormatter = new BinaryFormatter();

            var result = new clsArtistList(pMainFormUpdate);
            result = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
            lcFileStream.Close();

            result._mainFormUpdate = pMainFormUpdate;

            foreach (var item in result)
            {
                item.Value.InitArtistAfterDeserialization(
                    new IsDuplicateArtistDelegate(result.IsDuplicateArtist),
                    new FinishArtistEditingDelegate(result.OnArtistEditingDone));
            }

            return result;
        }

        public void Save()
        {
            var lcFileStream = new FileStream(_fileName, FileMode.Create);
            var lcFormatter = new BinaryFormatter();

            lcFormatter.Serialize(lcFileStream, this);
            lcFileStream.Close();
        }
    }
}