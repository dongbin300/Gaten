namespace Gaten.Game.DeonpaRPG
{
    internal class MagicNumber
    {
        private int mNum;
        private const int divisionLevel = 10;

        public MagicNumber()
        {

        }

        public int Create(Character character)
        {
            mNum = (character.profession.GetHashCode() / divisionLevel)
                + (character.level.GetHashCode() / divisionLevel)
                + (character.questProgress.GetHashCode() / divisionLevel)
                + (character.exp.GetHashCode() / divisionLevel)
                + (character.gold.GetHashCode() / divisionLevel)
                + (character.ability.hp.current.GetHashCode() / divisionLevel)
                + (character.ability.mp.current.GetHashCode() / divisionLevel)
                + (character.gun.GetHashCode() / divisionLevel)
                + (character.armor.GetHashCode() / divisionLevel)
                + (character.necklace.GetHashCode() / divisionLevel)
                + (character.avatar.GetHashCode() / divisionLevel)
                + (character.pendant.GetHashCode() / divisionLevel)
                + (character.others.GetHashCode() / divisionLevel)
                + (character.abilityStone.GetHashCode() / divisionLevel)
                + (character.sp.GetHashCode() / divisionLevel);

            return mNum;
        }

        public bool isRight(Character character, int num)
        {
            return num == Create(character);
        }
    }
}
