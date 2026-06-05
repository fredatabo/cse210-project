using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    private double GetShippingCost()
    {
        if (_customer.LivesInUSA())
        {
            return 5.0;
        }
        else
        {
            return 35.0;
        }
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        total += GetShippingCost();
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL\n";
        label += "=============\n";
        foreach (Product product in _products)
        {
            label += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL\n";
        label += "==============\n";
        label += $"Customer: {_customer.GetName()}\n";
        label += $"Address:\n{_customer.GetAddress().GetFullAddress()}\n";
        return label;
    }
}