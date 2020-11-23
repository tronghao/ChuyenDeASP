<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="them_de_thi.aspx.cs" Inherits="admin_them_de_thi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Quản lý đề thi
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
    </style>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <div class="row">
        <div class="col-md-4 offset-2 col-md-4-custom card">
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
        dragula([document.querySelector('#left'), document.querySelector('#right')], {
            accepts: function (el, target, source, sibling) {
                return true;
            },
        });
    </script>
</asp:Content>

