<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductCRUD.aspx.cs" Inherits="PurchaseSaleOrderSystem.ProductCRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/bootstrap.js"></script>
    <link href="assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="assets/css/jquery-ui.min.css" rel="stylesheet" />
    <script src="assets/js/jquery-ui.min.js"></script>
    <script src="assets/js/jquery-ui.js"></script>
    <link href="assets/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
    <script src="assets/js/jquery-ui-timepicker-addon.js"></script>

    <style>
        #Logout {
            position: relative;
            top: 30px;
            left: 1350px;
            background-color: blue;
            color: white;
        }

        #PurchaseLabel {
            position: relative;
            left: 150px;
        }

        #NewAdd {
            position: relative;
            top: 15px;
            left: 20px;
            background-color: green;
            color: white;
        }

        #DelProduct {
            position: relative;
            top: 15px;
            left: 20px;
            background-color: red;
            color: white;
        }

        #CreateOrder {
            position: relative;
            top: 15px;
            left: 150px;
            background-color: aquamarine;
            color: black;
        }

        #CancelOrder {
            position: relative;
            top: 15px;
            left: 150px;
            color: black;
        }
    </style>
    <script>
        function getprice(productname) {
            $.ajax({
                url: "API/GetPriceHandler.ashx",
                data: {
                    "ProductName": productname
                },
                type: "POST",
                dataType: "json",
            })
                .done(function (responsedata) {
                    $("#PriceBox").val(responsedata);
                })
                .fail(function (xhr, status, errThrown) {
                    alert("傳送失敗");
                })
        }

        function getproductid(productname) {
            $.ajax({
                url: "API/GetProductIDHandler.ashx",
                data: {
                    "ProductName": productname
                },
                type: "POST",
                dataType: "json",
            })
                .done(function (responsedata) {
                    $("#ProductIDL").html(responsedata);
                })
                .fail(function (xhr, status, errThrown) {
                    alert("傳送失敗");
                })
        }

        $(document).ready(function () {

            $('#datepicker').datetimepicker({
                "dateFormat": "yy-mm-dd",
                "timeFormat": "HH:mm"
            });

            $("#dialog").dialog({
                modal: true,
                autoOpen: false,
                width: 400,
                high: 450,
            });

            $("#NewAdd").click(function () {
                $("#dialog").dialog("open");
                getprice("香水");
                getproductid("香水");
            });

            $("#Cancel").click(function () {
                $("#dialog").dialog("close");
                $("#AddProdcut").val(0);
            })

            $("#AddP").click(function () {
                $.ajax({
                    url: "API/AddProductHandler.ashx",
                    data: {
                        "Product_ID": $("#ProductIDL").html(),
                        "Product_Name": $("#AddProdcut").val(),
                        "Product_Num": $("#NumBox").val(),
                        "Product_Price": $("#PriceBox").val()
                    },
                    type: "POST",
                    dataType: "json",
                })
                    .done(function (responsedata) {
                        location.reload(true);
                    })
                    .fail(function (xhr, status, errThrown) {
                        alert("傳送失敗");
                    })
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="PurchaseOrderList.aspx" style="position: relative; left: 650px; top: 20px">進貨單管理</a><br />
            <asp:Button ID="Logout" runat="server" Text="登出" OnClick="Logout_Click" /><br />
            <br />
            <br />
            <asp:Label ID="PurchaseLabel" runat="server" Text="進貨單管理" Style="font-size: 30px;"></asp:Label><br />
            <br />
            <div style="position: relative; left: 60px">
                單號<asp:TextBox ID="PurchaseOrderNum" runat="server" ReadOnly="true"></asp:TextBox><br />
                <br />
                進貨時間<asp:TextBox ID="datepicker" runat="server" TextMode="DateTime"></asp:TextBox><br />
                <br />
                <asp:Button autopostback="false" ID="NewAdd" runat="server" Text="新增" OnClientClick="return false" />&nbsp;&nbsp;&nbsp;
                <asp:Button autopostback="false" ID="DelProduct" runat="server" Text="刪除" OnClientClick="return confirm('確定刪除勾選產品？');" OnClick="DelProduct_Click"/>
            </div>
        </div>
        <div id="dialog" title="新增商品" class="container" style="text-align: center">
            選擇商品<asp:DropDownList ID="AddProdcut" runat="server" onchange="getprice(this.value);getproductid(this.value);"></asp:DropDownList><br />
            <br />
            商品編號:<asp:Label ID="ProductIDL" runat="server" Text=""></asp:Label><br />
            <br />
            數量<asp:TextBox ID="NumBox" runat="server" Style="width: 100px"></asp:TextBox><br />
            <br />
            進貨價格<asp:TextBox ID="PriceBox" runat="server" ReadOnly="true" Style="width: 100px"></asp:TextBox><br />
            <br />
            <asp:Button ID="AddP" runat="server" Text="加入" Style="background-color: aquamarine" />
            <asp:Button ID="Cancel" runat="server" Text="取消" />
        </div>
        <br />
        <br />
        <div class="row">
            <asp:Repeater ID="RepProductList" runat="server">
                <HeaderTemplate>
                    <div class="col-2 tableBorder">商品編號</div>
                    <div class="col-2 tableBorder">商品名稱</div>
                    <div class="col-2 tableBorder">進貨價格</div>
                    <div class="col-2 tableBorder">數量</div>
                    <div class="col-2 tableBorder">小計</div>
                    <div class="col-2 tableBorder"></div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-2 tableBorder"><%#Eval("Product_Pid") %></div>
                    <div class="col-2 tableBorder"><%#Eval("Product_Name") %></div>
                    <div class="col-2 tableBorder"><%#Eval("Product_Price") %></div>
                    <div class="col-2 tableBorder"><%#Eval("Product_Num") %></div>
                    <div class="col-2 tableBorder">NT<%#Eval("TotalPrice") %></div>
                    <div class="col-2 tableBorder">
                        <asp:CheckBox ID="CheckBoxD" runat="server" ToolTip='<%#Eval("PO_OrderID") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />
        <div class="Buttonright">
            <asp:Label ID="TotalPrice" runat="server" Text=""></asp:Label>
        </div>
        <div class="row align-items-center">
            <asp:Button ID="CreateOrder" runat="server" Text="建立" OnClick="CreateOrder_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CancelOrder" runat="server" Text="取消" OnClick="CancelOrder_Click" />
        </div>
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
