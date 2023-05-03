using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Undergraduate_Aliveri_Web_App_Project.Core.Repositories;
using Undergraduate_Aliveri_Web_App_Project.Models;

namespace Undergraduate_Aliveri_Web_App_Project.Persistance.Repositories
{
    public class AccommodationRepo : GenericRepository<Accommodation>, IAccommodationRepo
    {
        public AccommodationRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
}