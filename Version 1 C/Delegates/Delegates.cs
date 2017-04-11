using System;

namespace Version_1_C.Delegates
{
    [Serializable]
    public delegate bool IsDuplicateArtistDelegate(string artistName);

    [Serializable]
    public delegate void FinishArtistEditingDelegate(clsArtist pArtistName, bool isInsert);

    [Serializable]
    public delegate void MainFormUpdateDelegate();

    [Serializable]
    public delegate void LoadWorkFormDelegate(clsWork prWork);

    [Serializable]
    public delegate void Notify(string prGalleryName);
}
