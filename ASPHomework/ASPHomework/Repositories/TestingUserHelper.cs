using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using DataBase;

namespace ASPHomework.Repositories
{
    public class TestingUserHelper
    {
        public static void GenerateATestQuestion(int idQuestion)
        {
            using (var context = new ervinEntities())
            {
                var testQuestion = new TestQuestions { IdQuestion = idQuestion };
                context.SaveChanges();
            }
        }

        public static void GenerateTest(int userId)
        {
            int n = 10;
            var rnd = new Random();
            var simpleChoiceQuestions = rnd.Next(3, 6);
            var multipleChoiceQuestions = 10 - simpleChoiceQuestions;

            var allSelectedQuestionsId = new List<int>();

            var selectedSimpleQuestions = new List<int>();
            var selectedMultipleQuestions = new List<int>();
            using (var context = new ervinEntities())
            {
                var simpleChoiceQuestionsList = context.Questions.Where(x => x.TypeOfQuestion == false).ToList();
                selectedSimpleQuestions = GenerateNumbers(simpleChoiceQuestionsList.Count, simpleChoiceQuestions);

                for (var i = 0; i < selectedSimpleQuestions.Count; i++)
                {

                    var idForSelectedQuestion = simpleChoiceQuestionsList.Skip(selectedSimpleQuestions[i]).First().Id;
                    GenerateATestQuestion(idForSelectedQuestion);
                    allSelectedQuestionsId.Add(idForSelectedQuestion);
                }
                //multiplenow
                var multiChoiceQuestionsList = context.Questions.Where(x => x.TypeOfQuestion).ToList();
                selectedMultipleQuestions = GenerateNumbers(multiChoiceQuestionsList.Count, multipleChoiceQuestions);
                for (var i = 0; i < selectedMultipleQuestions.Count; i++)
                {

                    var idForSelectedQuestion = multiChoiceQuestionsList.Skip(selectedMultipleQuestions[i]).First().Id;
                    GenerateATestQuestion(idForSelectedQuestion);
                    allSelectedQuestionsId.Add(idForSelectedQuestion);
                }
            }

            using (var context = new ervinEntities())
            {
                var test = new Tests
                {
                    IdUser = userId,
                    TestQuestions1 =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[0]).ToList().Last(),
                    TestQuestions2 =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[1]).ToList().Last(),
                    TestQuestions3 =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[2]).ToList().Last(),
                    TestQuestions4 =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[3]).ToList().Last(),
                    TestQuestions5 =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[4]).ToList().Last(),
                    TestQuestions6 =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[5]).ToList().Last(),
                    TestQuestions7 =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[6]).ToList().Last(),
                    TestQuestions8 =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[7]).ToList().Last(),
                    TestQuestions9 =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[8]).ToList().Last(),
                    TestQuestions =
                        context.TestQuestions.Where(x => x.IdQuestion == allSelectedQuestionsId[9]).ToList().Last()
                };

                context.Tests.Add(test);
            }





        }

        public static List<int> GenerateNumbers(int length, int numberOfQuestions)
        {
            var selectedQuestions = new List<int>();
            var rnd = new Random();
            while (selectedQuestions.Count <= numberOfQuestions)
            {
                var theChosenOne = rnd.Next(0, length);
                selectedQuestions.Add(theChosenOne);
                selectedQuestions = selectedQuestions.Distinct().ToList();
            }
            return selectedQuestions;
        }

        public static Tests GetTest(int userId)
        {
            GenerateTest(userId);
            using (var context = new ervinEntities())
            {
                return context.Tests.Last(x => x.IdUser == userId);
            }
        }
    }
}