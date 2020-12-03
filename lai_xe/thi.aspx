<%@ Page Title="" Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="thi.aspx.cs" Inherits="thi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/bxslider/4.2.12/jquery.bxslider.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/bxslider/4.2.12/jquery.bxslider.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/easytimer@1.1.1/src/easytimer.min.js"></script>
    <style>

        .nd-cau-hoi, .cau-hoi, .thoi-gian, .ket-thuc-bai-thi, .footer {
              border: 1px solid #007bff;
              margin-bottom: 10px;
              border-radius: 5px;
        }

        .cau-hoi { 
            padding: 20px;
            text-align: center;
        }

        .cau-hoi .block-button {
            margin-bottom: 5px;
        }

        .btn-item-number {
            width: 40px;
            margin: 0 3px;
        }

        .thoi-gian {
            text-align: center;
            padding: 10px;
        }

        .thoi-gian .thoi-gian-con-lai {
           font-weight: bold;
           color: #0000ff;
           height: auto;
        }


        .ket-thuc-bai-thi {
            text-align: center;
            padding: 10px;
        }

        .nd-cau-hoi {
            padding: 20px;
        }

        .nd-cau-hoi .title-cau-hoi {
            font-weight: bold;
            color: #0000ff;
            height: auto;
            margin-bottom: 5px;
        }

        .nd-cau-hoi .noi-dung-cau-hoi {
            font-weight: bold;
        }

        .footer {
            text-align: center;
            padding: 10px;
            width: 100%;
            margin-left: 15px;
            margin-right: 15px;
            color: #28a745;
            font-weight: bold;
        }



        .bx-pager.bx-default-pager {
            display: none;
        }

        .bx-wrapper {
            margin-bottom: 50px;
            padding: 10px;
        }

        .bx-wrapper .bx-controls-direction a {
            top: 109%;
        }

        .bx-viewport {
            height:auto !important;
        }

        #ket-thuc {
            font-weight:bold;
            color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-md-4">
            <div class="cau-hoi">
                <p><b>Câu hỏi</b></p>
                <asp:Literal ID="ltrBtnCauHoi" runat="server"></asp:Literal>
                <%--<div class="block-button">
                    <button class="btn btn-success btn-item-number" >1</button>
                    <button class="btn btn-success btn-item-number" >2</button>
                    <button class="btn btn-success btn-item-number" >3</button>
                    <button class="btn btn-success btn-item-number" >4</button>
                    <button class="btn btn-success btn-item-number" >5</button>
                 </div>
                <div class="block-button">
                    <button class="btn btn-success btn-item-number" >6</button>
                    <button class="btn btn-success btn-item-number" >7</button>
                    <button class="btn btn-success btn-item-number" >8</button>
                    <button class="btn btn-success btn-item-number" >9</button>
                    <button class="btn btn-success btn-item-number" >10</button>
                 </div>
                <div class="block-button">
                    <button class="btn btn-success btn-item-number" >1</button>
                    <button class="btn btn-success btn-item-number" >2</button>
                    <button class="btn btn-success btn-item-number" >3</button>
                    <button class="btn btn-success btn-item-number" >4</button>
                    <button class="btn btn-success btn-item-number" >5</button>
                 </div>
                <div class="block-button">
                    <button class="btn btn-success btn-item-number" >6</button>
                    <button class="btn btn-success btn-item-number" >7</button>
                    <button class="btn btn-success btn-item-number" >8</button>
                    <button class="btn btn-success btn-item-number" >9</button>
                    <button class="btn btn-success btn-item-number" >10</button>
                 </div>--%>
            </div>
            <div class="thoi-gian">
                <span class="thoi-gian-con-lai">Thời gian còn lại: <span id="timer-down">123</span></span>
            </div>
            <div class="ket-thuc-bai-thi">
                <button id="btn-ket-thuc" type="button" class="btn btn-primary" onclick="ketThucBaiThi()">KẾT THÚC BÀI THI</button>
                <span id="ket-thuc"></span>
            </div>
        </div>
        <div class="col-md-8">
            <div class="nd-cau-hoi">
                <div class="slider">
                    <asp:Literal ID="ltrNDCH" runat="server"></asp:Literal>
                    
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="footer">
            LÁI XE AN TOÀN
        </div>
    </div>

    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <script>

        $(document).ready(function(){
            var bxslider = $('.slider').bxSlider({
                touchEnabled: false,
                oneToOneTouch: false
            });

            JumpToSlide = function (slideNumber) {

                var slide = slideNumber - 1;

                bxslider.goToSlide(slide);

            };
        });

        var timer = new Timer();
        timer.start({ countdown: true, startValues: { seconds: 1200 } });

        $('#timer-down').html(timer.getTimeValues().toString());

        timer.addEventListener('secondsUpdated', function (e) {
            $('#timer-down').html(timer.getTimeValues().toString(['minutes', 'seconds']));
        });

        timer.addEventListener('targetAchieved', function (e) {
            alert("Đã hết thời gian");
            ketThucBaiThi();
        });

        function ketThucBaiThi() {
            let arr = {};
            var radio = document.querySelectorAll("input[type='radio']");
            let daCo = false;
            for (let i = 0; i < radio.length; i++) {
                let name = radio[i].name;
                let splitName = name.split("ch");
                let cauHoi = splitName[1];
                
                if (radio[i].checked == true) {
                    let value = radio[i].value;
                    arr[cauHoi] = value;
                }
            }

            for (let i = 1; i <= soCauHoi; i++) {
                if (arr[i] == undefined)
                    arr[i] = "";
            }

            //call api
            let url = document.URL;
            let urlSplit = url.split("?bd=");

            let idBoDe = urlSplit[1];
            console.log(arr);
            $.ajax({
                type: 'post',  //chỉnh phương thức cho phù hợp
                url: 'http://localhost:1439/cham_thi.aspx?bd=' + idBoDe, //Link tới Route cần lấy dữ liệu
                data: arr,
                success: function (data) {
                    //if (data.success == "false")
                    //    alert("Lỗi API");
                    //else
                    console.log(data);
                    let ketThuc = document.getElementById("btn-ket-thuc");
                    ketThuc.style.display = "none";
                    let ketQua = document.getElementById("ket-thuc");
                    ketQua.innerHTML = "Số câu đúng: " + data.soCauDung + "/" + data.data.length;
                    ketQua.style.display = "block";
                    timer.stop();
                    let ketThucBaiThi = document.getElementsByClassName("ket-thuc-bai-thi");
                    ketThucBaiThi[0].style.backgroundColor = "orange";
                    for(let i=0; i<data.data.length; i++) {
                        let btnCauHoi = document.getElementById("btnCauHoi" + data.data[i].cauHoi);
                        if(data.data[i].correct == "Y")
                            btnCauHoi.className = "btn btn btn-success btn-item-number";
                        else btnCauHoi.className = "btn btn btn-danger btn-item-number";
                    }
                }
            });
        }

    </script>


</asp:Content>

