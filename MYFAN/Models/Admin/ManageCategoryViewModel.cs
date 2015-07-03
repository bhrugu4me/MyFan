using MYFAN.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class ManageCategoryViewModel
{
    private List<CategoryViewModel> _CategoryList;
    public List<CategoryViewModel> CategoryList
    {
        get
        {
            return _CategoryList;
        }
    }

    public ManageCategoryViewModel()
    {
        _CategoryList = new List<CategoryViewModel>();
    }

    public void Read()
    {
        // TO DO : Read ALL
        List<MYFAN.BusinessObjects.Category> categories = (new MYFAN.BusinessLogic.Category()).ReadAll();

        foreach (var item in categories)
        {
            CategoryViewModel vm = new CategoryViewModel();
            vm.MapFrom(item);
            _CategoryList.Add(vm);
        }

    }
}

public class CategoryViewModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int parentID { get; set; }
    public string parentName { get; set; }

    public List<SelectListItem> CategoryList
    {
        get { return (new Helper()).MapCategories(); }
    }
    public int Create()
    {
        // TO DO : Create
        MYFAN.BusinessObjects.Category bocategory = MapTo();
        return (new MYFAN.BusinessLogic.Category()).CreateUpdate(bocategory);
    }

    public bool Update()
    {
        // TO DO : Update
        MYFAN.BusinessObjects.Category bocategory = MapTo();
        return (new MYFAN.BusinessLogic.Category()).CreateUpdate(bocategory) > 0;
    }

    public void Read(int ID)
    {
        // TO DO : Read
        MYFAN.BusinessObjects.Category bocategory = (new MYFAN.BusinessLogic.Category()).Read(ID);
        MapFrom(bocategory);
    }

    public void MapFrom(MYFAN.BusinessObjects.Category category)
    {
        this.ID = category.ID;
        this.Name = category.Name;
        this.parentID = category.parentID;
        this.parentName = category.parentName;
    }
    public MYFAN.BusinessObjects.Category MapTo()
    {
        MYFAN.BusinessObjects.Category bocategory = new MYFAN.BusinessObjects.Category();
        bocategory.ID = this.ID;
        bocategory.Name = this.Name;
        bocategory.parentID = 0;
        if (this.parentID > 0)
        {
            bocategory.parentID = this.parentID;
        }        
        return bocategory;
    }
}
