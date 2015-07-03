using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum eNavigationArea
{
    City,
    State,
    AreaOFCity,
    Category,
    Country,
    AuthType
}
public class NevigationViewModel
{
    public eNavigationArea Area { get; set; }
    public String IsSelected(eNavigationArea NavigationArea)
    {
        if (this.Area == NavigationArea)
        {
            return "active";
        }
        else
        {
            return "";
        }
    }

    public NevigationViewModel(eNavigationArea area)
    {
        Area = area;
    }

}
