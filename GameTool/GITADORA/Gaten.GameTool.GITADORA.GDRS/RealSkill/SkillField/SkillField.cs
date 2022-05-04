namespace Gaten.GameTool.GITADORA.GDRS.RealSkill.SkillField
{
    /*
         Skill Field - 채보별 레이팅을 위한 검사 분야
         각 분야마다 일단 만점기준은 없음.
         만점기준 없이 알고리즘에 의해 점수가 책정되고 추후 밸런스 조정을 함.

         Density = NoteCount / Duration;
         DensityA = Density의 맨 앞뒤 0은 모두 제거하고 계산.

         ▶ 노트 밀도가 높음, 특정 노트의 밀도가 높음
         AverageA = 0을 제외한 DensityA의 모든 평균치
         AverageB = AverageA의 30%를 못미치는 프레이즈는 제외한 모든 평균치

         ▶ 곡길이가 길음
         0을 제외한 프레이즈의 Duration 합

         ▶ 노트수가 많음
         DensityA에서의 프레이즈 개수

         ▶ 같은 노트가 연속해서 나옴 (노트끼리의 간격 체크)
         2500 / Duration * (손노트의 평균간격 + 발노트의 평균간격)

         ▶ 손이동이 많음 (노트끼리의 간격 체크)
         2500 / Duration * (손노트의 평균간격 + 발노트의 평균간격)

         ▶ 엇박이 많음(3연음, 6연음도 포함) (정박이 아닌 노트를 모두 찾음)
         0, 87.5, 175, 262.5, 350, 437.5, 525, 612.5, 700 이외의 개수, 마진 10


         ○ Reading - 노트리딩
             - 복잡하게 나오는 노트를 잘 처리함 -
             판정기준:
                     탐 위주의 노트 밀도가 높음(60%)
                     노트 밀도가 높음(40%)
                     같은 노트가 연속해서 계속 나옴(?) => 노트끼리의 간격이 좁음(손, 발) (추후 같은노트로 체킹하게 수정)


         ○ Stamina - 체력
             - 체력이 많이 필요한 노트를 잘 처리함(지속적으로 빠른 노트) -
             판정기준:
                     페달노트가 많음(70%)
                     곡 길이가 길음(15%)
                     노트수가 많음(15%)


         ○ Agility - 민첩
             - 빠르게 처리해야하는 노트를 잘 처리함(순간적으로 빠른 노트) -
             판정기준:
                     손이동이 많음(65%) => 노트끼리의 간격이 좁음(손, 발)
                     빠르게 두번 혹은 세번 밟음(35%) => 노트끼리의 간격이 좁음(손, 발) (추후 같은노트로 체킹하게 수정)


         ○ Concentration - 집중
             - 흐름을 잃지 않고 꾸준히 잘 처리함 -
             판정기준: 
                     곡 길이가 길음(40%)
                     같은 노트가 연속해서 계속 나옴(40%) => 노트끼리의 간격이 좁음(손, 발) (추후 같은노트로 체킹하게 수정)
                     엇박이 많음(20%) => 정박이 아님


         ○ Accuracy - 정확도
             - 어려운 박자나 리듬을 잘 처리함 -
             판정기준:
                     엇박이 많음(100%) => 정박이 아님
                     3,4 마디 보면이 아님 (추후 수정)
     */
    internal class SkillField
    {
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }
        public virtual double Score { get; set; }

        public virtual void AddUp() { }
    }
}
