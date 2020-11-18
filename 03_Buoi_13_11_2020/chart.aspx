<%@ Page Title="" Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true" CodeFile="chart.aspx.cs" Inherits="chart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Styles -->
    <style>
    #div-chart {
        width: 100%;
        height: 500px;
    }
    g[aria-labelledby="id-66-title"] {
        display: none;
    }
    </style>

    <!-- Resources -->
    <script src="https://cdn.amcharts.com/lib/4/core.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="div-chart">

    </div>
    <asp:Literal ID="ltr" runat="server"></asp:Literal>
</asp:Content>

