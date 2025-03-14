class ShoppingCartPage {

    gotoCheckout(first_name, last_name, zip_code) {
        /**
         * TODO: implement the method so that it actually navigates to the checkout page.
         */
        cy.get('button#checkout').click()
        
        cy.get('input#first-name').type(first_name)
        cy.get('input#last-name').type(last_name)
        cy.get('input#postal-code').type(zip_code)

        cy.get('input#continue').click()
        cy.get('button#finish').click()
    }
}

export default ShoppingCartPage