<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Лабораторная работа 3</title>
</head>
<body>
    <h2>Лабораторная работа 3, ДОСТУП К ДАННЫМ В .NET. ТЕХНОЛОГИЯ ADO.NET</h2>
    <form id="form1" runat="server">       
        <h3>Общий пример</h3>
        <h4>Введите новость</h4>        
        <div style="margin-top: 5px">Содержание<asp:TextBox ID="tbText" runat="server"></asp:TextBox></div>
        <div style="margin-top: 5px">Автор<asp:TextBox ID="tbAuthor" runat="server"></asp:TextBox></div>
        <asp:Button ID="btnAdd" runat="server" Text="Добавить" OnClick="btnAdd_Click" style="margin-top: 5px" />      
              
        <div><h4>Список новостей</h4></div>
        <asp:GridView ID="gridNews" runat="server">
            <Columns>
            </Columns>
        </asp:GridView>
        <div>
            <asp:Button ID="Button2" runat="server" Text="Очистить" OnClick="btnClear_Click" style="margin-top: 5px" />      
        </div>
        <h3>Вариант 8. Ввод данных о заявке на ремонт</h3>
        <h4>Введите данные о заказе</h4>
        <div style="margin-top: 5px">Марка машины<asp:TextBox ID="tbModel" runat="server"></asp:TextBox></div>        
        <div style="margin-top: 5px">Фамилия заказчика<asp:TextBox ID="tbLastname" runat="server"></asp:TextBox></div>
        <div style="margin-top: 5px">Имя<asp:TextBox ID="tbname" runat="server"></asp:TextBox></div>
        <div style="margin-top: 5px">Причина обращения<asp:TextBox ID="tbProblem" runat="server"></asp:TextBox></div>
        <asp:RequiredFieldValidator ID="rfvModel" runat="server" EnableClientScript="false" ErrorMessage="Введите марку машины!" ControlToValidate="tbModel">  </asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvLastname" runat="server" EnableClientScript="false" ErrorMessage="Введите фамилию заказчика!" ControlToValidate="tbLastname">  </asp:RequiredFieldValidator>        
        <asp:Button ID="btnAddOrder" runat="server" Text="Добавить заказ" OnClick="btnAddOrder_Click" style="margin-top: 5px" />      
        <h4>Список заказов</h4>
        <div><h4>Список новостей</h4></div>
        <asp:GridView ID="gridOrders" runat="server">
            <Columns>
            </Columns>
        </asp:GridView>
        <div>
            <asp:Button ID="btnClearOrders" runat="server" Text="Очистить заказы" OnClick="btnClearOrders_Click" style="margin-top: 5px" />      
        </div>
    </form>

</body>
</html>
