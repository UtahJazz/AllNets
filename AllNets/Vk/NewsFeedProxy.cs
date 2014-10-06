using System.Collections.Generic;

namespace AllNets.Vk
{
    public class FreindsList
    {
        public List<int> response { get; set; }
    }

    public class Response
    {
        public List<Item> items { get; set; }
        public List<Profile> profiles { get; set; }
        public List<Group> groups { get; set; }
        public int new_offset { get; set; }
        public string new_from { get; set; }
    }

    public class RootObject
    {
        public Response response { get; set; }
    }

    public class Photo
    {
        public int pid { get; set; }
        public int aid { get; set; }
        public int owner_id { get; set; }
        public int user_id { get; set; }
        public string src { get; set; }
        public string src_big { get; set; }
        public string src_small { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string text { get; set; }
        public int created { get; set; }
        public int post_id { get; set; }
        public string access_key { get; set; }
        public string src_xbig { get; set; }
        public string src_xxbig { get; set; }
        public string src_xxxbig { get; set; }
    }

    public class Link
    {
        public string url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Audio
    {
        public int aid { get; set; }
        public int owner_id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public int duration { get; set; }
        public string url { get; set; }
        public string performer { get; set; }
        public int genre { get; set; }
    }

    public class Video
    {
        public int vid { get; set; }
        public int owner_id { get; set; }
        public string title { get; set; }
        public int duration { get; set; }
        public string description { get; set; }
        public int date { get; set; }
        public int views { get; set; }
        public string image { get; set; }
        public string image_big { get; set; }
        public string image_small { get; set; }
        public string access_key { get; set; }
        public string image_xbig { get; set; }
    }

    public class Attachment
    {
        public string type { get; set; }
        public Photo photo { get; set; }
        public Link link { get; set; }
        public Audio audio { get; set; }
        public Video video { get; set; }
    }

    public class Photo2
    {
        public int pid { get; set; }
        public int aid { get; set; }
        public int owner_id { get; set; }
        public int user_id { get; set; }
        public string src { get; set; }
        public string src_big { get; set; }
        public string src_small { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string text { get; set; }
        public int created { get; set; }
        public int post_id { get; set; }
        public string access_key { get; set; }
        public string src_xbig { get; set; }
        public string src_xxbig { get; set; }
        public string src_xxxbig { get; set; }
    }

    public class Page
    {
        public string pid { get; set; }
        public int gid { get; set; }
        public string title { get; set; }
        public string view_url { get; set; }
    }

    public class Link2
    {
        public string url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image_src { get; set; }
        public string preview_page { get; set; }
        public string preview_url { get; set; }
    }

    public class Audio2
    {
        public int aid { get; set; }
        public int owner_id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public int duration { get; set; }
        public string url { get; set; }
        public string performer { get; set; }
        public string lyrics_id { get; set; }
        public int genre { get; set; }
        public string album { get; set; }
    }

    public class Video2
    {
        public int vid { get; set; }
        public int owner_id { get; set; }
        public string title { get; set; }
        public int duration { get; set; }
        public string description { get; set; }
        public int date { get; set; }
        public int views { get; set; }
        public string image { get; set; }
        public string image_big { get; set; }
        public string image_small { get; set; }
        public string access_key { get; set; }
        public string image_xbig { get; set; }
    }

    public class Doc
    {
        public int did { get; set; }
        public int owner_id { get; set; }
        public string title { get; set; }
        public int size { get; set; }
        public string ext { get; set; }
        public string url { get; set; }
        public string access_key { get; set; }
    }

    public class Attachment2
    {
        public string type { get; set; }
        public Photo2 photo { get; set; }
        public Page page { get; set; }
        public Link2 link { get; set; }
        public Audio2 audio { get; set; }
        public Video2 video { get; set; }
        public Doc doc { get; set; }
    }

    public class PostSource
    {
        public string type { get; set; }
        public string platform { get; set; }
    }

    public class Comments
    {
        public int count { get; set; }
        public int can_post { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
        public int user_likes { get; set; }
        public int can_like { get; set; }
        public int can_publish { get; set; }
    }

    public class Reposts
    {
        public int count { get; set; }
        public int user_reposted { get; set; }
    }

    public class Item
    {
        public string type { get; set; }
        public int source_id { get; set; }
        public int date { get; set; }
        public int post_id { get; set; }
        public string post_type { get; set; }
        public string text { get; set; }
        public Attachment attachment { get; set; }
        public List<Attachment2> attachments { get; set; }
        public PostSource post_source { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Reposts reposts { get; set; }
        public List<object> photos { get; set; }
        public int? signer_id { get; set; }
        public int? copy_post_date { get; set; }
        public string copy_post_type { get; set; }
        public int? copy_owner_id { get; set; }
        public int? copy_post_id { get; set; }
        public string copy_text { get; set; }
    }

    public class Profile
    {
        public int uid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int sex { get; set; }
        public string screen_name { get; set; }
        public string photo { get; set; }
        public string photo_medium_rec { get; set; }
        public int online { get; set; }
        public string online_app { get; set; }
        public int? online_mobile { get; set; }
    }

    public class Group
    {
        public int gid { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public int is_closed { get; set; }
        public string type { get; set; }
        public string photo { get; set; }
        public string photo_medium { get; set; }
        public string photo_big { get; set; }
    }
}
