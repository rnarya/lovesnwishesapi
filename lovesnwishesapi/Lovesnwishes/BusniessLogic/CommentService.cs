using Lovesnwishes.DataBase;
using Lovesnwishes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lovesnwishes.BusniessLogic
{
    public class CommentService
    {
        lovesnwishesEntities objobjlovesnwishesEntities = new lovesnwishesEntities();
        public CommentModel PostComment(CommentModel comment)
        {
            try
            {
                tblComment objtblComment = new tblComment()
                {
                    CommentedDate = DateTime.UtcNow,
                    CommentedBy = comment.CommentedBy,
                    Comment = comment.Comment,
                    CommentType = 1,
                    FeedId=comment.FeedId,
                    IsActive = true
                };
                objobjlovesnwishesEntities.tblComments.Add(objtblComment);
                objobjlovesnwishesEntities.SaveChanges();
                comment.Id = objtblComment.Id;
           
            }

            catch (Exception ex)
            {
                comment.Id = 0;
            }
            return comment;
        }
    }
}