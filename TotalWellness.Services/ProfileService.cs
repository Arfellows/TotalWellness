using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalWellness.Data;
using TotalWellness.Models;

namespace TotalWellness.Services
{
    public class ProfileService
    {
        private readonly Guid _userId;

        public ProfileService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProfile(ProfileCreate model)
        {
            Random num = new Random();
            int teamId = num.Next(1, 6);

            var entity =
                new Profile()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DOB = model.DOB,
                    TeamId = teamId,
                    Email = model.Email                   
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProfileListItem> GetProfiles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Profiles
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProfileListItem
                                {
                                    ProfileId = e.ProfileId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName
                                }
                        );
                return query.ToArray();
            }
        }

        public ProfileDetail GetProfileById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.ProfileId == id && e.OwnerId == _userId);
                return
                    new ProfileDetail
                    {
                        ProfileId = entity.ProfileId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        DOB = entity.DOB,
                        Email = entity.Email
                    };
            }
        }

        public bool UpdateProfile(ProfileEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.ProfileId == model.ProfileId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProfile(int profileId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.ProfileId == profileId && e.OwnerId == _userId);

                ctx.Profiles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }
}
