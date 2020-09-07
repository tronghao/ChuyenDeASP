<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cộng 2 số</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Nhập a:"></asp:Label>
        <asp:TextBox ID="txtA" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nhập b: "></asp:Label>
        <asp:TextBox ID="txtB" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cộng" />
&nbsp;<asp:Button ID="btnTru" runat="server" OnClick="btnTru_Click" Text="Trừ" />
&nbsp;<asp:Button ID="btnNhan" runat="server" OnClick="btnNhan_Click" Text="Nhân" />
&nbsp;<asp:Button ID="btnChia" runat="server" OnClick="btnChia_Click" Text="Chia" />
    </div>
        <br />
        <asp:Label ID="lbKQ" runat="server"></asp:Label>
    </form>
</body>
</html>
