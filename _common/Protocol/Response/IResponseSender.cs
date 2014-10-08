﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public interface IResponseSender
    {
        void SendResponse(AbstractResponseClusterMessage response);
    }
}
