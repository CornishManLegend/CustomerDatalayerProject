<%@ Page Title="Notes List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotesList.aspx.cs" Inherits="CustomerDatalayerWebForms.NotesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><%=Title %></h1>
    <table class="table">
        <thead>
            <tr>
                <th>Note</th>
                <th>Note Edit</th>
                <th>Note Remove</th>
            </tr>
        </thead>
        <tbody>
            <%foreach(var note in Notes) 
                {%>
                    <tr>
                        <td><%=note.NoteRecord%></td>
                        <td><a class="btn btn-default" href="NoteEdit?customerId=<%=note.CustomerId %>&noteId=<%=note.NoteId%>">Edit</a></td>
                        <td><a class="btn btn-default" href="NoteDelete?customerId=<%=note.CustomerId %>&noteId=<%=note.NoteId%>">Remove</a></td>
                    </tr>
                <%} %>
        </tbody>
    </table>
    <div class="text-center">
        <a runat="server" class="btn btn-success" href="/">Back to Customers List</a>
        <asp:Button Text="Add a New Note" runat="server" class="btn btn-success" OnClick="OnClickAddNote" />
    </div>
</asp:Content>
