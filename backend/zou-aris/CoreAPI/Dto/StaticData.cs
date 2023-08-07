using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public static class StaticData
    {

        public static string AdminApi { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
