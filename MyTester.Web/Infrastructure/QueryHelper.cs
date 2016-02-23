using System;
using Domain;
using MyTester.Domain;
using System.Collections.Generic;
using System.Linq;
using MyTester.Models;

namespace MyTester.Infrastructure
{
    public class QueryHelper
    {
        public bool IsPersonAnswersRight(Query query, Person person)
        {
            //ответы пользователя
            var ansver = GetPersonsAnswersByQuery(query, person);

            //правильные варианты ответа
            var rightVariant = query.VariantsAnsver.Where(v => v.IsRight);

            //если количество ответов не равно количеству правильных отвтов
            if (ansver.Count != rightVariant.Count())
                return false;

            foreach (var right in rightVariant)
            {
                //если такого нет в ответах , то ответ неверный
                if (ansver.All(e => e.VariantAnsver.Id != right.Id))
                    return false;
            }

            return true;
        }

        public List<PersonsAnswers> GetPersonsAnswersByQuery(Query query, Person person)
        {
            //получить все ответы на данный вопрос этим конкретным пользователем
            var res = person.PersonsAnswers.Where(e => e.Query.Id == query.Id).ToList();
            return res;
        }

        public SummaryReportInfo GetSummaryReportInfo(List<Query> allQuerys, List<Person> allPersons)
        {
            var res = new SummaryReportInfo();
            res.PersonCount = allPersons.Count;
            
            //по каждому вопросу получить среднее значение очков

            var queryAveragePointList = new QueryAveragePoint();
            //...

            return res;

        }


        public double GetAveragePointByQuery(Query query, List<Person> allPersons)
        {
            if (allPersons.Count <= 0)
                return 0;

            //для каждого персона 
            //  если он ответил на этот вопрос правильно
            //   добавить количество правльных ответов к счетчику

            int countRightAnswers = 0;
            foreach (var person in allPersons)
            {
                if (IsPersonAnswersRight(query, person))
                    countRightAnswers++;

            }

            if (countRightAnswers > 0)
                return query.Point * allPersons.Count / countRightAnswers;

            else
                return 0;
        }
    }
}