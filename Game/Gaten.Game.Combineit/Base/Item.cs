using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Gaten.Game.Combineit.Base
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 아이템 상태
        /// </summary>
        public enum ItemStatus
        {
            Idle,
            Run,
            Wait
        }

        /// <summary>
        /// 아이템 ID (고유 식별 값)
        /// 100번부터 시작
        /// 재료 아이템의 ID는 제작 아이템의 ID보다 항상 낮아야 함
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 아이템 이름 (고유 식별 값)
        /// 숫자만으로 이루어질 수 없고, 문자나 문자+숫자로 이루어져야 함
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 아이템 설명
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 아이템 제작 필요 재료들
        /// 이 아이템을 제작하는 데 필요한 재료들
        /// (아이템, 개수) 리스트
        /// </summary>
        public ObservableCollection<ItemSet> Materials { get; set; }

        /// <summary>
        /// 아이템 제작/생산 시간(밀리초)
        /// 이 아이템을 제작/생산하는 데 걸리는 시간
        /// 계산 전용
        /// </summary>
        public int CombineTime { get; set; }

        /// <summary>
        /// 아이템 제작/생산 시간(초)
        /// 이 아이템을 제작/생산하는 데 걸리는 시간
        /// 표시 전용
        /// </summary>
        public float CombineTimeSecond => (float)CombineTime / 1000;

        /// <summary>
        /// 아이템 동시 제작/생산 개수
        /// 이 아이템을 제작/생산했을 때 얻는 아이템개수
        /// </summary>
        public int Bundle { get; set; }

        /// <summary>
        /// 아이템 제작/생산 상태
        /// 아이템을 제작/생산중이면 Run, 제작/생산이 완료되고 아이템을 얻을준비가 되면 Wait, 그 이외에는 Idle
        /// </summary>
        public ItemStatus Status { get; set; }

        /// <summary>
        /// 아이템 틱
        /// 제작/생산 시간을 관리하기 위한 변수
        /// </summary>
        public int Tick { get; set; }

        public int CombineMax => Manual.GetCombineMax(Id);

        public Item(int id, string name, ObservableCollection<ItemSet> materials, int combineTime, string comment = "", int bundle = 1)
        {
            Id = id;
            Name = name;
            Materials = materials;
            CombineTime = combineTime;
            Comment = comment;
            Bundle = bundle;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
