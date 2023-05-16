using System.ComponentModel.DataAnnotations;

namespace TVTestAPI.Models
{
    public class MyRequest
    {
        [Required, RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.+\\w+([-.]\\w+)*")]
        public string Email { get; set; }
    }
}
