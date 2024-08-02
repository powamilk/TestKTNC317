namespace TestKTNC317
{
    public class TaiKhoan
    {
        public int ID { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }

        public TaiKhoan(int _ID, string _TenDangNhap, string _MatKhau)
        {
            ID = _ID;
            TenDangNhap = _TenDangNhap;
            MatKhau = _MatKhau;
        }
    }

}
