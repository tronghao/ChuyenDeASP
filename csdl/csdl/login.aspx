<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btLogin" runat="server" OnClick="btLogin_Click" Text="Button" />
    <br />
</asp:Content>

