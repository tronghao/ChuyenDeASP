<%@ Page Title="" Language="C#" MasterPageFile="template.master" AutoEventWireup="true" CodeFile="upload_file.aspx.cs" Inherits="upload_file" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br />
        <div style="display:flex; align-items:center">
            <span class="bold">Upload File:</span>
            <asp:FileUpload ID="file" runat="server"/>
            <asp:Button ID="btnUpload" CssClass="btn btn-primary" runat="server" OnClick="btnUpload_Click" Text="Upload" />
         </div>
        <br />
        <br />
         <div style="display:flex; align-items:center">
            <span  class="bold"> Nhập Excel: </span>
            <asp:FileUpload ID="excelUpload" runat="server" />
            <asp:Button ID="btnImport" CssClass="btn btn-warning" runat="server" Text="Import" OnClick="btnImport_Click" />
         </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Literal ID="ltr" runat="server"></asp:Literal>
            </div>
        </div>
        
    
        <asp:Button ID="btnXuatExcel" CssClass="btn btn-success" runat="server" Text="xuất excel" OnClick="btnXuatExcel_Click" />
        
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        
        
        <style>
            .bold { font-weight: bold; }
        </style>
</asp:Content>

