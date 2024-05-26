using MVCTest.Models;

namespace MVCTest.Helpers
{
    public static class ModelGenerator
    {
        readonly static string description1 =
            @"Lorem Ipsum is simply dummy text of the printing
            and typesetting industry. Lorem Ipsum has been the industry's
            standard dummy text ever since the 1500s, when an unknown printer 
            took a galley of type and scrambled it to make a type specimen book.
            It has survived not only five centuries, but also the leap into electronic
            typesetting, remaining essentially unchanged. It was popularised in the 1960s
            with the release of Letraset sheets.";
        public static IEnumerable<TaskViewModel> GenerteTaskViewModel(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new TaskViewModel
                {
                    Title = $"Title{i}",
                    Assignee = $"Assignee@ass{i}.com",
                    Creator = $"Creator@creator{i}.com",
                    Description = "Description : " + (i < 5 ? description1 : description1.Substring(0, 100)),
                    IsCompleted = i % 2 == 0,
                };
            }
        }
    }
}
