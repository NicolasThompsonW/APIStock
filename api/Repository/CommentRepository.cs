using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Comment> CreateAsync(Comment commentModel)
        {
            if (_dbContext.Comments != null)
            {
                _dbContext.Comments.Add(commentModel);
                _dbContext.SaveChanges();
            }
            return Task.FromResult(commentModel);
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return _dbContext.Comments != null ? await _dbContext.Comments.ToListAsync() : new List<Comment>();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return _dbContext.Comments != null ? await _dbContext.Comments.FindAsync(id) : null;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var commentExist = await GetByIdAsync(id);
            if (commentExist == null)
            {
                return null;
            }
            commentExist.Title = commentModel.Title;
            commentExist.Content = commentModel.Content;
            await _dbContext.SaveChangesAsync();
            return commentExist;
        }


        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = _dbContext.Comments != null ? await _dbContext.Comments.FirstOrDefaultAsync(comment => comment.Id == id) : null;
            if (comment == null)
            {
                return null;

            }
            if (_dbContext.Comments != null)
            {
                _dbContext.Comments.Remove(comment);
            }
            await _dbContext.SaveChangesAsync();
            return comment;
        }
    }
}