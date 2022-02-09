using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalWellness.Data;
using TotalWellness.Models;

namespace TotalWellness.Services
{
    public class CommentService
    {
        

        public CommentService()
        {

        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Message = model.Message
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    ProfileId = e.ProfileId,
                                    Message = e.Message,
                                    Date = e.Date
                                }
                        );
                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        PostId = entity.PostId,
                        ProfileId = entity.ProfileId,
                        Message = entity.Message,
                        Date = entity.Date
                    };
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId);

                entity.CommentId = model.CommentId;
                


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
