<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrderList.aspx.cs" Inherits="PurchaseSaleOrderSystem.PurchaseOrderList" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="assets/css/jquery-ui.min.css" rel="stylesheet" />
    <style>
        #Logout {
            position: relative;
            top: 30px;
            left: 1350px;
            background-color: blue;
            color: white;
        }

        #Delete {
            position: relative;
            top: 350px;
            left: 150px;
            background-color: red;
            color: white;
        }

        #NewAdd {
            position: relative;
            top: 350px;
            left: 20px;
            background-color: green;
            color: white;
        }

        #PurchaseLabel {
            font-size: 30px;
            position: relative;
            left: 680px;
        }

        #ReportOutput {
            position: relative;
            top: 350px;
            left: 1300px;
            background-color: orange;
            color: white;
        }

        .TB {
            border: 1px solid black;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="User_Message" runat="server" Text=""></asp:Label>
            <asp:Button ID="Logout" runat="server" Text="登出" OnClick="Logout_Click" /><br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="PurchaseLabel" runat="server" Text="進貨單管理" Style="font-size: 30px;"></asp:Label>
            <div class="row">
                <asp:Repeater ID="RepPurchaseOrderList" runat="server">
                    <HeaderTemplate>
                        <div class="col-2 TB">單號</div>
                        <div class="col-2 TB">貨物種類數</div>
                        <div class="col-2 TB">進貨數量</div>
                        <div class="col-2 TB">預計進貨時間</div>
                        <div class="col-2 TB">進貨金額</div>
                        <div class="col-2 TB">刪除項目</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-2 TB">
                            <a href='ProductCRUD.aspx?ID=<%#Eval("PurchaseOrderID") %>'><%#Eval("PurchaseOrderID") %></a>
                        </div>
                        <div class="col-2 TB" id="PurchaseOrder_PID" runat="server"><%#Eval("PurchaseOrder_PID") %></div>
                        <div class="col-2 TB"><%#Eval("ProductNum") %></div>
                        <div class="col-2 TB"><%#Eval("PurchaseDate","{0:yyyy-MM-dd HH:mm}")%></div>
                        <div class="col-2 TB">NT<%#Eval("PurchaseOrderCost") %></div>
                        <div class="col-2 TB">
                            <asp:CheckBox ID="CheckBoxD" runat="server" ToolTip='<%#Eval("PurchaseOrderID") %>' />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Delete" runat="server" Text="刪除" OnClientClick="return confirm('確定刪除勾選的進貨單？');" OnClick="Delete_Click" />
            <asp:Button ID="NewAdd" runat="server" Text="新增" OnClick="NewAdd_Click" />
            <asp:Button ID="ReportOutput" runat="server" Text="輸出報表" OnClick="ReportOutput_Click" />
            <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" AutoDataBind="true" />
        </div>
    </form>
</body>
</html>
