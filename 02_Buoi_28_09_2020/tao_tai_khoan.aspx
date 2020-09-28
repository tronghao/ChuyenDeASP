<%@ Page Title="" Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="tao_tai_khoan.aspx.cs" Inherits="tao_tai_khoan" %>

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
    <asp:Button ID="btnTao" runat="server" Text="Tạo" OnClick="btnTao_Click" />
        </td>
        <td class="auto-style3">&nbsp;</td>
    </tr>
</table>
<br />
    <asp:GridView ID="gvUser" runat="server">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
<br />
    </asp:Content>

