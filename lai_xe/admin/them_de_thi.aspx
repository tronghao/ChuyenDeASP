<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="them_de_thi.aspx.cs" Inherits="admin_them_de_thi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Quản lý đề thi
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="title_bar" Runat="Server">
    Quản lý đề thi
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="nav" Runat="Server">
    <li>
        <a class="nav-link" href="index.aspx">
            <i class="nc-icon nc-chart-pie-35" aria-hidden="true"></i>
            <p>Dashboard</p>
        </a>
    </li>
    <li>
        <a class="nav-link" href="tao_tai_khoan.aspx">
            <i class="fa fa-user-o" aria-hidden="true"></i>
            <p>Tài khoản</p>
        </a>
    </li>
    <li>
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


<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/dragula/3.7.2/dragula.min.css" rel="stylesheet" />
    
    <style>
        .col-md-4-custom {
            margin-right: 10px;
        }

        .color-white {
            color: white;
            font-weight: 700;
            margin-top: -19px;
        }
        .item {
            border: 1px solid #ccc;
            border-radius: 30px;
            padding: 10px;
            background-color: #f7f7f8;
            margin-bottom: 10px;
        }

        .jc-center { justify-content:center; }
    </style>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <div class="row jc-center">
        <div class="col-md-4 col-md-4-custom card">
            <div class="card-header bg-primary text-center color-white">Câu hỏi</div>
            <div class="card-body">
                <div id="left" class="container">
                    <div class="item bg-warning text-center">Không kéo item này</div>
                    <asp:Literal ID="ltrCauHoi" runat="server"></asp:Literal>
                 </div>
            </div>
            
        </div>
       <div class="col-md-4 col-md-4-custom card">
           <div class="card-header bg-primary text-center color-white">Bộ đề: </div>
            <div class="card-body">
                <div id="right" class="container">
                    <div class="item bg-warning text-center">Không kéo item này</div>
                    <asp:Literal ID="ltr_bode" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="footer" Runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/dragula/3.7.2/dragula.min.js"></script>
    <script>
        var drake = dragula([document.querySelector('#left'), document.querySelector('#right')], {
            accepts: function (el, target, source, sibling) {
                return true;
            },
        });


        drake.on('dragend', function (el) {
            let url = document.URL;
            let urlSplit = url.split("?id=");
            
            let idBoDe = urlSplit[1];
            console.log(idBoDe);
            let containerRight = drake.containers[1].childNodes;
            let ids = "";
            containerRight.forEach( (item) => { 
                if(item.className == "item") {
                    let text = item.innerHTML;
                    let arrSplitText = text.split(")");
                    console.log(arrSplitText);
                    ids += arrSplitText[0] + ",";
                }
            });
            console.log(ids);
            $.ajax({
                type: 'get',  //chỉnh phương thức cho phù hợp
                url: 'http://localhost:1439/admin/them_de_thi.aspx?ids='+ ids + '&idBD=' + idBoDe, //Link tới Route cần lấy dữ liệu
                success:function(data){
                    if(data.success == "false")
                        alert("Lỗi API");
                }
            });
            //let containerRight = drake.containers[1].childNodes;
            //containerRight.forEach( (item) => { 
            //    if(item.className == "item") 
            //        //console.log(item.innerHTML); 
            //});
        });

        
    </script>
</asp:Content>

