<%@ Page Title="" Language="C#" MasterPageFile="../admin.master" AutoEventWireup="true" CodeFile="tao_cau_hoi.aspx.cs" Inherits="tao_cau_hoi" %>



<asp:Content ID="Content4" ContentPlaceHolderID="title" Runat="Server">
    Quản trị Tài Khoản
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style4 {
        width: 20%;
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

    table.dataTable.no-footer {
        border-bottom: none;
    }
</style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    
    <table class="auto-style1 table table-hover table-bordered">
    <tr>
        <td class="auto-style5" colspan="2">TẠO CÂU HỎI</td>
    </tr>
    <tr>
        <td class="auto-style4">Nội dung câu hỏi: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtNoiDungCauHoi" CssClass="form-control" runat="server" style="margin-left: 0px"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">Đáp án A: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtDapAnA" runat="server" CssClass="form-control"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">Đáp án B: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtDapAnB" CssClass="form-control" runat="server" style="margin-left: 0px"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">Đáp án C: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtDapAnC" CssClass="form-control" runat="server" style="margin-left: 0px"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">Đáp án D: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtDapAnD" CssClass="form-control" runat="server" style="margin-left: 0px"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">Đáp án đúng: </td>
        <td class="auto-style3"> 
            <asp:DropDownList ID="ddlDapAnDung" runat="server" class="form-control">  
                <asp:ListItem>A</asp:ListItem>  
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>C</asp:ListItem>  
                <asp:ListItem>D</asp:ListItem>  
            </asp:DropDownList>   

        </td>
    </tr>
    <tr> 
        <td class="auto-style3 text-right" colspan="2">
            <asp:Button ID="btnTao" CssClass="btn btn-success" runat="server" Text="Tạo" OnClick="btnTao_Click" />
            <asp:Button ID="btnCapNhat" CssClass="btn btn-success" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" />
            &nbsp;<asp:Button ID="btnHuy" CssClass="btn btn-danger" runat="server" Text="Hủy" OnClick="btnHuy_Click" />
        </td>
    </tr>
</table>
    
   
<br />
   


        <asp:Literal ID="ltr_table" runat="server"></asp:Literal>

        <div class="text-right mt-3">
            <asp:Button ID="btnExportExcel" CssClass="btn btn-warning" runat="server" Text="Export Excel" OnClick="btnExportExcel_Click" />
        </div>
    </asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
    <script type='text/javascript'>
        // Basic example
        $(document).ready(function () {
            $('#example').DataTable({
                searching: true,
                paging: true,
                ordering: true,
                info: false,
                language: {
                    lengthMenu: 'Hiển thị _MENU_ bản ghi',
                    search: 'Tìm kiếm ',
                    zeroRecords: 'Không tìm thấy',
                    infoEmpty: 'Không có bản ghi nào',
                    paginate: {
                        first: 'Premier',
                        previous: 'Trước',
                        next: 'Sau',
                        last: 'Dernier'
                    },
                } // false to disable search (or any other option)
            });
        });
    </script>
</asp:Content>

