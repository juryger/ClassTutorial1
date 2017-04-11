namespace Version_1_C.Delegates
{
    public delegate bool IsDuplicateArtistDelegate(string artistName);

    public delegate void FinishArtistEditingDelegate(clsArtist pArtistName, bool isInsert);

    public delegate void MainFormUpdateDelegate();

    public delegate void LoadWorkFormDelegate(clsWork prWork);

    public delegate void Notify(string prGalleryName);
}
