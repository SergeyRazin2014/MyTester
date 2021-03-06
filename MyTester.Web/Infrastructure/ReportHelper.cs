﻿using MyTester.Domain;
using MyTester.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyTester.Infrastructure
{
    public class ReportHelper
    {
        ///определить ответил ли пользователь правильно на конкретный вопрос
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

        //получить все ответы на данный вопрос конкретным пользователем
        public List<PersonsAnswers> GetPersonsAnswersByQuery(Query query, Person person)
        {
            var res = person.PersonsAnswers.Where(e => e.Query.Id == query.Id).ToList();
            return res;
        }

        //получить список элементов - вопрос, среднееЗначениеБаллов
        public List<QueryAveragePoint> GetQueryAveragePointList(List<Query> allQuerys, List<Person> allPersons)
        {
            //по каждому вопросу получить среднее значение баллов
            var queryAveragePointList = new List<QueryAveragePoint>();
            foreach (var query in allQuerys)
            {
                var queryAveragePint = new QueryAveragePoint();
                queryAveragePint.Query = query;
                queryAveragePint.AveragePoint = GetAveragePointByQuery(query, allPersons);

                queryAveragePointList.Add(queryAveragePint);
            }

            return queryAveragePointList;
        }

        //получить среднее значение баллов за вопрос
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
            {
                double res = (query.Point * countRightAnswers / allPersons.Count);
                return res;
            }

            return 0;
        }

        //получить данные для общего отчета
        public SummaryReportInfo GetSummaryReport(List<Query> allQuerys, List<Person> allPersons)
        {
            SummaryReportInfo summaryReportInfo = new SummaryReportInfo();
            summaryReportInfo.PersonCount = allPersons.Count();

            summaryReportInfo.QueryAveragePointList = GetQueryAveragePointList(allQuerys, allPersons);

            return summaryReportInfo;
        }

        //получить средний балл по каждому пользователю
        public List<PersonAverage> GetPersonAverageList(List<Person> allPersons, List<Query> allQueries)
        {
            var res = new List<PersonAverage>();

            foreach (var per in allPersons)
            {
                //рассчитать сумму баллов набранных пользователем
                double sumPonts = 0;
                foreach (var query in allQueries)
                {
                    //если пользователь ответл верно, то добавить к сумме баллов
                    if (IsPersonAnswersRight(query, per))
                    {
                        sumPonts += query.Point;
                    }
                }

                //рассчитать среднее количество очков
                var averagePoints = sumPonts / allQueries.Count();

                var personAverage = new PersonAverage();
                personAverage.Person = per;
                personAverage.AveragePoint = averagePoints;

                res.Add(personAverage);
            }

            return res;
        }

        public List<QueryPoint> GetDetailReportRow(List<Person> allPersons, List<Query> allQueries)
        {
            List<QueryPoint> queryPointList = new List<QueryPoint>();

            foreach (var query in allQueries)
            {
                var queryPoint = new QueryPoint();
                queryPoint.Query = query;
                queryPoint.AveragePointByQuery = GetAveragePointByQuery(query, allPersons);
                queryPoint.PersonPointList = GetPersonPointList(query, allPersons);

                queryPointList.Add(queryPoint);
            }

            return queryPointList.OrderBy(e => e.Query.Id).ToList();
        }

        //получить список элементов - вопрос, респондент, балл
        public List<PersonPoint> GetPersonPointList(Query query, List<Person> allPersons)
        {
            List<PersonPoint> personPointList = new List<PersonPoint>();

            foreach (var pers in allPersons)
            {
                PersonPoint personPoint = new PersonPoint();
                personPoint.Query = query;
                personPoint.Person = pers;
                personPoint.Point = IsPersonAnswersRight(query, pers) ? query.Point : 0;

                personPointList.Add(personPoint);
            }

            return personPointList.OrderBy(e => e.Person.Id).ToList();
        }

        public DetailReport GetDetailReport(List<Person> allPersons, List<Query> allQueries)
        {
            var detailReport = new DetailReport();

            detailReport.AllPersons = allPersons;
            detailReport.Row = GetDetailReportRow(allPersons, allQueries);

            detailReport.Summary = GetSummaryRow(allPersons, allQueries);

            return detailReport;
        }

        public List<PersonSumPoint> GetSummaryRow(List<Person> allPersons, List<Query> allQueries)
        {
            List<PersonSumPoint> resList = new List<PersonSumPoint>();

            //для каждого персона посчитать сумму его баллов по каждому вопросу
            foreach (var person in allPersons)
            {
                double sumPoint = 0;

                foreach (var query in allQueries)
                {
                    if (IsPersonAnswersRight(query, person))
                    {
                        sumPoint += query.Point;
                    }
                }

                PersonSumPoint personSumPoint = new PersonSumPoint();
                personSumPoint.SumPoint = sumPoint;
                personSumPoint.Person = person;

                resList.Add(personSumPoint);
            }

            return resList.OrderBy(e => e.Person.Id).ToList();
        }
    }
}