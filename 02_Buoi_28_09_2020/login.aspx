<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .row.pad-20 {
            padding: 20px;
        }
    </style>
    <div class="row pad-20">

        <asp:Label ID="Label1" runat="server" Text="Tên đăng nhập: "></asp:Label>
        <asp:TextBox ID="txtTenDangNhap" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Mật khẩu: "></asp:Label>
        <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" CssClass="btn btn-primary" OnClick="btnDangNhap_Click"/>

    </div>
</asp:Content>

