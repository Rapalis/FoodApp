namespace FoodApp.Constants
{
    public static class RouteConsts
    {
        public const string BASE_URL = "api/v1/";
        public const string PROVIDERS_ENDPOINT_URL = "Providers";
        public const string DISHES_ENDPOINT_URL = "Dishes";
        public const string REVIEWS_ENDPOINT_URL = "Reviews";
        public const string PROVIDERS_DISHES_ENDPOINT_URL = PROVIDERS_ENDPOINT_URL + "/{providerId}/" + DISHES_ENDPOINT_URL;
        public const string DISHES_REVIEWS_ENDPOINT_URL = PROVIDERS_DISHES_ENDPOINT_URL + "/{dishId}/" + REVIEWS_ENDPOINT_URL;
    }
}
