using System;
using System.Globalization;
using System.Windows.Media.Imaging;
using AllNets.Vk;
using TweetSharp;

namespace AllNets.ViewModels
{
    enum NetType {Twit, VkPost};

    public class PostViewModel 
    {
        private NetType _type;
        private TwitterStatus _twit;
        private VkPost _vkPost;

        public int Id;

        public long PostId
        {
            get
            {
                if (_type == NetType.Twit)
                    return _twit.Id;
                return _vkPost.Id;
            }
        }

        public string SourceText
        {
            get
            {
                if (_type == NetType.VkPost)
                    return _vkPost.Text;
                return _twit.Text;
            }
        }

        public VkPost Post
        {
            get
            {
                return _vkPost;
            }
            set
            {
                _vkPost = value;
                _type = NetType.VkPost;
            }
        }

        public Likes Likes
        {
            get
            {
                if (_type == NetType.VkPost)
                    return _vkPost.Likes;
                return null;
            }
        }

        public BitmapImage Image
        {
            get
            {
                if (_type == NetType.VkPost && _vkPost.Image != null)
                    if (_vkPost.Image.photo != null)
                        return new BitmapImage(new Uri(_vkPost.Image.photo.src_big, UriKind.Absolute));
                return null;
            }
        }

        public BitmapImage PreviewImage
        {
            get
            {
                if (_type == NetType.VkPost && _vkPost.Image != null)
                    if (_vkPost.Image.photo != null)
                        return new BitmapImage(new Uri(_vkPost.Image.photo.src, UriKind.Absolute));
                return null;
            }
        }


        public Reposts Reposts
        {
            get
            {
                if (_type == NetType.VkPost)
                    return _vkPost.Reposts;
                return null;
            }
        }

        public TwitterStatus Twit
        {
            get
            {
                return _twit;
            }
            set
            {
                _twit = value;
                _type = NetType.Twit;
            }
        }

        public string AuthorName
        {
            get
            {
                if (_type == NetType.Twit)
                {
                    return _twit.Author.ScreenName;
                }
                return _vkPost.AuthorName;
            }
        }

        public string CreatedDate
        {
            get
            {
                if (_type == NetType.Twit)
                    return Twit.CreatedDate.ToString(CultureInfo.InvariantCulture);
                return (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(_vkPost.CreatedDate).ToString(CultureInfo.InvariantCulture);
            }
        }

        public string PreviewText
        {
            get
            {
                if (_type == NetType.Twit)
                    return RemoveHtmlTags(Twit.Text);
                if (_vkPost.Text != null && RemoveHtmlTags(_vkPost.Text).Length > 140)
                    return RemoveHtmlTags(_vkPost.Text.Substring(0, 140));
                return RemoveHtmlTags(_vkPost.Text);
            }
        }

        public string Text
        {
            get
            {
                if (_type == NetType.Twit)
                    return RemoveHtmlTags(Twit.Text);
                return RemoveHtmlTags(_vkPost.Text);
            }
        }

        public BitmapImage AuthorImage
        {
            get
            {
                if (_type == NetType.Twit)
                    return new BitmapImage(new Uri(_twit.Author.ProfileImageUrl, UriKind.Absolute));
                return new BitmapImage(new Uri(_vkPost.AuthorImage, UriKind.Absolute));
            }
        }

        public PostViewModel(TwitterStatus twit, int id)
        {
            _twit = twit;
            Id = id;
            _type = NetType.Twit;
        }

        public PostViewModel(VkPost vkPost, int id)
        {
            _vkPost = vkPost;
            Id = id;
            _type = NetType.VkPost;
        }

        private string RemoveHtmlTags(string text)
        {
            if (text == null)
                return null;
            return text.Replace("<br>", "");
        }
    }
}