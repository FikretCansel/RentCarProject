using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string Added = "Başarı ile Eklendi";
        public static string Listed = "Detaylar Başarı ile Listelendi";
        public static string Deleted = "Başarı ile silindi";
        public static string Updated = "Başarı ile Eklendi";
        public static string Maintenance = "Bakımdayız";
        public static string AddErrorfromRent = "Araç zaten kiralanmış";
        public static string MuchImageError = "Bir araba için fazla 5 resim eklebilirsiniz";
        public static string UserRegistered = "Kullanıcı başarı ile eklendi";
        internal static string SuccessfulLogin="Başarı ile giriş yapıldı";
        public static string PasswordError = "Şifre Hatalı";

        public static string AccessToken = "Access token oluşturuldu";

        public static string UserAlreadyExists = "Kullanıcı Mevcut.Başka bir email giriniz";
        public static string AuthorizationDenied = "Yetkiniz Yok";

        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
