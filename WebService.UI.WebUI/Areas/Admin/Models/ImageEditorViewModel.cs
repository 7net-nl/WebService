using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.UI.WebUI.Areas.Admin.Models
{
    public class ImageEditorViewModel
    {
        public List<string> Images { get; set; }
        public short CurrentPage { get; set; } = 1;
        public short CountOnpage { get; set; } = 12;
        public short TotalPage { get; set; } = 1;
    }
}
