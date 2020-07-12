const Promise = require('bluebird')
const axios = require('axios');

const performance = require('performance-now')
const question01 = require('./questions/Question1')
const question02 = require('./questions/Question2')
const question03 = require('./questions/Question3')
const question04 = require('./questions/Question4')
const question05 = require('./questions/Question5')
const question06 = require('./questions/Question6')


describe('Coding Challenge Skeleton Tests', () => {

    test('runs question 1', () => {
        return getTests(1)
            .then(tests => {
                let promises = []
                let output = []
                for (let i = 0; i < tests.length; i++) {
                    try {
                        const testRunner = runq1(tests[i])
                                .timeout(1000)
                                .then(({answer, timeTaken}) => {
                                    const correct = answer === tests[i]["output"] ? "CORRECT" : "INCORRECT"
                                    console.log(tests[i].input + " is " + correct)
                                    output.push({
                                        "questionNumber": 1,
                                        "testNumber": i,
                                        "correct": correct,
                                        "speed": timeTaken * 1000000
                                    })
                                })
                                .catch(Promise.TimeoutError, (e) => {
                                    console.log("A question 1 test has timed out. Each individual test has a maximum of one second to run.")
                                    resolve(output.push({
                                        "questionNumber": 1,
                                        "testNumber": i,
                                        "correct": "TIMED_OUT",
                                        "speed": -1
                                    }))
                                })
                        promises.push(testRunner)
                    } catch (error) {
                        console.log(error)
                    }
                }
                return Promise.all(promises).then(_ => submitAnswers(output, 1))
            })
    })

    test('runs question 2', () => {
        return getTests(2)
            .then(tests => {
                let promises = []
                let output = []
                for (let i = 0; i < tests.length; i++) {
                    try {
                        const testRunner = runq2(tests[i])
                                .timeout(1000)
                                .then(({answer, timeTaken}) => {
                                    const correct = answer === tests[i]["output"] ? "CORRECT" : "INCORRECT"
                                    console.log(tests[i].input + " is " + correct)
                                    output.push({
                                        "questionNumber": 2,
                                        "testNumber": i,
                                        "correct": correct,
                                        "speed": timeTaken * 1000000
                                    })
                                })
                                .catch(Promise.TimeoutError, (e) => {
                                    console.log("A question 2 test has timed out. Each individual test has a maximum of one second to run.")
                                    resolve(output.push({
                                        "questionNumber": 2,
                                        "testNumber": i,
                                        "correct": "TIMED_OUT",
                                        "speed": -1
                                    }))
                                })
                        promises.push(testRunner)
                    } catch (error) {
                        console.log(error)
                    }
                }
                return Promise.all(promises).then(_ => submitAnswers(output, 2))
            })
    })

    test('runs question 3', () => {
        return getTests(3)
            .then(tests => {
                let promises = []
                let output = []
                for (let i = 0; i < tests.length; i++) {
                    try {
                        const testRunner = runq3(tests[i])
                                .timeout(1000)
                                .then(({answer, timeTaken}) => {
                                    const correct = answer === tests[i]["output"] ? "CORRECT" : "INCORRECT"
                                    console.log(tests[i].input + " is " + correct)
                                    output.push({
                                        "questionNumber": 3,
                                        "testNumber": i,
                                        "correct": correct,
                                        "speed": timeTaken * 1000000
                                    })
                                })
                                .catch(Promise.TimeoutError, (e) => {
                                    console.log("A question 3 test has timed out. Each individual test has a maximum of one second to run.")
                                    resolve(output.push({
                                        "questionNumber": 3,
                                        "testNumber": i,
                                        "correct": "TIMED_OUT",
                                        "speed": -1
                                    }))
                                })
                        promises.push(testRunner)
                    } catch (error) {
                        console.log(error)
                    }
                }
                return Promise.all(promises).then(_ => submitAnswers(output, 3))
            })
    })

    test('runs question 4', () => {
        return getTests(4)
            .then(tests => {
                let promises = []
                let output = []
                for (let i = 0; i < tests.length; i++) {
                    try {
                        const testRunner = runq4(tests[i])
                                .timeout(1000)
                                .then(({answer, timeTaken}) => {
                                    const correct = answer === tests[i]["output"] ? "CORRECT" : "INCORRECT"
                                    console.log(tests[i].input + " is " + correct)
                                    output.push({
                                        "questionNumber": 4,
                                        "testNumber": i,
                                        "correct": correct,
                                        "speed": timeTaken * 1000000
                                    })
                                })
                                .catch(Promise.TimeoutError, (e) => {
                                    console.log("A question 4 test has timed out. Each individual test has a maximum of one second to run.")
                                    resolve(output.push({
                                        "questionNumber": 4,
                                        "testNumber": i,
                                        "correct": "TIMED_OUT",
                                        "speed": -1
                                    }))
                                })
                        promises.push(testRunner)
                    } catch (error) {
                        console.log(error)
                    }
                }
                return Promise.all(promises).then(_ => submitAnswers(output, 4))
            })
    })

    test('runs question 5', () => {
        return getTests(5)
            .then(tests => {
                let promises = []
                let output = []
                for (let i = 0; i < tests.length; i++) {
                    try {
                        const testRunner = runq5(tests[i])
                                .timeout(1000)
                                .then(({answer, timeTaken}) => {
                                    const correct = answer === tests[i]["output"] ? "CORRECT" : "INCORRECT"
                                    console.log(tests[i].input + " is " + correct)
                                    output.push({
                                        "questionNumber": 5,
                                        "testNumber": i,
                                        "correct": correct,
                                        "speed": timeTaken * 1000000
                                    })
                                })
                                .catch(Promise.TimeoutError, (e) => {
                                    console.log("A question 5 test has timed out. Each individual test has a maximum of one second to run.")
                                    resolve(output.push({
                                        "questionNumber": 5,
                                        "testNumber": i,
                                        "correct": "TIMED_OUT",
                                        "speed": -1
                                    }))
                                })
                        promises.push(testRunner)
                    } catch (error) {
                        console.log(error)
                    }
                }
                return Promise.all(promises).then(_ => submitAnswers(output, 5))
            })
    })

    test('runs question 6', () => {
        return getTests(6)
            .then(tests => {
                let promises = []
                let output = []
                for (let i = 0; i < tests.length; i++) {
                    try {
                        const testRunner = runq6(tests[i])
                                .timeout(1000)
                                .then(({answer, timeTaken}) => {
                                    const correct = answer === tests[i]["output"] ? "CORRECT" : "INCORRECT"
                                    console.log(tests[i].input + " is " + correct)
                                    output.push({
                                        "questionNumber": 6,
                                        "testNumber": i,
                                        "correct": correct,
                                        "speed": timeTaken * 1000000
                                    })
                                })
                                .catch(Promise.TimeoutError, (e) => {
                                    console.log("A question 6 test has timed out. Each individual test has a maximum of one second to run.")
                                    resolve(output.push({
                                        "questionNumber": 6,
                                        "testNumber": i,
                                        "correct": "TIMED_OUT",
                                        "speed": -1
                                    }))
                                })
                        promises.push(testRunner)
                    } catch (error) {
                        console.log(error)
                    }
                }
                return Promise.all(promises).then(_ => submitAnswers(output, 6))
            })
    })
})

const getTests = (question) => {
    const uuid = process.env.travistestidentifier;
    let url = `https://ta-cc-gl.herokuapp.com/tests/run/${question}`
    if (uuid !== undefined) {
        url = `${url}/${uuid}`
    }
    return axios.get(url)
        .then(function (response) {
            return response.data
        }).catch(function (response) {
            console.log(response)
        })
}

const submitAnswers = (answers, question, done) => {
    const uuid = process.env.travistestidentifier;
    if (uuid !== undefined) {
        const url = `https://ta-cc-gl.herokuapp.com/answer/contestant/${uuid}/${question}`
        return axios.post(url, answers).then(_ => {
            console.log(`Submitted answers for question ${question}`)
        }).catch(function (response) {
            console.log(response)
        })
    }
}

function runq1(test) {
    return new Promise((resolve, reject) => {
        const input = JSON.parse(test['input'])
        const t0 = performance()
        const answer = question01(input)
        const t1 = performance()
        const timeTaken = t1 - t0
        return resolve({
            answer,
            timeTaken
        })
    })
}

function runq2(test) {
    return new Promise((resolve, reject) => {
        const input = JSON.parse(test['input'])
        
        const t0 = performance()
        const answer = question02(input['cashFlowIn'], input['cashFlowOut'])
        const t1 = performance()
        const timeTaken = t1 - t0
        return resolve({
            answer,
            timeTaken
        })
    })
}

function runq3(test) {
    return new Promise((resolve, reject) => {
        const input = JSON.parse(test['input'])
        
        const t0 = performance()
        const answer = question03(input['numNodes'], input['edges'])
        const t1 = performance()
        const timeTaken = t1 - t0
        return resolve({
            answer,
            timeTaken
        })
    })
}

function runq4(test) {
    return new Promise((resolve, reject) => {
        const input = JSON.parse(test['input'])
        
        const t0 = performance()
        const answer = question04(input['rows'], input['numberMachines'])
        const t1 = performance()
        const timeTaken = t1 - t0
        return resolve({
            answer,
            timeTaken
        })
    })
}

function runq5(test) {
    return new Promise((resolve, reject) => {
        const input = JSON.parse(test['input'])
        
        const t0 = performance()
        const answer = question05(input['allowedAllocations'], input['totalValue'])
        const t1 = performance()
        const timeTaken = t1 - t0
        return resolve({
            answer,
            timeTaken
        })
    })
}

function runq6(test) {
    return new Promise((resolve, reject) => {
        const input = JSON.parse(test['input'])
        
        const t0 = performance()
        const answer = question06(input['numServers'], input['targetNode'], input['arcs'])
        const t1 = performance()
        const timeTaken = t1 - t0
        return resolve({
            answer,
            timeTaken
        })
    })
}