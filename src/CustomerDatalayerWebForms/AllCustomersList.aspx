<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllCustomersList.aspx.cs" Inherits="CustomerDatalayerWebForms.AllCustomersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><%=Title %></h1>
    <table class="table">
        <thead>
            <tr>
                <th>Customer ID</th>
                <th>First name</th>
                <th>Last name</th>
                <th>Phone number</th>
                <th>Email</th>
                <th>Total Purchases Amount</th>
            </tr>
        </thead>
        <tbody>
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
                        <td><asp:Button class="btn btn-danger" Text="Delete" runat="server" OnClick="OnClickDelete"/></td>
                    </tr>
                <%} %>
        </tbody>
    </table>
    <div class="text-center">
        <a runat="server" class="btn btn-success" href="~/CustomerManage">Add new customer</a>
    </div>
</asp:Content>
