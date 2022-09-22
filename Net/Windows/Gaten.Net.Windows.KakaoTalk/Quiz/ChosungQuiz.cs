using Gaten.Net.IO;
using Gaten.Net.Math;

namespace Gaten.Net.Windows.KakaoTalk.Quiz
{
    public class ChosungTitle
    {
        public string Title { get; set; }
        public string Description => Title switch
        {
            "4cIdiom" => "사자성어",
            "Animal" => "동물",
            "Anime" => "애니",
            "Capital" => "수도이름",
            "CvStore" => "편의점",
            "Food" => "음식",
            "Game" => "게임",
            "Movie" => "영화",
            "Nation" => "나라이름",
            "Nearby" => "주변사물",
            "Plant" => "식물",
            "Ramen" => "라면이름",
            _ => "기타"
        };

        public List<Quiz> Quizzes { get; set; } = new();
    }

    public class Quiz
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public Quiz(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }

    public class ChosungQuiz
    {
        private static SmartRandom r = new();
        public static List<ChosungTitle> ChosungTitles = new();
        public static Quiz CurrentQuiz = new("", "");

        public static void Init()
        {
            var quizPath = GPath.Desktop.Down("quiz");
            var quizTitle = new DirectoryInfo(quizPath).GetDirectories("[Chosung]*");
            foreach (var title in quizTitle)
            {
                var chosungTitle = new ChosungTitle();
                chosungTitle.Title = title.Name.Replace("[Chosung]", "");
                var questionPath = title.FullName.Down("question.txt");
                var answerPath = title.FullName.Down("answer.txt");
                var questionData = GFile.ReadToArray(questionPath);
                var answerData = GFile.ReadToArray(answerPath);
                for (int i = 0; i < questionData.Length; i++)
                {
                    chosungTitle.Quizzes.Add(new Quiz(questionData[i], answerData[i]));
                }
                ChosungTitles.Add(chosungTitle);
            }
        }

        public static string GetQuestion()
        {
            var chosungTitle = r.Next(ChosungTitles);
            var quiz = r.Next(chosungTitle.Quizzes);
            CurrentQuiz = quiz;

            return $"[{chosungTitle.Description}] {quiz.Question}";
        }

        public static (bool, string) TryAnswer(string data)
        {
            var answer = CurrentQuiz.Answer.Trim().Replace(" ", "");
            var input = data.Trim().Replace(" ", "");
            if (answer.Equals(input))
            {
                return (true, CurrentQuiz.Answer);
            }
            else
            {
                return (false, "");
            }
        }
    }
}
