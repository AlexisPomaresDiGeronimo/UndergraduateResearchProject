using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Undergraduate_Aliveri_Web_App_Project.Core.Repositories;
using Undergraduate_Aliveri_Web_App_Project.Core;
using Undergraduate_Aliveri_Web_App_Project.Models;
using Undergraduate_Aliveri_Web_App_Project.Persistance.Repositories;

namespace Undergraduate_Aliveri_Web_App_Project.Persistance
{
    internal class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
            Accommondation = new AccommondationRepo(context);
            Contact = new ContactRepo(context);
            Entertainment = new EntertainmentRepo(context);
            Photo = new PhotoRepo(context);
            Post = new PostRepo(context);
            Sightseeing = new SightseeingRepo(context);
            Transportation = new TransportationRepo(context);
        }

        public IAccommondationRepo Accommondation { get; }

        public IContactRepo Contact { get; }

        public IEntertainmentRepo Entertainment { get; }

        public IPhotoRepo Photo { get; }

        public IPostRepo Post { get; }

        public ISightseeingRepo Sightseeing { get; }

        public ITransportationRepo Transportation { get; }

        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }

        int IUnitOfWork.Complete()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}