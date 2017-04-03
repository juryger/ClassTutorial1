using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Version_1_C
{
    [Serializable()]
    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string _fileName = "gallery.bin";

        public void EditArtist(string prKey)
        {
            var lcArtist = this[prKey];
            if (lcArtist != null)
            {
                lcArtist.EditDetails();
            }
        }

        public bool NewArtist(out string errorMsg)
        {
            errorMsg = string.Empty;

            clsArtist lcArtist = new clsArtist(this);
            try
            {
                if (lcArtist.Name != "")
                {
                    Add(lcArtist.Name, lcArtist);
                }
            }
            catch (Exception)
            {
                errorMsg = "Duplicate Key!";
            }

            return string.IsNullOrEmpty(errorMsg);
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

        public static clsArtistList Retrieve()
        {
            var lcFileStream = new FileStream(_fileName, FileMode.Open);
            var lcFormatter = new BinaryFormatter();

            var result = new clsArtistList();
            result = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
            lcFileStream.Close();

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
