<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllCustomersList.aspx.cs" Inherits="CustomerDatalayerWebForms.AllCustomersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table class="table">
        <tr>
            <th>Customer ID</th>
            <th>First name</th>
            <th>Last name</th>
            <th>Phone number</th>
            <th>Email</th>
            <th>Total Purchases Amount</th>
        </tr>
        <%foreach(var customer in Customers) 
            {%>
                
                <tr>
                    <td><%=customer.CustomerId%></td>
                    <td><%=customer.FirstName%></td>
                    <td><%=customer.LastName%></td>
                    <td><%=customer.PhoneNumber%></td>
                    <td><%=customer.Email%></td>
                    <td><%=customer.TotalPurchasesAmount%></td>
                    <td><a class="btn btn-default" href="CustomerManage?customerId=<%=customer.CustomerId%>">Edit</a></td>
                </tr>
            <%} %>
    </table>
</asp:Content>
