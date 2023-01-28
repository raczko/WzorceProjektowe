
using System;
using System.Collections.Generic;


public abstract class ProductPrototype
{

    public decimal Price { get; set; }

    public ProductPrototype(decimal price)
    {
        Price = price;
    }

    public ProductPrototype Clone()
    {
        return (ProductPrototype)this.MemberwiseClone();
    }

}


public class Bread : ProductPrototype
{

    public Bread(decimal price) : base(price) { }

}

public class Butter : ProductPrototype
{

    public Butter(decimal price) : base(price) { }

}



public class Supermarket
{

    private Dictionary<string, ProductPrototype> _productList = new Dictionary<string, ProductPrototype>();

    public void AddProduct(string key, ProductPrototype productPrototype)
    {
        _productList.Add(key, productPrototype);
    }

    public ProductPrototype GetClonedProduct(string key)
    {
        return _productList[key].Clone();
    }


}


class MainClass
{
    public static void Main(string[] args)
    {

        Supermarket supermarket = new Supermarket();

        supermarket.AddProduct("Bread", new Butter(9.50m));
        supermarket.AddProduct("Butter", new Butter(5.30m));


        //...
        ProductPrototype product = supermarket.GetClonedProduct("Bread");
        Console.WriteLine(String.Format("Bread - {0} zł", product.Price));
        ProductPrototype product2 = supermarket.GetClonedProduct("Bread");
        product.Price = 6.30m;
        Console.WriteLine(String.Format("Bread - {0} zł", product2.Price));
        Console.WriteLine(String.Format("Bread - {0} zł", product.Price));
        //...

    }
}