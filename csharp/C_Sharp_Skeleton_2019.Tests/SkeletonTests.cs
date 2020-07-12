using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using C_Sharp_Challenge_Skeleton.Answers;
using C_Sharp_Challenge_Skeleton.Beans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace C_Sharp_Skeleton_2019.Tests
{
    [TestClass]
    public class SkeletonTests
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string baseUrl = "https://ta-cc-gl.herokuapp.com/";

        [TestMethod]
        public async Task TestQ1()
        {
            var travisUUID = Environment.GetEnvironmentVariable("travistestidentifier");
            if (travisUUID == null)
            {
                travisUUID = "";
            }
            Console.WriteLine("Testing Q1");
            string responseBody = await client.GetStringAsync(baseUrl + "tests/run/1/" + travisUUID);
            List<TestCase> testCases = JsonConvert.DeserializeObject<List<TestCase>>(responseBody);
            List<Answer> answers = new List<Answer>();

            foreach (var test in testCases)
            {
                try
                {
                    Answer answer = new Answer();
                    int[] input = JsonConvert.DeserializeObject<int[]>(test.input);
                    var cancellationToken = new CancellationTokenSource();
                    cancellationToken.CancelAfter(1000);
                    await Task.Run(() => answer = getFirstAnswer(input, test), cancellationToken.Token);
                    answers.Add(answer);
                }
                catch (TaskCanceledException _)
                {
                    Console.WriteLine("A test in Question 1 has timed out. Tests must complete within one second.");
                    answers.Add(new Answer()
                    {
                        questionNumber = 1,
                        testNumber = test.testNumber,
                        correct = "TIMED_OUT",
                        speed = -1
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            if (travisUUID.Length > 0)
            {
                Console.WriteLine("Submitting Q1");
                string ans = JsonConvert.SerializeObject(answers);
                await client.PostAsync(baseUrl + "answer/contestant/" + travisUUID + "/1", new StringContent(ans, Encoding.UTF8, "application/json"));
            }
        }

        Answer getFirstAnswer(int[] input, TestCase test)
        {
            var timer = new Stopwatch();

            timer.Start();

            var answer = Question1.Answer(input);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new Answer()
            {
                questionNumber = 1,
                testNumber = test.testNumber,
                correct = answer == test.output ? "CORRECT" : "INCORRECT",
                speed = timeTaken
            };
        }

        [TestMethod]
        public async Task TestQ2()
        {
            var travisUUID = Environment.GetEnvironmentVariable("travistestidentifier");
            if (travisUUID == null)
            {
                travisUUID = "";
            }
            Console.WriteLine("Testing Q2");
            string responseBody = await client.GetStringAsync(baseUrl + "tests/run/2/" + travisUUID);
            List<TestCase> testCases = JsonConvert.DeserializeObject<List<TestCase>>(responseBody);
            List<Answer> answers = new List<Answer>();

            foreach (var test in testCases)
            {
                try
                {
                    Answer answer = new Answer();
                    Cashflows input = JsonConvert.DeserializeObject<Cashflows>(test.input);
                    var cancellationToken = new CancellationTokenSource();
                    cancellationToken.CancelAfter(1000);
                    await Task.Run(() => answer = getSecondAnswer(input, test), cancellationToken.Token);
                    answers.Add(answer);
                }
                catch (TaskCanceledException _)
                {
                    Console.WriteLine("A test in Question 2 has timed out. Tests must complete within one second.");
                    answers.Add(new Answer()
                    {
                        questionNumber = 2,
                        testNumber = test.testNumber,
                        correct = "TIMED_OUT",
                        speed = -1
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            if (travisUUID.Length > 0)
            {
                Console.WriteLine("Submitting Q2");
                string ans = JsonConvert.SerializeObject(answers);
                await client.PostAsync(baseUrl + "answer/contestant/" + travisUUID + "/2", new StringContent(ans, Encoding.UTF8, "application/json"));
            }
        }

        Answer getSecondAnswer(Cashflows input, TestCase test)
        {
            var timer = new Stopwatch();

            timer.Start();

            var answer = Question2.Answer(input.cashFlowIn, input.cashFlowOut);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new Answer()
            {
                questionNumber = 2,
                testNumber = test.testNumber,
                correct = answer == test.output ? "CORRECT" : "INCORRECT",
                speed = timeTaken
            };
        }

        [TestMethod]
        public async Task TestQ3()
        {
            var travisUUID = Environment.GetEnvironmentVariable("travistestidentifier");
            if (travisUUID == null)
            {
                travisUUID = "";
            }
            Console.WriteLine("Testing Q3");
            string responseBody = await client.GetStringAsync(baseUrl + "tests/run/3/" + travisUUID);
            List<TestCase> testCases = JsonConvert.DeserializeObject<List<TestCase>>(responseBody);
            List<Answer> answers = new List<Answer>();

            foreach (var test in testCases)
            {
                try
                {
                    Answer answer = new Answer();
                    Exchanges input = JsonConvert.DeserializeObject<Exchanges>(test.input);
                    var cancellationToken = new CancellationTokenSource();
                    cancellationToken.CancelAfter(1000);
                    await Task.Run(() => answer = getThirdAnswer(input, test), cancellationToken.Token);
                    answers.Add(answer);
                }
                catch (TaskCanceledException _)
                {
                    Console.WriteLine("A test in Question 3 has timed out. Tests must complete within one second.");
                    answers.Add(new Answer()
                    {
                        questionNumber = 3,
                        testNumber = test.testNumber,
                        correct = "TIMED_OUT",
                        speed = -1
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            if (travisUUID.Length > 0)
            {
                Console.WriteLine("Submitting Q3");
                string ans = JsonConvert.SerializeObject(answers);
                await client.PostAsync(baseUrl + "answer/contestant/" + travisUUID + "/3", new StringContent(ans, Encoding.UTF8, "application/json"));
            }
        }

        Answer getThirdAnswer(Exchanges input, TestCase test)
        {
            var timer = new Stopwatch();

            timer.Start();

            var answer = Question3.Answer(input.numNodes, input.edges);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new Answer()
            {
                questionNumber = 3,
                testNumber = test.testNumber,
                correct = answer == test.output ? "CORRECT" : "INCORRECT",
                speed = timeTaken
            };
        }

        [TestMethod]
        public async Task TestQ4()
        {
            var travisUUID = Environment.GetEnvironmentVariable("travistestidentifier");
            if (travisUUID == null)
            {
                travisUUID = "";
            }
            Console.WriteLine("Testing Q4");
            string responseBody = await client.GetStringAsync(baseUrl + "tests/run/4/" + travisUUID);
            List<TestCase> testCases = JsonConvert.DeserializeObject<List<TestCase>>(responseBody);
            List<Answer> answers = new List<Answer>();

            foreach (var test in testCases)
            {
                try
                {
                    Answer answer = new Answer();
                    FixMachines input = JsonConvert.DeserializeObject<FixMachines>(test.input);
                    var cancellationToken = new CancellationTokenSource();
                    cancellationToken.CancelAfter(1000);
                    await Task.Run(() => answer = getFourthAnswer(input, test), cancellationToken.Token);
                    answers.Add(answer);
                }
                catch (TaskCanceledException _)
                {
                    Console.WriteLine("A test in Question 4 has timed out. Tests must complete within one second.");
                    answers.Add(new Answer()
                    {
                        questionNumber = 4,
                        testNumber = test.testNumber,
                        correct = "TIMED_OUT",
                        speed = -1
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            if (travisUUID.Length > 0)
            {
                Console.WriteLine("Submitting Q4");
                string ans = JsonConvert.SerializeObject(answers);
                await client.PostAsync(baseUrl + "answer/contestant/" + travisUUID + "/4", new StringContent(ans, Encoding.UTF8, "application/json"));
            }
        }

        Answer getFourthAnswer(FixMachines input, TestCase test)
        {
            var timer = new Stopwatch();

            timer.Start();

            var answer = Question4.Answer(input.rows, input.numberMachines);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new Answer()
            {
                questionNumber = 4,
                testNumber = test.testNumber,
                correct = answer == test.output ? "CORRECT" : "INCORRECT",
                speed = timeTaken
            };
        }

        [TestMethod]
        public async Task TestQ5()
        {
            var travisUUID = Environment.GetEnvironmentVariable("travistestidentifier");
            if (travisUUID == null)
            {
                travisUUID = "";
            }
            Console.WriteLine("Testing Q5");
            string responseBody = await client.GetStringAsync(baseUrl + "tests/run/5/" + travisUUID);
            List<TestCase> testCases = JsonConvert.DeserializeObject<List<TestCase>>(responseBody);
            List<Answer> answers = new List<Answer>();

            foreach (var test in testCases)
            {
                try
                {
                    Answer answer = new Answer();
                    StructuredTrades input = JsonConvert.DeserializeObject<StructuredTrades>(test.input);
                    var cancellationToken = new CancellationTokenSource();
                    cancellationToken.CancelAfter(1000);
                    await Task.Run(() => answer = getFifthAnswer(input, test), cancellationToken.Token);
                    answers.Add(answer);
                }
                catch (TaskCanceledException _)
                {
                    Console.WriteLine("A test in Question 5 has timed out. Tests must complete within one second.");
                    answers.Add(new Answer()
                    {
                        questionNumber = 5,
                        testNumber = test.testNumber,
                        correct = "TIMED_OUT",
                        speed = -1
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }


            if (travisUUID.Length > 0)
            {
                Console.WriteLine("Submitting Q5");
                string ans = JsonConvert.SerializeObject(answers);
                await client.PostAsync(baseUrl + "answer/contestant/" + travisUUID + "/5", new StringContent(ans, Encoding.UTF8, "application/json"));
            }
        }

        Answer getFifthAnswer(StructuredTrades input, TestCase test)
        {
            var timer = new Stopwatch();

            timer.Start();

            var answer = Question5.Answer(input.allowedAllocations, input.totalValue);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new Answer()
            {
                questionNumber = 5,
                testNumber = test.testNumber,
                correct = answer == test.output ? "CORRECT" : "INCORRECT",
                speed = timeTaken
            };
        }

        [TestMethod]
        public async Task TestQ6()
        {
            var travisUUID = Environment.GetEnvironmentVariable("travistestidentifier");
            if (travisUUID == null)
            {
                travisUUID = "";
            }
            Console.WriteLine("Testing Q6");
            string responseBody = await client.GetStringAsync(baseUrl + "tests/run/6/" + travisUUID);
            List<TestCase> testCases = JsonConvert.DeserializeObject<List<TestCase>>(responseBody);
            List<Answer> answers = new List<Answer>();

            foreach (var test in testCases)
            {
                try
                {
                    Answer answer = new Answer();
                    Server input = JsonConvert.DeserializeObject<Server>(test.input);
                    var cancellationToken = new CancellationTokenSource();
                    cancellationToken.CancelAfter(1000);
                    await Task.Run(() => answer = getSixthAnswer(input, test), cancellationToken.Token);
                    answers.Add(answer);
                }
                catch (TaskCanceledException _)
                {
                    Console.WriteLine("A test in Question 6 has timed out. Tests must complete within one second.");
                    answers.Add(new Answer()
                    {
                        questionNumber = 6,
                        testNumber = test.testNumber,
                        correct = "TIMED_OUT",
                        speed = -1
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            if (travisUUID.Length > 0)
            {
                Console.WriteLine("Submitting Q6");
                string ans = JsonConvert.SerializeObject(answers);
                await client.PostAsync(baseUrl + "answer/contestant/" + travisUUID + "/6", new StringContent(ans, Encoding.UTF8, "application/json"));
            }
        }

        Answer getSixthAnswer(Server input, TestCase test)
        {
            var timer = new Stopwatch();

            timer.Start();

            var answer = Question6.Answer(input.numServers, input.targetNode, input.arcs);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new Answer()
            {
                questionNumber = 6,
                testNumber = test.testNumber,
                correct = answer == test.output ? "CORRECT" : "INCORRECT",
                speed = timeTaken
            };
        }

        class TestCase
        {
            public int testNumber { get; set; }
            public string input { get; set; }
            public int output { get; set; }
        }

        class TestCaseList
        {
            public List<TestCase> testCases { get; set; }
        }

        class Answer
        {
            public int questionNumber { get; set; }
            public int testNumber { get; set; }
            public string correct { get; set; }
            public double speed { get; set; }
        }
    }
}
