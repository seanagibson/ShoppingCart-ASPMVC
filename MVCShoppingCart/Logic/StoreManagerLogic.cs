using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCShoppingCart.DAL;
using MVCShoppingCart.Models;


namespace MVCShoppingCart.Logic
{
    public class StoreManagerLogic
    {
        ShoppingCartContext db = new ShoppingCartContext();

        public StoreManager getStoreDetails(int id)
        {
            var storeDetails = db.StoreManagers.Find(id);

            return storeDetails;
        }

        public void editStoreManagerDBRecord(StoreManager storeManager)
        {
            db.Entry(storeManager).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void createStoreManagerDBRecord(StoreManager storeManager)
        {
            var newStoreManager = new StoreManager
            {
                StoreManagerId = db.StoreManagers.Count() + 1,
                StoreAddress = storeManager.StoreAddress,
                StoreCity = storeManager.StoreCity,
                StoreState = storeManager.StoreState,
                StoreZipCode = storeManager.StoreZipCode,
                SalesTaxRate = storeManager.SalesTaxRate,
            };
            db.StoreManagers.Add(newStoreManager);
            db.SaveChanges();
        }

        public List<StoreManager> toList()
        {
            return db.StoreManagers.ToList();
        }
    }
}