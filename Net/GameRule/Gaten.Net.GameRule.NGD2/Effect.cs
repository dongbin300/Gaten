using Gaten.Net.GameRule.NGD2.Format;

namespace Gaten.Net.GameRule.NGD2
{
    public class Effect
    {
        /// <summary>
        /// 공격력
        /// 0~INF
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// 공격력 %
        /// 0~INF(%)
        /// </summary>
        public int PowerMultiple { get; set; }

        /// <summary>
        /// 공격력+공격력 % 합산
        /// </summary>
        public int PowerSum => (int)(Power * (double)(1 + PowerMultiple / 100));

        /// <summary>
        /// 크리티컬율
        /// 0~10000(100%)
        /// </summary>
        public int CriticalRate { get; set; }

        /// <summary>
        /// 크리티컬율
        /// 0~100%
        /// 소수점 2자리까지 표시
        /// </summary>
        public double CriticalRateIM => IMConverter.GetCriticalRate(CriticalRate);

        /// <summary>
        /// 크리티컬데미지
        /// 0~INF(%)
        /// </summary>
        public int CriticalDamageMultiple { get; set; }

        /// <summary>
        /// 파워크리티컬데미지(10번째 크리티컬)
        /// 0~INF(%)
        /// </summary>
        public int PowerCriticalDamageMultiple { get; set; }

        /// <summary>
        /// MP MAX
        /// 0~INF
        /// </summary>
        public int MpMax { get; set; }

        /// <summary>
        /// MP 리젠량
        /// 0~INF
        /// </summary>
        public int MpRegen { get; set; }

        /// <summary>
        /// 공격속도
        /// </summary>
        public int AttackSpeed { get; set; }

        /// <summary>
        /// 공격속도에 따른 틱 딜레이수치
        /// </summary>
        public int AttackSpeedIM => IMConverter.GetAttackSpeed(AttackSpeed);

        /// <summary>
        /// 공격시 MP 리젠량
        /// 0~INF
        /// </summary>
        public int AttackMpRegen { get; set; }

        /// <summary>
        /// 스킬 사용시 MP 소모 감소량 %
        /// 0~100(%)
        /// </summary>
        public int MpReductionMultiple { get; set; }

        /// <summary>
        /// 부스트 파워(증가량)
        /// 0~INF
        /// </summary>
        public int BoostPower { get; set; }

        /// <summary>
        /// 부스트 MAX
        /// 0~INF
        /// </summary>
        public int BoostMax { get; set; }

        /// <summary>
        /// 근징 드롭량
        /// 0~INF
        /// </summary>
        public int SpiritDrop { get; set; }

        /// <summary>
        /// 근징 드롭량 %
        /// 0~INF(%)
        /// </summary>
        public int SpiritDropMultiple { get; set; }

        /// <summary>
        /// 근징 드롭량 + 근징 드롭량 % 합산
        /// </summary>
        public int SpiritDropSum => (int)(SpiritDrop * (double)(1 + SpiritDropMultiple / 100));

        /// <summary>
        /// 근징 드롭률
        /// 0~100(%)
        /// </summary>
        public int SpiritDropRate { get; set; }

        /// <summary>
        /// 근징 드롭률
        /// 0~100%
        /// 소수점 2자리까지 표시
        /// </summary>
        public double SpiritDropRateIM => IMConverter.GetSpiritDropRate(SpiritDropRate);

        /// <summary>
        /// 스카 드롭률
        /// 0~100(%)
        /// </summary>
        public int SkillCardDropRate { get; set; }

        /// <summary>
        /// 스카 드롭률
        /// 0~100%
        /// 소수점 2자리까지 표시
        /// </summary>
        public double SkillCardDropRateIM => IMConverter.GetSkillCardDropRate(SkillCardDropRate);

        /// <summary>
        /// 키조각 드롭률
        /// 0~100(%)
        /// </summary>
        public int KeyPieceDropRate { get; set; }

        /// <summary>
        /// 키조각 드롭률
        /// 0~100%
        /// 소수점 2자리까지 표시
        /// </summary>
        public double KeyPieceDropRateIM => IMConverter.GetKeyPieceDropRate(KeyPieceDropRate);

        /// <summary>
        /// 크리티컬 시 근징 드롭량
        /// 0~INF
        /// </summary>
        public int CriticalSpiritDrop { get; set; }

        /// <summary>
        /// 염력 드롭량
        /// 0~INF
        /// </summary>
        public int PsychokinesisDrop { get; set; }

        /// <summary>
        /// 염력 드롭률
        /// 0~100(%)
        /// </summary>
        public int PsychokinesisDropRate { get; set; }

        /// <summary>
        /// 염력 공격력
        /// 0~INF
        /// </summary>
        public int PsychokinesisPower { get; set; }

        /// <summary>
        /// 무공 드롭량
        /// 0~INF(%)
        /// </summary>
        public int MugongDropMultiple { get; set; }

        /// <summary>
        /// 휴식 경험치
        /// </summary>
        public long RestXp { get; set; }

        public int GameSpeed { get; set; }

        /// <summary>
        /// 염력레벨업에 필요한 염력 개수 감소 수치
        /// </summary>
        public int PsychokinesisPriceSale { get; set; }

        public Effect()
        {
            Power = 0;
            PowerMultiple = 0;
            CriticalRate = 0;
            CriticalDamageMultiple = 0;
            PowerCriticalDamageMultiple = 0;
            MpMax = 0;
            MpRegen = 0;
            AttackMpRegen = 0;
            MpReductionMultiple = 0;
            BoostPower = 0;
            BoostMax = 0;
            SpiritDrop = 0;
            SpiritDropMultiple = 0;
            SpiritDropRate = 0;
            SkillCardDropRate = 0;
            KeyPieceDropRate = 0;
            CriticalSpiritDrop = 0;
            PsychokinesisDrop = 0;
            PsychokinesisDropRate = 0;
            PsychokinesisPower = 0;
            MugongDropMultiple = 0;
            RestXp = 0;
            GameSpeed = 500;
            PsychokinesisPriceSale = 0;
        }

        public static Effect operator +(Effect e1, Effect e2)
        {
            return new Effect()
            {
                Power = e1.Power + e2.Power,
                PowerMultiple = e1.PowerMultiple + e2.PowerMultiple,
                CriticalRate = e1.CriticalRate + e2.CriticalRate,
                CriticalDamageMultiple = e1.CriticalDamageMultiple + e2.CriticalDamageMultiple,
                PowerCriticalDamageMultiple = e1.PowerCriticalDamageMultiple + e2.PowerCriticalDamageMultiple,
                MpMax = e1.MpMax + e2.MpMax,
                MpRegen = e1.MpRegen + e2.MpRegen,
                AttackMpRegen = e1.AttackMpRegen + e2.AttackMpRegen,
                MpReductionMultiple = e1.MpReductionMultiple + e2.MpReductionMultiple,
                BoostPower = e1.BoostPower + e2.BoostPower,
                BoostMax = e1.BoostMax + e2.BoostMax,
                SpiritDrop = e1.SpiritDrop + e2.SpiritDrop,
                SpiritDropMultiple = e1.SpiritDropMultiple + e2.SpiritDropMultiple,
                SpiritDropRate = e1.SpiritDropRate + e2.SpiritDropRate,
                SkillCardDropRate = e1.SkillCardDropRate + e2.SkillCardDropRate,
                KeyPieceDropRate = e1.KeyPieceDropRate + e2.KeyPieceDropRate,
                CriticalSpiritDrop = e1.CriticalSpiritDrop + e2.CriticalSpiritDrop,
                PsychokinesisDrop = e1.PsychokinesisDrop + e2.PsychokinesisDrop,
                PsychokinesisDropRate = e1.PsychokinesisDropRate + e2.PsychokinesisDropRate,
                MugongDropMultiple = e1.MugongDropMultiple + e2.MugongDropMultiple,
                RestXp = e1.RestXp + e2.RestXp,
                PsychokinesisPriceSale = e1.PsychokinesisPriceSale + e2.PsychokinesisPriceSale
            };
        }
    }
}
