using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

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
                lcArtist.EditDetails();
            else
                MessageBox.Show("Sorry no artist by this name");
        }

        public void NewArtist()
        {
            clsArtist lcArtist = new clsArtist(this);
            try
            {
                if (lcArtist.Name != "")
                {
                    Add(lcArtist.Name, lcArtist);
                    MessageBox.Show("Artist added!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Duplicate Key!");
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
