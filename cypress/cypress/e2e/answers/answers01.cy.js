describe('Answers 01', () => {

    it('should log in to the Sauce Demo store', () => {

        /**
         * TODO: navigate to https://www.saucedemo.com
         */
        cy.visit('https://www.saucedemo.com')

        /**
         * TODO: log in with username 'standard_user' and password 'secret_sauce'
         */
        cy.get('#user-name').type('standard_user')
        cy.get('#password').type('secret_sauce')
        cy.get('#login-button').click()

        /**
         * TODO: Check that a link with the text 'Sauce Labs Backpack' is visible
         * HINT: use this locator: 'a#item_4_title_link > div'
         */
        cy.get('a#item_4_title_link > div')
            .should('have.text', 'Sauce Labs Backpack')
    })
})