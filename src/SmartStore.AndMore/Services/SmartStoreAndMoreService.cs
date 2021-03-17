using System;
using System.Linq;
using Autofac;
using SmartStore.Core.Data;
using SmartStore.Core.Domain.Common;
using SmartStore.AndMore.Domain;
using SmartStore.Services.Catalog;
using SmartStore.Core.Events;

namespace SmartStore.AndMore.Services
{
    public partial class SmartStoreAndMoreService : ISmartStoreAndMoreService
    {
        private readonly IRepository<SmartStoreAndMoreRecord> _repository;
        private readonly IDbContext _dbContext;
        private readonly AdminAreaSettings _adminAreaSettings;
        private readonly IEventPublisher _eventPublisher;

        public SmartStoreAndMoreService(
            IRepository<SmartStoreAndMoreRecord> repository,
            IDbContext dbContext,
            AdminAreaSettings adminAreaSettings,
            IEventPublisher eventPublisher,
            IComponentContext ctx)
        {
            _repository = repository;
            _dbContext = dbContext;
            _adminAreaSettings = adminAreaSettings;
            _eventPublisher = eventPublisher;
        }

        public SmartStoreAndMoreRecord GetSmartStoreAndMoreRecord(int entityId, string entityName)
        {
            if (entityId == 0)
                return null;

            var record = new SmartStoreAndMoreRecord();

            var query =
                from x in _repository.Table
                    //where x.EntityId == entityId && x.EntityName == entityName
                select x;

            record = query.FirstOrDefault();

            return record;
        }

        public SmartStoreAndMoreRecord GetSmartStoreAndMoreRecordById(int id)
        {
            if (id == 0)
                return null;

            var record = new SmartStoreAndMoreRecord();

            var query =
                from x in _repository.Table
                where x.Id == id
                select x;

            record = query.FirstOrDefault();

            return record;
        }

        public void InsertSmartStoreAndMoreRecord(SmartStoreAndMoreRecord record)
        {
            Guard.NotNull(record, nameof(record));

            var utcNow = DateTime.UtcNow;
            record.CreatedOnUtc = utcNow;

            _repository.Insert(record);
        }

        public void UpdateSmartStoreAndMoreRecord(SmartStoreAndMoreRecord record)
        {
            Guard.NotNull(record, nameof(record));

            var utcNow = DateTime.UtcNow;
            record.UpdatedOnUtc = utcNow;

            _repository.Update(record);
        }

        public void DeleteSmartStoreAndMoreRecord(SmartStoreAndMoreRecord record)
        {
            Guard.NotNull(record, nameof(record));

            _repository.Delete(record);
        }
    }
}
