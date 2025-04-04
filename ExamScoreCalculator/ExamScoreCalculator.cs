using System;

namespace ExamScoreCalculator
{
    public class ScoreCalculator
    {
        public int ParseScore(string input, int maxScore, string fieldName)
        {
            if (!int.TryParse(input, out int score))
            {
                throw new ArgumentException($"{fieldName} должны быть числом");
            }

            if (score < 0)
            {
                throw new ArgumentException($"{fieldName} не могут быть отрицательными");
            }

            if (score > maxScore)
            {
                throw new ArgumentException($"{fieldName} не могут превышать {maxScore}");
            }

            return score;
        }

        public string DetermineGrade(int totalScore)
        {
            if (totalScore >= 56 && totalScore <= 80) return "5 (отлично)";
            if (totalScore >= 32 && totalScore <= 55) return "4 (хорошо)";
            if (totalScore >= 16 && totalScore <= 31) return "3 (удовлетворительно)";
            if (totalScore >= 0 && totalScore <= 15) return "2 (неудовлетворительно)";

            throw new ArgumentException("Общая сумма баллов выходит за допустимые пределы (0-80)");
        }

        public int CalculateTotalScore(string dbScore, string devScore, string supportScore)
        {
            const int MAX_DB_SCORE = 22;
            const int MAX_DEV_SCORE = 38;
            const int MAX_SUPPORT_SCORE = 20;

            int totalScore = 0;

            totalScore += ParseScore(dbScore, MAX_DB_SCORE, "Баллы за модуль баз данных");
            totalScore += ParseScore(devScore, MAX_DEV_SCORE, "Баллы за модуль разработки");
            totalScore += ParseScore(supportScore, MAX_SUPPORT_SCORE, "Баллы за модуль сопровождения");

            return totalScore;
        }
    }
}