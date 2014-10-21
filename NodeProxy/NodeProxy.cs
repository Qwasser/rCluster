using System;
using System.Collections.Generic;
using _common.NodeInterfaces;
using _common.Protocol;
using _common.Protocol.Request;
using _common.Protocol.Response;
using _common.SocketConnection;

namespace NodeProxy
{
    public class NodeProxy : IWorkerManagerListener, ILibraryManagerListener, ISystemInfoListener, ILoadManagerListener, INodeConnectionObserver
    {
        private readonly INodeConnection _nodeConnection;
        
        private readonly IAsyncLibraryManager _asyncLibraryManager;
        
        private readonly IAsyncLoadManager _asyncLoadManager;
        
        private readonly IAsyncSystemInfo _asyncSystemInfo;
        
        private readonly IAsyncWorkerManager _asyncWorkerManager;

        private readonly NodeProxyConfiguration _configuration;

        private List<INodeProxyListener> _listeners; 

        public NodeProxy(INodeConnection nodeConnection, IRequestSender sender, NodeProxyConfiguration configuration)
        {
            _nodeConnection = nodeConnection;
            _nodeConnection.SetResponseHandler(new MasterNodeContext(this, this, this, this));
            _nodeConnection.AddObserver(this);
            _configuration = configuration;
            _asyncLibraryManager = new RemoteLibraryManager(sender);
            _asyncLoadManager = new RemoteLoadManager(sender);
            _asyncSystemInfo = new RemoteSystemInfo(sender);
            _asyncWorkerManager = new RemoteWorkerManager(sender);

            _listeners = new List<INodeProxyListener>();
        }

        public void Connect()
        {
            _nodeConnection.Connect(_configuration.Ip, _configuration.Port);
        }

        public void Disconnect()
        {
            _nodeConnection.Disconnect();
        }

        public void OnWorkersCountRetreived(int count)
        {
            foreach (var listener in _listeners)
            {
                listener.OnWorkersCountRetreived(count);
            }
        }

        public void OnWorkerManagerError(string error)
        {
            foreach (var listener in _listeners)
            {
                listener.OnWorkerManagerError(error);
            }
        }

        public void OnRedisIpRetrived(string ip)
        {
            throw new NotImplementedException();
        }

        public void OnWorkersLoadRetreived(float load)
        {
            foreach (var listener in _listeners)
            {
                listener.OnWorkersLoadRetreived(load);
            }
        }

        public void OnWorkersMemoryRetreived(float memory)
        {
            foreach (var listener in _listeners)
            {
                listener.OnWorkersMemoryRetreived(memory);
            }
        }

        public void OnLibraryListRetreived(List<string> libraryList)
        {
            throw new NotImplementedException();
        }

        public void OnHasLibrary(string libraryName, bool hasLibrary)
        {
            throw new NotImplementedException();
        }

        public void OnLibraryInstalled(string libraryName)
        {
            throw new NotImplementedException();
        }

        public void OnLibraryManagerError(string msg)
        {
            
        }

        public void OnTotalMemoryRetreived(float memory)
        {
            foreach (var listener in _listeners)
            {
                listener.OnTotalMemoryRetreived(memory);
            }
        }

        public void OnTotalLoadRetreived(float load)
        {
            foreach (var listener in _listeners)
            {
                listener.OnTotalLoadRetreived(load);
            }
        }

        public void OnWorkersMaxLimitRetreived(int limit)
        {
            foreach (var listener in _listeners)
            {
                listener.OnWorkersMaxLimitRetreived(limit);
            }
        }

        public void OnWorkersCurrentLimitRetreived(int limit)
        {
            foreach (var listener in _listeners)
            {
                listener.OnWorkersCurrentLimitRetreived(limit);
            }
        }

        public void OnLoadStatusRetreived(LoadStatus status)
        {
            foreach (var listener in _listeners)
            {
                listener.OnLoadStatusRetreived(status);
            }
        }

        public void OnLoadStatusChanged(LoadStatus status)
        {
            foreach (var listener in _listeners)
            {
                listener.OnLoadStatusChanged(status);
            }
        }

        public void OnConnectionError()
        {
            foreach (var listener in _listeners)
            {
                listener.OnConnectionError();
            }
        }

        public void OnDisconnected()
        {
            foreach (var listener in _listeners)
            {
                listener.OnDisconnected();
            }
        }

        public void OnConnected()
        {
            foreach (var listener in _listeners)
            {
                listener.OnConnected();
            }

 
            _asyncLoadManager.GetMaxLimit();

            _asyncWorkerManager.GetWorkersCount();

            _asyncLoadManager.GetStatus();

            _asyncSystemInfo.GetSystemMemory();
            _asyncSystemInfo.GetSystemLoad();
            _asyncWorkerManager.GetWorkersLoad();
            _asyncWorkerManager.GetWorkersMemory();

        }

        public void OnConnecting()
        {
            foreach (var listener in _listeners)
            {
                listener.OnConnecting();
            }
        }

        public void AddListener(INodeProxyListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(INodeProxyListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
