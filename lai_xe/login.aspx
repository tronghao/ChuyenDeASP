<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css">
    <link href="css/login2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="card card-login mx-auto text-center bg-dark">
            <div class="card-header mx-auto bg-dark">

                            <span class="logo_title mt-5"> Đăng nhập </span>
    <!--            <h1>--><?php //echo $message?><!--</h1>-->

            </div>
            <div class="card-body">
                   <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-user"></i></span>
                        </div>
                       <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-key"></i></span>
                        </div>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btnVeTrangChu" runat="server" Text="Về trang chủ" OnClick="Button1_Click" class="btn btn-info"/>
                        <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" class="btn btn-outline-danger float-right login_btn" OnClick="btnDangNhap_Click"/>
                    </div>

            </div>
        </div>
    </div>
    </form>
</body>
</html>
