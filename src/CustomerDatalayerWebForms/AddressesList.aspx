<%@ Page Title="Addresses List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressesList.aspx.cs" Inherits="CustomerDatalayerWebForms.AddressesList" %>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><%=Title %></h1>
    <table class="table">
        <thead>
            <tr>
                <th>Address ID</th>
                <th>Customer ID</th>
                <th>Address Line1</th>
                <th>Address Line2</th>
                <th>Address Type</th>
                <th>City</th>
                <th>Postal Code</th>
                <th>State</th>
                <th>Country</th>
            </tr>
        </thead>
        <tbody>
            <%foreach(var address in Addresses) 
                {%>
                    <tr>
                        <td><%=address.AddressId%></td>
                        <td><%=address.CustomerId%></td>
                        <td><%=address.AddressLine1%></td>
                        <td><%=address.AddressLine2%></td>
                        <td><%=address.AddressType%></td>
                        <td><%=address.City%></td>
                        <td><%=address.PostalCode%></td>
                        <td><%=address.AddrState%></td>
                        <td><%=address.Country%></td>
                        <td><a class="btn btn-default" href="AddressEdit?addressId=<%=address.AddressId%>">Edit</a></td>
                        <td><a class="btn btn-default" href="AddressDelete?addressId=<%=address.AddressId%>">Remove</a></td>
                    </tr>
                <%} %>
        </tbody>
    </table>
    <div class="text-center">
        <a runat="server" class="btn btn-success" href="~/AddressManage">Add a New Address</a>
    </div>
</asp:Content>
