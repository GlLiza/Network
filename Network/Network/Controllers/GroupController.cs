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
        [Authorize(Roles = "secretary")]
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
            return View(model);
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

        public ActionResult AddToGroup()
        {
            string idAspNet = User.Identity.GetUserId();
            var user = _userService.GetUserByAspNetId(idAspNet);

            var listGroupId = _groupService.GetListOfId();
            var listGroup = _groupService.GetGroupList(listGroupId);
          

            AddtoGroup model = new AddtoGroup();
            model.groupList = listGroup;           
            model.userId = user.Id;

            return View("_AddToGroup",model);
        }

        [HttpPost]
        [Authorize(Roles = "group_member")]
        public ActionResult AddToGroup(MembersOfGroup member)
        {
            return RedirectToAction("Index", "User");

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