

using System.Reflection;
using System.Runtime.Serialization;

namespace LearnBlazorV1.Types
{
    public class ButtonType
    {
        public enum Type
        {
            [EnumMember(Value = "button")]
            Button,
            [EnumMember(Value = "submit")]
            Submit,
            [EnumMember(Value = "reset")]
            Reset
        }
    }


}
