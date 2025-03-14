class OrderConfirmationPage {

    getConfirmationMessage() {
        return cy.get('h2.complete-header')
    }
}

export default OrderConfirmationPage