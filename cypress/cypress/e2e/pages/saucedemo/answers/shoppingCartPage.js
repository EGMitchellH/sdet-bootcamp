class ShoppingCartPage {

    gotoCheckout() {
        /**
         * TODO: implement the method so that it actually navigates to the checkout page.
         */
        cy.get('button#checkout').click()
    }
}

export default ShoppingCartPage