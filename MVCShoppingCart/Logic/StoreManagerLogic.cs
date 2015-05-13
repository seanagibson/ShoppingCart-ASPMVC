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

        public StoreManager getStoreDetails()
        {
            int id = 1; //There should only be one store manager record in db
            var storeDetails = db.StoreManagers.Find(id);

            return storeDetails;
        }

        public void updateStoreManager(StoreManager storeManager)
        {
            var storeDBRecord = db.StoreManagers.Find(1);

            if(storeDBRecord == null) //create a new db record
            {
                var newStoreManager = new StoreManager
                {
                    StoreManagerId = 1,
                    StoreAddress = storeManager.StoreAddress,
                    StoreCity = storeManager.StoreCity,
                    StoreState = storeManager.StoreState,
                    StoreZipCode = storeManager.StoreZipCode,
                    SaleTaxRate = storeManager.SaleTaxRate,
                };
                db.StoreManagers.Add(newStoreManager);
                db.SaveChanges();
            }
            else //update the db record
            {
                db.Entry(storeManager).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}