<%@ Page Title="" Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="tao_tai_khoan.aspx.cs" Inherits="tao_tai_khoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style4 {
        width: 10%;
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
    
    .btn-success {
        color: #fff !important;
        background-color: #28a745 !important;
        border-color: #28a745 !important;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <table class="auto-style1 table table-hover">
    <tr>
        <td class="auto-style5" colspan="2">TẠO TÀI KHOẢN</td>
    </tr>
    <tr>
        <td class="auto-style4">Tên tài khoản: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtTenTaiKhoan" CssClass="form-control" runat="server" style="margin-left: 0px"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">Mật khẩu: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">
            &nbsp;</td>
        <td class="auto-style3 text-right">
            <asp:Button ID="btnTao" CssClass="btn btn-success" runat="server" Text="Tạo" OnClick="btnTao_Click" />
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

