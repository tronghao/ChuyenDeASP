<%@ Page Title="" Language="C#" MasterPageFile="./template.master" AutoEventWireup="true" CodeFile="them_cau_hoi.aspx.cs" Inherits="them_cau_hoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 139px;
    }
    .auto-style3 {
        height: 23px;
        text-align: center;
    }
    .auto-style4 {
        width: 139px;
        height: 23px;
    }
    .auto-style5 {
        height: 23px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="auto-style1">
    <tr>
        <td class="auto-style3" colspan="2">THÊM CÂU HỎI</td>
    </tr>
    <tr>
        <td class="auto-style4">Nội dung:</td>
        <td class="auto-style5">
            <asp:TextBox ID="txtND" runat="server" Height="41px" TextMode="MultiLine" Width="363px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Đáp án A:</td>
        <td>
            <asp:TextBox ID="txtA" runat="server" Height="21px" Width="363px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Đáp án B:</td>
        <td>
            <asp:TextBox ID="txtB" runat="server" Height="22px" Width="363px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Đáp án C:</td>
        <td>
            <asp:TextBox ID="txtC" runat="server" Height="23px" Width="363px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Đáp án D:</td>
        <td>
            <asp:TextBox ID="txtD" runat="server" Height="25px" Width="363px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">Đáp án Đúng</td>
        <td class="auto-style5">
            <asp:TextBox ID="txtDapAnDung" runat="server" Height="17px" Width="363px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>

    <br />
    <asp:GridView ID="gvData" runat="server">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

</asp:Content>

