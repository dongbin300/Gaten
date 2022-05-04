﻿namespace Gaten.Net.Windows.CHK
{
    public class VerificationCode
    {
        public static string Seed { get; set; }

        public static string Hash { get; set; }

        public VerificationCode()
        {
            MakeDefault();
        }

        public void MakeDefault()
        {
            Seed = "34 19 CA 77 99 DC 68 71 0A 60 BF C3 A7 E7 75 A7 1F 29 7D A6 D7 B0 3A BB CC 31 24 ED 17 4C 13 0B 65 20 A2 B7 91 BD 18 6B 8D C3 5D DD E2 7A D5 37 F6 59 64 D4 63 9A 12 0F 43 5C 2E 46 E3 74 F8 2A 08 6A 37 06 37 F6 D6 3B 0E 94 63 16 45 67 5C EC D7 7B F7 B7 1A FC D4 9E 73 FA 3F 8C 2E C0 E1 0F D1 74 09 07 95 E3 64 D7 75 16 68 74 99 A7 4F DA D5 20 18 1F E7 E6 A0 BE A6 B6 E3 1F CA 0C EF 70 31 D5 1A 31 4D B8 24 35 E3 F8 C7 7D E1 1A 58 DE F4 05 27 43 BA AC DB 07 DC 69 BE 0A A8 8F EC 49 D7 58 16 3F E5 DB C1 8A 41 CF C0 05 9D CA 1C 72 A2 B1 5F A5 C4 23 70 9B 84 04 E1 14 80 7B 90 DA FA DB 69 06 A3 F3 0F 40 BE F3 CE D4 E3 C9 CB D7 5A 40 01 34 F2 68 14 F8 38 8E C5 1A FE D6 3D 4B 53 05 05 FA 34 10 45 8E DD 91 69 FE AF E0 EE F0 F3 48 7E DD 9F AD DC 75 62 7A AC E5 31 1B 62 67 20 CD 36 4D E0 98 21 74 FB 09 79 71 36 67 CD 7F 77 5F D6 3C A2 A2 A6 C6 1A E3 CE 6A 4E CD A9 6C 86 BA 9D 3B B5 F4 76 FD F8 44 F0 BC 2E E9 6E 29 23 25 2F 6B 08 AB 27 44 7A 12 CC 99 ED DC F2 75 C5 3C 38 7E F7 1C 1B C5 D1 2D 94 65 06 C9 48 DD BE 32 2D AC B5 C9 32 81 66 4A D8 34 35 3F 15 DF B2 EE EB B6 04 F6 4D 96 35 42 94 9C 62 8A D3 61 52 A8 7B 6F DC 61 FC F4 6C 14 2D FE 99 EA A4 0A E8 D9 FE 13 D0 48 44 59 80 66 F3 E3 34 D9 8D 19 16 D7 63 FE 30 18 7E 3A 9B 8D 0F B1 12 F0 F5 8C 0A 78 58 DB 3E 63 B8 8C 3A AA F3 8E 37 8A 1A 2E 5C 31 F9 EF E3 6D E3 7E 9B BD 3E 13 C6 44 C0 B9 BC 3A DA 90 A4 AD B0 74 F8 57 27 89 47 E6 3F 37 E4 42 79 5A DF 43 8D EE B4 0A 49 E8 3C C3 88 1A 88 01 6B 76 8A C3 FD A3 16 7A 4E 56 A7 7F CB BA 02 5E 1C EC B0 B9 C9 76 1E 82 B1 39 3E C9 57 C5 19 24 38 4C 5D 2F 54 B8 6F 5D 57 8E 30 A1 0A 52 6D 18 71 5E 13 06 C3 59 1F DC 3E 62 DC DA B5 EB 1B 91 95 F9 A7 91 D5 DA 33 53 CE 6B F5 00 70 01 7F D8 EE E8 C0 0A F1 CE 63 EB B6 D3 78 EF CC A5 AA 5D BC A4 96 AB F2 D2 61 FF EA 9A A8 6A ED A2 BD 3E ED 61 39 C1 82 92 16 36 23 B1 B0 A0 24 E5 05 9B A7 AA 0D 12 9B 33 83 92 20 DA 25 B0 EC FC 24 D0 38 23 FC 95 F2 74 80 73 E5 19 97 50 7D 44 45 93 44 DB A2 AD 1D 69 44 14 EE E7 2C 7F 87 FF 38 9E 32 F1 4D BC 29 DA 42 27 26 FE C1 D2 2B A9 F6 42 7A 0E CB E8 7C D1 0F 5B EC 56 69 B7 61 31 B4 6D F9 25 40 34 79 6D FA 53 A7 0B FA A4 82 CE C3 45 49 61 0D 45 2C 8F 28 49 60 F7 F3 7D C9 1E 0F D0 89 C1 26 52 F8 D3 4D 8F 35 14 BA 9D 5F 0B 07 A9 4A 00 F7 22 26 2F 3E 67 FB 1F A1 9C 11 C6 69 4F 5D 66 58 34 15 90 6C E5 54 46 AF 5F 63 D6 8A 0C 95 DF BD 0D E4 AF BF 40 40 4C A3 F6 51 71 29 ED 26 F8 85 28 22 D5 BF BE CF FA 28 C5 7F 51 B8 06 63 07 EC BD 8F 29 FA 55 7E 71 1A 40 32 66 E8 D4 DE 9D D4 5E FC 93 7A 3D D5 3B CD 75 2E 80 0A 4F 74 87 1B CC 8F EA 9A A9 DB 7C 16 53 E5 EF AB 78 C1 6E A4 72 89 5A 98 2C 70 50 FB A1 DF 1F 6B B7 D9 44 07 80 82 56 FD BF C0 83 0E 49 D0 5B 1E 68 6A 0E 9A C2 0B 2F 8E 43 A0 E1 99 0C F6 B2 E0 7A 1C 5E 2C C8 A0 45 3C 0B E9 88 AC B9 96 C6 74 AE 83 2A BB 13 FA 65 EB 4F 1F A6 B0 8A 8A E1 81 E9 B8 B9 D5 55 15 4E 45 F2 AD 9B 3E C2 35 7E 5F 92 2E 72 B6 5B 68 23 6E C6 45 0E E9 3B 87 D4 F4 41 C0 E3 A8 05 44 BE E4 0F 8A 13 1A C4 37 F4 5A 40 55 EF 9D 79 1D 4B 4A 79 3A 9C 76 85 37 CC 82 3D 0F B6 60 A6 93 7E BD 5C C2 C4 72 C7 7F 90 4D 1B 96 10 13 05 68 68 35 C0 7B FF 46 85 43 2A";

            Hash = "01 04 05 06 02 01 05 02 00 03 07 07 05 04 06 03";
        }
    }
}
