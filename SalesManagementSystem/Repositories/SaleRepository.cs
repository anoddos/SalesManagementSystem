﻿using System;
using System.Collections.Generic;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;
using db = SalesManagementSystemDB.Models;
using System.Linq;

namespace SalesManagementSystem.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private SalesDbContext _dbContext;
        public SaleRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(Sale sale)
        {
            db.Sale dbSale = new db.Sale()
            {
                TimeStamp = sale.TimeStamp,
                ConsultantId = sale.ConsultantId,
                SoldProducts = sale.Products.Select(x => new db.SoldItem()
                {
                    ProductId = x.ProductId,
                    Unit = x.Unit,
                    SaleId = sale.Id
                }).ToList()
            };

            _dbContext.Add(dbSale);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(long id)
        {
            var toBeDeleted = _dbContext.Sale.SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
            {
                DeleteSoldItems(id);
                _dbContext.Remove(toBeDeleted);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<Sale> Read()
        {
            var dbSales = _dbContext.Sale.Select(x => new Sale()
            {
                TimeStamp = x.TimeStamp,
                ConsultantId = x.ConsultantId,
                Products = x.SoldProducts.Select(x => new SoldItem()
                {
                    ProductId = x.ProductId,
                    Unit = x.Unit
                }).ToList()
            }).ToList();

            return dbSales;
        }

        public bool Update(Sale sale)
        {
            db.Sale dbSale = _dbContext.Sale.SingleOrDefault(x => x.Id == sale.Id);
            if (dbSale != null)
            {
                DeleteSoldItems(sale.Id);
                dbSale.TimeStamp = sale.TimeStamp;
                dbSale.ConsultantId = sale.ConsultantId;
                dbSale.SoldProducts = sale.Products.Select(x => new db.SoldItem()
                {
                    ProductId = x.ProductId,
                    Unit = x.Unit,
                    SaleId = sale.Id
                }).ToList();

                _dbContext.Update(dbSale);
            }

            return _dbContext.SaveChanges() > 0;
        }

        private void DeleteSoldItems(long saleId)
        {
            var toBeDeleted = _dbContext.SoldItem.Where(x => x.SaleId == saleId);
            _dbContext.RemoveRange(toBeDeleted);
            _dbContext.SaveChanges();
        }
    }
}