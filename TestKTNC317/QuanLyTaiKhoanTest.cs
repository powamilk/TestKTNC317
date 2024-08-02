namespace TestKTNC317
{
    [TestFixture]
    public class QuanLyTaiKhoanTest
    {
        private TKManager _tkManager;
        [SetUp]
        public void SetUp()
        {
            _tkManager = new TKManager();
        }

        [Test]
        public void ThemTaiKhoan_ThongTinHopLe_ThemTaiKhoanThanhCong()
        {
            var taiKhoan = new TaiKhoan(1, "user1", "password1");
            _tkManager.ThemTaiKhoan(taiKhoan);

            var result = _tkManager.GetAllTaiKhoans().FirstOrDefault(tk => tk.ID == 1);
            Assert.IsNotNull(result);
            Assert.AreEqual("user1", result.TenDangNhap);
            Assert.AreEqual("password1", result.MatKhau);


        }

        [Test]
        public void ThemTaiKhoan_DeTrongUserName_ThongBaoLoi()
        {
            var taiKhoan = new TaiKhoan(1, "", "password1");
            Assert.Throws<Exception>(() => _tkManager.ThemTaiKhoan(taiKhoan));

        }

        [Test]
        public void ThemTaiKhoan_TenDangNhapTrung_ThongBaoLoi()
        {
            var taiKhoan1 = new TaiKhoan(1, "usser1", "password2");
            var taiKhoan2 = new TaiKhoan(2, "usser1", "password1");
            _tkManager.ThemTaiKhoan(taiKhoan1);
            Assert.Throws<Exception>(() => _tkManager.ThemTaiKhoan(taiKhoan2));
        }

        [Test]
        public void ThemTaiKhoan_MatKhauRong_ThongBaoLoi()
        {
            var taiKhoan = new TaiKhoan(1, "user1", "");
            Assert.Throws<Exception>(() => _tkManager.ThemTaiKhoan(taiKhoan));
        }

        [Test]
        public void CapNhatTaiKhoan_ThongTinHopLe_CapNhatThanhCong()
        {
            var taiKhoan = new TaiKhoan(1, "user1", "password1");
            _tkManager.ThemTaiKhoan(taiKhoan);
            _tkManager.CapNhatTaiKhoan(1, "user1", "password1");

            var result = _tkManager.GetAllTaiKhoans().FirstOrDefault(tk => tk.ID == 1);
            Assert.IsNotNull(result);
            Assert.AreEqual("userUpdated", result.TenDangNhap);
            Assert.AreEqual("passwordUpdate", result.MatKhau);
        }

        [Test]
        public void CapNhatTaiKhoan_TenDangNhapRong_ThongBaoLoi()
        {
            var taiKhoan = new TaiKhoan(1, "", "password");
            _tkManager.ThemTaiKhoan(taiKhoan);
            Assert.Throws<Exception>(() => _tkManager.CapNhatTaiKhoan(1, "", "password"));
        }

        [Test]
        public void CapNhatTaiKhoan_MatKhauRong_ThongBaoLoi()
        {
            var taiKhoan = new TaiKhoan(1, "user1", "");
            _tkManager.ThemTaiKhoan(taiKhoan);
            Assert.Throws<Exception>(() => _tkManager.CapNhatTaiKhoan(1, "user1", ""));
        }

        [Test]
        public void CapNhatTaiKhoan_TenDangNhapTrung_ThongBaoLoi()
        {
            var taiKhoan1 = new TaiKhoan(1, "usser1", "password2");
            var taiKhoan2 = new TaiKhoan(2, "usser2", "password1");
            _tkManager.ThemTaiKhoan(taiKhoan1);
            _tkManager.ThemTaiKhoan(taiKhoan2);
            Assert.Throws<Exception>(() => _tkManager.CapNhatTaiKhoan(2, "usser1", "password2"));
        }

        [Test]
        public void XoaTaiKhoan_IDHopLe_XoaTaiKhoanThanhCong()
        {
            var taiKhoan = new TaiKhoan(1, "user1", "password1");
            _tkManager.ThemTaiKhoan(taiKhoan);
            _tkManager.XoaTaiKhoan(1);
            var result = _tkManager.GetAllTaiKhoans().FirstOrDefault(tk => tk.ID == 1);
            Assert.IsNull(result);
        }

        [Test]
        public void ThemTaiKhoan_TenDangNhapVaMatKhauTaiGioiHan_ThemThanhCong()
        {
            var tenDangNhapMax = new string('a', 15);
            var matKhauMax = new string('b', 20);
            var taiKhoan = new TaiKhoan(1, tenDangNhapMax, matKhauMax);
            _tkManager.ThemTaiKhoan(taiKhoan);
            var result = _tkManager.GetAllTaiKhoans().FirstOrDefault(tk => tk.ID == 1);
            Assert.IsNotNull(result);
            Assert.AreEqual(tenDangNhapMax, result.TenDangNhap);
            Assert.AreEqual(matKhauMax, result.MatKhau);

        }


        [Test]
        public void ThemTaiKhoan_TenDangNhapRongVaMatKhauToiGioiHan()
        {
            var matKhauMax = new string('b', 20);
            var taiKhoan = new TaiKhoan(2, "", matKhauMax);
            Assert.Throws<Exception>(() => _tkManager.ThemTaiKhoan(taiKhoan));
        }

        [Test]
        public void ThemTaiKhoan_TenDangNhapToiGioiHanVaMatKhauRong()
        {
            var taiKhoanMax = new string('a', 15);
            var taiKhoan = new TaiKhoan(1, taiKhoanMax, "");
            Assert.Throws<Exception>(() => _tkManager.ThemTaiKhoan(taiKhoan));
        }

        [Test]
        public void ThemTaiKhoan_TenDangNhapVaMatKhauToiGioiHan_IDAm()
        {
            var tenDangNhapMax = new string('a', 15);
            var matKhauMax = new string('b', 20);
            var taiKhoan = new TaiKhoan(-1, tenDangNhapMax, matKhauMax);
            Assert.Throws<Exception>(() => _tkManager.ThemTaiKhoan(taiKhoan));
        }

        [Test]
        public void CapNhatTaiKhoan_MatKhauVaTaiKhoanToiGioiHan()
        {
            var taiKhoan = new TaiKhoan(1, "user1", "password2");
            _tkManager.ThemTaiKhoan(taiKhoan);

            var tenDangNhapMax = new string('a', 15);
            var matKhauMax = new string('b', 20);
            _tkManager.CapNhatTaiKhoan(1, tenDangNhapMax, matKhauMax);

            var result = _tkManager.GetAllTaiKhoans().FirstOrDefault(tk => tk.ID == 1);
            Assert.IsNotNull(result);
            Assert.AreEqual(tenDangNhapMax, result.TenDangNhap);
            Assert.AreEqual(matKhauMax, result.MatKhau);
        }

        [Test]
        public void CapNhatTaiKhoan_TenDangNhapGioiHanVaMatKhauRong()
        {
            var taiKhoan = new TaiKhoan(1, "user1", "");
            _tkManager.ThemTaiKhoan(taiKhoan);
            var tenDangNhapMax = new string('a', 15);
            _tkManager.CapNhatTaiKhoan(1, tenDangNhapMax, "");
            var result = _tkManager.GetAllTaiKhoans().FirstOrDefault(tk => tk.ID == 1);
            Assert.IsNotNull(result);
            Assert.AreEqual(tenDangNhapMax, result.TenDangNhap);
            Assert.AreEqual("", result.MatKhau);
        }

        [Test]
        public void CapNhatTaiKhoan_TenDangNhapRongVaMatKhauGioiHan()
        {
            var taiKhoan = new TaiKhoan(1, "", "password2");
            _tkManager.ThemTaiKhoan(taiKhoan);

            var matKhauMax = new string('b', 20);
            _tkManager.CapNhatTaiKhoan(1, "", matKhauMax);
            var result = _tkManager.GetAllTaiKhoans().FirstOrDefault(tk => tk.ID == 1);
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.TenDangNhap);
            Assert.AreEqual(matKhauMax, result.MatKhau);
        }

        [Test]

        public void XoaTaiKhoan_IdKhongTonTai()
        {
            var taiKhoan1 = new TaiKhoan(5, "usser1", "password2");
            var taiKhoan2 = new TaiKhoan(6, "usser2", "password1");
            _tkManager.ThemTaiKhoan(taiKhoan1);
            _tkManager.ThemTaiKhoan(taiKhoan2);
            _tkManager.XoaTaiKhoan(10);

            var danhSach = _tkManager.GetAllTaiKhoans();
            Assert.AreEqual(2, danhSach.Count);
        }



    }
}
