namespace web1.models
    {
public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int SupplierID { get; set; }
    public int categoryID {get;set;}
    public double UnitPrice { get; set; }
    public bool Discounted { get; set; }
}
    }