using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

// набор пространств для работы с базами данных
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Сводное описание для Customers
/// </summary>
[WebService(Namespace = "http://lab4v8.istx05.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
// [System.Web.Script.Services.ScriptService]
public class Customers : System.Web.Services.WebService
{

    public Customers()
    {

        //Раскомментируйте следующую строку в случае использования сконструированных компонентов 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Привет всем!";
    }
    [WebMethod(Description = "Задача 1. Вывод простого списка")]
    public List<Customer> GetCustomersInfo()
    {
        List<Customer> data = new List<Customer>();
        data.Add(new Customer("Иван Иванов", DateTime.Now));
        data.Add(new Customer("Петр Петров", DateTime.Today));
        return data;
    }
    
    [WebMethod(Description = "Задача 2. Вывод списка заказов клиентов из базы данных Автосервис")]
    
    
    public List<OrderInfo> GetOrdersInfo()
    {
        // создаем пустой список заказов
        List<OrderInfo> orders = new List<OrderInfo>();

        //SqlConnection connection; // объект для подключения к базе

        // создаем строку подключения 
       // string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog = demodb;Integrated Security = True;Pooling=False";
        //try
       // {
            // открываем соединение с базой данных
           // connection = new SqlConnection(connectionString);
           // connection.Open();

            // получаем данные из БД
            
            // Создаем объект DataAdapter для списка заказов
            // c заданным набором полей, упорядоченным по дате создания
            //SqlDataAdapter adapter = new SqlDataAdapter("select Model, Lastname, Name, Problem, Date from tb_orders", connection);
            
            // Создаем объект Dataset для хранения полученной информации
           // DataSet ds = new DataSet();
            
            // Заполняем Dataset данными из запроса
           // adapter.Fill(ds);
            //DataTable dt = ds.Tables[0];

            // выбираем все строки из таблицы
            //foreach (DataRow row in dt.Rows)
           // {
                // создать объект для заказа
                //OrderInfo orderInfo = new OrderInfo();

                // заполнить из таблицы (см. список полей в Select)
                //var cells = row.ItemArray;
                //orderInfo.Model = cells[0].ToString();
                //orderInfo.Lastname = cells[1].ToString();
                //orderInfo.Name = cells[2].ToString();
                //orderInfo.Problem = cells[3].ToString();
                //orderInfo.Date = Convert.ToDateTime(cells[4].ToString());

                // добавить информацию о заказе в список
                //orders.Add(orderInfo);                
            //}
        //}
        //catch (SqlException ex)
        //{
            //Console.WriteLine("Ошибка при установлении соединения: ",
            //ex.Message);
            //Console.ReadKey();
          //  return;
        //}

        // вернуть полученный список заказов
        return orders;
    }    
}
