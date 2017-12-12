using Network.DAL.Interfaces;
using Network.DAL.Repositories;
using System;
using Network.DAL.EFModel;
using System.Web;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Network.BL.WebServices
{
    public class UserService 
    {
        private readonly IUser _userRepository;
        private readonly IUser_sContact _contactRepository;
        private readonly IUser_sPersonalData _persDataRepository;
        private readonly IImage _imgRepository;
        private readonly IAducation _aducationRepository;


        public UserService(UserRepository researcherRepository,User_sContactRepository contactRepository,
            User_sPersonalDataRepository persDataRepository, ImageRepository imgRepository, AducationRepository aducationRepository)
        {
            _userRepository = researcherRepository;
            _contactRepository = contactRepository;
            _persDataRepository = persDataRepository;
            _imgRepository = imgRepository;
            _aducationRepository = aducationRepository;
        }

        public void AddImage(Image img)
        {
            if (img!=null)
            {
                img.Id = Guid.NewGuid();
                _imgRepository.AddImage(img);
            }
            
        }

        public void AddPersData(User_sPersonalData data)
        {
            if (data != null)
            {
                data.Id = Guid.NewGuid();
                _persDataRepository.AddData(data);
            }
        }

        public void AddContact(User_sContact contact)
        {
            if (contact != null)
            {
                contact.Id = Guid.NewGuid();
                _contactRepository.AddContact(contact);
            }
               
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                user.Id = Guid.NewGuid();
                _userRepository.AddUser(user);
            }

        }

        public byte[] СonvertingImg(HttpPostedFileBase img)
        {
            byte[] imageData = null;

            if (img != null)
            {
                using (var binaryReader = new BinaryReader(img.InputStream))
                {
                    imageData = binaryReader.ReadBytes(img.ContentLength);
                }
            }
            return imageData;
        }

        public IQueryable<string> GetUsersIdWithoutCurrent(string id)
        {

            if (id != null)
            {
                var list = _userRepository.GetListOfIds();
                var res=list.Where(f=>f!=id);
                return res;
            }
            return null;

        }

        public User_sPersonalData GetDataByAspUserId(string id)
        {
            if (id != null)
            {
                var user = _userRepository.GetUserByAspUserId(id);
                if (user != null)
                {
                    var data = _persDataRepository.Find(user.PersonalDataId);
                    return data;
                }
            }
            return null;
        }

        public List<User_sPersonalData> GetDataForListOfUser(IQueryable<Guid> list)
        {
            List<User_sPersonalData> result = new List<User_sPersonalData>();

            if (list != null)
            {
                foreach (var id in list)
                {
                    var itemUser = _userRepository.Find(id);
                    var itemPersonalData = _persDataRepository.Find(itemUser.PersonalDataId);
                    result.Add(itemPersonalData);
                }
            }
            return result;
        }

        public List<User_sPersonalData> GetDataForListOfUserByAspId(IQueryable<string> list)
        {
            List<User_sPersonalData> result = new List<User_sPersonalData>();

            if (list != null)
            {
                foreach (var id in list)
                {
                    var itemUser = _userRepository.GetUserByAspUserId(id);
                    var itemPersonalData = _persDataRepository.Find(itemUser.PersonalDataId);
                    result.Add(itemPersonalData);
                }
            }
            return result;
        }



        public byte[] GetImageByDataId(Guid id)
        {
            if (id != null)
            {
                var data = _persDataRepository.Find(id);
                if (data != null)
                {
                    var img=_imgRepository.FindImg(data.ImageId);
                    return img.Image1;
                }
            }
            return null;
        }

        public void AddAducation(Aducation aducation)
        {
            if (aducation != null)
            {
                aducation.Id = Guid.NewGuid();
                _aducationRepository.AddAducation(aducation);
            }
        }

        public User GetUserById(Guid id)
        {
            if (id != null)
            {
                var user = _userRepository.Find(id);
                return user;
            }
            else return null;
        }

        public User_sPersonalData GetUserPersData(Guid id)
        {
            if (id != null)
            {
                var user = _userRepository.FindData(id);
                return user;
            }
            else return null;
        }

        public List<User_sPersonalData> GetLeadAll()
        {
            var listId=_userRepository.GetAllLeadId();
            if (listId != null)
            {
                var listUser = GetDataForListOfUserByAspId(listId);
                return listUser;
            }
            else return null;        
        }

        public List<User_sPersonalData> GetGroupMemberAll()
        {
            var listId = _userRepository.GetAllMemberId();
            if (listId != null)
            {
                var listUser = GetDataForListOfUserByAspId(listId);
                return listUser;
            }
            else return null;

        }

       


    }
}
