<%@ Page Title="" Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container container-custom">
        <div class="row" style="display: flex;">

            
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12 mb-3">
                        <img src="https://daotaolaixelachong.vn/upload/thumb/thi-bang-lai-xe-may-a11511755868.jpg" style="width:100%; height: 200px"/>
                    </div>
                    <div class="col-md-12">
                        <div class="left">
                            <p class="title-luyen-thi">LUYỆN THI LÝ THUYẾT GPLX A1 200 CÂU</p>

                            <p>Đề thi lấy từ bộ đề thi sát hạch lý thuyết lái xe mô tô hạng A1 năm 2020 áp dụng từ 01/08/2020.</p>

                            <p>Ứng dụng tương ứng với tài liệu 200 câu hỏi luật giao thông đường bộ dùng cho học viên thi bằng lái xe máy A1.</p>

                            <p>Ứng dụng được thiết kế tương thích với mọi loại thiết bị (máy tính để bàn, laptop, máy tính bảng, điện thoại) nhằm giúp học viên dễ dàng sử dụng.</p>

                            <p>Bằng cách thực hành nhuần nhuyễn 8 đề thi, bạn sẽ vượt qua phần thi sát hạch lý thuyết một cách dễ dàng.</p>
                        </div>
                    </div>
                </div>
                
            </div>
            <div class="col-md-8 right">
                <div class="mb-4">
                    <div class="shadow-sm text-center p-3 bg-light">
			            <h4><strong class="text-success">BỘ ĐỀ THI BẰNG LÁI XE MÁY A1 2020</strong></h4>
			
			            <div class="text-primary">
				            <strong><asp:Label ID="lb_de_thi" runat="server" Text=""></asp:Label></strong>
			            </div>
                        
			            <div class="">
                            <asp:Literal ID="ltrDe" runat="server"></asp:Literal>    
			            </div>

                        <div class="">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <%--<a href='thi.aspx?bd='>
                                        <asp:Button ID="Button1<%# Eval("ten_bo_de") %>" runat="server" Text="<%# Eval("ten_bo_de") %>" OnClick="redirect(<%# Eval("ma_bo_de") %>)"/>
                                    </a>--%>
                                </ItemTemplate>
                            </asp:Repeater>
			            </div>

			            <%--<div class="text-primary">
				            <strong>20 câu hỏi các tình huống giao thông nghiêm trọng:</strong>

			            </div>
			            <div class="">
				            <button type="submit" class="btn btn-success btn-thongtin" name="chondethi" value="de00">20 câu điểm liệt</button>
			            </div>--%>
		            </div>
                </div>
                <div>
                    <div class="">	
			            <div>
				            <p><strong class="text-primary">Cấu trúc đề thi mới: áp dụng từ 01/08/2020</strong></p>
				            <ul>
					            <li>Thời gian làm bài: 19 phút.</li>
					            <li>Mỗi câu hỏi trong đề sát hạch có từ 02 đến 04 ý trả lời và chỉ có 01 ý trả lời đúng nhất.</li>
					            <li>Trong số các câu hỏi, có 01 câu trả lời sai (câu hỏi điểm liệt) sẽ bị truất quyền sát hạch.</li>
					            <li>Các câu còn lại, mỗi câu tính 01 điểm.</li>
					            <li>Kết thúc bài thi, thí sinh đạt 21/25 điểm trở lên và không sai câu hỏi điểm liệt là đạt.</li>
				            </ul>
				            <p><i><strong style="color: blue;">Lưu ý:</strong> Khi trả lời đúng tất cả các câu hỏi trong 8 đề thi thử bằng lái xe máy A1 online này, có nghĩa là bạn đã trả lời đúng và đầy đủ 200 câu hỏi dùng cho sát hạch, cấp giấy phép lái xe hạng A1 năm 2020.</i></p>
			            </div>
		            </div>
                </div>
            </div>
        </div>
    </div>


    <style>
        .left {

        }
        .left, .right {
           border: 1px solid blue;
           border-radius: 5px;
           padding: 10px;
        }
        .right {
        }

        p {
            text-align: justify;
        }

        .container-custom {
            padding-left: 0px;
        }

        .title-luyen-thi{
            color: #28a745; 
            font-weight: bold
        }

        button.btn.btn-success.btn-thongtin {
            margin-right: 5px;
        }
    </style>
</asp:Content>

