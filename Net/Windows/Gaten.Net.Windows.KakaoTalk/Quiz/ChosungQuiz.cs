using Gaten.Net.IO;
using Gaten.Net.Math;

using System.Text;

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
            "Brand" => "브랜드",
            "Fruit" => "과일",
            "Job" => "직업",
            "Snack" => "과자",
            "Icecream" => "아이스크림",
            "Color" => "색",
            "Gemstone" => "보석",
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

    public class PassUser
    {
        public string Nickname { get; set; }
        public int Penalty { get; set; }
        public DateTime Time { get; set; }

        public PassUser(string nickname, int penalty, DateTime time)
        {
            Nickname = nickname;
            Penalty = penalty;
            Time = time;
        }
    }

    public class ChosungQuiz
    {
        private static SmartRandom r = new();
        public static List<ChosungTitle> ChosungTitles = new();
        public static Quiz CurrentQuiz = new("", "");
        public static string ScorePath = GPath.Desktop.Down("quiz", "score.txt");
        public static bool IsRandomTitle = false;
        public static List<PassUser> PassUsers = new();

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

            if (r.Next(5) == 3)
            {
                IsRandomTitle = true;
                return $"[???] {quiz.Question}";
            }
            else
            {
                IsRandomTitle = false;
                return $"[{chosungTitle.Description}] {quiz.Question}";
            }
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

        public static string GetScoreInfo()
        {
            var userScores = GetUserScores();
            var topScores = userScores.OrderByDescending(x => x.Value).Take(20);
            var builder = new StringBuilder();
            int i = 1;
            foreach(var item in topScores)
            {
                builder.AppendLine($"[{i,-2}] {item.Key,-12} {item.Value,-12}");
                i++;
            }
            return builder.ToString();
        }

        public static Dictionary<string, int> GetUserScores()
        {
            var result = new Dictionary<string, int>();
            var data = File.ReadAllLines(ScorePath);
            foreach(var d in data)
            {
                var e = d.Split(',');
                result.Add(e[0], int.Parse(e[1]));
            }
            return result;
        }

        public static void SetUserScores(Dictionary<string, int> scores)
        {
            var scoreData = new List<string>();
            foreach(var score in scores)
            {
                scoreData.Add($"{score.Key},{score.Value}");
            }
            File.WriteAllLines(ScorePath, scoreData);
        }

        public static int GetUserScore(string userName)
        {
            var userScores = GetUserScores();
            if (userScores.ContainsKey(userName))
            {
                return userScores[userName];
            }
            else
            {
                return 0;
            }
        }

        public static int UpdateScore(string userName, int score)
        {
            var userScores = GetUserScores();
            if(userScores.ContainsKey(userName))
            {
                userScores[userName] += score;
            }
            else
            {
                userScores.Add(userName, score);
            }
            SetUserScores(userScores);

            return userScores[userName];
        }
    }
}
