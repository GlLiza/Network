using Microsoft.AspNet.Identity;
using Network.BL.WebServices;
using Network.DAL.EFModel;
using Network.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Network.Controllers
{
    public class GroupController : Controller
    {
        

        private  GroupService _groupService;
        private  UserService _userService;

        public GroupController(GroupService groupService, UserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        // GET: Gro
        
        public ActionResult Index()
        {
            List<GroupViewModel> model = new List<GroupViewModel>();
            var idList = _groupService.GetListOfId();
            if (idList != null)
            {
                var listGroup = _groupService.GetGroupList(idList);

                foreach (var item in listGroup)
                {
                    GroupViewModel gr = new GroupViewModel();
                    gr.Id = item.Id;

                    var userHead = _userService.GetUserPersData(item.HeadId);
                    //var head = _userService.GetDataByAspUserId(userHead.Id);
                    gr.NameHead = userHead.Name;

                    gr.Number = Convert.ToInt32(item.Number);
                    gr.Specialization = item.Specialization;

                    model.Add(gr);
                }

            }

            return View(model);
        }

        [Authorize(Roles = "secretary")]
        public ActionResult CreateGroup()
        {
            var leadList = GetLead();
            var model = new CreateGroup();
            model.ListLead = leadList;
            return View("_CreateGroup",model);
        }

        [HttpPost]
        [Authorize(Roles = "secretary")]
        public ActionResult CreateGroup(CreateGroup u)
        {
            if (u != null)
            {
                Group gr = new Group
                {                    
                    HeadId = u.Head.Id,
                    Number = u.Number,
                    Specialization = u.Specialization
                };
                _groupService.AddGroup(gr);
            }
            return RedirectToAction("Index","Group");
        }
        
        public ActionResult AddToGroup(Guid id)
        {
            MembersOfGroup member = new MembersOfGroup()
            {
                GroupId = id
            };
            return View("_AddToGroup", member);
        }

        [HttpPost]
        [Authorize(Roles = "group_member")]
        public ActionResult AddToGroup(MembersOfGroup member)
        {
            if (member != null)
            {
                var curUser = User.Identity.GetUserId();
                var user = _userService.GetUserByAspNetId(curUser);
                member.MembersId = user.Id;
                var check = _groupService.CheckMemberInGroup(user.Id,member.GroupId);
                if (check)
                {
                                   
                    _groupService.AddMembersToGroup(member);
                }
                
                return RedirectToAction("Index", "Group");

            }
            else return null;


        }



        //public bool CheckBeforeAddToGroup(Guid userId, Guid groupId)
        //{
        //    var check= _groupService.CheckMemberInGroup(userId,groupId);
        //    if (check)
        //    {
        //        return true;
        //    }
        //    else return false;

        //}


        public ActionResult ListMembersOfGroup(Guid idGroup)
        {
            List<UserListViewModel> model = new List<UserListViewModel>();
            var listMembersId = _groupService.GetmembersListByGroupId(idGroup);
            var data = _userService.GetDataForListOfUser(listMembersId);

            foreach (var item in data)
            {
                UserListViewModel user = new UserListViewModel();
                user.Id = item.Id;
                user.Name = item.Name;
                user.Image = _userService.GetImageByDataId(item.Id);

                model.Add(user);
            }

            return View("_ListMembersOfGroup", model);
        }


        [Authorize(Roles = "secretary")]
        public ActionResult DeleteGroup(Guid id)
        {
            var group = _groupService.GetGroupById(id);
            return View("_Delete", group);
        }
        [Authorize(Roles = "secretary")]
        [HttpPost]
        public ActionResult DeleteGroup(Group gr)
        {
           _groupService.DeleteMembersInGroup(gr.Id);           
            _groupService.DeleteGroup(gr.Id);            
            return RedirectToAction("Index","Group");
        }

      



        /// <summary>
        /// ////
        /// </summary>
        /// <returns></returns>
        public List<SelectLeadViewModel> GetLead()
        {
            var leadList = _userService.GetLeadAll();
            if (leadList != null)
            {
                List<SelectLeadViewModel> list = new List<SelectLeadViewModel>();
                foreach (var lead in leadList)
                {
                    SelectLeadViewModel item = new SelectLeadViewModel();
                    item.Id = lead.Id;
                    item.Name = lead.Name;
                    list.Add(item);
                }
                return list;
            }
            else return null;
        }
    }
}