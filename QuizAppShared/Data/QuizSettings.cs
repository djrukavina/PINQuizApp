﻿namespace QuizAppShared.Data
{
    public static class QuizSettings
    {
        public static readonly Dictionary<int, string> QuizCategories = new Dictionary<int, string>
        {
            { 1, "Any Category" },
            { 9, "General Knowledge" },
            { 10, "Entertainment: Books" },
            { 11, "Entertainment: Film" },
            { 12, "Entertainment: Music" },
            { 13, "Entertainment: Musicals & Theatres" },
            { 14, "Entertainment: Television" },
            { 15, "Entertainment: Video Games" },
            { 16, "Entertainment: Board Games" },
            { 17, "Science & Nature" },
            { 18, "Science: Computers" },
            { 19, "Science: Mathematics" },
            { 20, "Mythology" },
            { 21, "Sports" },
            { 22, "Geography" },
            { 23, "History" },
            { 24, "Politics" },
            { 25, "Art" },
            { 26, "Celebrities" },
            { 27, "Animals" },
            { 28, "Vehicles" },
            { 29, "Entertainment: Comics" },
            { 30, "Science: Gadgets" },
            { 31, "Entertainment: Japanese Anime & Manga" },
            { 32, "Entertainment: Cartoon & Animations" }
        };

        public static readonly Dictionary<int, string> QuizDifficulty = new Dictionary<int, string>
        {
            {0, "Any Difficulty" },
            {1, "easy" },
            {2, "medium" },
            {3, "hard" }
        };
    }
}
