using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Undergraduate_Aliveri_Web_App_Project.Core.Repositories;

namespace Undergraduate_Aliveri_Web_App_Project.Core
{
    internal interface IUnitOfWork : IDisposable
    {
        IAccommondationRepo Accommondation { get; }
        IContactRepo Contact { get; }
        IEntertainmentRepo Entertainment { get; }
        IPhotoRepo Photo { get; }
        IPostRepo Post { get; }
        ISightseeingRepo Sightseeing { get; }
        ITransportationRepo Transportation { get; }
        int Complete();
    }
}
