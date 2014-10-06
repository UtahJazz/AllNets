namespace AllNets.Vk
{
    internal class VkHelper
    {
        public static string AuthorizationUrl
        {
            get
            {
                return "https://oauth.vk.com/authorize?client_id=4572346" +
                        "redirect_uri=http://api.vk.com/blank.html&display=wap&scope=notifications,friends,wall,messages,friends&response_type=token";
            }
        }
    }
}
