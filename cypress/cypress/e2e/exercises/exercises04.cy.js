describe('Exercises 04', () => {

    /** 
     * TODO: write a test that performs an HTTP GET to https://jsonplaceholder.typicode.com/users/1
     * Check that the response status code is equal to 200, and that the value of the 'name'
     * response body element is equal to 'Leanne Graham'
     */
    it ('can get HTTP request w/ response 200)', () => 
     {
        let name = 'Leanne Graham'

        cy.request({
            method: 'GET',
            url: 'https://jsonplaceholder.typicode.com/users/1',
            headers : {
                'Accept' : 'application/json'
            }
            }).then((response) => {
                expect(response.status).to.eq(200)
                expect(response.body.name).to.eq(name)
            })
     })


    /**
     * TODO: write a test that performs an HTTP POST to https://jsonplaceholder.typicode.com/posts
     * with a request Content-Type header equal to 'application/json' and a request body that looks
     * like this (feel free to copy it):
     * {
     *     'userId': 1,
     *     'title': 'My new blog post',
     *     'body': 'Awesome content' 
     * }
     * Check that the response status code is equal to HTTP 201, and that the response body echoes
     * the value of the 'title' element (i.e., the value of the 'title' element should be the same
     * as the value you submitted).
     * 
     * Scenario 4 from this blog post should be helpful:
     * https://medium.com/@haneefullah00345/api-automation-with-cypress-a-comprehensive-guide-42a7c447225a
     */
     it ('finds the user', () =>
     {
        let postBody = {
            'userID' : 1,
            'title' : 'My new blog post',
            'body' : 'Awesome content'
        }

        cy.request({
            method: 'POST',
            url: 'https://jsonplaceholder.typicode.com/posts',
            headers : 
                {
                    'Content-Type' : 'application/json'
                },
            body: postBody
            }).then((response) => {
                expect(response.status).to.eq(201)
                expect(response.body.title).to.eq('My new blog post')
            })
                
        })
     })