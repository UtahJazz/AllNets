using TweetSharp;

namespace AllNets.Twitter
{
    static class TwitterHelper
    {
        public static TwitterService Authentication()
        {
            var service = new TwitterService(ApiKey, ApiSecret);
            service.AuthenticateWith(AccessToken, AccessTokenSecret);
            return service;
        }

        private const string ApiKey = "YUmrkjSluxOOWdTRAcB9EK6dj";
        private const string ApiSecret = "zkfFZ1zjjnV1KsXbiXKgLxInCWToq9W2q6Lga78z5aHk8wgjyF";
        private const string AccessTokenSecret = "fKE9vGh2Vp9qgk6vtuId3E3UeMYqFu3FrLW5bU8pbEYhf";
        private const string AccessToken = "2478894750-9gIfzNehB4DVUJwTu1s9bvOVcPTA6pDNZkAm0WR";

    }
}
