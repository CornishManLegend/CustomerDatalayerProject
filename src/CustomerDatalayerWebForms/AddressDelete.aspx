<%@ Page Title="Address Delete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressDelete.aspx.cs" Inherits="CustomerDatalayerWebForms.AddressDelete" %>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">
        <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">
        <p></p>
        <h2>Are you sure you want to remove address <%=Request.QueryString["addressId"] %>?</h2>
        <asp:Button class="btn btn-primary" Text="No" runat="server" OnClick="OnClickNo"/>
        <asp:Button class="btn btn-primary" Text="Remove" runat="server" OnClick="OnClickDelete"/>
    </div>
</asp:Content>
