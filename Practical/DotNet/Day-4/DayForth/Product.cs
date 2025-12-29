class Product
{
    public string Name;
    public int Price;

    public Product() { }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

// class Product
// {
//     public int ProductId { get; set; }              // just like getter and setter Annotation in java springboot.
//     public string ProductName { get; set; }
//     public double Price { get; set; }
// }