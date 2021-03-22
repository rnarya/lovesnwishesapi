using Lovesnwishes.DataBase;
using Lovesnwishes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lovesnwishes.BusniessLogic
{
    public class FeedService
    {
        lovesnwishesEntities objobjlovesnwishesEntities = new lovesnwishesEntities();
        public FeedReponse GetFeed(int feedId)
        {
            FeedReponse objFeedReponse = new FeedReponse();
            try
            {
                var query = objobjlovesnwishesEntities.tblFeeds.Where(x => x.Id == feedId).FirstOrDefault();
                if (query != null)
                {
                    objFeedReponse = new FeedReponse()
                    {
                        CreatedDate = query.CreateDate,
                        FeedType = query.FeedType.Value,
                        Status = query.Feed,
                        UniqueId = query.MediaFolder,
                        mediaJson=query.MediaContent
                    };

                }
            }
            catch (Exception ex)
            {

            }
            return objFeedReponse;
        }

        public FeedReponse PostFeed(Feed feed)
        {
            FeedReponse objFeedReponse = new FeedReponse();
            try
            {
                tblFeed objtblFeed = new tblFeed()
                {
                    CreateDate = DateTime.UtcNow,
                    FeedType = 1,
                    CreatedBy = feed.CreatedBy,
                    Feed = feed.Status,
                    MediaFolder = feed.UniqueId,
                    IsDeleted = false,
                    MediaContent = feed.mediaJson
                };
                objobjlovesnwishesEntities.tblFeeds.Add(objtblFeed);
                objobjlovesnwishesEntities.SaveChanges();
                objFeedReponse.Id = objtblFeed.Id;
                objFeedReponse.UniqueId = objtblFeed.MediaFolder;
            }

            catch (Exception ex)
            {
                objFeedReponse.Id = 0;
            }
            return objFeedReponse;
        }

        public List<FeedReponse> GetFeedList(int UserId)
        {
            List<FeedReponse> listFeedReponse = new List<FeedReponse>();
            try
            {
                var query = objobjlovesnwishesEntities.tblFeeds.ToList();
                listFeedReponse = (from ff in query
                                   select new FeedReponse
                                   {
                                       Id = ff.Id,
                                       CreatedDate = ff.CreateDate,
                                       FeedType = ff.FeedType.Value,
                                       Status = ff.Feed,
                                       UniqueId = ff.MediaFolder,
                                       mediaJson = ff.MediaContent,
                                       UserDetail = objobjlovesnwishesEntities.tblUsers.Where(x => x.Id == ff.CreatedBy).Select(x => new User
                                       {
                                           Email = x.Email,
                                           FirstName = x.FirstName,
                                           LastName = x.LastName,
                                           ProfileImageUrl = x.ProfileImageUrl,
                                           ID = x.Id

                                       }).FirstOrDefault(),
                                       CommentList = (from cm in objobjlovesnwishesEntities.tblComments
                                                      where cm.FeedId == ff.Id
                                                      select new CommentModel
                                                      {
                                                          Comment = cm.Comment,
                                                          CommentedBy = cm.CommentedBy,
                                                          FeedId = cm.FeedId,
                                                          Id = cm.Id,
                                                          UserDetail = objobjlovesnwishesEntities.tblUsers.Where(x => x.Id == cm.CommentedBy).Select(x => new User
                                                          {
                                                              Email = x.Email,
                                                              FirstName = x.FirstName,
                                                              LastName = x.LastName,
                                                              ProfileImageUrl = x.ProfileImageUrl,
                                                              ID = x.Id

                                                          }).FirstOrDefault()
                                                      }).ToList()
                                   }).OrderByDescending(x=>x.Id).ToList();
            }
            catch (Exception ex)
            {

            }
            return listFeedReponse;
        }
    }
}