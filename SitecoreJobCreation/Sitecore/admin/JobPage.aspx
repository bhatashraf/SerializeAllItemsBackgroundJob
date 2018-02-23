<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobPage.aspx.cs" Inherits="SitecoreJobCreation.Sitecore.admin.JobPage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jobs</title>
</head>
<body>
    <%--   <form id="form1" runat="server">
    <div>

    </div>
    </form>--%>
    <div>
        Administrative Tool:
    </div>
    <div>
        Job status:
    </div>
    <div>
        <ul>
            <li>
                <span>Total Jobs:</span>
                <asp:Label runat="server" ID="TotalNumberOfJobs" />
            </li>
            <li>
                <span>Total number of running jobs: </span>
                <asp:Label runat="server" ID="TotalNumberOfRunningJobs" />
            </li>
            <li>
                <span>Total number fo queued jobs: </span>
                <asp:Label runat="server" ID="TotalNumberOfQueuedJobs" />
            </li>
            <li>
                <span>Total number of finished jobs</span>
                <asp:Label runat="server" ID="TotalNumberOfFinishedJobs" />
            </li>
        </ul>
    </div>
    <div>
        <span>Running Jobs:</span>
        <asp:Repeater ID="rptRunningJobs" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>
                            <span> Job Title </span>
                        </th>
                        <th>
                            <span> Priority </span>
                        </th>
                        <th>
                            <span> Progress </span>
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="RunningJobsTitle" Text='<%#Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="RunningJobPriority" Text='<%# Eval("Priority") %>' />
                    </td>
                     <td>
                        <asp:Label runat="server" ID="RunningJobProgress" Text='<%# Eval("Progress") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        </div>
        <div>
            <span>Finished Jobs</span>
            <asp:Repeater ID="rptFinishedJobs" runat="server">
                <HeaderTemplate>
                    <table>  
                        <tr>
                            <th>
                                <span> Title </span>
                            </th>
                            <th>
                                <span> Priority </span>
                            </th>
                            <th>
                                <span> Progress </span>
                            </th>
                        </tr>                 
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                             <asp:Label runat="server" ID="FinishedJobTitle" Text='<%#Eval("Title") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Label runat="server" ID="RunningJobPriority" Text='<%# Eval("Priority") %>' />
                        </td>
                    </tr>
                     <tr>
                        <td>
                             <asp:Label runat="server" ID="RunningJobProgress" Text='<%# Eval("Progress") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                     </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
         <div>
            <span>Queued Jobs</span>
            <asp:Repeater ID="rptQueuedJobs" runat="server">
                <HeaderTemplate>
                    <table>  
                        <tr>
                            <th>
                                <span> Title </span>
                            </th>
                            <th>
                                <span> Priority </span>
                            </th>
                            <th>
                                <span> Progress </span>
                            </th>
                        </tr>                 
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                             <asp:Label runat="server" ID="QueuedJobTitle" Text='<%#Eval("Title") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Label runat="server" ID="QueuedJobPriority" Text='<%# Eval("Priority") %>' />
                        </td>
                    </tr>
                     <tr>
                        <td>
                             <asp:Label runat="server" ID="QueuedJobProgress" Text='<%# Eval("Progress") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                     </table>
                </FooterTemplate>
            </asp:Repeater>
    </div>
</body>
</html>
