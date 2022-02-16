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
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model, int id)
        {
            Profile profile;

            using (var ctx = new ApplicationDbContext())
            {
                profile = ctx.Profiles.Single(i => i.OwnerId == _userId);
            }

            var entity =
                new Comment()
                {
                    ProfileId = profile.ProfileId,
                    PostId = id,
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

            //Post post;

            //using (var ctx = new ApplicationDbContext())
            //{
            //    post = ctx.Posts.Single(p => p.PostId == );
            //}

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        //.Where(c => c.Post.PostId == post.PostId)
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
                        Creator = entity.Profile.FirstName,
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
