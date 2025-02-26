namespace web.Utility
{
    public class SD
    {
        public static string? CouponApiBase { get; set; }
        public static string? AuthApiBase { get; set; }
        public static string? ProductApiBase {get ; set;}

    public const string TokenCookies = "JwtToken";
        
        public enum ApiTypes
        {

            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
