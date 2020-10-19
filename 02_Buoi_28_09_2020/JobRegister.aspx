<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/template.master" CodeFile="JobRegister.aspx.cs" Inherits="JobRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
    .title-before-content {
        background-color: #666;
        color: #fff;
    }

    .title-form {
        font-weight: bold;
        font-size: 20px;
        margin: 10px 0;
    }

    .mt-2 {
        margin-top: 10px;
    }

    .mb-2 {
        margin-bottom: 10px;
    }

    .mb-5 {
        margin-bottom: 25px;
    }

    .resize-none {
        resize: none;
    }
</style>

   <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12 text-center title-form"> ĐĂNG KÝ THÔNG TIN VIỆC LÀM</div>
        </div>

        <div class="row">
            <div class="col-sm-12 title-before-content">
                Thông tin cá nhân
            </div>
            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        * Họ & tên:
                    </div>

                    <div class="col-sm-4">
                        <asp:TextBox ID="txtHoVaTen" runat="server" Width="100%"></asp:TextBox>
                       
                    </div>
                    <div class="col-sm-5">
                         <asp:RequiredFieldValidator ID="RequiredHoVaTen" runat="server" ErrorMessage="RequiredFieldValidator" Text="Nhập họ và tên" ControlToValidate="txtHoVaTen" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            
            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        * Ngày tháng năm sinh:
                    </div>

                    <div class="col-sm-4">
                        <asp:TextBox ID="txtNgaySinh" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-5">
                        <asp:RequiredFieldValidator ID="RequiredNgaySinh" runat="server" ErrorMessage="RequiredFieldValidator" Text="Nhập ngày sinh" ControlToValidate="txtNgaySinh" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                </div>
            </div>

            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        Giới tính:
                    </div>

                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddl_gioi_tinh" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-sm-12 mt-2 mb-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        Tình trạng hôn nhân:
                    </div>

                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddl_tinh_trang_hon_nhan" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

         <div class="row">
            <div class="col-sm-12 title-before-content">
                Thông tin liên lạc
            </div>
            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        * Địa chỉ:
                    </div>

                    <div class="col-sm-7">
                        <asp:TextBox ID="txtDiaChi" runat="server" Width="500px" ControlToValidate="txtDiaChi"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:RequiredFieldValidator ID="RequiredDiaChi" runat="server" ErrorMessage="RequiredFieldValidator" Text="Nhập địa chỉ" ControlToValidate="txtNgaySinh" ForeColor="Red" Visible="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            
            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        *Tỉnh/Thành Phố:
                    </div>

                    <div class="col-sm-3">
                        <asp:TextBox ID="txtTinhThanhPho" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="RequiredTinhThanhPho" runat="server" ErrorMessage="RequiredFieldValidator" Text="Nhập tỉnh/thành phố" ControlToValidate="txtTinhThanhPho" ForeColor="Red" Visible="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        Số điện thoại:
                    </div>

                    <div class="col-sm-4">
                        <asp:TextBox ID="txtSDT" runat="server"></asp:TextBox>
                    </div>
                     <div class="col-sm-3">
                         <asp:RegularExpressionValidator ID="RegularExpressionSDT" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtSDT" Text="Nhập sai định dạng" ForeColor="Red" ValidationExpression="((09|03|07|08|05)+([0-9]{8})\b)"></asp:RegularExpressionValidator>
                     </div>
                </div>
            </div>

            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        Số điện thoại di động:
                    </div>

                    <div class="col-sm-4">
                        <asp:TextBox ID="txtSDTDiDong" runat="server" ControlToValidate="txtSDTDiDong"></asp:TextBox>
                    </div>

                    <div class="col-sm-3">
                         <asp:RegularExpressionValidator ID="RegularExpressionSDTDiDong" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtSDTDiDong" Text="Nhập sai định dạng" ForeColor="Red" ValidationExpression="((09|03|07|08|05)+([0-9]{8})\b)"></asp:RegularExpressionValidator>
                     </div>
                </div>
            </div>

            <div class="col-sm-12 mt-2 mb-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        *Email:
                    </div>

                    <div class="col-sm-6">
                        <asp:TextBox ID="txtEmail" runat="server" Width="371px" ControlToValidate="txtEmail"></asp:TextBox>
                    </div>

                    <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ErrorMessage="RequiredFieldValidator" Text="Nhập email" ControlToValidate="txtEmail" ForeColor="Red" Visible="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularEmailText" runat="server" ErrorMessage="RegularExpressionValidator" Text="Nhập đúng định dạng email" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-sm-12 title-before-content">
                Trình độ học vấn
            </div>
            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        * Trình độ học vấn:
                    </div>

                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddl_trinh_do_hoc_van" runat="server">
                        </asp:DropDownList>
                    </div>

                </div>
            </div>
            
            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        *Thông tin về học vấn:
                    </div>

                    <div class="col-sm-6">
                        <asp:TextBox ID="txtThongTinHocVan" CssClass="resize-none" runat="server" Rows="2" TextMode="MultiLine" Width="433px"></asp:TextBox>
                    </div>

                     <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="RequiredThongTinHocVan" runat="server" ErrorMessage="RequiredFieldValidator" Text="Nhập thông tin học vấn" ControlToValidate="txtThongTinHocVan" ForeColor="Red" Visible="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        Ngoại ngữ:
                    </div>

                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox12" CssClass="resize-none" runat="server" TextMode="MultiLine" Width="433px"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-sm-12 mt-2 mb-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        Kỹ năng:
                    </div>

                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox13" CssClass="resize-none" runat="server" TextMode="MultiLine" Width="433px"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12 title-before-content">
                Kinh nghiệm làm việc
            </div>
            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        Số năm kinh nghiệm:
                    </div>

                    <div class="col-sm-4">
                        <asp:TextBox ID="txtSoNamKinhNghiem" runat="server" ControlToValidate="txtSoNamKinhNghiem"></asp:TextBox>
                    </div>

                    <div class="col-sm-3">
                         <asp:RegularExpressionValidator ID="RegularExpressionSoNamKinhNghiem" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtSoNamKinhNghiem" Text="Nhập sai định dạng" ForeColor="Red" ValidationExpression="^\d$"></asp:RegularExpressionValidator>
                     </div>
                </div>
            </div>
            
            <div class="col-sm-12 mt-2 mb-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        Kinh nghiệm làm việc:
                    </div>

                    <div class="col-sm-2">
                        <asp:TextBox ID="TextBox15" CssClass="resize-none" runat="server" TextMode="MultiLine" Width="433px"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12 title-before-content">
                Mong muốn của bản thân
            </div>
            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        Việc làm mong muốn:
                    </div>

                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox16" CssClass="resize-none" runat="server" TextMode="MultiLine" Width="433px"></asp:TextBox>
                    </div>
                </div>
            </div>
            
            <div class="col-sm-12 mt-2">
                <div class="row">
                    <div class="col-sm-3 text-right">
                        * Mức lương thỏa thuận:
                    </div>

                    <div class="col-sm-3">
                        <asp:TextBox ID="txtMucLuong" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-sm-1 text-left">VNĐ</div>
                    <div class="col-sm-5">
                        <asp:RequiredFieldValidator ID="RequiredMucLuong" runat="server" ErrorMessage="RequiredFieldValidator" Text="Nhập mức lương" ControlToValidate="txtMucLuong" ForeColor="Red" Visible="True"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionMucLuong" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtMucLuong" Text="Nhập sai định dạng" ForeColor="Red" ValidationExpression="^\d$"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>

            <div class="col-sm-12 mt-2 mb-5">
                <div class="row">
                    <div class="col-sm-7 col-sm-offset-3">
                        <asp:Button ID="Button1" runat="server" Text="Gửi hồ sơ" />
                        <asp:Button ID="Button2" runat="server" Text="Xóa Form" />
                    </div>
                </div>
            </div>
        </div>
    </div>
 
</asp:Content>
