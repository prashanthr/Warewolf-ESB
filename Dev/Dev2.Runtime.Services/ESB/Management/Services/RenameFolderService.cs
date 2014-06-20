﻿using System;
using Dev2.Communication;
using Dev2.DynamicServices;
using Dev2.DynamicServices.Objects;
using Dev2.Interfaces;
using Dev2.Runtime.Hosting;
using Dev2.Workspaces;
using System.Collections.Generic;
using System.Text;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class RenameFolderService : IEsbManagementEndpoint
    {
        public string HandlesType()
        {
            return "RenameFolderService";
        }

        public StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            IExplorerRepositoryResult item;
            try
            {
                if(values == null)
                {
                    throw new ArgumentNullException("values");
                }
                if(theWorkspace == null)
                {
                    throw new ArgumentNullException("theWorkspace");
                }
                StringBuilder path;
                if(!values.TryGetValue("path", out path))
                {
                    throw new ArgumentException("path value not supplied.");
                }
                StringBuilder newPath;
                if(!values.TryGetValue("newPath", out newPath))
                {
                    throw new ArgumentException("newPath value not supplied.");
                }
                item = ServerExplorerRepository.Instance.RenameFolder(path.ToString(), newPath.ToString(), theWorkspace.ID);
            }
            catch(Exception e)
            {
                item = new ExplorerRepositoryResult(ExecStatus.Fail, e.Message);
            }
            var serializer = new Dev2JsonSerializer();
            return serializer.SerializeToBuilder(item);
        }

        public DynamicService CreateServiceEntry()
        {
            var findServices = new DynamicService { Name = HandlesType(), DataListSpecification = "<DataList><ResourceType ColumnIODirection=\"Input\"/><Roles ColumnIODirection=\"Input\"/><ResourceName ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>" };

            var fetchItemsAction = new ServiceAction { Name = HandlesType(), ActionType = enActionType.InvokeManagementDynamicService, SourceMethod = HandlesType() };

            findServices.Actions.Add(fetchItemsAction);

            return findServices;
        }
    }
}