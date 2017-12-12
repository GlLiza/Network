using Network.DAL.EFModel;
using Network.DAL.Interfaces;
using Network.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Network.BL.WebServices
{
    public class GroupService
    {
        private readonly IGroup _groupRepository;


        public GroupService()     {        }

        public GroupService(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        
        public void AddGroup(Group gr)
        {
            if (gr != null)
            {
                gr.Id = Guid.NewGuid();
                _groupRepository.CreateGroup(gr);
            }
        }

        public void DeleteGroup(Guid id)
        {
            if (id != null)
            {
                var gr = _groupRepository.GetGroupById(id);
                if (gr != null)
                {
                    _groupRepository.DeleteGroup(gr);
                }                
            }
        }

        public void EditGroup(Guid id)
        {
            if (id != null)
            {
                var gr = _groupRepository.GetGroupById(id);
                if (gr != null)
                {
                    _groupRepository.EditGroup(gr);
                }
            }           
        }

        public List<Group> GetGroupsForHead(Guid headId)
        {
            if (headId != null)
            {
                var groupIdList = _groupRepository.GetGroupsIdByHeadId(headId);
                if (groupIdList != null)
                {
                    var groupList = GetGroupList(groupIdList);
                }
            }
            return null;
        }

        public IQueryable<Guid> GetListOfId()
        {
            var list = _groupRepository.GetAllGroups();
            return list;
        }
        public List<Group> GetGroupList(IQueryable<Guid> listId)
        {
            List<Group> list = new List<Group>();
            if (listId != null)
            {
                foreach (var id in listId)
                {
                    var item = _groupRepository.GetGroupById(id);
                    list.Add(item);
                }
            }
            return list;         

        }



        public void AddMembersToGroup(MembersOfGroup member)
        {
            if (member != null)
            {
                member.Id = Guid.NewGuid();
                _groupRepository.AddMembers(member);
            }
        }

        public void RemoveMembers(MembersOfGroup member)
        {
            if (member != null)
            {
                _groupRepository.DeleteMembers(member.Id);
            }
        }

        public IQueryable<Guid> GetmembersListByGroupId(Guid id)
        {
            if (id != null)
            {
                var gr = _groupRepository.GetGroupById(id);
                if (gr != null)
                {
                    var listId = _groupRepository.GetMembersIdByGroup(gr.Id);
                    return listId;
                }
            }
            return null;
        }

    }
}
