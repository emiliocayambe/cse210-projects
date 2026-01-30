using System.Collections.Generic;

public class Product
{
    private string _name;
    private int _productId;
    private double _price;
    private int _quantity;

    public Product(int productId, string name, double price, int quantity)
    {
        _productId = productId;
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost() => _price * _quantity;
    public string GetName() => _name;
    public string GetId() => _productId.ToString();
    

}