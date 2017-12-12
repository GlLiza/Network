﻿using Network.DAL.Interfaces;
using System;
using Network.DAL.EFModel;
using System.Linq;

namespace Network.DAL.Repositories
{
    public class GroupRepository : RepositoryBase, IGroup
    {
        public GroupRepository(InstitutNetworkContext context) : base(context) { }

   

        public void AddMembers(MembersOfGroup member)
        {
            _context.MembersOfGroup.Add(member);
            base.Save();
        }

        public void CreateGroup(Group gr)
        {
            _context.Group.Add(gr);
            base.Save();
        }

        public void DeleteGroup(Group gr)
        {
            _context.Group.Remove(gr);
            base.Save();
        }

        public void DeleteMembers(Guid id)
        {
            var member = _context.MembersOfGroup.Find(id);
            _context.MembersOfGroup.Remove(member);
            base.Save();

        }

        public void EditGroup(Group gr)
        {
            var group = _context.Group.Find(gr.Id);
            _context.Entry(group).CurrentValues.SetValues(gr);
            base.Save();
        }

        public Group GetGroupById(Guid id)
        {
            return _context.Group.Find(id);
        }

        public IQueryable<Guid> GetAllGroups()
        {
            return _context.Group.Select(x=>x.Id);
        }

        public IQueryable<Guid> GetGroupsIdByHeadId(Guid id)
        {
            var list=_context.Group.Where(s => s.HeadId == id).Select(s => s.Id);
            return list;
        }

        public IQueryable<Guid> GetMembersIdByGroup(Guid id)
        {
            var list = _context.MembersOfGroup.Where(s => s.GroupId == id).Select(s => s.MembersId);
            return list;
        }

    }
}