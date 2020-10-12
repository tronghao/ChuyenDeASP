<%@ Page Title="" Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="Add_Bo_De.aspx.cs" Inherits="Add_Bo_De" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 178px;
        }
        .auto-style3 {
            width: 75px;
        }
         .auto-style4 {
             width: 75px;
             height: 22px;
         }
         .auto-style5 {
             width: 178px;
             height: 22px;
         }
         .auto-style6 {
             height: 22px;
         }
         .auto-style8 {
             width: 75px;
             height: 29px;
         }
         .auto-style9 {
             width: 178px;
             height: 29px;
         }
         .auto-style10 {
             height: 29px;
         }
         .auto-style11 {
             width: 159%
         }
         .auto-style12 {
             width: 178px;
             text-align: center;
         }
    </style>
     <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style12">
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Thêm Bộ Đề Thi" Font-Overline="True" Font-Size="Large" Font-Strikeout="True"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Mã bộ đề"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtMaBD" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label3" runat="server" Text="Tên bộ đề"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtTenBD" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <table class="auto-style11">
                        <tr>
                            <td>
                    <asp:Button ID="btn_Them" runat="server" OnClick="btn_Them_Click" Text="Thêm" />
                            </td>
                            <td>
                                <asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa" Width="51px" />
                            </td>
                            <td>
                                <asp:Button ID="btnLamMoi" runat="server" OnClick="btnLamMoi_Click" Text="Làm mới" Width="83px" />
                            </td>
                            <td>
                                <asp:Button ID="btnTim" runat="server" OnClick="btnTim_Click" Text="Tìm" Width="67px" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtTim" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style12">
                    <asp:GridView ID="gv" runat="server" Width="382px" OnRowDeleting="gv_RowDeleting" OnSelectedIndexChanged="gv_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>

