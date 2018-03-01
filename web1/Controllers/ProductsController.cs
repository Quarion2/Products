using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web1.models;





public class ProductsController:Controller
{
    public List<Product> GetAllProduct (string searchedPhrase)
    {
        
        SqlConnection connection=new SqlConnection();
        connection.ConnectionString=@"Server=DESKTOP-RUFIFTV\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command=new SqlCommand();

        command.CommandType=System.Data.CommandType.Text;
        command.CommandText=$"Select * from GetAllProduct where productname like '%{searchedPhrase}%' ";
        command.Connection= connection;
          

        SqlDataReader reader = command.ExecuteReader();
        
        List<Product> allProducts=new List<Product>();
        while (reader.Read())
            {
                Product temp = new Product();
            temp.ProductID=int.Parse(reader["productid"].ToString());
            temp.ProductName=reader["productname"].ToString();
            temp.categoryID=int.Parse(reader["categoryid"].ToString());
            temp.UnitPrice=double.Parse(reader["unitprice"].ToString());
            temp.SupplierID=int.Parse(reader["supplierid"].ToString());
            temp.Discounted=bool.Parse(reader["discontinued"].ToString());
            allProducts.Add(temp);
                
            }
        return allProducts;
        
    }
}
