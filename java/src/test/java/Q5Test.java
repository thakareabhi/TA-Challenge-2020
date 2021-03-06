import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.springframework.boot.test.context.SpringBootTest;
import skeleton.answers.Question5;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.*;

@SpringBootTest
public class Q5Test {

    private List<TestCase> testCases;
    private List<Answer> answers = new ArrayList<>();
    private TestRunner testRunner = new TestRunner();
    private ExecutorService executorService = Executors.newFixedThreadPool(1);

    @Before
    public void setUp() throws Exception {
        testCases = testRunner.getTests(5);
    }

    @After
    public void tearDown() throws Exception {
        testRunner.submitAnswers(answers, 5);
    }

    @Test
    public void testQuestion5() {
        for (int i=1; i<=testCases.size(); i++) {
            try {
                TestCase testCase = testCases.get(i-1);
                int finalI = i;
                Future<Answer> future = executorService.submit(() -> {
                    Q5Object input =
                            new ObjectMapper().readValue(testCase.getInput(),
                                    Q5Object.class);
                    long startTime = System.nanoTime();
                    Integer answer = Question5.shareExchange(input.allowedAllocations, input.totalValue);
                    long endTime = System.nanoTime();
                    return new Answer(5, finalI, correct(answer,
                            testCase.getOutput()),
                            endTime-startTime);
                });

                Answer answer = future.get(1, TimeUnit.SECONDS);
                System.out.println(new ObjectMapper().writeValueAsString(answer));
                answers.add(answer);

            } catch (TimeoutException e) {
                System.out.println("A Question 5 test timed out. Tests must " +
                        "complete within one second.");
                answers.add(new Answer(5, i, "TIMED_OUT", -1));
            } catch (Exception e) {
                e.printStackTrace();
            }

        }
    }

    private String correct(int actual, int expected) {
        return actual == expected ? "CORRECT" : "INCORRECT";
    }


}
