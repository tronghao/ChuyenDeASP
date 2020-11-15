<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload_file.aspx.cs" Inherits="upload_file" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        File upload:
        <asp:FileUpload ID="file" runat="server" />
        <br />
        <asp:Button ID="btnUpload" CssClass="btn btn-primary" runat="server" OnClick="btnUpload_Click" Text="Upload" />
        <br />
        <br />
        <asp:Literal ID="ltr" runat="server"></asp:Literal>
    
        <asp:Button ID="btnXuatExcel" CssClass="btn btn-success" runat="server" Text="xuất excel" OnClick="btnXuatExcel_Click" />
    
        <br />
        <br />
        Import excel
        <asp:FileUpload ID="excelUpload" runat="server" />
        <br />
        <asp:Button ID="btnImport" CssClass="btn btn-warning" runat="server" Text="Import" OnClick="btnImport_Click" />
    
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
