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

        public NguoiDung GetByID(string userName)
        {
            return db.NguoiDungs.SingleOrDefault(p => p.TenDangNhap == userName);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.NguoiDungs.SingleOrDefault(p => p.TenDangNhap == userName);
            if (result == null)
            {
                //Tài khoản không tồn tại
                return 0;
            }
            else
            {
                if (result.TrangThai == false)
                {
                    //Tài khoản đã bị vô hiệu hóa
                    return -1;

                }
                else
                {
                    if (result.MatKhau == passWord)
                    {
                        //Đúng
                        return 1;
                    }
                    else
                    {
                        //Sai mật khẩu
                        return -2;
                    }
                }
            }
        }
    }
}