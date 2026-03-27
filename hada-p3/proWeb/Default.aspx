<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1>Products managment</h1>
<asp:Label ID="Label1" runat="server" Text="Code"></asp:Label>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<br />

<asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
<br />

<asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
<br />

    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="Computing"></asp:ListItem>
        <asp:ListItem Value="Telephony"></asp:ListItem>
        <asp:ListItem Value="Gaming"></asp:ListItem>
        <asp:ListItem Value="Home appliances"></asp:ListItem>

    </asp:DropDownList>

<br />
<asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
<br />

<asp:Label ID="Label5" runat="server" Text="Creation Date"></asp:Label>
<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
<br />

<asp:Button ID="Button1" runat="server" Text="Create" />
<asp:Button ID="Button2" runat="server" Text="Update" />
<asp:Button ID="Button3" runat="server" Text="Delete" />
<asp:Button ID="Button4" runat="server" Text="Read" />
<asp:Button ID="Button6" runat="server" Text="Read First" />
<asp:Button ID="Button7" runat="server" Text="Read Next" />

</asp:Content>
