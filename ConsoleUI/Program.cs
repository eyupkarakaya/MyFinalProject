using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Princeple
    class Program
    {
        static void Main(string[] args)
        {

           int a = 21;
            if (a==21)
            {
                Console.WriteLine("Yazılım Geliştirici Yetiştirme Kampı 11. Gün Başlıyor ");
            }
            else
            {
                Console.WriteLine("Bekle dostum acele etme");
            }


            //ProductTest();
            //IoC
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(50, 100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
