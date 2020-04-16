using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace demo.Bo
{
    public class UserBo
    {
        public static Models.DemoEntities.DemoContext db = new Models.DemoEntities.DemoContext();

        /// <summary>
        /// 增加用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Models.User.AddUserR AddUser(Models.User.AddUserP model)
        {
            var r = new Models.User.AddUserR();
            Models.DemoEntities.User userSearch = (from u in db.User where u.Phone == model.phone select u).FirstOrDefault();
            if (userSearch == null)
            {
                Models.DemoEntities.User user = new Models.DemoEntities.User
                {
                    id = model.id,
                    Phone = model.phone,
                    Password = model.password,
                    NickName = model.nickName,
                    State = model.state
                };
                db.User.Add(user);
                int i = db.SaveChanges();
                if (i > 0)
                {
                    r.code = 1;
                    r.message = "数据插入成功";
                }
                else
                {
                    r.code = 0;
                    r.message = "数据插入成功";
                }
            }
            else
            {
                r.code = 0;
                r.message = "手机号已经存在";
            }
            return r;
        }
        public static Models.User.AddUserR RemoveUser(Models.User.AddUserP model)
        {
            var r = new Models.User.AddUserR();
            Models.DemoEntities.User userSearch = (from u in db.User where u.id == model.id select u).FirstOrDefault();
            if (userSearch == null)
            {
                Models.DemoEntities.User user = new Models.DemoEntities.User
                {
                    id = model.id,
                    //Phone = model.phone,
                    Password = model.password,
                    NickName = model.nickName,
                    State = model.state
                };
                db.User.Remove(user);
            }
           
                return r;
            }
    }
}
