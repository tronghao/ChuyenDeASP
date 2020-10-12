<%@ Page Title="" Language="C#" MasterPageFile="./common.master" AutoEventWireup="true" CodeFile="tao_tai_khoan.aspx.cs" Inherits="tao_tai_khoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 24%;
    }
    .auto-style3 {
        width: 122px;
    }
    .auto-style4 {
    }
    .auto-style5 {
        text-align: center;
    }
    body {
        width: 100%;
        margin: 5px;
    }

    .table-condensed tr th {
        border: 0px solid #6e7bd9;
        color: white;
        background-color: #6e7bd9;
    }

    .table-condensed, .table-condensed tr td {
        border: 0px solid #000;
    }

    tr:nth-child(even) {
        background: #f8f7ff
    }

    tr:nth-child(odd) {
        background: #fff;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style5" colspan="2">TẠO TÀI KHOẢN</td>
    </tr>
    <tr>
        <td class="auto-style4">Tên tài khoản: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtTenTaiKhoan" runat="server" style="margin-left: 0px"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">Mật khẩu: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtMatKhau" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">
            &nbsp;</td>
        <td class="auto-style3">
    <asp:Button ID="btnTao" runat="server" Text="Tạo" OnClick="btnTao_Click" />
        &nbsp;<asp:Button ID="btnTim" runat="server" OnClick="btnTim_Click" Text="Tìm" />
            <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" />
&nbsp;<asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" />
        </td>
    </tr>
</table>
<br />
    <asp:GridView ID="gvUser" runat="server" UseAccessibleHeader="true" CssClass="table table-condensed table-hover" OnRowDeleting="gvUser_RowDeleting" OnSelectedIndexChanged="gvUser_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lbKetQuaTim" runat="server" Text="Kết quả tìm"></asp:Label>
    <asp:GridView ID="gvTim" runat="server">
    </asp:GridView>
<br />
    </asp:Content>

