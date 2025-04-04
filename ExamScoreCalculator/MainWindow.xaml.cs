using System;
using System.Windows;
using System.Windows.Controls;

namespace ExamScoreCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                errorTextBlock.Text = "";

                // Получаем баллы из текстовых полей
                int dbScore = ParseScore(dbScoreTextBox.Text, 22, "Баллы за модуль баз данных");
                int devScore = ParseScore(devScoreTextBox.Text, 38, "Баллы за модуль разработки");
                int supportScore = ParseScore(supportScoreTextBox.Text, 20, "Баллы за модуль сопровождения");

                // Суммируем баллы
                int totalScore = dbScore + devScore + supportScore;
                totalScoreTextBlock.Text = totalScore.ToString();

                // Определяем оценку
                string grade = DetermineGrade(totalScore);
                gradeTextBlock.Text = grade;
            }
            catch (Exception ex)
            {
                errorTextBlock.Text = ex.Message;
            }
        }

        private int ParseScore(string input, int maxScore, string fieldName)
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

        private string DetermineGrade(int totalScore)
        {
            if (totalScore >= 56 && totalScore <= 80) return "5 (отлично)";
            if (totalScore >= 32 && totalScore <= 55) return "4 (хорошо)";
            if (totalScore >= 16 && totalScore <= 31) return "3 (удовлетворительно)";
            if (totalScore >= 0 && totalScore <= 15) return "2 (неудовлетворительно)";

            throw new ArgumentException("Общая сумма баллов выходит за допустимые пределы (0-80)");
        }
    }
}