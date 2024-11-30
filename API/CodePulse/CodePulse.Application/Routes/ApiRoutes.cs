namespace CodePulse.Application.Routes;

public static class ApiRoutes
{
    private const string Base = "api";
    private const string Version = "v1";
    private const string Root = Base + "/" + Version+"/";

    public static class Categories
    {
        private const string BaseCategoriesUrl = Root + "categories/";
        public const string List = BaseCategoriesUrl;
        public const string Single = BaseCategoriesUrl + "{id}";
        public const string Create = BaseCategoriesUrl;
        public const string Update = BaseCategoriesUrl + "{id}";
        public const string Delete = BaseCategoriesUrl + "{id}";
    }
}