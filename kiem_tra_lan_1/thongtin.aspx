<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="thongtin.aspx.cs" Inherits="thongtin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Tên tài khoản: <asp:Label ID="lbTenTaiKhoan" runat="server" Text=""></asp:Label>
    
    <br />
    Email: <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label>
    <br />
    Hình ảnh: <asp:Label ID="lbHinhAnh" runat="server" Text=""></asp:Label>
    <br />
    Giới tính: <asp:Label ID="lbGioiTinh" runat="server" Text=""></asp:Label>
    <br />
    Trình duyệt: <asp:Label ID="lbTrinhDuyet" runat="server" Text=""></asp:Label>
    <br />
    Ip: <asp:Label ID="lbIp" runat="server" Text=""></asp:Label>
    <br />
    Hostname: <asp:Label ID="lbHostname" runat="server" Text=""></asp:Label>
    <br />
    Thời gian truy cập: <asp:Label ID="lbThoiGianTruyCap" runat="server" Text=""></asp:Label>
    <br />
</asp:Content>

