﻿using System;
using System.Collections.Generic;
using Dev2.Common;
using Dev2.Data.Settings;
using Dev2.DynamicServices;
using Dev2.Workspaces;

namespace Dev2.Runtime.ESB.Management.Services
{
    /// <summary>
    /// Checks a users permissions on the local file system
    /// </summary>
    public class SettingsRead : IEsbManagementEndpoint
    {
        public string Execute(IDictionary<string, string> values, IWorkspace theWorkspace)
        {
            var settings = new Settings();
            try
            {
                var securityRead = new SecurityRead();
                securityRead.Execute(values, theWorkspace);
                settings.Security = securityRead.Permissions;

            }
            catch(Exception ex)
            {
                ServerLogger.LogError(ex);
                settings.HasError = true;
                settings.Error = "Error writing settings configuration : " + ex.Message;
            }

            return settings.ToString();
        }

        public DynamicService CreateServiceEntry()
        {
            var dynamicService = new DynamicService
            {
                Name = HandlesType(),
                DataListSpecification = "<DataList><Settings/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>"
            };

            var serviceAction = new ServiceAction
            {
                Name = HandlesType(),
                ActionType = enActionType.InvokeManagementDynamicService,
                SourceMethod = HandlesType()
            };

            dynamicService.Actions.Add(serviceAction);

            return dynamicService;
        }

        public string HandlesType()
        {
            return "SettingsReadService";
        }
    }
}