using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Customer
/// </summary>

public class Customer
{
    public Guid ID { get; set; }
    public string FIO { get; set; }
    public DateTime CreationDate { get; set; }
    public Customer(string FIO, DateTime cr)
    {
        ID = Guid.NewGuid();
        //Guid - глобальный уникальный идентификатор длиной 128 бит
        //метод Guid.NewGuid() создает новую последовательность бит,
        // отличную от предыдущих
        this.FIO = FIO;
        CreationDate = cr;
    }
    public Customer()
    {

    }

    
}
