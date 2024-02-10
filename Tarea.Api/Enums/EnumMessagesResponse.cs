using System.ComponentModel;

namespace Tarea.Api.Enums
{
    public class EnumMessagesResponse
    {
        public enum EnumResponse
        {
            [Description("Ok")]
            Ok = 200,

            [Description("No Content")]
            NoContent = 204,

            [Description("Internal Server Error")]
            Err = 500
        }
    }

}
