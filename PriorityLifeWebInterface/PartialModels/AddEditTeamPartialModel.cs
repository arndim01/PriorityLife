using Microsoft.AspNetCore.Mvc;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.PartialModels
{
    public class AddEditTeamPartialModel
    {
        [BindProperty]
        public PriorityLifeAPI.BusinessObject.Team Team { get; set; }

        public List<Salesperson> SalespersonDropDownListData;

        public CrudOperation Operation;
        public string ReturnUrl;

        public AddEditTeamPartialModel()
        {



            Console.WriteLine("test");
        }

    }
}
