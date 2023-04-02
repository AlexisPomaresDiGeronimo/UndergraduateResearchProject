using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Undergraduate_Aliveri_Web_App_Project.Core.Repositories;
using Undergraduate_Aliveri_Web_App_Project.Models;

namespace Undergraduate_Aliveri_Web_App_Project.Persistance.Repositories
{
    public class ContactRepo : GenericRepository<Contact>, IContactRepo
    {
        public ContactRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}