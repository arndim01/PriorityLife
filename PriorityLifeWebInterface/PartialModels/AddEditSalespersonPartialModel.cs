using Microsoft.AspNetCore.Mvc;
using PriorityLifeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.PartialModels
{
    public class AddEditSalespersonPartialModel
    {
        [BindProperty]
        public PriorityLifeAPI.BusinessObject.Salesperson Salesperson { get; set; }

        public CrudOperation Operation;
        public string ReturnUrl;

        public AddEditSalespersonPartialModel()
        {
            
        }
    }
}
