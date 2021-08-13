using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.Enums
{
    public enum ReadyStatus
    {
        Incomplete,

        [Display(Name = "Preview ONLY")]
        PreviewOnly,

        [Display(Name = "Production Ready")]
        ProductionReady,
    }
}