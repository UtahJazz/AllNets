namespace AllNets.Vk
{
    public class VkPost
    {
        public int CreatedDate;
        public string AuthorName;
        public string Text;
        public string AuthorImage;
        public int Id;
        public Likes Likes;
        public Reposts Reposts;
        public Attachment Image;

        public VkPost(int createdDate, string authorName, string text, string authorImage, int id, Likes likes, 
            Reposts reposts, Attachment image)
        {
            CreatedDate = createdDate;
            AuthorName = authorName;
            Text = text;
            AuthorImage = authorImage;
            Id = id;
            Likes = likes;
            Reposts = reposts;
            Image = image;
        }
    }
}
