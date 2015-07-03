using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class ManageCityViewModel
{
    private List<CityViewModel> _CityList;
    public List<CityViewModel> CityList
    {
        get
        {
            return _CityList;
        }
    }

    public ManageCityViewModel()
    {
        _CityList = new List<CityViewModel>();
    }

    public void Read()
    {
        // TO DO : Read ALL
        List<MYFAN.BusinessObjects.City> categories = (new MYFAN.BusinessLogic.City()).ReadAll();

        foreach (var item in categories)
        {
            CityViewModel vm = new CityViewModel();
            vm.MapFrom(item);
            _CityList.Add(vm);
        }
    }
}
public class CityViewModel
{
    public int ID { get; set; }
    public string Name { get; set; }

    public int StateID { get; set; }
    public string StateName { get; set; }

    public List<SelectListItem> StateLIst
    {
        get { return (new Helper()).MapSates(); }
    }
    public int Create()
    {
        // TO DO
        MYFAN.BusinessObjects.City boCity = MapToCity();
        return (new MYFAN.BusinessLogic.City()).CreateUpdate(boCity);
    }

    public bool Update()
    {
        // TO DO
        MYFAN.BusinessObjects.City boState = MapToCity();
        return (new MYFAN.BusinessLogic.City()).CreateUpdate(boState) > 0;
    }

    public void Read(int ID)
    {
        MYFAN.BusinessObjects.City boState = (new MYFAN.BusinessLogic.City()).Read(ID);
        MapFrom(boState);
    }

    public MYFAN.BusinessObjects.City MapToCity()
    {
        MYFAN.BusinessObjects.City cityItem = new MYFAN.BusinessObjects.City();
        cityItem.Name = this.Name;
        cityItem.ID = this.ID;
        cityItem.Created_By = "0";
        cityItem.Updated_By = "0";
        cityItem.State = new MYFAN.BusinessObjects.State() { Name = this.StateName, ID = this.StateID };
        return cityItem;
    }

    public void MapFrom(MYFAN.BusinessObjects.City cityItem)
    {
        this.Name = cityItem.Name;
        this.ID = cityItem.ID;
        this.StateName = cityItem.State.Name;
        this.StateID = cityItem.State.ID;
    }
}