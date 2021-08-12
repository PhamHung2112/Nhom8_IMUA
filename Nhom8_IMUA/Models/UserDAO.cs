using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Models
{
    public class UserDAO
    {
        Nhom8DB db = null;
        public UserDAO()
        {
            db = new Nhom8DB();
        }

        public long Insert(NguoiDung entity)
        {
            db.NguoiDungs.Add(entity);
            db.SaveChanges();
            return entity.MaND;
        }

        public bool CheckUserName(string userName)
        {
            return db.NguoiDungs.Count(x => x.TenDangNhap == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.NguoiDungs.Count(x => x.Email == email) > 0;
        }
    }
}