<%@ Page Title="Note Editing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoteEdit.aspx.cs" Inherits="CustomerDatalayerWebForms.NoteEdit" %>
<asp:Content ID="Content9" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">

        <div class="form-group">
            <asp:Label Text="Customer ID" runat="server"></asp:Label>
            <asp:TextBox ID="customerId" class="form-control center-block" runat="server" disabled="disabled"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="noteLabel" Text="Note:" runat="server"></asp:Label>
            <asp:TextBox ID="noteText" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Note Text can not be blank" ControlToValidate="noteText" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="noteText" ErrorMessage="The length of the Note Text cannot be more than 255 characters" ForeColor="Red" ValidationExpression="^{0,255}$">
            </asp:RegularExpressionValidator>
        </div>

        <asp:Button class="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"/>
        <a class="btn btn-primary" href="/NotesList?customerId=<%=Request.QueryString["customerId"] %>">Cancel</a>

    </div>
</asp:Content>
