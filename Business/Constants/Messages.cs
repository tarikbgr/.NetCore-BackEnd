using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
		public static string MaintenenceTime = "Sistem Bakımda";

		public static string CarAdded = "Araba Eklendi";
		public static string CarListed = "Arabalar Listelendi";
		public static string CarDeleted = "Araba Silindi";
		public static string CarUpdated = "Araba Güncellendi";
		public static string CarNameInvalid = "Araba Ürün İsmi Geçersiz";
		public static string CarDetails = "Araba Detayları Getirildi";

		public static string BrandAdded = "Marka Eklendi";
		public static string BrandListed = "Markalar Listelendi";
		public static string BrandDeleted = "Markalar Silindi";
		public static string BrandUpdated = "Markalar Güncellendi";
		public static string BrandNameInvalid = "Marka İsmi Geçersiz";

		public static string ColorAdded = "Renk Eklendi";
		public static string ColorListed = "Renk Listelendi";
		public static string ColorDeleted = "Renk Silindi";
		public static string ColorUpdated = "Renk Güncellendi";
		public static string ColorNameInvalid = "Ürün Renk İsmi Geçersiz";

		public static string ErorAdded = "Araç Henüz Teslim Edilmedi.";
		public static string SuccesRanted = "Araç  Başarıyla Kiralandı";

		public static string CarCountOFBrandId = "Bir Markada En Fazla 15 Adet araç olabilir";
		public static string CarNameAlreadyExists = "Bu Araba İsmi Zaten Var";

		public static string AuthorizationDenied = "Yetkiniz Yok";
		public static string UserRegistered = "UserRegistered";
		public static string UserNotFound = "UserNotFound";
		public static string PasswordError = "PasswordError";
		public static string UserAlreadyExists = "UserAlreadyExists";
		public static string AccessTokenCreated = "AccessTokenCreated";
		public static string SuccessfulLogin = "SuccessfulLogin";
	}
}
