<%@ Page Title="Address Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressManage.aspx.cs" Inherits="CustomerDatalayerWebForms.AddressManage" %>
<asp:Content ID="Content7" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">

        <div class="form-group">
            <asp:Label Text="Customer ID" runat="server"></asp:Label>
            <asp:DropDownList ID="customerId" class="form-control center-block" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label Text="Address Line1" runat="server"></asp:Label>
            <asp:TextBox ID="addressLine1" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Address Line1 can not be blank" ControlToValidate="addressLine1" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="addressLine1" ErrorMessage="The length of Address Line1 cannot be more than 100 characters" ForeColor="Red" ValidationExpression="^.{0,100}$">
            </asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label Text="Address Line2" runat="server"></asp:Label>
            <asp:TextBox ID="addressLine2" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="addressLine2" ErrorMessage="The length of Address Line2 cannot be more than 100 characters" ForeColor="Red" ValidationExpression="^.{0,100}$">
            </asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label Text="Address Type" runat="server"></asp:Label>
            <asp:DropDownList ID="addressType" class="form-control center-block" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label Text="City" runat="server"></asp:Label>
            <asp:TextBox ID="city" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field City can not be blank" ControlToValidate="city" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="city" ErrorMessage="The length of City name cannot be more than 50 characters" ForeColor="Red" ValidationExpression="^.{0,50}$">
            </asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label Text="Postal Code" runat="server"></asp:Label>
            <asp:TextBox ID="postalCode" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Postal Code can not be blank" ControlToValidate="postalCode" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="postalCode" ErrorMessage="The Postal Code cannot be longer than 6 characters. Only integers." ForeColor="Red" ValidationExpression="^[0-9]{0,6}$">
            </asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label Text="State" runat="server"></asp:Label>
            <asp:TextBox ID="state" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field State can not be blank" ControlToValidate="state" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="state" ErrorMessage="The State name cannot be longer than 20 characters." ForeColor="Red" ValidationExpression="^.{0,20}$">
            </asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label Text="Country" runat="server"></asp:Label>
            <asp:TextBox ID="country" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Country can not be blank" ControlToValidate="country" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="country" ErrorMessage="The Country name can be either USA or Canada" ForeColor="Red" ValidationExpression="^(USA|Canada)$">
            </asp:RegularExpressionValidator>
        </div>

        <div class="text-center">
            <asp:Button class="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"/>
            <a class="btn btn-primary" href="/AddressesList.aspx">Cancel</a>
        </div>
    </div>
</asp:Content>
