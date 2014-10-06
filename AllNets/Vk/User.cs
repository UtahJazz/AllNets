using System;
using System.Windows.Media.Imaging;

namespace AllNets.Vk
{
    public class User
    {
        public string FirstName;
        public string LastName;
        public string Photo;
        public string ScreenName;

        public string Name
        {
            get { return FirstName + " " + LastName; }
            set { FirstName = value; }
        }

        public BitmapImage Image
        {
            get
            {
                return new BitmapImage(new Uri(Photo, UriKind.Absolute));
            }
        }

        public User(string firstName, string lastName, string photo, string screenName)
        {
            FirstName = firstName;
            LastName = lastName;
            Photo = photo;
            ScreenName = screenName;
        }

        public User()
        { }
    }
}
