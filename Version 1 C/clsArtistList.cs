using System;
using System.Collections;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsArtistList : SortedList
    {
        private const string _fileName = "gallery.xml";

        public void EditArtist(string prKey)
        {
            clsArtist lcArtist;
            lcArtist = (clsArtist)this[prKey];
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
            System.IO.FileStream lcFileStream = new System.IO.FileStream(_fileName, System.IO.FileMode.Open);
            System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
                new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

            var result = new clsArtistList();
            result = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
            lcFileStream.Close();

            return result;
        }

        public void Save()
        {
            System.IO.FileStream lcFileStream = new System.IO.FileStream(_fileName, System.IO.FileMode.Create);
            System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
                new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

            lcFormatter.Serialize(lcFileStream, this);
            lcFileStream.Close();
        }
    }
}
