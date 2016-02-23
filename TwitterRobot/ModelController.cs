using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterRobot.Model;

namespace TwitterRobot
{
    public static class ModelController
    {
        public static List<AlreadyFollowed> GetAlreadyFollowedList() 
        {
            try
            {
                using (var db = new TwitterRobotEntities()) 
                {
                    return (from m in db.AlreadyFollowed select m).ToList();
                }
            }
            catch 
            {
                return null;
            }
        }

        public static void insertUserToAlreadyFollowed(long twitterId, string twitterName)
        {
            try
            {
                using (var db = new TwitterRobotEntities())
                {
                    AlreadyFollowed info = new AlreadyFollowed();
                    info.twitterID = twitterId;
                    info.twitterName = twitterName;
                    info.followDate = DateTime.Now;
                    db.AlreadyFollowed.Add(info);
                    db.SaveChanges();
                }
            }
            catch { }
        }
    }
}
