namespace TestKTNC317
{
    public class TKManager
    {
        private List<TaiKhoan> taiKhoans = new List<TaiKhoan>();

        public void ThemTaiKhoan(TaiKhoan taiKhoan)
        {
            if (string.IsNullOrWhiteSpace(taiKhoan.TenDangNhap) || taiKhoan.TenDangNhap.Any(c => !char.IsLetterOrDigit(c)))
            {
                throw new Exception("Ten dang nhap ko duoc bo trong");
            }

            if (string.IsNullOrWhiteSpace(taiKhoan.MatKhau))
            {
                throw new Exception("Mat Khau ko duoc bo trong");
            }
            if (taiKhoans.Any(tk => tk.TenDangNhap == taiKhoan.TenDangNhap))
            {
                throw new Exception("Ten Dang Nhap bi trung ");
            }
            taiKhoans.Add(taiKhoan);
        }

        public void CapNhatTaiKhoan(int id, string newTenDangNhap, string newMatKhau)
        {
            var tk = taiKhoans.FirstOrDefault(i => i.ID == id);
            if (tk != null)
            {

                if (string.IsNullOrWhiteSpace(newTenDangNhap) || newTenDangNhap.Any(c => !char.IsLetterOrDigit(c)))
                {
                    throw new Exception("Ten dang nhap ko duoc bo trong");
                }

                if (string.IsNullOrWhiteSpace(newMatKhau))
                {
                    throw new Exception("Mat Khau ko duoc bo trong");
                }
                if (taiKhoans.Any(tk => tk.TenDangNhap == newTenDangNhap && tk.ID != id))
                {
                    throw new Exception("Ten Dang Nhap bi trung ");
                }

                tk.TenDangNhap = newTenDangNhap;
                tk.MatKhau = newMatKhau;
            }
        }

        public void XoaTaiKhoan(int id)
        {
            taiKhoans.RemoveAll(i => i.ID == id);
        }

        public List<TaiKhoan> GetAllTaiKhoans()
        {
            return taiKhoans;
        }
    }

}
