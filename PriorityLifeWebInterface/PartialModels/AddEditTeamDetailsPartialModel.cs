using Microsoft.AspNetCore.Mvc;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.PartialModels
{
    public class AddEditTeamDetailsPartialModel
    {
        [BindProperty]
        public PriorityLifeAPI.BusinessObject.TeamDetails TeamDetails { get; set; }

        public List<Team> TeamDropDownListData;
        public List<Salesperson> SalespersonDropDownListData;

        public CrudOperation Operation;
        public string ReturnUrl;

        public AddEditTeamDetailsPartialModel()
        {
        }
    }
}
