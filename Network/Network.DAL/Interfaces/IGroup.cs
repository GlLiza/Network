using Network.DAL.EFModel;
using System;
using System.Linq;

namespace Network.DAL.Interfaces
{
    public interface IGroup
    {
        void CreateGroup(Group gr);
        void EditGroup(Group gr);
        Group GetGroupById(Guid id);
        void DeleteGroup(Group gr);
        IQueryable<Guid> GetGroupsIdByHeadId(Guid id);

        IQueryable<Guid> GetMembersIdByGroup(Guid id);
        IQueryable<Guid> GetAllGroups();

        void AddMembers(MembersOfGroup member);
        void DeleteMembers(Guid id);
        IQueryable<MembersOfGroup> CheckMember(Guid userId, Guid groupId);
    }
}
