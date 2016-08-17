
<%@ Page Title="Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="WebApplication1.Employee" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div>
               <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

        </div>
        <asp:Panel runat="server" ID="pnlForm">

        <div>
            <table border="0">
                <tr>
                    <td>
                        <asp:Label ID="lblEmployeeId" runat="server" Text="Employee Id"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeId" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmployeeId" runat="server" ErrorMessage="Employee Id Required" ControlToValidate="txtEmployeeId" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" Text="FirstName"></asp:Label><span style="color: red">*</span></td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSalary" runat="server" Text="Salary"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblDEpt" runat="server" Text="Department"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDept" runat="server"></asp:TextBox></td>
                </tr>


                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnUpdate_3" runat="server" Text="Update_3" OnClick="btnUpdate_3_Click" />
                      
                        <asp:Button ID="btnSave_3" runat="server" Text="SAve_3" OnClick="btnSave_3_Click" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>

                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">
                     


                    </td>
                </tr>



            </table>
        </div>

        </asp:Panel>


  <asp:Panel runat="server" ID="pnlGrid">
      <asp:Button runat="server" Text="Add new" ID="btnAddNew" OnClick="btnAddNew_Click"  />
         <div class="GridviewDiv">
            <asp:GridView runat="server" ID="gvEmployee" ShowFooter="true" PageSize="6" AutoGenerateColumns="false"
              AllowPaging="true" OnPageIndexChanging="gvEmployee_PageIndexChanging" PagerSettings-Mode="Numeric" 
                DataKeyNames="EmpId" 
                >
             
                

                <HeaderStyle CssClass="headerstyle" />
                <Columns>
                   
                     <asp:BoundField DataField="EmpId" HeaderText="Emp Id" ReadOnly="true" />
                     <asp:BoundField DataField="EmpFirstName" HeaderText="First Name" ReadOnly="true" />
                     <asp:BoundField DataField="EmpLastName" HeaderText="Last Name" ReadOnly="true" />
                     <asp:BoundField DataField="Salary" HeaderText="Salary" ReadOnly="true" />
                     <asp:BoundField DataField="DeptId" HeaderText="Dept Id" ReadOnly="true" />



                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkView" OnClick="lnkView_Click">View </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkEdit" OnClick="lnkEdit_Click">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkDelete" OnClick="lnkDelete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
 </asp:Panel>
    </asp:Content>
