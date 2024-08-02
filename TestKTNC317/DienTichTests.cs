using TestKTNC317;

[TestFixture]
public class DienTichTests
{
    private DienTich _dienTich;

    [SetUp]
    public void Setup()
    {
        _dienTich = new DienTich();
    }

    [Test]
    public void TinhDienTich_ChieuDaiDuongAm_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _dienTich.TinhDienTich(-1, 10));
    }

    [Test]
    public void TinhDienTich_ChieuRongDuongAm_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _dienTich.TinhDienTich(10, -1));
    }

    [Test]
    public void TinhDienTich_ChieuDaiVaChieuRongDuongAm_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _dienTich.TinhDienTich(-1, -1));
    }

    [Test]
    public void TinhDienTich_ChieuDaiLonHon150_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _dienTich.TinhDienTich(151, 10));
    }

    [Test]
    public void TinhDienTich_ChieuRongLonHon150_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _dienTich.TinhDienTich(10, 151));
    }

    [Test]
    public void TinhDienTich_ChieuDaiVaChieuRongLonHon150_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _dienTich.TinhDienTich(151, 151));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang0VaChieuRongBang150_Returns0()
    {
        Assert.AreEqual(0, _dienTich.TinhDienTich(0, 150));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang150VaChieuRongBang0_Returns0()
    {
        Assert.AreEqual(0, _dienTich.TinhDienTich(150, 0));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang0VaChieuRongBang0_Returns0()
    {
        Assert.AreEqual(0, _dienTich.TinhDienTich(0, 0));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang150VaChieuRongBang150_Returns22500()
    {
        Assert.AreEqual(22500, _dienTich.TinhDienTich(150, 150));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang150VaChieuRongBang100_Returns15000()
    {
        Assert.AreEqual(15000, _dienTich.TinhDienTich(150, 100));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang1VaChieuRongBang1_Returns1()
    {
        Assert.AreEqual(1, _dienTich.TinhDienTich(1, 1));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang150VaChieuRongBang1_Returns150()
    {
        Assert.AreEqual(150, _dienTich.TinhDienTich(150, 1));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang1VaChieuRongBang150_Returns150()
    {
        Assert.AreEqual(150, _dienTich.TinhDienTich(1, 150));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang75VaChieuRongBang2_Returns150()
    {
        Assert.AreEqual(150, _dienTich.TinhDienTich(75, 2));
    }

    [Test]
    public void TinhDienTich_ChieuDaiBang2VaChieuRongBang75_Returns150()
    {
        Assert.AreEqual(150, _dienTich.TinhDienTich(2, 75));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case1()
    {
        Assert.AreEqual(30, _dienTich.TinhDienTich(6, 5));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case2()
    {
        Assert.AreEqual(0, _dienTich.TinhDienTich(0, 10));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case3()
    {
        Assert.AreEqual(300, _dienTich.TinhDienTich(15, 20));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case4()
    {
        Assert.AreEqual(22500, _dienTich.TinhDienTich(150, 150));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case5()
    {
        Assert.AreEqual(15000, _dienTich.TinhDienTich(150, 100));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case6()
    {
        Assert.AreEqual(1, _dienTich.TinhDienTich(1, 1));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case7()
    {
        Assert.AreEqual(150, _dienTich.TinhDienTich(15, 10));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case8()
    {
        Assert.AreEqual(800, _dienTich.TinhDienTich(40, 20));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case9()
    {
        Assert.AreEqual(450, _dienTich.TinhDienTich(15, 30));
    }

    [Test]
    public void TinhDienTich_ValidValues_ReturnsCorrectArea_Case10()
    {
        Assert.AreEqual(2500, _dienTich.TinhDienTich(50, 50));
    }
}
