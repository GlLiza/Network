using Network.DAL.EFModel;
using System;

namespace Network.DAL.Interfaces
{
    public interface IAdvertisement
    {
        void AddAdvertisement(Advertisement item);
        void DeleteAdvertisement(Guid id);
        void UpdateAdvertisement(Advertisement id);
        Advertisement Find(Guid id);
    }
}
