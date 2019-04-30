using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CRMaster.Models
{
    public enum MenuItemType
    {
        Oportunidades,
        Sobre
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
