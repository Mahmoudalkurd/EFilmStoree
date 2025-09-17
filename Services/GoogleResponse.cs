namespace EBookStore.Models
{
    public class GoogleBooksResponse
    {
        public List<GoogleBook> Items { get; set; }
    }

    public class GoogleBook
    {
        public VolumeInfo VolumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public ImageLinks ImageLinks { get; set; }
    }

    public class ImageLinks
    {
        public string Thumbnail { get; set; }
    }
}
