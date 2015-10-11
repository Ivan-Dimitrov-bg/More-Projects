<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientsNamesAndAddress.aspx.cs" Inherits="ClientsNamesAndAddress.ClientsNamesAndAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customers Address info</title>
    <link href="SiteStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div><asp:Label ID="LabelTitle" runat="server" Text="Id Client">Enter Client ID to see information for Address List </asp:Label></div>
    
    <div>
        <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label> &nbsp 
        <asp:TextBox ID="TextBoxLabel" runat="server" Height="16px" Width="72px" CausesValidation="True"></asp:TextBox>  &nbsp 
        <asp:Button ID="ButtonSearchForID" runat="server" Text="Search" OnClick="ButtonSearchForID_Click" /> 

    </div>
    <div>
        <asp:GridView ID="GridViewCustomers" runat="server" AutoGenerateColumns="False" >

            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Client ID" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:BoundField DataField="EMail" HeaderText="E-Mail" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
            </Columns>

        </asp:GridView>

    </div>
        <div><asp:Label ID="LabelMassage" runat="server" Text=""></asp:Label></div> 

    </form>
</body>
</html>
