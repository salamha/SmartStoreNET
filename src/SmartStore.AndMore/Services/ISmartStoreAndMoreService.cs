using SmartStore.AndMore.Domain;

namespace SmartStore.AndMore.Services
{
    public partial interface ISmartStoreAndMoreService
    {
        SmartStoreAndMoreRecord GetSmartStoreAndMoreRecord(int entityId, string entityName);
        SmartStoreAndMoreRecord GetSmartStoreAndMoreRecordById(int id);
        void InsertSmartStoreAndMoreRecord(SmartStoreAndMoreRecord record);
        void UpdateSmartStoreAndMoreRecord(SmartStoreAndMoreRecord record);
        void DeleteSmartStoreAndMoreRecord(SmartStoreAndMoreRecord record);
    }
}
