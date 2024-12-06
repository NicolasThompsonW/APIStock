using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
                Title = commentModel.Title
            };
        }
        public static Comment ToCommentFromCreate(this CreateCommentDto createCommentDto, int stockId)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                StockId = stockId,
                Content = createCommentDto.Content,
            };
        }

        public static Comment ToCommentFromUpdate(this CommentUpdateDto commentUpdateDto)
        {
            return new Comment
            {
                Title = commentUpdateDto.Title,
                Content = commentUpdateDto.Content
            };
        }
    }
}