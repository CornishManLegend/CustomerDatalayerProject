<%@ Page Title="Note Delete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoteDelete.aspx.cs" Inherits="CustomerDatalayerWebForms.NoteDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">
        <p></p>
        <h2>Are you sure you want to remove the note?</h2>
        <asp:Button class="btn btn-primary" Text="No" runat="server" OnClick="OnClickNo"/>
        <asp:Button class="btn btn-primary" Text="Remove" runat="server" OnClick="OnClickDelete"/>
    </div>
</asp:Content>
