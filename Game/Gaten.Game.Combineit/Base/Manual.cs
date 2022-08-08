using System.Collections.Generic;
using System.Linq;

namespace Gaten.Game.Combineit.Base
{
    public class Manual
    {
        /// <summary>
        /// 재료 사전
        /// [아이템ID, 재료목록]
        /// </summary>
        public static Dictionary<int, List<ItemSet>> MaterialDictionary { get; set; } = new Dictionary<int, List<ItemSet>>();

        public Manual()
        {
        }

        public static int GetCombineMax(int itemId)
        {
            List<ItemSet>? materials = MaterialDictionary[itemId];

            foreach (ItemSet material in materials)
            {
                if (Character.IsPossessItem(material.Item))
                {
                    int count = Character.GetPossessionItemCount(material.Item) / material.Count;
                }
            }

            return materials.Max(m => Character.GetPossessionItemCount(m.Item) / m.Count);
        }
    }
}
