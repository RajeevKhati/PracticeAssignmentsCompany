using Company.Project.EventFacade.FacadeLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventFacade.FacadeFactory
{
    public interface IEventFacadeFactory
    {
        IEventFacade Create();
    }
}
