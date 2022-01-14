using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// набор пространств для работы с базами данных
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

// класс для описания новости
public class NewsItem
{
    private string title;
    private string text;
    private string author;
    private int articleRating;
   public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string Text
    {
        get { return text; }
        set { text = value; }
    }
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    public int ArticleRating
    {
        get { return articleRating; }
        set { articleRating = value; }
    }
    public NewsItem()
    {
        Random rnd = new Random();
        this.ArticleRating = rnd.Next(5);                       
    }
}

// класс для описания заказ

public class OrderItem
{
    private string model;
    private string lastname;
    private string name;
    public string problem;
    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public string Lastname
    {
        get { return lastname; }
        set { lastname = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Problem
    {
        get { return problem; }
        set { problem = value; }
    }
}


/* скрипты для создания таблиц в базе demodb
 
 --- общая задача 
 CREATE TABLE [dbo].[tb_news]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Text] NVARCHAR(MAX) NULL, 
    [Author] NCHAR(50) NULL, 
    [Rating] INT NULL, 
    [Date] DATETIME NULL
)
 
--- для варианта 8  
 CREATE TABLE [dbo].[tb_orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATE NULL, 
    [Model] NCHAR(20) NULL, 
    [Lastname] NVARCHAR(50) NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Problem] NVARCHAR(MAX) NULL
)
 
*/

public partial class _Default : System.Web.UI.Page
{
    static protected SqlConnection connection; // подключение к базе
    static private string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog = demobd;Integrated Security = True;Pooling=False";
    protected void Page_Init(object sender, EventArgs e) // обработка события инициализации (создания) страницы
    {
        // при инициализации страницы подключаемся к базе данных
        if (connection == null)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ошибка при установлении соединения: ",
                ex.Message);
                Console.ReadKey();
                return;
            }
        }                
    }

    protected void Page_Load(object sender, EventArgs e) // обработка загрузки страницы
    {
        // заполняем данными из БД
        this.GetNewsFromDb();
    }
    protected void btnAdd_Click(object sender, EventArgs e) // обработка нажатия кнопки "Добавить"
    {
        if (true) //rfvTitle.IsValid) - проверка обязательных полей отключена
        {           
            // проверка пройдена

            // создаем новый элемент типа "Новость"
            NewsItem newsItem = new NewsItem();

            // заполняем параметры, при этом рейтинг назначается случайным образом            
            newsItem.Text = tbText.Text;
            newsItem.Author = tbAuthor.Text;

            // очищаем поля на форме            
            tbText.Text = "";
            tbAuthor.Text = "";

            // добавляем элемент в список
            //newsList.Add(newsItem);            

            // добавляем данные в БД
            try
            {
                SqlCommand command1 = new SqlCommand("INSERT INTO tb_News (Text, Author, Rating, Date) " +
                                                      "VALUES ('" + newsItem.Text+"','"+newsItem.Author+"',"+
                                                      newsItem.ArticleRating.ToString()+",getdate())", connection);
                command1.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ошибка при вставке данных: ", ex.Message);
                Console.ReadKey();
            }

            // получаем данные из таблицы
            this.GetNewsFromDb();
            this.GetOrdersFromDb();
            
        }        
    }

    protected void btnClear_Click(object sender, EventArgs e) // обработка нажатия кнопки "Очистить"
    {
        // удаляем все записи из таблицы
        try
        {
            SqlCommand command1 = new SqlCommand("DELETE FROM tb_News", connection);
            command1.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Ошибка при удалении данных: ", ex.Message);
            Console.ReadKey();
        }

        // получаем данные из таблицы
        this.GetNewsFromDb();
    }

    // для варианта 8
    protected void btnAddOrder_Click(object sender, EventArgs e) // обработка нажатия кнопки "Добавить заказ"
    {
        if (rfvModel.IsValid && rfvLastname.IsValid) // проверка обязательных полей
        {
            // проверка пройдена

            // создаем новый элемент типа "Заказ"
            OrderItem orderItem = new OrderItem();

            // заполняем параметры
            orderItem.Model = tbModel.Text;
            orderItem.Lastname = tbLastname.Text;
            orderItem.Name = tbname.Text;
            orderItem.Problem = tbProblem.Text;

            // очищаем поля на форме            
            tbModel.Text = "";
            tbLastname.Text = "";
            tbname.Text = "";
            tbProblem.Text = "";

            // добавляем данные в БД
            try
            {
                SqlCommand commandAddOrder = new SqlCommand("INSERT INTO tb_orders (Model, Lastname, Name, Problem, Date) " +
                                                      "VALUES ('" + orderItem.Model + "','" + orderItem.Lastname + "','" +
                                                      orderItem.Name + "','" + orderItem.Problem+ "',getdate())", connection);
                commandAddOrder.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ошибка при вставке данных: ", ex.Message);
                Console.ReadKey();
            }

            // получаем данные из таблицы
            this.GetOrdersFromDb();

        }
    }
    protected void btnClearOrders_Click(object sender, EventArgs e) // обработка нажатия кнопки "Очистить заказы"
    {
        // удаляем все записи из таблицы заказов
        try
        {
            SqlCommand command1 = new SqlCommand("DELETE FROM tb_orders", connection);
            command1.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Ошибка при удалении данных: ", ex.Message);
            Console.ReadKey();
        }

        // получаем данные из таблицы
        this.GetOrdersFromDb();
    }
    
    protected void GetNewsFromDb()
    {
        // Создаем объект DataAdapter для списка новостей
        SqlDataAdapter adapter = new SqlDataAdapter("select * from tb_news", connection);
        // Создаем объект Dataset
        DataSet ds = new DataSet();
        // Заполняем Dataset
        adapter.Fill(ds);
        // Отображаем данные
        gridNews.DataSource = ds.Tables[0];
        this.gridNews.DataBind();
    }

    protected void GetOrdersFromDb()
    {
        // Создаем объект DataAdapter для списка заказов
        SqlDataAdapter adapter = new SqlDataAdapter("select * from tb_orders", connection);
        // Создаем объект Dataset
        DataSet ds = new DataSet();
        // Заполняем Dataset
        adapter.Fill(ds);
        // Отображаем данные
        gridOrders.DataSource = ds.Tables[0];
        this.gridOrders.DataBind();
    }
}