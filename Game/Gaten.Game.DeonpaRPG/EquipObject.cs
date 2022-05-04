using System;
using System.Collections.Generic;

namespace Gaten.Game.DeonpaRPG
{
    class EquipObject
    {
        public enum EquipObjectTypes { Gun, Armor, Necklace, Avatar, Pendant, Others, AbilityStone, Potion };
        public EquipObjectTypes type;
        public string name;
        public int level;
        public long price;
        public int weight;
        public Ability effect;

        public EquipObject()
        {

        }

        public EquipObject(EquipObjectTypes type, string name, int level, long price, int weight, Ability effect)
        {
            this.type = type;
            this.name = name;
            this.level = level;
            this.price = price;
            this.weight = weight;
            this.effect = effect;
        }

        public void ShowDescription()
        {
            Character character = Character.GetInstance();

            Console.WriteLine($"==={name}===");
            Console.WriteLine($"레벨 {level}");
            Console.WriteLine($"{weight}kg");

            if (effect.attack != 0)
                Console.WriteLine($"공격력 +{effect.attack}");
            if (effect.attackSpeed != 0)
                Console.WriteLine($"공격속도 +{effect.attackSpeed}");
            if (effect.defense != 0)
                Console.WriteLine($"방어력 +{effect.defense}");
            if (effect.specialDefense != 0)
                Console.WriteLine($"특수방어력 +{effect.specialDefense}");
            if (effect.hp.max != 0)
                Console.WriteLine($"HP +{effect.hp.max}");
            if (effect.mp.max != 0)
                Console.WriteLine($"MP +{effect.mp.max}");
            if (effect.hpRecovery != 0)
                Console.WriteLine($"HP회복 +{effect.hpRecovery}");
            if (effect.mpRecovery != 0)
                Console.WriteLine($"MP회복 +{effect.mpRecovery}");
            if (effect.inventoryWeight.max != 0)
                Console.WriteLine($"인무 +{effect.inventoryWeight.max}kg");
            if (effect.expBonus != 0)
                Console.WriteLine($"Exp +{effect.expBonus}%");
            if (effect.goldBonus != 0)
                Console.WriteLine($"골드 +{effect.goldBonus}%");
            if (effect.spBonus != 0)
                Console.WriteLine($"Sp획득 +{effect.spBonus}%");
            if (effect.hpInstantRecovery != 0)
                Console.WriteLine($"HP {effect.hpInstantRecovery} 회복 (현재HP {character.ability.hp.current}/{character.ability.hp.max})");
            if (effect.mpInstantRecovery != 0)
                Console.WriteLine($"MP {effect.mpInstantRecovery} 회복 (현재MP {character.ability.mp.current}/{character.ability.mp.max})");

            try
            {
                foreach (KeyValuePair<string, int> temp in effect.effectDict)
                    if (temp.Key.Length == 2)
                        Console.WriteLine($"{character.skilldb.GetSkill(temp.Key).name} Lv +{temp.Value}");
            }
            catch
            {

            }
            

            Console.WriteLine($"{price}골드 (현재골드 {character.gold})");
        }
    }

    class EODB
    {
        public EquipObject[] equipObjects = new EquipObject[1000];
        public int equipObjectCount = 0;

        private static EODB instance = new EODB();

        private EODB()
        {
            // a:공 d:방 c:특방 w:인무 t:공속 h:HP m:MP r:HP회복 v:MP회복 e:EXP획 g:골드획 s:SP획
            // 기본
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "기본총", 0, 0, 0, new Ability());
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "기본갑옷", 0, 0, 0, new Ability());
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "기본목걸이", 0, 0, 0, new Ability());
            AddEquipObject(EquipObject.EquipObjectTypes.Avatar, "기본아바타", 0, 0, 0, new Ability());
            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "기본펜던트", 0, 0, 0, new Ability());
            AddEquipObject(EquipObject.EquipObjectTypes.Others, "기본기타", 0, 0, 0, new Ability());
            AddEquipObject(EquipObject.EquipObjectTypes.AbilityStone, "기본능력의돌", 0, 0, 0, new Ability());

            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "낡은구식총", 3, 100, 1, new Ability("a16"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "낡은총", 8, 300, 1, new Ability("a26"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "구식총", 12, 750, 1, new Ability("a38w1"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "정교한총", 18, 1600, 1, new Ability("a56w1"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "구식 포터블", 20, 2200, 1, new Ability("a72"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "포터블", 26, 3000, 2, new Ability("a105t-5"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "구식 라이징건", 30, 10000, 2, new Ability("a138t2w3h10"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "견고한 메이식건", 40, 22000, 4, new Ability("a286t1h28"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "초급건", 50, 30000, 8, new Ability("a425h35"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "중급건", 60, 40000, 10, new Ability("a465h45"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "상급건", 70, 60000, 13, new Ability("a525h58m12w5"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "망가진건", 80, 20000, 12, new Ability("a435h8"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "핸드 리볼버", 80, 90000, 15, new Ability("a538h72m48w6"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "망가진 리트피터", 90, 120000, 18, new Ability("a688h86m52w5"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "구식 피트리볼버", 100, 200000, 21, new Ability("a875h105m76w5t3"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "오리할콘건", 110, 220000, 25, new Ability("a1012h106m82"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "스틸건", 120, 50000, 20, new Ability("a855h15t1"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "구식 오리할콘건", 120, 300000, 28, new Ability("a1016h158m124"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "견고한 오리할콘건", 130, 360000, 30, new Ability("a1285h172m138t3au3")); // 레어슈타+3
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "망가진 오리할콘건", 140, 580000, 32, new Ability("a2085h305m205t5w10"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "단단한 오리할콘건", 150, 900000, 36, new Ability("a2885h553m475t8w12"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "하이로우 오리할콘건", 160, 1200000, 38, new Ability("a3955h852m684t12w2"));

            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-1", 170, 2000000, 42, new Ability("a5255h1075m868t15w4"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-2", 180, 2500000, 43, new Ability("a6538h1285m926t16"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-3", 190, 2650000, 45, new Ability("a6688h1352m1000t18"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-4", 200, 3300000, 46, new Ability("a9842h1865m1538t20"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-5", 220, 4000000, 48, new Ability("a16585h1857m1625t20w5")); // 중스+3
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-6", 240, 5000000, 52, new Ability("a25852h2545m2085t21w6"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-7", 260, 6100000, 56, new Ability("a43852h3255m3080t22w8"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-8", 280, 7000000, 62, new Ability("a68200h4085m3822t25w10"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-9", 300, 10500000, 68, new Ability("a96852h7851m6531t32w20d7552c6852"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-10", 320, 10000000, 64, new Ability("a98572h8052m7215t35w15"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-11", 340, 11000000, 67, new Ability("a126585h8053m7216t36w18"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-12", 360, 12500000, 68, new Ability("a182542h8525m7865t38w20"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-13", 380, 14000000, 71, new Ability("a205248h10542m8642t40w20"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "M-14", 400, 20000000, 75, new Ability("a253200h20500m20300t45w20"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "레인져-1", 450, 25000000, 78, new Ability("a223250h42650m18500t40w25"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "레인져-2", 480, 28500000, 82, new Ability("a287654h50250m20450t42w30"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "레인져-3", 500, 38000000, 88, new Ability("a321542h87520m23525t43w30"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "런쳐-1", 450, 22500000, 79, new Ability("a382526h20000m20000t40w20"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "런쳐-2", 480, 35000000, 85, new Ability("a852765h30000m30000t38w22"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "런쳐-3", 500, 60000000, 95, new Ability("a2000054h40000m40000t35w23"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "홀리우즈-1", 450, 21500000, 70, new Ability("a184254h18000m38000t45w20"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "홀리우즈-2", 480, 27000000, 71, new Ability("a190000h19000m62000t46w20"));
            AddEquipObject(EquipObject.EquipObjectTypes.Gun, "홀리우즈-3", 500, 30000000, 72, new Ability("a190000h20000m125000t48w22"));

            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "레지스트링", 3, 50, 1, new Ability("d22"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "레지스트링2", 9, 400, 1, new Ability("d48"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "레지스트링3", 15, 800, 2, new Ability("d76"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "레지스트링4", 22, 2500, 2, new Ability("d106c85"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "레지스트링5", 28, 3000, 3, new Ability("d128h6"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "구식 링메일", 30, 8000, 4, new Ability("d175h15"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "견고한 링", 40, 20000, 6, new Ability("d400h38"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "초급 링메일", 50, 30000, 12, new Ability("d688h48"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "중급 링메일", 60, 45000, 15, new Ability("d1285h50"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "상급 링메일", 70, 75000, 20, new Ability("d1583h52m25t5"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "해브 메일", 80, 30000, 18, new Ability("d1258h12t-3"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "미스릴 링메일", 80, 120000, 6, new Ability("d1854h65m48"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "견고한 미스릴 링메일", 90, 150000, 6, new Ability("d2285h66m49"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "상급 미스릴 링메일", 100, 250000, 6, new Ability("d2785h108m78t8w7"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "다이아몬드 링메일", 110, 280000, 6, new Ability("d3255h110m80t9w3"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "견고한 메일", 120, 90000, 25, new Ability("d3007h17m8"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "구식 다이아몬드 링메일", 120, 350000, 6, new Ability("d3344h148m126t10w8"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "견고한 다이아몬드 링메일", 130, 500000, 6, new Ability("d3854c1726h165m148t12w10a125"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "망가진 다이아몬드 링메일", 140, 20000, 6, new Ability("d3965c1824h178m182w10a145"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "단단한 다이아몬드 링메일", 150, 20000, 6, new Ability("d4558c3258h205m208t-8w5a205"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "하이로우 다이아몬드 링메일", 160, 20000, 6, new Ability("d6250c-1000h405m608t-12w-7a325"));

            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-1", 170, 1350000, 42, new Ability("d9685c8864h425m625t-12w-10a-165"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-2", 180, 1600000, 43, new Ability("d10854c9652h468m752t-15w-15a-185"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-3", 190, 1800000, 44, new Ability("d8726c6684h508m884t-15w5a205"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-4", 200, 2500000, 46, new Ability("d12585c8500h685m1025t5w10a225"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-5", 220, 3800000, 47, new Ability("d16425c14845h1250m1028t5w15a265"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-6", 240, 4800000, 51, new Ability("d18425c16252h1420m1085t-1w15a325"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-7", 260, 6000000, 55, new Ability("d25243c22435h1455m1095t-5w25a465"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-8", 280, 6500000, 60, new Ability("d26855c23255h1625m1615t-8w30a485"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-9", 300, 7000000, 68, new Ability("d40852c36525h1685m1425t-25w25a725"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-10", 320, 8500000, 72, new Ability("d60250c56425h1825m1725t25w25a865"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-11", 340, 10000000, 76, new Ability("d88625c76524h2065m2032t35w26a1255"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-12", 360, 14000000, 80, new Ability("d90000c80000h5826m5265t35w25a3085"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-13", 380, 14000000, 86, new Ability("d92500c85500h5826m5265t36w26a3005"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "플레이트아머 G-14", 400, 18500000, 88, new Ability("d187525c164254h7255m6845t38w35a3255"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "통합갑옷-1", 450, 25000000, 93, new Ability("d252428c224845h8652m7685t40w36a4525"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "통합갑옷-2", 480, 27000000, 98, new Ability("d382545c364252h8652m7685t40w38a8525"));
            AddEquipObject(EquipObject.EquipObjectTypes.Armor, "통합갑옷-3", 500, 30000000, 105, new Ability("d862545c842425h8652m7686t42w40a20565"));

            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "목걸이", 3, 60, 1, new Ability("d34"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "목걸이2", 6, 150, 1, new Ability("d62"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "목걸이3", 16, 1800, 1, new Ability("d175c172h8"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "목걸이4", 18, 700, 1, new Ability("d162"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "목걸이5", 21, 3000, 1, new Ability("d258h12m8w2"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "목걸이6", 26, 4000, 1, new Ability("d324h13m9w3"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "목걸이7", 28, 5200, 2, new Ability("d362h15m9w4a6"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "구식 목걸이", 30, 9800, 2, new Ability("d405c328w2a15h17m12"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "견고한 목걸이", 40, 25000, 4, new Ability("d808c655w4a25h24m35"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "초급 목걸이", 50, 50000, 10, new Ability("d1288c975h31m45a35"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "중급 목걸이", 60, 70000, 15, new Ability("d1648c1250h36m48a55"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "상급 목걸이", 70, 100000, 20, new Ability("d1752c1285h65m67a85t6"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "화염의 비노슈타 목걸이", 80, 15000, 19, new Ability("d1352m6t1w5"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "토파즈 목걸이", 80, 150000, 22, new Ability("d1886c1385h75m77a125"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "구식 토파즈 목걸이", 90, 200000, 24, new Ability("d2525c1728h76m78a135"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "견고한 토파즈 목걸이", 100, 330000, 28, new Ability("d2788c2648h88m102a155t5w7as2")); // 양자폭탄2 +2
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "자수정 목걸이", 110, 300000, 30, new Ability("d3050c2855h90m105a155"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "흑룡의 목걸이", 120, 100000, 25, new Ability("d2050c555h25m18w4"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "구식 자수정 목걸이", 120, 400000, 33, new Ability("d3078c2922h128m142a185w6as5au5")); // 양자2+5, 레슈+5
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "견고한 자수정 목걸이", 130, 550000, 38, new Ability("d4255c3685h154m170a255t10w8"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "망가진 자수정 목걸이", 140, 620000, 39, new Ability("d4825c4055h168m172a285t12w8"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "단단한 자수정 목걸이", 150, 750000, 40, new Ability("d6258c5245h175m183a305t12w12"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "하이로우 자수정 목걸이", 160, 930000, 42, new Ability("d8325c6545h208m232a365t13w15")); // 라마건M-19 +5

            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-1", 170, 1200000, 45, new Ability("d8625c7248h225m245a455t14w20")); // 스틸바베큐+20
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-2", 180, 1500000, 44, new Ability("d12655h260m285w25")); // 스바+50 순중+20 레갠+30
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-3", 190, 2500000, 45, new Ability("d17265h385m362w30")); // 레갠+50 레일1 +100 레일2 +80 레일3 +50
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-4", 200, 3200000, 48, new Ability("d20500h480m425w35")); // 레일2+200 레일3+150 파스+10 중스+5
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-5", 220, 3800000, 50, new Ability("d20800h980m860w38")); // 파스+12 중스+8
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-6", 240, 5500000, 52, new Ability("d38652c29654h2856m3254a1025t3w42"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-7", 260, 6100000, 56, new Ability("d42185c32645h3025m3285a1085t4w45"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-8", 280, 6500000, 62, new Ability("d48525c36253h3026m3325a1205t5w45"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-9", 300, 8000000, 66, new Ability("d82554c69425h3085m3265a1605t15w55"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-10", 320, 9000000, 70, new Ability("d86554c82488h3265m3248a1805t18w60"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-11", 340, 10500000, 75, new Ability("d87250c86542h3685m3545a2605t22w70"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-12", 360, 15000000, 76, new Ability("d187255c164255h3825m3765a3205t20w80"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-13", 380, 15000000, 75, new Ability("d187256c164256h3825m3765a3255t22w75"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "N-14", 400, 18000000, 80, new Ability("d187266c164532h8825m7965a3455t25w80"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "통합목걸이-1", 450, 23000000, 85, new Ability("d187266c164532h20452m18325a3655t25w82"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "통합목걸이-2", 480, 35000000, 92, new Ability("d364252c342588h20452m18325a8255t30w85"));
            AddEquipObject(EquipObject.EquipObjectTypes.Necklace, "통합목걸이-3", 500, 60000000, 98, new Ability("d725425c704824h20452m18325a15255t35w90"));

            AddEquipObject(EquipObject.EquipObjectTypes.Avatar, "최하급 아바타", 18, 5500000, 0, new Ability("e100r8v8d1000h150m150a5000c4500t15w15aa5ab5ac7ad4"));
            AddEquipObject(EquipObject.EquipObjectTypes.Avatar, "하급 아바타", 48, 10350000, 0, new Ability("e100r15v15d1450h300m300a10000c9000t25w28ag7ah7ai7al5"));
            AddEquipObject(EquipObject.EquipObjectTypes.Avatar, "중급 아바타", 68, 31900000, 0, new Ability("e100r23v23d2600h1000m1000a25000c27000t50w56al14am10an9ao8"));
            AddEquipObject(EquipObject.EquipObjectTypes.Avatar, "상급 아바타", 78, 87600000, 0, new Ability("e100r32v32d4300h2300m2300a15000c40000t70w75ao20ap21aq12ar11at4"));
            AddEquipObject(EquipObject.EquipObjectTypes.Avatar, "최상급 아바타", 108, 417300000, 0, new Ability("e100r130v130d8200h11000m11000a50000c180000t126w131")); // 스킬 추가해야함

            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "HP의 펜던트", 500, 50000000000, 0, new Ability("e100g100s100h1000000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "MP의 펜던트", 500, 50000000000, 0, new Ability("e100g100s100m1000000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "공격력의 펜던트", 500, 50000000000, 0, new Ability("e100g100s100a10000000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "방어력의 펜던트", 500, 50000000000, 0, new Ability("e100g100s100d10000000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "공속의 펜던트", 500, 50000000000, 0, new Ability("e100g100s100t40"));
            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "인무의 펜던트", 500, 50000000000, 0, new Ability("e100g100s100w100"));
            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "특수방어력의 펜던트", 500, 50000000000, 0, new Ability("e100g100s100c10000000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "HP회복의 펜던트", 500, 50000000000, 0, new Ability("e100g100s100r50000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Pendant, "MP회복의 펜던트", 500, 50000000000, 0, new Ability("e100g100s100v50000"));

            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "나무열매", 1, 100, 0, new Ability("hr50"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "구식 나무열매", 3, 250, 0, new Ability("hr150"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "초급 나무열매", 5, 450, 0, new Ability("hr300"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "중급 나무열매", 8, 1000, 0, new Ability("hr750"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "고급 나무열매", 12, 1800, 0, new Ability("hr1500"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "아침의 이슬", 20, 3000, 0, new Ability("hr3000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "중급 HP포션", 38, 5800, 0, new Ability("hr6000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "마력의 꽃", 1, 150, 0, new Ability("mr50"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "구식 마력의 꽃", 3, 250, 0, new Ability("mr100"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "초급 마력의 꽃", 6, 700, 0, new Ability("mr300"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "중급 마력의 꽃", 10, 1500, 0, new Ability("mr800"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "고급 마력의 꽃", 18, 2500, 0, new Ability("mr1500"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "새벽의 이슬", 25, 4500, 0, new Ability("mr3000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "중급 MP포션", 38, 8500, 0, new Ability("mr6000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "수박", 20, 2500, 0, new Ability("hr1000mr1000"));
            AddEquipObject(EquipObject.EquipObjectTypes.Potion, "오렌지", 30, 4000, 0, new Ability("hr2000mr2000"));
        }

        public static EODB GetInstance()
        {
            return instance;
        }

        public void AddEquipObject(EquipObject.EquipObjectTypes type, string name, int level, long price, int weight, Ability effect)
        {
            equipObjects[equipObjectCount++] = new EquipObject(type, name, level, price, weight, effect);
        }

        public EquipObject Equip(string name)
        {
            return GetEquipObject(name);
        }

        public EquipObject GetEquipObject(string name)
        {
            for (int i = 0; i < equipObjectCount; i++)
                if (name == equipObjects[i].name)
                    return equipObjects[i];
            return null;
        }
    }
}
