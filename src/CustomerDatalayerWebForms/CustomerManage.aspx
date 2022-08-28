<%@ Page Title="Customer manage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerManage.aspx.cs" Inherits="CustomerDatalayerWebForms.CustomerManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">
        <div class="form-group">
            <asp:Label Text="First name" runat="server"></asp:Label>
            <asp:TextBox ID="firstName" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Last name" runat="server"></asp:Label>
            <asp:TextBox ID="lastName" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Phone number" runat="server"></asp:Label>
            <asp:TextBox ID="phoneNumber" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Email" runat="server"></asp:Label>
            <asp:TextBox ID="email" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Total purchases amount" runat="server"></asp:Label>
            <asp:TextBox ID="totalPurchasesAmount" class="form-control center-block" runat="server"></asp:TextBox>
        </div>

        <div class="text-center">
            <asp:Button class="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"/>
        </div>
    </div>

</asp:Content>
