<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/template.master" CodeFile="min_n.aspx.cs" Inherits="min_n" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 20px">
    
        <asp:Label ID="Label1" runat="server" Text="Nhập n:"></asp:Label>
&nbsp;<asp:TextBox ID="txtN" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnTinh" runat="server" OnClick="btnTinh_Click" Text="Tính" />
        <br />
        <br />
        <asp:Label ID="lbKQ" runat="server"></asp:Label>

    </div>
</asp:Content>
