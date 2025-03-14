describe('Examples 04', () => {
    it('can perform a straightforward API test', () => {

        let expectedJoke = 'My dog used to chase people on a bike a lot. It got so bad I had to take his bike away.'

        cy.request({
            method: 'GET',
            url: 'https://icanhazdadjoke.com/j/R7UfaahVfFd',
            headers: {
                'Accept': 'application/json'
            }
        }).then((response) => {
            expect(response.status).to.eq(200)
            expect(response.body.joke).to.eq(expectedJoke)
        })
    })
})