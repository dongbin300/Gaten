namespace Gaten.Game.NGDG2.GameRule.Character
{
    /// <summary>
    /// 직업
    /// </summary>
    public class NgdgClass
    {
        /// <summary>
        /// 직업 종류
        /// </summary>
        public enum Type
        {
            None,
            Warrior,
            Magician,
            Gunner
        }

        /// <summary>
        /// 직업 종류
        /// </summary>
        public Type ClassType;

        /// <summary>
        /// 직업 이름(ID)
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// 직업 한글 표기
        /// </summary>
        public string Value = string.Empty;

        public NgdgClass()
        {

        }

        public NgdgClass(string name)
        {
            Name = name;

            switch (name)
            {
                case "Warrior":
                    ClassType = Type.Warrior;
                    Value = "전사";
                    break;

                case "Magician":
                    ClassType = Type.Magician;
                    Value = "마법사";
                    break;

                case "Gunner":
                    ClassType = Type.Gunner;
                    Value = "거너";
                    break;

                default:
                    ClassType = Type.None;
                    Value = "알 수 없음";
                    break;
            }
        }

        public NgdgClass(Type classType)
        {
            ClassType = classType;

            switch (classType)
            {
                case Type.Warrior:
                    Name = "Warrior";
                    Value = "전사";
                    break;

                case Type.Magician:
                    Name = "Magician";
                    Value = "마법사";
                    break;

                case Type.Gunner:
                    Name = "Gunner";
                    Value = "거너";
                    break;

                default:
                    Name = "None";
                    Value = "알 수 없음";
                    break;
            }
        }
    }
}
