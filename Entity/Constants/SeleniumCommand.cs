using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Constants
{
    public static class SeleniumCommand
    {
        public const string TWITTER_JS_DOCUMENTISREADY_COMMAND = "return document.readyState";
        public const string TWITTER_JS_DOCUMENTISREADY_STATUS = "complete";
        public const string TWITTER_LOGIN_USERNAME_TEXT_ELEMENT_BYNAME = "text";
        public const string TWITTER_LOGIN_CONTINUE_BUTTON_ELEMENT_BYXPATH = "//div[contains(@class, 'css-901oao r-1awozwy r-6koalj r-18u37iz r-16y2uox r-37j5jr r-a023e6 r-b88u0q r-1777fci r-rjixqe r-bcqeeo r-q4m81j r-qvutc0')]";
        public const string TWITTER_LOGIN_USERPASSWORD_TEXT_ELEMENT_BYNAME = "password";
        public const string TWITTER_LOGIN_LOGIN_BUTTON_ELEMENT_BYXPATH = "//div[contains(@class, 'css-901oao r-1awozwy r-6koalj r-18u37iz r-16y2uox r-37j5jr r-a023e6 r-b88u0q r-1777fci r-rjixqe r-bcqeeo r-q4m81j r-qvutc0')]";
        public const string TWITTER_SHARE_TWEET_TEXT_ELEMENT_BYXPATH = "//div[contains(@class, 'public-DraftStyleDefault-block public-DraftStyleDefault-ltr')]";
        public const string TWITTER_SHARE_TWEET_BUTTON_ELEMENT_BYXPATH = "//div[contains(@class, 'css-18t94o4 css-1dbjc4n r-l5o3uw r-42olwf r-sdzlij r-1phboty r-rs99b7 r-19u6a5r r-2yi16 r-1qi8awa r-1ny4l3l r-ymttw5 r-o7ynqc r-6416eg r-lrvibr')]";
        public const string TWITTER_SHARE_TWEET_TEXT_SPAN_ELEMENT_BYXPATH_TWEET_TEXT_ELEMENT = "//div[contains(@class, 'public-DraftStyleDefault-block public-DraftStyleDefault-ltr')]/span/span";
        public const string TWITTER_SHARE_TWEETMEDIA_FILE_ELEMENT_BYXPATH = "//input[@type = 'file']";
        public const string TWITTER_SHARE_TWEETMEDIA_FILE_IMAGE_ELEMENT_BYXPATH = "//div[contains(@class, 'css-1dbjc4n r-15zivkp r-14gqq1x r-184en5c')]";
        public const string TWITTER_FOLLOW_FOLLOW_BUTTON_ELEMENT_BYXPATH = "//div[contains(@class,'css-1dbjc4n r-6gpygo')]";
        public const string TWITTER_ACCOUNT_CHANGE_PASSWORD_IN_REQUIRE_CHANGING_PASSWORD_BUTTON_ELEMENT_BYXPATH = "//a[contains(@class, 'Button EdgeButton EdgeButton--primary')]";
        public const string TWITTER_ACCOUNT_STATUS_ELEMENT_BYXPATH = "//span[contains(@class, 'css-901oao css-16my406 r-poiln3 r-bcqeeo r-qvutc0')]";
        public const string TWITTER_YOUR_ACCOUNT_STATUS_ELEMENT_BYPATH = "//div[contains(@class,'PageHeader Edge')]";
        public const string TWITTER_YOUR_ACCOUNT_STATUS_INLOGIN_ELEMENT_BYPATH = "//h1[contains(@class, 'css-4rbku5 css-901oao r-18jsvk2 r-37j5jr r-1yjpyg1 r-b88u0q r-ueyrd6 r-bcqeeo r-qvutc0')]";
        public const string TWITTER_YOUR_ACCOUNT_STATUS_INLOGIN_THING_REQUIRE_PHONE_NUMBER_ELEMENT_BYPATH = "//span[contains(@class, 'css-901oao css-16my406 r-poiln3 r-bcqeeo r-qvutc0')]";
        public const string TWITTER_YOUR_ACCOUNT_TEXT_INLOGIN_THING_REQUIRE_PHONE_NUMBER_ELEMENT_BYPATH = "//input[contains(@class, 'r-30o5oe r-1niwhzg r-17gur6a r-1yadl64 r-deolkf r-homxoj r-poiln3 r-7cikom r-1ny4l3l r-t60dpp r-1dz5y72 r-fdjqy7 r-13qz1uu')]";
        public const string TWITTER_YOUR_ACCOUNT_BUTTON_INLOGIN_THING_REQUIRE_PHONE_NUMBER_ELEMENT_BYPATH = "//div[contains(@class, 'css-18t94o4 css-1dbjc4n r-1m3jxhj r-sdzlij r-1phboty r-rs99b7 r-19yznuf r-64el8z r-1ny4l3l r-1dye5f7 r-o7ynqc r-6416eg r-lrvibr')]";
        public const string TWITTER_YOUR_ACCOUNT_STATUS_BLOCKED_TR = "Bazı hesap özelliklerini geçici olarak sınırladık.";
        public const string TWITTER_YOUR_ACCOUNT_STATUS_REQUIRE_CHANGING_PASSWORD_TR = "Şifre değiştirmen gerekiyor";
        public const string TWITTER_ACCOUNT_STATUS_BLOCKED_TR = "Hesap askıya alındı";
        public const string TWITTER_ACCOUNT_STATUS_BLOCKED_EN = "Account suspended";
        public const string TWITTER_ACCOUNT_STATUS_NOEXIST_TR = "Böyle bir hesap yok";
        public const string TWITTER_ACCOUNT_STATUS_NOEXIST_EN = "This account doesn’t exist";
        public const string TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_TR = "Hesabını güvende tutmamıza yardımcı ol.";
        public const string TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_REQUIRE_PHONE_NUMBER_TR = "Telefon numarası";
        public const string TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_REQUIRE_EMAIL_ADRESS_TR = "e-posta adresi";



    }
}
