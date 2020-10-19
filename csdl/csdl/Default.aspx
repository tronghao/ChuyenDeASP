<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Username<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <br />
    Password<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    Fullname<asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btThem" runat="server" OnClick="btThem_Click" Text="Thêm" />
    <asp:Button ID="btSua" runat="server" OnClick="btSua_Click" Text="Sửa" />
    <br />
    Nhap ten<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="bttim" runat="server" OnClick="bttim_Click" Text="Tìm" />
    <br />
    <br />
    <asp:GridView CssClass="table table-condensed table-hover" ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="username" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>

