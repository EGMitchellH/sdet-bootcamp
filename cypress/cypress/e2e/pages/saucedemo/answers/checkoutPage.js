class CheckoutPage {

    checkoutOrder() {
        /**
         * TODO: implement the method so that it actually fills the form and completes the order.
         */
        cy.get('input#first-name').type('Jane')
        cy.get('input#last-name').type('Doe')
        cy.get('input#postal-code').type('90210')
        cy.get('input#continue').click()
        cy.get('button#finish').click()
    }
}

export default CheckoutPage