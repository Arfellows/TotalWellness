using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalWellness.Data;
using TotalWellness.Models;

namespace TotalWellness.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            Profile profile;

            using (var ctx = new ApplicationDbContext())
            {
                profile = ctx.Profiles.Single(i => i.OwnerId == _userId);
            }
            var entity =

                new Post()
                {
                    ProfileId = profile.ProfileId,
                    Subject = model.Subject,
                    Message = model.Message
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            
            Profile profile;

            using (var ctx = new ApplicationDbContext())
            {
                profile = ctx.Profiles.Single(p => p.OwnerId == _userId);
            }

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts 
                        .Where(p => p.Profile.TeamId == profile.TeamId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.PostId,
                                    Subject = e.Subject,
                                    PostDate = e.PostDate
                                }
                        );
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            Profile profile;

            using (var ctx = new ApplicationDbContext())
            {
                profile = ctx.Profiles.Single(i => i.OwnerId == _userId);
            }

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == id);
                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Creator = profile.FirstName,
                        Subject = entity.Subject,
                        Message = entity.Message,
                        PostDate = entity.PostDate
                    };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == model.PostId);

                entity.PostId = model.PostId;
                entity.Message = model.Message;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
