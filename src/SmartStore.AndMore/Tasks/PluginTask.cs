using SmartStore.Services;
using SmartStore.Services.Tasks;
using SmartStore.AndMore.Services;

namespace SmartStore.AndMore
{
    public class MyFirstTask : ITask
    {
        private readonly ICommonServices _services;
        private readonly ISmartStoreAndMoreService _smartStoreAndMoreService;

        public MyFirstTask(
            ICommonServices services,
            ISmartStoreAndMoreService smartStoreAndMoreService)
        {
            _services = services;
            _smartStoreAndMoreService = smartStoreAndMoreService;
        }

        public void Execute(TaskExecutionContext context)
        {
            // Do something
        }
    }
}