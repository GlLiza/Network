using Network.DAL.EFModel;
using System;
using System.Linq;

namespace Network.DAL.Interfaces
{
    public interface IUser
    {
        void AddUser(User item);
        void Update(User item);
        User Find(Guid id);

        IQueryable<string> GetListOfIds();
        User GetUserByAspUserId(string id);
        IQueryable<string> GetAllLeadId();
        IQueryable<string> GetAllMemberId();

        User_sPersonalData FindData(Guid id);


    }
}
