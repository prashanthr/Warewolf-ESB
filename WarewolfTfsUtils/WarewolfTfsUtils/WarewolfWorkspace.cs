﻿using System;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System.Text;

namespace WarewolfTfsUtils
{
    public class WarewolfWorkspace
    {

        public string FetchWorkspace(string server, string project, string workspaceName, string workingDirectory)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder("<TfsResult>");

            Workspace workspace = null;

            try
            {

                TeamFoundationServer tfs = TeamFoundationServerFactory.GetServer(server);

                tfs.EnsureAuthenticated();

                VersionControlServer vcs = (VersionControlServer)tfs.GetService(typeof(VersionControlServer));

                // clean up ;)
                Workspace[] workspaces = vcs.QueryWorkspaces(workspaceName, vcs.AuthenticatedUser, Workstation.Current.Name);
                if (workspaces.Length > 0)
                {
                    vcs.DeleteWorkspace(workspaceName, vcs.AuthenticatedUser);
                }

                workspace = vcs.CreateWorkspace(workspaceName, vcs.AuthenticatedUser, "Temporary Workspace");

                workspace.Map(project, workingDirectory);
                GetRequest request = new GetRequest(new ItemSpec(project, RecursionType.Full), VersionSpec.Latest);
                GetStatus status = workspace.Get(request, GetOptions.GetAll | GetOptions.Overwrite);
                    // this line doesn't do anything - no failures or errors
                foreach (var s in status.GetFailures())
                {
                    sb.Append("<TfsStatusMsg>" + s.Message + "</TfsStatusMsg>");
                }

                if (status.GetFailures().Length == 0)
                {
                    sb.Append("<TfsStatusMsg>Ok</TfsStatusMsg>");
                }
            }
            catch (Exception e)
            {
                sb.Append("<TfsStatusMsg>" + e.Message + "</TfsStatusMsg>");
            }
            finally
            {
                if (workspace != null)
                {
                    workspace.Delete();
                    
                }
            }


            sb.Append("</TfsResult>");

            return sb.ToString();
        }

    }
}
