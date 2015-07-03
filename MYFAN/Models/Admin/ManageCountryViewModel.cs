using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class ManageCountryViewModel
{
    private List<CountryViewModel> _CountryList;
    public List<CountryViewModel> CountryList
    {
        get
        {
            return _CountryList;
        }
    }

    public ManageCountryViewModel()
    {
        _CountryList = new List<CountryViewModel>();
    }

    public void Read()
    {
        // TO DO : Read ALL
        List<MYFAN.BusinessObjects.Country> categories = (new MYFAN.BusinessLogic.Country()).ReadAll();

        foreach (var item in categories)
        {
            CountryViewModel vm = new CountryViewModel();
            vm.MapFrom(item);
            _CountryList.Add(vm);
        }
    }
}
public class CountryViewModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Icon { get; set; }
    public MYFAN.BusinessObjects.Country MapToCountry()
    {
        MYFAN.BusinessObjects.Country countryItem = new MYFAN.BusinessObjects.Country();
        countryItem.Name = this.Name;
        countryItem.ID = this.ID;
        countryItem.Image = this.Image;
        countryItem.Icon = this.Icon;
        countryItem.Created_By = "0";
        countryItem.Updated_By = "0";
        return countryItem;
    }
    public void MapFrom(MYFAN.BusinessObjects.Country countryItem)
    {
        this.Name = countryItem.Name;
        this.ID = countryItem.ID;
        this.Icon = countryItem.Icon;
        this.Image = countryItem.Image;
    }

    internal int Create()
    {
          MYFAN.BusinessObjects.Country boCountry = MapToCountry();
          return (new MYFAN.BusinessLogic.Country()).CreateUpdate(boCountry);
    }

    internal void Read(int id)
    {
        MYFAN.BusinessObjects.Country boCounty = (new MYFAN.BusinessLogic.Country()).Read(id);
        MapFrom(boCounty);
    }

    internal bool Update()
    {
        MYFAN.BusinessObjects.Country boCountry = MapToCountry();
        return (new MYFAN.BusinessLogic.Country()).CreateUpdate(boCountry) > 0;
    }
}