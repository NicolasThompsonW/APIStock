using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StockRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Stock> CreteAsync(Stock stockModel)
        {
            if (_dbContext.Stocks == null)
            {
                throw new InvalidOperationException("Stocks DbSet is null.");
            }
            await _dbContext.Stocks.AddAsync(stockModel);
            await _dbContext.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = _dbContext.Stocks != null ? await _dbContext.Stocks.FirstOrDefaultAsync(stock => stock.Id == id) : null;
            if (stockModel == null)
            {
                return null;
            }
            if (_dbContext.Stocks != null)
            {
                _dbContext.Stocks.Remove(stockModel);
            }
            await _dbContext.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _dbContext.Stocks?.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks?.Where(stock => stock.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks?.Where(stock => stock.Symbol.Contains(query.Symbol));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks?.OrderByDescending(stock => stock.Symbol) : stocks?.OrderBy(stock => stock.Symbol);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await (stocks?.Skip(skipNumber).Take(query.PageSize).ToListAsync() ?? Task.FromResult<List<Stock>>(new List<Stock>()));
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await (_dbContext.Stocks?.Include(c => c.Comments).FirstOrDefaultAsync(stock => stock.Id == id) ?? Task.FromResult<Stock?>(null));
        }

        public async Task<bool> StockExistAsync(int id)
        {
            return _dbContext.Stocks != null && await _dbContext.Stocks.AnyAsync(stock => stock.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock = _dbContext.Stocks?.FirstOrDefault(stock => stock.Id == id);
            if (existingStock == null)
            {
                return null;
            }
            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Price = stockDto.Price;
            existingStock.LastDiv = stockDto.LastDiv;
            existingStock.Industry = stockDto.Industry;
            existingStock.MarketCap = stockDto.MarketCap;
            if (_dbContext.Stocks != null)
            {
                _dbContext.Stocks.Update(existingStock);
            }
            await _dbContext.SaveChangesAsync();
            return existingStock;

        }
    }
}