<%@ Page Title="Customer Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerManage.aspx.cs" Inherits="CustomerDatalayerWebForms.CustomerManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">
        <div class="form-group">
            <asp:Label Text="First name" runat="server"></asp:Label>
            <asp:TextBox ID="firstName" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="firstName" ErrorMessage="The length of the first name can be from 3 to 50 characters" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{0,50}$">
            </asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Last name" runat="server"></asp:Label>
            <asp:TextBox ID="lastName" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Last Name can not be blank" ControlToValidate="lastName" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="lastName" ErrorMessage="The length of the last name can be from 3 to 50 characters" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{0,50}$">
            </asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Phone number" runat="server"></asp:Label>
            <asp:TextBox ID="phoneNumber" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="phoneNumber" ErrorMessage="Incorrect the phone number format" ForeColor="Red" ValidationExpression="^[1-9]\d{14,14}$">
            </asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Email" runat="server"></asp:Label>
            <asp:TextBox ID="email" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="email" ErrorMessage="Incorrect the email format" ForeColor="Red" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$">
            </asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Total purchases amount" runat="server"></asp:Label>
            <asp:TextBox ID="totalPurchasesAmount" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="totalPurchasesAmount" ErrorMessage="The value cannot be negative" ForeColor="Red" ValidationExpression="[\+]?[0-9]*(\.[0-9]+)?">
            </asp:RegularExpressionValidator>
        </div>

        <div class="text-center">
            <asp:Button class="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"/>
        </div>
    </div>

</asp:Content>
