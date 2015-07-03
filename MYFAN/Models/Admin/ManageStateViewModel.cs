using MYFAN.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class ManageStateViewModel
{
    private List<StateViewModel> _StateList;
    public List<StateViewModel> StateList
    {
        get
        {
            return _StateList;
        }
    }

    public ManageStateViewModel()
    {
        _StateList = new List<StateViewModel>();
    }

    public void Read()
    {
        // TO DO : Read ALL
        List<MYFAN.BusinessObjects.State> categories = (new MYFAN.BusinessLogic.State()).ReadAll();

        foreach (var item in categories)
        {
            StateViewModel vm = new StateViewModel();
            vm.MapFrom(item);
            _StateList.Add(vm);
        }
    }
}

public class StateViewModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Abbr { get; set; }

    public int CountryID { get; set; }
    public string ContryName { get; set; }

    public List<SelectListItem> CountryLIst
    {
        get { return (new Helper()).MapContries(); }
    }
    public int Create()
    {
        // TO DO
        MYFAN.BusinessObjects.State boState = MapToState();
        return (new MYFAN.BusinessLogic.State()).CreateUpdate(boState);
    }

    public bool Update()
    {
        // TO DO
        MYFAN.BusinessObjects.State boState = MapToState();
        return (new MYFAN.BusinessLogic.State()).CreateUpdate(boState) > 0;
    }

    public void Read(int ID)
    {
        MYFAN.BusinessObjects.State boState = (new MYFAN.BusinessLogic.State()).Read(ID);
        MapFrom(boState);
    }

    public MYFAN.BusinessObjects.State MapToState()
    {
        MYFAN.BusinessObjects.State stateItem = new MYFAN.BusinessObjects.State();
        stateItem.Name = this.Name;
        stateItem.ID = this.ID;
        stateItem.Abbr = this.Abbr;
        stateItem.Updated_By = "0";
        stateItem.Created_By = "0";
        stateItem.Country = new MYFAN.BusinessObjects.Country() { Name = this.ContryName, ID = this.CountryID };
        return stateItem;
    }

    public void MapFrom(MYFAN.BusinessObjects.State stateItem)
    {
        this.Name = stateItem.Name;
        this.ID = stateItem.ID;
        this.Abbr = stateItem.Abbr;
        this.ContryName = stateItem.Country.Name;
        this.CountryID = stateItem.Country.ID;
    }


}

