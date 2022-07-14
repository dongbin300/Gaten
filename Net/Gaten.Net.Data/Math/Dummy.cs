using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Data.Math
{
    public class Dummy
    {
        private static readonly string KoreanLastName = "김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김김이이이이이이이이이이이이이이이이이이이이이이이이이이이이이이이이이이이이이박박박박박박박박박박박박박박박박박박박박박최최최최최최최최최최최최정정정정정정정정정정정강강강강강강조조조조조윤윤윤윤윤장장장장장임임임임한한한한오오오오서서서서신신신신권권권권황황황안안안송송송류류류전전전홍홍홍고고문문양양손손배배조조백백허허유유남심노정하곽성차주우구신임라전민유진지엄채원천";
        private static readonly string KoreanFirstName = "민준서연서준서윤도윤지우예준서현시우하은하준하윤주원민서지호지유지후윤서준우지민준서채원건우수아도현지아현우지윤지훈은서우진다은선우예은서진수빈유준지안연우소율민재예린현준예원은우하린정우지원시윤소윤승우서아승현시은준혁유나지환유진윤우채은승민윤아유찬가은지우서영이준민지민성예진준영예나시후수민진우수연수호연우지원시아수현아린재윤예서시현주아동현하율태윤시연이안연서민규다인한결서우재원유주민우다연재민아인은찬현서윤호아윤시원서은민찬채윤지안하연시온서율성민서진준호유빈승준나윤성현지율현서나은재현수현하율예지지한다현우빈서하태민소은지성나연예성지은민호민주태현사랑지율시현서우예빈민혁윤지은호지현성준소연규민채아정민혜원지수지민은채윤성주하승아윤재다윤우주소민하람서희하진나현민석채린준수민아은성하영태양세아예찬세은준희도연도훈규리하민아영준성다온가윤지완지연현수예림승원태희강민민채";
        private static SmartRandom random = new();

        public static bool OfBool() => random.Next(2) == 0;
        public static short OfShort() => (short)random.Next(short.MaxValue);
        public static int OfInt() => random.Next(int.MaxValue);
        public static string OfKoreanName() => KoreanLastName[random.Next(KoreanLastName.Length)].ToString() + KoreanFirstName[(random.Next(KoreanFirstName.Length) / 2) * 2].ToString() + KoreanFirstName[(random.Next(KoreanFirstName.Length) / 2) * 2 + 1].ToString();
        public static DateTime OfDate(DateTime startDate) => startDate.AddDays(random.Next((int)(DateTime.UtcNow - startDate).TotalDays));
        public static DateTime OfDateTime(DateTime startDateTime) => startDateTime.AddSeconds(random.Next((int)(DateTime.UtcNow - startDateTime).TotalSeconds));
        public static string OfIpv4() => random.Next(256).ToString() + random.Next(256).ToString() + random.Next(256).ToString() + random.Next(256).ToString();
        public static string OfIpv6() => random.Next(65536).ToString("X4") + ":" + random.Next(65536).ToString("X4") + ":" + random.Next(65536).ToString("X4") + ":" + random.Next(65536).ToString("X4") + ":" + random.Next(65536).ToString("X4") + ":" + random.Next(65536).ToString("X4") + ":" + random.Next(65536).ToString("X4") + ":" + random.Next(65536).ToString("X4");
        public static string OfPhoneNumber() => "010-" + (random.Next(9000) + 1000).ToString() + "-" + (random.Next(9000) + 1000).ToString();
        public static string OfDigit(int digit) => (random.Next((int)(System.Math.Pow(10, digit) - System.Math.Pow(10, digit - 1))) + System.Math.Pow(10, digit - 1)).ToString();
    }
}
