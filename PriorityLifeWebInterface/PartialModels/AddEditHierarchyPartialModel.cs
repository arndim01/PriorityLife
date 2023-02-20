using Microsoft.AspNetCore.Mvc;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.PartialModels
{
    public class AddEditHierarchyPartialModel
    {
        [BindProperty]
        public PriorityLifeAPI.BusinessObject.Hierarchy Hierarchy { get; set; }

        public List<Salesperson> SalespersonDropDownListData;

        public CrudOperation Operation;
        public string ReturnUrl;

        public AddEditHierarchyPartialModel()
        {


        }
    }
}
