<%@ Page Title="" Language="C#" MasterPageFile="../admin.master" AutoEventWireup="true" CodeFile="tao_tai_khoan.aspx.cs" Inherits="tao_tai_khoan" %>



<asp:Content ID="Content4" ContentPlaceHolderID="title" Runat="Server">
    Quản trị tài khoản
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="title_bar" Runat="Server">
    Quản trị tài khoản
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="nav" Runat="Server">
    <li>
        <a class="nav-link" href="index.aspx">
            <i class="nc-icon nc-chart-pie-35" aria-hidden="true"></i>
            <p>Dashboard</p>
        </a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="tao_tai_khoan.aspx">
            <i class="fa fa-user-o" aria-hidden="true"></i>
            <p>Tài khoản</p>
        </a>
    </li>
    <li >
        <a class="nav-link" href="tao_bo_de.aspx">
            <i class="nc-icon nc-paper-2"></i>
            <p>Bộ đề</p>
        </a>
    </li>
    <li>
        <a class="nav-link" href="tao_cau_hoi.aspx">
            <i class="nc-icon nc-notes"></i>
            <p>Câu hỏi</p>
        </a>
    </li>
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
        <td class="auto-style4">Họ tên: </td>
        <td class="auto-style3"> <asp:TextBox ID="txtHoTen" CssClass="form-control" runat="server" style="margin-left: 0px"></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="auto-style4">Giới tính: </td>
        <td class="auto-style3"> 
            <asp:DropDownList ID="ddlGioiTinh" runat="server" class="form-control">  
                <asp:ListItem>Nam</asp:ListItem>  
                <asp:ListItem>Nữ</asp:ListItem>  
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

