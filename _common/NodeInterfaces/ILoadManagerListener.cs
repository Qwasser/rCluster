﻿using _common.Protocol;

namespace _common.NodeInterfaces
{
    interface ILoadManagerListener
    {
        void OnMaxLimitRetreived(int limit);
        void OnCurrentLimitRetreived(int limit);
        void OnLoadStatusRetreived(LoadStatus status);
        void OnLoadStatusChanged(LoadStatus status);

    }
}
