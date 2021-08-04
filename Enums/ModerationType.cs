using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.Enums
{
    public enum ModerationType
    {
        [Description("Political propaganda")]
        Political,

        [Description("Offensive Language")]
        Language,

        [Description("Drug Reference")]
        Drugs,

        [Description("Threatening Speech")]
        Threatening,

        [Description("Sexual Content")]
        Sexual,

        [Description("Hate Speech")]
        HateSpeech,

        [Description("Targeted Shaming")]
        Shaming,

        [Description("Illegal Content")]
        IllegalContent,

        [Description("Spam")]
        Spam,
    }
}