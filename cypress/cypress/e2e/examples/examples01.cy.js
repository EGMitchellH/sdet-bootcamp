describe('Examples 01', () => {

    it('should log in to the ParaBank application', () => {

        // Navigate to the ParaBank home page
        cy.visit('https://parabank.parasoft.com')

        // Log in
        cy.get('[name="username"]').type('john')
        cy.get('[name="password"]').type('demo')
        cy.get('[value="Log In"]').click()

        // Check that the expected element is visible and has text 'Account Services'
        cy.get('h2')
            .should('be.visible')
            .should('have.text', 'Account Services')
    })
})