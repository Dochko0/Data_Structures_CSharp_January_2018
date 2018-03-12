using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Instock : IProductStock
{
    private List<Product> byInsertion = new List<Product>();
    private List<Product> byChanging = new List<Product>();
    private Dictionary<string, Product> byLabel = new Dictionary<string, Product>();
    //private Dictionary<string, Product> byIndex = new Dictionary<string, Product>();
    //private int steps = 0;
    //private int energy = 0;



    public int Count => this.byLabel.Count;

    public void Add(Product product)
    {
        List<Product> node = new List<Product>();
        if (!this.byLabel.ContainsKey(product.Label))
        {
            this.byLabel.Add(product.Label, product);
            this.byInsertion.Add(product);
        }

    }

    public void ChangeQuantity(string product, int quantity)
    {
        //foreach (var item in this.byInsertion.Where(x => x.Label == product))
        //{   
        //    item.Quantity = quantity;
        //}
        this.byLabel.Values.Where(x => x.Label == product).Select(x => x.Quantity = quantity);
        //this.byLabel.Values.Where(x => x.Label == product).Select(x => x.Quantity = quantity);
    }

    public bool Contains(Product product)
    {
        if (!this.byLabel.ContainsKey(product.Label))
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public Product Find(int index)
    {
        try
        {
            return this.byInsertion[index];
        }
        catch (Exception)
        {

            throw new IndexOutOfRangeException();
        }
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        return this.byInsertion.Where(x => x.Price == price);
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        return this.byLabel.Values.Where(x => x.Quantity == quantity);
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        return this.byLabel.Values.Where(x => x.Price > lo && x.Price <= hi).OrderByDescending(x=>x.Price);
    }

    public Product FindByLabel(string label)
    {
        if (!this.byLabel.ContainsKey(label))
        {
            throw new ArgumentException();
        }
        Product product;
        var productExists = this.byLabel.TryGetValue(label, out product);
        return product;
    }

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        if (count>byInsertion.Count)
        {
            throw new ArgumentException();
        }
        return this.byInsertion.OrderBy(x => x.Label).Take(count);
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        if (count > byInsertion.Count)
        {
            throw new ArgumentException();
        }
        return this.byInsertion.OrderByDescending(x => x.Price).Take(count);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        if (this.Count == 0)
            yield break;

        foreach (var item in this.byInsertion)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
