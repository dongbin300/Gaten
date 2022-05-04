namespace Gaten.Game.DeonpaRPG
{
    class Deongeon
    {
        public string name;
        public int startLevel;
        public int minLevel;
        public int maxLevel;
        public Monster[] monsters = new Monster[100];
        public int monsterCount = 0;

        public Deongeon(string name, int startLevel, int minLevel, int maxLevel)
        {
            this.name = name;
            this.startLevel = startLevel;
            this.minLevel = minLevel;
            this.maxLevel = maxLevel;
        }

        public void AddMonster(string name, int level, long hp, long gold, long exp, int sp)
        {
            monsters[monsterCount++] = new Monster(name, level, hp, gold, exp, sp);
        }

        public Monster CreateMonster(string name)
        {
            Monster monster = new Monster();
            for (int i = 0; i < monsterCount; i++)
            {
                if (monsters[i].name == name)
                {
                    monster.name = name;
                    monster.level = monsters[i].level;
                    monster.hpMax = monsters[i].hpMax;
                    monster.hpCur = monster.hpMax;
                    monster.gold = monsters[i].gold;
                    monster.exp = monsters[i].exp;
                    monster.sp = monsters[i].sp;
                    monster.attack = monsters[i].attack;
                    break;
                }
            }
            return monster;
        }
    }

    class DeongeonDB
    {
        public Deongeon human = new Deongeon("휴먼", 0, 1, 100);
        public Deongeon goblinWorld = new Deongeon("고블린나라", 0, 1, 170);
        public Deongeon templeSuburb = new Deongeon("신전외곽", 80, 90, 130);
        public Deongeon templeInside = new Deongeon("신전내부", 100, 120, 180);
        public Deongeon thiefHideout = new Deongeon("도둑아지트", 150, 200, 501);
        public Deongeon fairytaleWorld = new Deongeon("동화나라", 60, 88, 288);
        public Deongeon hiddenMap1 = new Deongeon("히든맵1", 400, 450, 501);
        public Deongeon hiddenMap2 = new Deongeon("히든맵2", 410, 460, 501);
        public Deongeon thunderGentlemanLodging = new Deongeon("썬더젠틀맨의숙소", 501, 501, 501);
        public Deongeon headSpinLodging = new Deongeon("헤드스핀의숙소", 501, 501, 501);
        public Deongeon deongeonCorner = new Deongeon("던전길목", 501, 501, 501);

        private static DeongeonDB instance = new DeongeonDB();

        private DeongeonDB()
        {
            human.AddMonster("고블린", 1, 20, 18, 25, 0);
            human.AddMonster("고블린투석십장", 2, 45, 22, 35, 0);
            human.AddMonster("시가브", 3, 65, 26, 45, 0);
            human.AddMonster("타우아미", 3, 85, 28, 50, 0);
            human.AddMonster("프리그", 6, 175, 38, 92, 1);
            human.AddMonster("플래그", 7, 200, 40, 100, 1);
            human.AddMonster("타우비스트", 8, 250, 42, 123, 1);
            human.AddMonster("그라이크", 11, 368, 56, 164, 1);
            human.AddMonster("타우라우", 14, 482, 68, 200, 1);
            human.AddMonster("아미노스", 17, 605, 82, 238, 1);
            human.AddMonster("레피큐스", 20, 750, 95, 280, 1);
            human.AddMonster("아스마이어", 22, 920, 110, 330, 2);
            human.AddMonster("노스큘", 24, 1000, 122, 350, 2);
            human.AddMonster("스팅어", 30, 1685, 140, 388, 3);
            human.AddMonster("레이져", 38, 2172, 187, 452, 3);
            human.AddMonster("라이플", 45, 2685, 215, 500, 4);
            human.AddMonster("니구", 55, 4072, 248, 585, 4);
            human.AddMonster("너는?", 56, 8854, 250, 600, 4);
            human.AddMonster("나도?", 60, 11000, 302, 653, 4);
            human.AddMonster("너도?", 68, 28500, 417, 835, 5);
            human.AddMonster("ㅋㅋ", 72, 35300, 465, 920, 5);
            human.AddMonster("슈타이어", 76, 42800, 510, 1000, 6);
            human.AddMonster("레깅노스", 80, 60000, 550, 1100, 6);
            human.AddMonster("수퍼아머", 85, 88000, 625, 1250, 6);
            human.AddMonster("제일", 88, 120000, 685, 1400, 6);
            human.AddMonster("전구스타", 90, 135000, 698, 1425, 6);
            templeSuburb.AddMonster("진흙골렘", 92, 160000, 702, 1465, 6);
            templeSuburb.AddMonster("스틸골렘", 94, 200000, 708, 1525, 6);
            templeSuburb.AddMonster("황금골렘", 95, 210000, 715, 1620, 6);
            templeSuburb.AddMonster("샤우타", 98, 250000, 760, 1885, 7);
            templeSuburb.AddMonster("카곤", 100, 300000, 880, 1960, 7);
            templeSuburb.AddMonster("키놀", 108, 450000, 920, 2620, 7);
            templeSuburb.AddMonster("공어", 110, 500000, 960, 2700, 7);
            templeSuburb.AddMonster("황어", 115, 600000, 1080, 3200, 7);
            templeSuburb.AddMonster("비노슈", 120, 700000, 1250, 3800, 7);
            templeSuburb.AddMonster("플라타나", 126, 850000, 1400, 4500, 7);
            templeInside.AddMonster("익스펠러", 122, 730000, 1285, 4050, 7);
            templeInside.AddMonster("루쿠쿠", 128, 880000, 1425, 4600, 7);
            templeInside.AddMonster("헌터", 135, 1000000, 1600, 5500, 7);
            templeInside.AddMonster("팔레트", 138, 1060000, 1680, 5780, 7);
            templeInside.AddMonster("X-익스펠러", 145, 1350000, 1920, 6500, 7);
            templeInside.AddMonster("Y-익스펠러", 155, 1600000, 2180, 7200, 7);
            templeInside.AddMonster("Z-익스펠러", 165, 2020000, 2350, 8000, 7);
            templeInside.AddMonster("페이플", 170, 2180000, 2580, 8500, 7);
            templeInside.AddMonster("GBL교신도", 176, 2600000, 2800, 9500, 7);
            templeInside.AddMonster("레릭헌터", 165, 2280000, 2450, 8200, 7);
            goblinWorld.AddMonster("고블린", 1, 25, 18, 26, 0);
            goblinWorld.AddMonster("고이병", 3, 75, 28, 46, 0);
            goblinWorld.AddMonster("고일병", 5, 160, 36, 90, 1);
            goblinWorld.AddMonster("고상병", 9, 265, 43, 125, 1);
            goblinWorld.AddMonster("고병장", 12, 380, 58, 175, 1);
            goblinWorld.AddMonster("고하사", 15, 500, 70, 212, 1);
            goblinWorld.AddMonster("고중사", 18, 650, 88, 250, 1);
            goblinWorld.AddMonster("고상사", 21, 800, 100, 300, 1);
            goblinWorld.AddMonster("고소위", 25, 1100, 125, 352, 2);
            goblinWorld.AddMonster("고중위", 32, 1750, 145, 400, 3);
            goblinWorld.AddMonster("고대위", 36, 2000, 185, 450, 3);
            goblinWorld.AddMonster("고소령", 42, 2350, 200, 480, 3);
            goblinWorld.AddMonster("고중령", 48, 3000, 230, 530, 4);
            goblinWorld.AddMonster("고대령", 52, 3500, 240, 550, 4);
            goblinWorld.AddMonster("고준장", 62, 12000, 315, 700, 5);
            goblinWorld.AddMonster("고소장", 75, 40000, 500, 980, 6);
            goblinWorld.AddMonster("고중장", 82, 70000, 600, 1200, 6);
            goblinWorld.AddMonster("고대장", 91, 150000, 700, 1450, 6);
            goblinWorld.AddMonster("고원수", 95, 220000, 725, 1600, 7);
            goblinWorld.AddMonster("고제독", 102, 350000, 908, 2050, 7);
            goblinWorld.AddMonster("고신병", 108, 450000, 1000, 2500, 7);
            goblinWorld.AddMonster("고사령", 115, 600000, 1105, 2850, 7);
            goblinWorld.AddMonster("고총사령", 142, 1200000, 1820, 6200, 7);
            goblinWorld.AddMonster("고대통령", 162, 2000000, 2300, 7800, 7);
            fairytaleWorld.AddMonster("토끼", 88, 100000, 650, 1300, 6);
            fairytaleWorld.AddMonster("호랭이", 128, 850000, 1400, 4500, 7);
            fairytaleWorld.AddMonster("두꺼비", 158, 1650000, 2200, 7500, 7);
            fairytaleWorld.AddMonster("호랑이", 168, 2200000, 2500, 8500, 7);
            fairytaleWorld.AddMonster("노란도깨비", 175, 2500000, 2800, 9200, 7);
            fairytaleWorld.AddMonster("파란도깨비", 175, 2000000, 2500, 9000, 7);
            fairytaleWorld.AddMonster("빨간도깨비", 175, 3000000, 3200, 10000, 7);
            fairytaleWorld.AddMonster("초록도깨비", 178, 4000000, 3800, 12000, 7);
            fairytaleWorld.AddMonster("GBL주신도교", 182, 5500000, 4500, 12500, 7);
            fairytaleWorld.AddMonster("GBM주신도", 188, 8000000, 6000, 14000, 7);
            fairytaleWorld.AddMonster("루가루-y", 188, 4000000, 6200, 13000, 7);
            fairytaleWorld.AddMonster("루가루-x", 192, 5000000, 6500, 15000, 7);
            fairytaleWorld.AddMonster("루가루-z", 200, 7500000, 7500, 18000, 7);
            fairytaleWorld.AddMonster("은두꺼비", 200, 30000000, 7000, 30000, 8);
            fairytaleWorld.AddMonster("금두꺼비", 205, 50000000, 8000, 50000, 8);
            fairytaleWorld.AddMonster("황금두꺼비", 210, 80000000, 10000, 100000, 9);
            fairytaleWorld.AddMonster("칡흙손", 228, 30000000, 12000, 80000, 8);
            fairytaleWorld.AddMonster("찱흙손", 238, 50000000, 15000, 90000, 8);
            fairytaleWorld.AddMonster("마녀", 245, 68000000, 20000, 100000, 9);
            fairytaleWorld.AddMonster("라이징마녀", 265, 125000000, 50000, 150000, 9);
            thiefHideout.AddMonster("도둑의아들", 208, 8000000, 8500, 20000, 7);
            thiefHideout.AddMonster("흐접도둑", 228, 35000000, 13000, 82000, 8);
            thiefHideout.AddMonster("초보도둑", 248, 70000000, 20000, 100000, 9);
            thiefHideout.AddMonster("중수도둑", 268, 140000000, 55000, 160000, 9);
            thiefHideout.AddMonster("고수도둑", 288, 200000000, 80000, 200000, 9);
            thiefHideout.AddMonster("초고수도둑", 308, 250000000, 100000, 240000, 9);
            thiefHideout.AddMonster("1범도둑", 328, 300000000, 120000, 280000, 10);
            thiefHideout.AddMonster("2범도둑", 348, 400000000, 150000, 350000, 10);
            thiefHideout.AddMonster("3범도둑", 368, 500000000, 180000, 420000, 10);
            thiefHideout.AddMonster("4범도둑", 388, 600000000, 200000, 480000, 10);
            thiefHideout.AddMonster("5범도둑", 408, 800000000, 300000, 650000, 10);
            thiefHideout.AddMonster("(중간보스)타락한도둑", 408, 25000000000, 20000000, 40000000, 1000);
            thiefHideout.AddMonster("슈즈도둑", 428, 1000000000, 400000, 800000, 10);
            thiefHideout.AddMonster("하의도둑", 448, 1500000000, 500000, 1000000, 10);
            thiefHideout.AddMonster("상의도둑", 468, 2000000000, 650000, 1250000, 10);
            thiefHideout.AddMonster("머리도둑", 488, 3000000000, 950000, 1700000, 10);
            thiefHideout.AddMonster("헤어도둑", 508, 5000000000, 1200000, 2500000, 12);
            thiefHideout.AddMonster("헌팅", 508, 150000000000, 80000000, 150000000, 1500);
            thiefHideout.AddMonster("헌터킬러", 509, 250000000000, 200000000, 400000000, 4000);
            hiddenMap1.AddMonster("김씨가문", 451, 1600000000, 505000, 1020000, 10);
            hiddenMap1.AddMonster("이씨가문", 452, 1650000000, 510000, 1030000, 10);
            hiddenMap1.AddMonster("정씨가문", 453, 1700000000, 515000, 1040000, 10);
            hiddenMap1.AddMonster("최씨가문", 454, 1750000000, 520000, 1050000, 10);
            hiddenMap1.AddMonster("고씨가문", 455, 1800000000, 525000, 1060000, 10);
            hiddenMap1.AddMonster("박씨가문", 456, 1850000000, 530000, 1080000, 10);
            hiddenMap1.AddMonster("전씨가문", 457, 1900000000, 535000, 1100000, 10);
            hiddenMap1.AddMonster("조씨가문", 458, 1950000000, 540000, 1120000, 10);
            hiddenMap1.AddMonster("성씨가문", 459, 1980000000, 550000, 1130000, 10);
            hiddenMap1.AddMonster("송씨가문", 460, 2000000000, 560000, 1150000, 10);
            hiddenMap1.AddMonster("장씨가문", 471, 2100000000, 660000, 1300000, 10);
            hiddenMap1.AddMonster("지씨가문", 472, 2140000000, 670000, 1320000, 10);
            hiddenMap1.AddMonster("민씨가문", 473, 2180000000, 680000, 1350000, 10);
            hiddenMap1.AddMonster("선씨가문", 474, 2220000000, 700000, 1380000, 10);
            hiddenMap1.AddMonster("신씨가문", 475, 2250000000, 720000, 1400000, 10);
            hiddenMap1.AddMonster("주씨가문", 476, 2280000000, 740000, 1420000, 10);
            hiddenMap1.AddMonster("도씨가문", 477, 2320000000, 760000, 1450000, 10);
            hiddenMap1.AddMonster("임씨가문", 478, 2350000000, 780000, 1480000, 10);
            hiddenMap1.AddMonster("유씨가문", 479, 2400000000, 800000, 1500000, 10);
            hiddenMap1.AddMonster("윤씨가문", 480, 2450000000, 820000, 1520000, 10);
            hiddenMap1.AddMonster("공씨가문", 495, 3500000000, 1000000, 2000000, 11);
            hiddenMap1.AddMonster("진씨가문", 496, 3550000000, 1010000, 2050000, 11);
            hiddenMap1.AddMonster("홍씨가문", 497, 3580000000, 1020000, 2080000, 11);
            hiddenMap1.AddMonster("황씨가문", 498, 3650000000, 1040000, 2120000, 11);
            hiddenMap1.AddMonster("양씨가문", 499, 3800000000, 1050000, 2150000, 11);
            hiddenMap1.AddMonster("라씨가문", 500, 3880000000, 1060000, 2200000, 11);
            hiddenMap1.AddMonster("한씨가문", 501, 3950000000, 1080000, 2300000, 11);
            hiddenMap2.AddMonster("one", 461, 2010000000, 570000, 1160000, 10);
            hiddenMap2.AddMonster("two", 462, 2020000000, 580000, 1180000, 10);
            hiddenMap2.AddMonster("three", 463, 2030000000, 590000, 1200000, 10);
            hiddenMap2.AddMonster("four", 464, 2040000000, 600000, 1210000, 10);
            hiddenMap2.AddMonster("five", 465, 2050000000, 610000, 1220000, 10);
            hiddenMap2.AddMonster("six", 466, 2060000000, 620000, 1230000, 10);
            hiddenMap2.AddMonster("seven", 467, 2070000000, 630000, 1250000, 10);
            hiddenMap2.AddMonster("eight", 468, 2080000000, 640000, 1270000, 10);
            hiddenMap2.AddMonster("nine", 469, 2090000000, 650000, 1280000, 10);
            hiddenMap2.AddMonster("ten", 470, 2100000000, 660000, 1300000, 10);
            hiddenMap2.AddMonster("eleven", 481, 2500000000, 830000, 1520000, 10);
            hiddenMap2.AddMonster("twelve", 482, 2550000000, 840000, 1540000, 10);
            hiddenMap2.AddMonster("thirteen", 483, 2600000000, 850000, 1560000, 10);
            hiddenMap2.AddMonster("fourteen", 484, 2650000000, 860000, 1580000, 10);
            hiddenMap2.AddMonster("fifteen", 485, 2700000000, 870000, 1600000, 10);
            hiddenMap2.AddMonster("sixteen", 486, 2750000000, 880000, 1620000, 10);
            hiddenMap2.AddMonster("seventeen", 487, 2800000000, 890000, 1640000, 10);
            hiddenMap2.AddMonster("eighteen", 488, 2850000000, 900000, 1660000, 10);
            hiddenMap2.AddMonster("nineteen", 489, 2900000000, 910000, 1680000, 10);
            hiddenMap2.AddMonster("twenty", 490, 3000000000, 920000, 1700000, 11);
            hiddenMap2.AddMonster("thirty", 491, 3100000000, 930000, 1750000, 11);
            hiddenMap2.AddMonster("fourty", 492, 3200000000, 950000, 1800000, 11);
            hiddenMap2.AddMonster("fifty", 493, 3300000000, 970000, 1850000, 11);
            hiddenMap2.AddMonster("sixty", 494, 3400000000, 990000, 1900000, 11);
            hiddenMap2.AddMonster("seventy", 500, 3800000000, 1050000, 2150000, 11);
            hiddenMap2.AddMonster("eighty", 501, 3900000000, 1060000, 2250000, 11);
            hiddenMap2.AddMonster("ninety", 600, 2500000000000, 2200000000, 4500000000, 50000);
            hiddenMap2.AddMonster("hundred", 700, 8500000000000, 7000000000, 14000000000, 160000);
            deongeonCorner.AddMonster("쿠트", 505, 10000000000, 2250000, 4800000, 12);
            deongeonCorner.AddMonster("쿠파", 510, 20000000000, 4000000, 9000000, 12);
            deongeonCorner.AddMonster("쿠파파", 515, 30000000000, 5500000, 15000000, 12);
            deongeonCorner.AddMonster("부기", 520, 80000000000, 11000000, 30000000, 13);
            thunderGentlemanLodging.AddMonster("썬더젠틀맨", 1000, 500000000000000, 5000000000000, 10000000000000, 100000000);
            headSpinLodging.AddMonster("헤드스핀", 1200, 2000000000000000, 40000000000000, 80000000000000, 1000000000);
        }

        public static DeongeonDB GetInstance()
        {
            return instance;
        }
    }
}
