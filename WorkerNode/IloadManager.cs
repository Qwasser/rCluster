using _common;
using _common.Protocol;

namespace WorkerNode
{
    interface ILoadManager
    {
        int GetMaxLimit();

        LoadStatus GetStatus();

        void SetStatus(LoadStatus status);
    }
}
