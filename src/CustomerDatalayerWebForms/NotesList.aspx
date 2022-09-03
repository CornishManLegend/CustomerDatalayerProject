<%@ Page Title="Notes List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotesList.aspx.cs" Inherits="CustomerDatalayerWebForms.NotesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><%=Title %></h1>
    <table class="table">
        <thead>
            <tr>
                <th>Note ID</th>
                <th>Customer ID</th>
                <th>Note</th>
            </tr>
        </thead>
        <tbody>
            <%foreach(var note in Notes) 
                {%>
                
                    <tr>
                        <td><%=note.CustomerId%></td>
                        <td><%=note.CustomerId%></td>
                        <td><%=note.%></td>
                        <td><a class="btn btn-default" href="CustomerManage?customerId=<%=customer.CustomerId%>">Edit</a></td>
                        <td><a class="btn btn-default" href="CustomerDelete?customerId=<%=customer.CustomerId%>">Remove</a></td>

                    </tr>
                <%} %>
        </tbody>
    </table>
    <div class="text-center">
        <a runat="server" class="btn btn-success" href="~/CustomerManage">Add a New Note</a>
    </div>
</asp:Content>
