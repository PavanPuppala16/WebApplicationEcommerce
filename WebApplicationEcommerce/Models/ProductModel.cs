﻿namespace WebApplicationEcommerce.Models
{
    public class ProductModel
    {
       
            public List<Produce> _products { get; set; }
            public List<Produce> findAll()
            {
                _products = new List<Produce>{new Produce()
            {
                Id = "1", Name = "Flower1", Photo = "thumb1.jpg", Price = 2.80
            },
            new Produce()
            {
                Id = "2",Name="Flower2",Photo="thumb2.jpg", Price=3.80
            },
            new Produce()
            {
                Id = "3",Name="Flower3",Photo="thumb3.jpg", Price=3.80
            },
              new Produce()
            {
                Id = "4",Name="Flower4",Photo="thumb4.jpg", Price=3.60
            },
            new Produce()
            {
                Id = "5",Name="Flower5",Photo="thumb5.jpg", Price=6.80
            },
            new Produce()
            {
                Id = "6",Name="Flower6",Photo="thumb6.jpg", Price=1.68
            },
              new Produce()
            {
                Id = "7",Name="Flower7",Photo="thumb7.jpg", Price=3.80
            },
              new Produce()
            {
                Id = "8",Name="Flower8",Photo="thumb8.jpg", Price=3.45
            },
            new Produce()
            {
                Id = "9",Name="Flower9",Photo="thumb9.jpg", Price=3.80
            },
              new Produce()
            {
                Id = "10",Name="Flower10",Photo="thumb10.jpg", Price=3.80
            }
            };
                return _products;
            }
            public Produce find(string id)
            {
                List<Produce> products = findAll();
                var prod = products.Where(a => a.Id == id).FirstOrDefault();
                return prod;
            }
        
    }
}
